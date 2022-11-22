using System.Linq;
using HarmonyLib;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.Enums;
using UnityEngine;
using TownOfUsReworked.PlayerLayers.Roles.Roles;
using TownOfUsReworked.PlayerLayers.Objectifiers.Objectifiers;
using TownOfUsReworked.PlayerLayers.Objectifiers;

namespace TownOfUsReworked.PlayerLayers.Roles.IntruderRoles.IntruderMod
{
    [HarmonyPatch(typeof(EndGameManager), nameof(EndGameManager.Start))]
    public class Outro
    {
        public static void Postfix(EndGameManager __instance)
        {
            if (Role.GetRoles(RoleEnum.Taskmaster).Any(x => ((Taskmaster)x).WinTasksDone))
                return;

            if (Role.GetRoles(RoleEnum.Troll).Any(x => ((Troll)x).Killed))
                return;

            if (Role.GetRoles(RoleEnum.Cannibal).Any(x => ((Cannibal)x).EatNeed == 0))
                return;

            if (Objectifier.GetObjectifiers(ObjectifierEnum.Phantom).Any(x => ((Phantom)x).CompletedTasks))
                return;

            var role = Role.AllRoles.FirstOrDefault(x => x.Faction == Faction.Intruders && (((Blackmailer)x).IntruderWin |
                ((Camouflager)x).IntruderWin | ((Consigliere)x).IntruderWin | ((Consort)x).IntruderWin | ((Disguiser)x).IntruderWin |
                ((Grenadier)x).IntruderWin | ((Impostor)x).IntruderWin | ((Janitor)x).IntruderWin | ((Morphling)x).IntruderWin |
                ((Poisoner)x).IntruderWin | ((Teleporter)x).IntruderWin | ((Undertaker)x).IntruderWin | ((Wraith)x).IntruderWin));

            if (role == null)
                return;

            PoolablePlayer[] array = Object.FindObjectsOfType<PoolablePlayer>();

            foreach (var player in array)
                player.NameText().text = role.ColorString + player.NameText().text + "</color>";

            __instance.BackgroundBar.material.color = role.FactionColor;
            var text = Object.Instantiate(__instance.WinText);
            text.text = "Intruders Win!";
            text.color = role.FactionColor;
            var pos = __instance.WinText.transform.localPosition;
            pos.y = 1.5f;
            text.transform.position = pos;
            text.text = $"<size=4>{text.text}</size>";
            SoundManager.Instance.PlaySound(TownOfUsReworked.IntruderWin, false, 0.3f);
        }
    }
}