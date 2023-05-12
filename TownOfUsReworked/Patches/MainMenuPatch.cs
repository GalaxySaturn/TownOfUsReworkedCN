namespace TownOfUsReworked.Patches
{
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public static class MainMenuPatch
    {
        private static AnnouncementPopUp popUp;

        public static void Postfix(MainMenuManager __instance)
        {
            CosmeticsLoader.LaunchFetchers();
            var amongUsLogo = GameObject.Find("bannerLogo_AmongUs");

            if (amongUsLogo != null)
            {
                amongUsLogo.transform.localScale *= 0.5f;
                amongUsLogo.transform.position += Vector3.up * 0.25f;
            }

            var tourewLogo = new GameObject("bannerLogo_TownOfUsReworked");
            tourewLogo.transform.position = Vector3.up;
            var renderer = tourewLogo.AddComponent<SpriteRenderer>();
            renderer.sprite = AssetManager.GetSprite("TownOfUsReworkedBanner");

            var InvButton = GameObject.Find("InventoryButton");

            if (InvButton == null)
                return;

            var discObj = UObject.Instantiate(InvButton, InvButton.transform.parent);
            var iconrenderer1 = discObj.GetComponent<SpriteRenderer>();
            iconrenderer1.sprite = AssetManager.GetSprite("Discord");

            var button1 = discObj.GetComponent<PassiveButton>();
            button1.OnClick.RemoveAllListeners();
            button1.OnClick.AddListener((Action)(() => Application.OpenURL("https://discord.gg/cd27aDQDY9")));

            var announceObj = UObject.Instantiate(InvButton, InvButton.transform.parent);
            var iconrenderer2 = announceObj.GetComponent<SpriteRenderer>();
            iconrenderer2.sprite = AssetManager.GetSprite("Update");

            var button2 = announceObj.GetComponent<PassiveButton>();
            button2.OnClick.RemoveAllListeners();
            button2.OnClick.AddListener((Action)(() =>
            {
                popUp?.Destroy();
                popUp = UObject.Instantiate(UObject.FindObjectOfType<AnnouncementPopUp>(true));
                popUp.gameObject.SetActive(true);

                var changesAnnouncement = new Assets.InnerNet.Announcement
                {
                    Id = "tourewChanges",
                    Language = 0,
                    Number = 500,
                    Title = "Town Of Us Reworked Changes",
                    ShortTitle = "Changes",
                    SubTitle = "no idea what im doing anymore lmao",
                    PinState = false,
                    Date = "30.04.2023"
                };

                var changelog = Utils.CreateText("Changelog");
                changesAnnouncement.Text = $"<size=75%>{changelog}</size>";

                __instance.StartCoroutine(Effects.Lerp(0.01f, new Action<float>(_ =>
                {
                    var backup = DataManager.Player.Announcements.allAnnouncements;
                    popUp.Init(false);
                    DataManager.Player.Announcements.allAnnouncements = new();
                    DataManager.Player.Announcements.allAnnouncements.Insert(0, changesAnnouncement);

                    foreach (var item in popUp.visibleAnnouncements)
                        item.Destroy();

                    foreach (var item in UObject.FindObjectsOfType<AnnouncementPanel>())
                    {
                        if (item != popUp.ErrorPanel)
                            item.gameObject.Destroy();
                    }

                    popUp.CreateAnnouncementList();
                    popUp.visibleAnnouncements[0].PassiveButton.OnClick.RemoveAllListeners();
                    DataManager.Player.Announcements.allAnnouncements = backup;
                    var titleText = GameObject.Find("Title_Text").GetComponent<TextMeshPro>();

                    if (titleText != null)
                        titleText.text = "";
                })));
            }));

            __instance.StartCoroutine(Effects.Lerp(0.01f, new Action<float>(_ =>
            {
                foreach (var tf in InvButton.transform.parent.GetComponentsInChildren<Transform>())
                    tf.localPosition = new(tf.localPosition.x * 0.8f, tf.localPosition.y);
            })));
        }
    }
}