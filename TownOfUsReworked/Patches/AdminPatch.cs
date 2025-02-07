namespace TownOfUsReworked.Patches
{
    [HarmonyPatch(typeof(MapCountOverlay), nameof(MapCountOverlay.Update))]
    public static class AdminPatch
    {
        public static void SetSabotaged(MapCountOverlay __instance, bool sabotaged)
        {
            __instance.isSab = sabotaged;
            __instance.BackgroundColor.SetColor(sabotaged ? Palette.DisabledGrey : Color.green);
            __instance.SabotageText.gameObject.SetActive(sabotaged);

            if (sabotaged)
            {
                foreach (var area in __instance.CountAreas)
                    area.UpdateCount(0);
            }
        }

        public static void UpdateBlips(CounterArea area, List<int> colorMapping, bool isOP)
        {
            area.UpdateCount(colorMapping.Count);
            var icons = area.myIcons.ToArray();
            colorMapping.Sort();
            var useCompactText = icons.Count > 2 * area.MaxWidth;

            for (var i = 0; i < colorMapping.Count; i++)
            {
                var icon = icons[i];
                var sprite = icon.GetComponent<SpriteRenderer>();
                var text = icon.GetComponentInChildren<TextMeshPro>(true);

                if (DoUndo.IsCamoed)
                    sprite.color = Color.grey;

                if (sprite != null)
                {
                    if (isOP)
                        PlayerMaterial.SetColors(colorMapping[i], sprite);
                    else
                        PlayerMaterial.SetColors(new Color(0.8793f, 1, 0, 1), sprite);
                }

                if (text != null && isOP)
                {
                    text.gameObject.SetActive(true);
                    text.text = colorMapping[i].ToString();

                    //Show first row numbers below player icons
                    //Show second row numbers above player icons
                    //Show all icons on player icons when there are three rows

                    if (useCompactText)
                        text.transform.localPosition = new(0, 0, -20);
                    else if (i / area.MaxWidth == 0)
                        text.transform.localPosition = new(0, -area.YOffset, -20);
                    else
                        text.transform.localPosition = new(0, area.YOffset, -20);
                }
            }
        }

        public static void UpdateBlips(MapCountOverlay __instance, bool isOP)
        {
            var rooms = ShipStatus.Instance.FastRooms;
            var colorMapDuplicate = new List<int>();

            foreach (var area in __instance.CountAreas)
            {
                if (!rooms.ContainsKey(area.RoomType))
                    continue;

                var room = rooms[area.RoomType];

                if (room.roomArea == null)
                    continue;

                var objectsInRoom = room.roomArea.OverlapCollider(__instance.filter, __instance.buffer);
                var colorMap = new List<int>();

                for (var i = 0; i < objectsInRoom; i++)
                {
                    var collider = __instance.buffer[i];

                    var player = collider.GetComponent<PlayerControl>();
                    var data = player?.Data;

                    if (collider.tag == "DeadBody" && ((isOP && (int)CustomGameOptions.WhoSeesDead is 1) || (!isOP && (int)CustomGameOptions.WhoSeesDead is 2) || (int)CustomGameOptions.
                        WhoSeesDead is 0 || ConstantVariables.DeadSeeEverything))
                    {
                        var playerId = collider.GetComponent<DeadBody>().ParentId;
                        colorMap.Add(GameData.Instance.GetPlayerById(playerId).DefaultOutfit.ColorId);
                        colorMapDuplicate.Add(GameData.Instance.GetPlayerById(playerId).DefaultOutfit.ColorId);
                    }
                    else
                    {
                        var component = collider.GetComponent<PlayerControl>();

                        if (component && component.Data != null && !component.Data.Disconnected && !component.Data.IsDead && (__instance.showLivePlayerPosition || !component.AmOwner) &&
                            !colorMapDuplicate.Contains(data.DefaultOutfit.ColorId))
                        {
                            colorMap.Add(data.DefaultOutfit.ColorId);
                            colorMapDuplicate.Add(data.DefaultOutfit.ColorId);
                        }
                    }
                }

                UpdateBlips(area, colorMap, isOP);
            }
        }

        public static bool Prefix(MapCountOverlay __instance)
        {
            var localPlayer = CustomPlayer.Local;
            var isOP = localPlayer.Is(RoleEnum.Operative) || ConstantVariables.DeadSeeEverything;

            if (!isOP)
                isOP = localPlayer.Is(RoleEnum.Retributionist) && ((Retributionist)Role.LocalRole).IsOP;

            __instance.timer += Time.deltaTime;

            if (__instance.timer < 0.1f)
                return false;

            __instance.timer = 0f;
            var sabotaged = PlayerTask.PlayerHasTaskOfType<IHudOverrideTask>(localPlayer);

            if (sabotaged != __instance.isSab)
                SetSabotaged(__instance, sabotaged);

            if (!sabotaged)
                UpdateBlips(__instance, isOP);

            return false;
        }
    }
}