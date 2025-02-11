namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class PromotedGodfather : Intruder
    {
        public PromotedGodfather(PlayerControl player) : base(player)
        {
            Name = "PromotedGodfather";
            RoleType = RoleEnum.PromotedGodfather;
            StartText = () => "Promote Your Fellow <color=#FF0000FF>Intruders</color> To Do Better";
            AbilitiesText = () => "- You have succeeded the former <color=#404C08FF>Godfather</color> and have a shorter cooldown on your former role's abilities\n" +
                $"{FormerRole?.AbilitiesText()}";
            Color = CustomGameOptions.CustomIntColors ? Colors.Godfather : Colors.Intruder;
            RoleAlignment = RoleAlignment.IntruderSupport;
            BlockMenu = new(Player, ConsClick, Exception1);
            Type = LayerEnum.PromotedGodfather;
            TeleportPoint = Vector3.zero;
            Investigated = new();
            DisguisePlayer = null;
            DisguisedPlayer = null;
            MorphedPlayer = null;
            SampledPlayer = null;
            MeasuredPlayer = null;
            AmbushedPlayer = null;
            BombedPlayer = null;
            BlockTarget = null;
            BlockButton = new(this, "ConsortRoleblock", AbilityTypes.Effect, "Secondary", Roleblock);
            BombButton = new(this, "Enforce", AbilityTypes.Direct, "Secondary", Bomb, Exception7);
            BlackmailButton = new(this, "Blackmail", AbilityTypes.Direct, "Secondary", Blackmail, Exception2);
            CamouflageButton = new(this, "Camouflage", AbilityTypes.Effect, "Secondary", HitCamouflage);
            FlashButton = new(this, "Flash", AbilityTypes.Effect, "Secondary", HitFlash);
            CleanButton = new(this, "Clean", AbilityTypes.Dead, "Secondary", Clean);
            DragButton = new(this, "Drag", AbilityTypes.Dead, "Tertiary", Drag);
            DropButton = new(this, "Drop", AbilityTypes.Effect, "Tertiary", Drop);
            DisguiseButton = new(this, "Disguise", AbilityTypes.Direct, "Secondary", HitDisguise, Exception3);
            MeasureButton = new(this, "Measure", AbilityTypes.Direct, "Tertiary", Measure, Exception4);
            MorphButton = new(this, "Morph", AbilityTypes.Effect, "Secondary", HitMorph);
            SampleButton = new(this, "Sample", AbilityTypes.Direct, "Tertiary", Sample, Exception5);
            InvisButton = new(this, "Invis", AbilityTypes.Effect, "Secondary", HitInvis);
            AmbushButton = new(this, "Ambush", AbilityTypes.Direct, "Secondary", HitAmbush, Exception6);
            InvestigateButton = new(this, "Investigate", AbilityTypes.Direct, "Secondary", Investigate, Exception8);
            MineButton = new(this, "Mine", AbilityTypes.Effect, "Secondary", Mine);
            MarkButton = new(this, "Mark", AbilityTypes.Effect, "Secondary", Mark);
            TeleportButton = new(this, "Teleport", AbilityTypes.Effect, "Secondary", Teleport);
            InspectorResults = InspectorResults.LeadsTheGroup;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }

        //PromotedGodfather Stuff
        public Role FormerRole;
        public float TimeRemaining;
        public bool OnEffect => TimeRemaining > 0f;
        public float TimeRemaining2;
        public bool DelayActive => TimeRemaining2 > 0f;
        public bool Enabled;

        public bool Exception1(PlayerControl player) => player == BlockTarget || player == Player || player.Is(Faction) || (player.Is(SubFaction) && SubFaction != SubFaction.None);

        public bool Exception2(PlayerControl player) => player == BlackmailedPlayer || (player.Is(Faction) && Faction != Faction.Crew && CustomGameOptions.BlackmailMates) ||
            (player.Is(SubFaction) && SubFaction != SubFaction.None && CustomGameOptions.BlackmailMates);

        public bool Exception3(PlayerControl player) => (player.Is(Faction) && CustomGameOptions.DisguiseTarget == DisguiserTargets.NonIntruders) || (!player.Is(Faction) &&
            CustomGameOptions.DisguiseTarget == DisguiserTargets.Intruders);

        public bool Exception4(PlayerControl player) => player == MeasuredPlayer;

        public bool Exception5(PlayerControl player) => player == SampledPlayer;

        public bool Exception6(PlayerControl player) => player == AmbushedPlayer;

        public bool Exception7(PlayerControl player) => player == BombedPlayer || player.Is(Faction) || (player.Is(SubFaction) && SubFaction != SubFaction.None);

        public bool Exception8(PlayerControl player) => Investigated.Contains(player.PlayerId) || ((player.Is(Faction) || (player.Is(SubFaction) && SubFaction != SubFaction.None)) &&
            CustomGameOptions.FactionSeeRoles);

        public override void UpdateHud(HudManager __instance)
        {
            base.UpdateHud(__instance);
            var system = ShipStatus.Instance.Systems[SystemTypes.Sabotage].Cast<SabotageSystemType>();
            var dummyActive = system.dummy.IsActive;
            var sabActive = system.specials.Any(s => s.IsActive);
            var condition = !dummyActive && !sabActive;
            var notSampled = CustomPlayer.AllPlayers.Where(x => SampledPlayer != x).ToList();
            var notAmbushed = CustomPlayer.AllPlayers.Where(x => x != AmbushedPlayer).ToList();
            var notBombed = CustomPlayer.AllPlayers.Where(x => x != BombedPlayer).ToList();
            var flag = BlockTarget == null;
            var hits = Physics2D.OverlapBoxAll(Player.transform.position, Utils.GetSize(), 0);
            hits = hits.Where(c => (c.name.Contains("Vent") || !c.isTrigger) && c.gameObject.layer != 8 && c.gameObject.layer != 5).ToArray();
            CanPlace = hits.Count == 0 && Player.moveable && !ModCompatibility.GetPlayerElevator(Player).Item1;
            CanMark = CanPlace && TeleportPoint != Player.transform.position;
            MarkButton.Update("MARK", MarkTimer(), CustomGameOptions.MarkCooldown, CanMark, IsTele);
            TeleportButton.Update("TELEPORT", TeleportTimer(), CustomGameOptions.TeleportCd, true, TeleportPoint != Vector3.zero && IsTele);
            MineButton.Update("MINE", MineTimer(), CustomGameOptions.MineCd, CanPlace, IsMiner);
            BlockButton.Update(flag ? "SET TARGET" : "ROLEBLOCK", RoleblockTimer(), CustomGameOptions.ConsRoleblockCooldown, OnEffect, TimeRemaining,
                CustomGameOptions.ConsRoleblockDuration, true, IsCons);
            InvestigateButton.Update("INVESTIGATE", ConsigliereTimer(), CustomGameOptions.ConsigCd, true, IsConsig);
            BombButton.Update("BOMB", BombTimer(), CustomGameOptions.EnforceCooldown, DelayActive || OnEffect, DelayActive ? TimeRemaining2 : TimeRemaining, DelayActive ?
                CustomGameOptions.EnforceDelay : CustomGameOptions.EnforceDuration, true, IsEnf);
            AmbushButton.Update("AMBUSH", AmbushTimer(), CustomGameOptions.AmbushDuration, OnEffect, TimeRemaining, CustomGameOptions.AmbushDuration, true, IsAmb);
            MorphButton.Update("MORPH", MorphTimer(), CustomGameOptions.MorphlingCd, OnEffect, TimeRemaining, CustomGameOptions.MorphlingDuration, true, SampledPlayer != null && IsMorph);
            SampleButton.Update("SAMPLE", SampleTimer(), CustomGameOptions.MeasureCooldown, true, IsMorph);
            FlashButton.Update("FLASH", FlashTimer(), CustomGameOptions.GrenadeCd, OnEffect, TimeRemaining, CustomGameOptions.GrenadeDuration, condition, IsGren);
            DisguiseButton.Update("DISGUISE", DisguiseTimer(), CustomGameOptions.DisguiseCooldown, DelayActive || OnEffect, DelayActive ? TimeRemaining2 : TimeRemaining,
                DelayActive ? CustomGameOptions.TimeToDisguise : CustomGameOptions.DisguiseDuration, true, MeasuredPlayer != null && IsDisg);
            MeasureButton.Update("MEASURE", MeasureTimer(), CustomGameOptions.MeasureCooldown, true, IsDisg);
            BlackmailButton.Update("BLACKMAIL", BlackmailTimer(), CustomGameOptions.BlackmailCd, true, IsBM);
            CamouflageButton.Update("CAMOUFLAGE", CamouflageTimer(), CustomGameOptions.CamouflagerCd, OnEffect, TimeRemaining, CustomGameOptions.CamouflagerDuration, !DoUndo.IsCamoed,
                IsCamo);
            CleanButton.Update("CLEAN", CleanTimer(), CustomGameOptions.JanitorCleanCd, true, CurrentlyDragging == null && IsJani);
            DragButton.Update("DRAG", DragTimer(), CustomGameOptions.DragCd, true, CurrentlyDragging == null && IsJani);
            DropButton.Update("DROP", true, CurrentlyDragging != null && IsJani);
            InvisButton.Update("INVIS", InvisTimer(), CustomGameOptions.InvisCd, OnEffect, TimeRemaining, CustomGameOptions.InvisDuration, true, IsWraith);
        }

        //Impostor Stuff
        public bool IsImp => FormerRole?.RoleType == RoleEnum.Impostor;

        //Blackmailer Stuff
        public CustomButton BlackmailButton;
        public PlayerControl BlackmailedPlayer;
        public DateTime LastBlackmailed;
        public bool ShookAlready;
        public Sprite PrevOverlay;
        public Color PrevColor;
        public bool IsBM => FormerRole?.RoleType == RoleEnum.Blackmailer;

        public float BlackmailTimer()
        {
            var timespan = DateTime.UtcNow - LastBlackmailed;
            var num = Player.GetModifiedCooldown(CustomGameOptions.BlackmailCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Blackmail()
        {
            if (BlackmailTimer() != 0f || Utils.IsTooFar(Player, BlackmailButton.TargetPlayer) || BlackmailButton.TargetPlayer == BlackmailedPlayer)
                return;

            var interact = Utils.Interact(Player, BlackmailButton.TargetPlayer);

            if (interact[3])
            {
                BlackmailedPlayer = BlackmailButton.TargetPlayer;
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.GodfatherAction);
                writer.Write((byte)GodfatherActionsRPC.Blackmail);
                writer.Write(PlayerId);
                writer.Write(BlackmailButton.TargetPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
            }

            if (interact[0])
                LastBlackmailed = DateTime.UtcNow;
            else if (interact[1])
                LastBlackmailed.AddSeconds(CustomGameOptions.ProtectKCReset);
        }

        //Camouflager Stuff
        public CustomButton CamouflageButton;
        public DateTime LastCamouflaged;
        public bool IsCamo => FormerRole?.RoleType == RoleEnum.Camouflager;

        public void Camouflage()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
            Utils.Camouflage();

            if (Utils.Meeting)
                TimeRemaining = 0f;
        }

        public void UnCamouflage()
        {
            Enabled = false;
            LastCamouflaged = DateTime.UtcNow;
            Utils.DefaultOutfitAll();
        }

        public void HitCamouflage()
        {
            if (CamouflageTimer() != 0f || DoUndo.IsCamoed)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.GodfatherAction);
            writer.Write((byte)GodfatherActionsRPC.Camouflage);
            writer.Write(PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            TimeRemaining = CustomGameOptions.CamouflagerDuration;
            Camouflage();
            Utils.Camouflage();
        }

        public float CamouflageTimer()
        {
            var timespan = DateTime.UtcNow - LastCamouflaged;
            var num = Player.GetModifiedCooldown(CustomGameOptions.CamouflagerCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        //Grenadier Stuff
        public CustomButton FlashButton;
        public DateTime LastFlashed;
        private static List<PlayerControl> ClosestPlayers = new();
        private static readonly Color32 NormalVision = new(212, 212, 212, 0);
        private static readonly Color32 DimVision = new(212, 212, 212, 51);
        private static readonly Color32 BlindVision = new(212, 212, 212, 255);
        public List<PlayerControl> FlashedPlayers;
        public bool IsGren => FormerRole?.RoleType == RoleEnum.Grenadier;

        public float FlashTimer()
        {
            var timespan = DateTime.UtcNow - LastFlashed;
            var num = Player.GetModifiedCooldown(CustomGameOptions.GrenadeCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Flash()
        {
            if (!Enabled)
            {
                ClosestPlayers = Utils.GetClosestPlayers(Player.GetTruePosition(), CustomGameOptions.FlashRadius);
                FlashedPlayers = ClosestPlayers;
            }

            Enabled = true;
            TimeRemaining -= Time.deltaTime;

            if (Utils.Meeting)
                TimeRemaining = 0f;

            //To stop the scenario where the flash and sabotage are called at the same time.
            var system = ShipStatus.Instance.Systems[SystemTypes.Sabotage].Cast<SabotageSystemType>();
            var dummyActive = system.dummy.IsActive;
            var sabActive = system.specials.Any(s => s.IsActive);

            if (sabActive || dummyActive)
                return;

            foreach (var player in ClosestPlayers)
            {
                if (CustomPlayer.Local == player)
                {
                    Utils.HUD.FullScreen.enabled = true;
                    Utils.HUD.FullScreen.gameObject.active = true;

                    if (TimeRemaining > CustomGameOptions.GrenadeDuration - 0.5f)
                    {
                        var fade = (TimeRemaining - CustomGameOptions.GrenadeDuration) * (-2f);

                        if (ShouldPlayerBeBlinded(player))
                            Utils.HUD.FullScreen.color = Color32.Lerp(NormalVision, BlindVision, fade);
                        else if (ShouldPlayerBeDimmed(player))
                            Utils.HUD.FullScreen.color = Color32.Lerp(NormalVision, DimVision, fade);
                        else
                            Utils.HUD.FullScreen.color = NormalVision;
                    }
                    else if (TimeRemaining <= (CustomGameOptions.GrenadeDuration - 0.5f) && TimeRemaining >= 0.5f)
                    {
                        Utils.HUD.FullScreen.enabled = true;
                        Utils.HUD.FullScreen.gameObject.active = true;

                        if (ShouldPlayerBeBlinded(player))
                            Utils.HUD.FullScreen.color = BlindVision;
                        else if (ShouldPlayerBeDimmed(player))
                            Utils.HUD.FullScreen.color = DimVision;
                        else
                            Utils.HUD.FullScreen.color = NormalVision;
                    }
                    else if (TimeRemaining < 0.5f)
                    {
                        var fade2 = (TimeRemaining * -2.0f) + 1.0f;

                        if (ShouldPlayerBeBlinded(player))
                            Utils.HUD.FullScreen.color = Color32.Lerp(BlindVision, NormalVision, fade2);
                        else if (ShouldPlayerBeDimmed(player))
                            Utils.HUD.FullScreen.color = Color32.Lerp(DimVision, NormalVision, fade2);
                        else
                            Utils.HUD.FullScreen.color = NormalVision;
                    }
                    else
                    {
                        Utils.HUD.FullScreen.color = NormalVision;
                        TimeRemaining = 0f;
                    }

                    if (MapBehaviour.Instance)
                        MapBehaviour.Instance.Close();

                    if (Minigame.Instance)
                        Minigame.Instance.Close();
                }
            }
        }

        private static bool ShouldPlayerBeDimmed(PlayerControl player) => (player.Is(Faction.Intruder) || player.Data.IsDead) && !Utils.Meeting;

        private static bool ShouldPlayerBeBlinded(PlayerControl player) => !(player.Is(Faction.Intruder) || player.Data.IsDead || Utils.Meeting);

        public void UnFlash()
        {
            Enabled = false;
            LastFlashed = DateTime.UtcNow;
            Utils.HUD.FullScreen.color = NormalVision;
            FlashedPlayers.Clear();
            var fs = false;

            switch (TownOfUsReworked.VanillaOptions.MapId)
            {
                case 0:
                case 1:
                case 3:
                    var reactor1 = ShipStatus.Instance.Systems[SystemTypes.Reactor].Cast<ReactorSystemType>();
                    var oxygen1 = ShipStatus.Instance.Systems[SystemTypes.LifeSupp].Cast<LifeSuppSystemType>();
                    fs = reactor1.IsActive || oxygen1.IsActive;
                    break;

                case 2:
                    var seismic = ShipStatus.Instance.Systems[SystemTypes.Laboratory].Cast<ReactorSystemType>();
                    fs = seismic.IsActive;
                    break;

                case 4:
                    var reactor = ShipStatus.Instance.Systems[SystemTypes.Reactor].Cast<HeliSabotageSystem>();
                    fs = reactor.IsActive;
                    break;

                case 5:
                    fs = CustomPlayer.Local.myTasks.Any(x => x.TaskType == ModCompatibility.RetrieveOxygenMask);
                    break;

                case 6:
                    var reactor3 = ShipStatus.Instance.Systems[SystemTypes.Reactor].Cast<ReactorSystemType>();
                    var oxygen3 = ShipStatus.Instance.Systems[SystemTypes.LifeSupp].Cast<LifeSuppSystemType>();
                    var seismic2 = ShipStatus.Instance.Systems[SystemTypes.Laboratory].Cast<ReactorSystemType>();
                    fs = reactor3.IsActive || seismic2.IsActive || oxygen3.IsActive;
                    break;
            }

            Utils.HUD.FullScreen.enabled = fs;
        }

        public void HitFlash()
        {
            var system = ShipStatus.Instance.Systems[SystemTypes.Sabotage].Cast<SabotageSystemType>();
            var dummyActive = system.dummy.IsActive;
            var sabActive = system.specials.Any(s => s.IsActive);

            if (sabActive || dummyActive || FlashTimer() != 0f)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.GodfatherAction);
            writer.Write((byte)GodfatherActionsRPC.FlashGrenade);
            writer.Write(PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            TimeRemaining = CustomGameOptions.GrenadeDuration;
            Flash();
        }

        //Janitor Stuff
        public CustomButton CleanButton;
        public DateTime LastCleaned;
        public DateTime LastDragged;
        public CustomButton DragButton;
        public CustomButton DropButton;
        public DeadBody CurrentlyDragging;
        public bool IsJani => FormerRole?.RoleType == RoleEnum.Janitor;

        public float DragTimer()
        {
            var timespan = DateTime.UtcNow - LastDragged;
            var num = Player.GetModifiedCooldown(CustomGameOptions.DragCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Clean()
        {
            if (CleanTimer() != 0f || Utils.IsTooFar(Player, CleanButton.TargetBody))
                return;

            var playerId = CleanButton.TargetBody.ParentId;
            var player = Utils.PlayerById(playerId);
            Utils.Spread(Player, player);
            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.FadeBody);
            writer.Write(playerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            Coroutines.Start(Utils.FadeBody(CleanButton.TargetBody));
            LastCleaned = DateTime.UtcNow;

            if (CustomGameOptions.JaniCooldownsLinked)
                LastKilled = DateTime.UtcNow;
        }

        public void Drag()
        {
            if (Utils.IsTooFar(Player, DragButton.TargetBody) || CurrentlyDragging)
                return;

            var playerId = DragButton.TargetBody.ParentId;
            var player = Utils.PlayerById(playerId);
            Utils.Spread(Player, player);
            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.GodfatherAction);
            writer.Write((byte)GodfatherActionsRPC.Drag);
            writer.Write(PlayerId);
            writer.Write(playerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            CurrentlyDragging = DragButton.TargetBody;
            var drag = CurrentlyDragging.gameObject.AddComponent<DragBehaviour>();
            drag.Source = Player;
            drag.Body = CurrentlyDragging.gameObject.AddComponent<Rigidbody2D>();
            drag.Collider = CurrentlyDragging.gameObject.GetComponent<Collider2D>();
            drag.Dragged = CurrentlyDragging;
        }

        public void Drop()
        {
            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.Drop);
            writer.Write(CurrentlyDragging.ParentId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);

            foreach (var component in CurrentlyDragging?.bodyRenderers)
                component.material.SetFloat("_Outline", 0f);

            CurrentlyDragging.gameObject.GetComponent<DragBehaviour>().Destroy();
            CurrentlyDragging = null;
            LastDragged = DateTime.UtcNow;
        }

        public float CleanTimer()
        {
            var timespan = DateTime.UtcNow - LastCleaned;
            var num = Player.GetModifiedCooldown(CustomGameOptions.JanitorCleanCd, ConstantVariables.LastImp && CustomGameOptions.SoloBoost ? -CustomGameOptions.UnderdogKillBonus : 0) *
                1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        //Disguiser Stuff
        public CustomButton DisguiseButton;
        public DateTime LastDisguised;
        public PlayerControl MeasuredPlayer;
        public PlayerControl DisguisedPlayer;
        public PlayerControl DisguisePlayer;
        public CustomButton MeasureButton;
        public DateTime LastMeasured;
        public bool IsDisg => FormerRole?.RoleType == RoleEnum.Disguiser;

        public void Disguise()
        {
            TimeRemaining -= Time.deltaTime;
            Utils.Morph(DisguisedPlayer, DisguisePlayer);

            if (IsDead || DisguisedPlayer.Data.IsDead || DisguisedPlayer.Data.Disconnected || Utils.Meeting)
                TimeRemaining = 0f;
        }

        public void DisgDelay()
        {
            TimeRemaining2 -= Time.deltaTime;

            if (IsDead || DisguisedPlayer.Data.IsDead || DisguisedPlayer.Data.Disconnected || Utils.Meeting)
                TimeRemaining2 = 0f;
        }

        public void UnDisguise()
        {
            Utils.DefaultOutfit(DisguisedPlayer);
            LastDisguised = DateTime.UtcNow;

            if (CustomGameOptions.DisgCooldownsLinked)
                LastMeasured = DateTime.UtcNow;
        }

        public float DisguiseTimer()
        {
            var timespan = DateTime.UtcNow - LastDisguised;
            var num = Player.GetModifiedCooldown(CustomGameOptions.DisguiseCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public float MeasureTimer()
        {
            var timespan = DateTime.UtcNow - LastMeasured;
            var num = Player.GetModifiedCooldown(CustomGameOptions.MeasureCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void HitDisguise()
        {
            if (DisguiseTimer() != 0f || Utils.IsTooFar(Player, DisguiseButton.TargetPlayer) || DisguiseButton.TargetPlayer == MeasuredPlayer || OnEffect || DelayActive)
                return;

            var interact = Utils.Interact(Player, DisguiseButton.TargetPlayer);

            if (interact[3])
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.GodfatherAction);
                writer.Write((byte)GodfatherActionsRPC.Disguise);
                writer.Write(PlayerId);
                writer.Write(MeasuredPlayer.PlayerId);
                writer.Write(DisguiseButton.TargetPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                TimeRemaining = CustomGameOptions.DisguiseDuration;
                TimeRemaining2 = CustomGameOptions.TimeToDisguise;
                DisguisePlayer = MeasuredPlayer;
                DisguisedPlayer = DisguiseButton.TargetPlayer;
                DisgDelay();

                if (CustomGameOptions.DisgCooldownsLinked)
                    LastMeasured = DateTime.UtcNow;
            }
            else if (interact[0])
            {
                LastDisguised = DateTime.UtcNow;

                if (CustomGameOptions.DisgCooldownsLinked)
                    LastMeasured = DateTime.UtcNow;
            }
            else if (interact[1])
            {
                LastDisguised.AddSeconds(CustomGameOptions.ProtectKCReset);

                if (CustomGameOptions.DisgCooldownsLinked)
                    LastMeasured.AddSeconds(CustomGameOptions.ProtectKCReset);
            }
        }

        public void Measure()
        {
            if (MeasureTimer() != 0f || Utils.IsTooFar(Player, MeasureButton.TargetPlayer) || MeasureButton.TargetPlayer == MeasuredPlayer)
                return;

            var interact = Utils.Interact(Player, MeasureButton.TargetPlayer);

            if (interact[3])
                MeasuredPlayer = MeasureButton.TargetPlayer;

            if (interact[0])
            {
                LastMeasured = DateTime.UtcNow;

                if (CustomGameOptions.DisgCooldownsLinked)
                    LastDisguised = DateTime.UtcNow;
            }
            else if (interact[1])
            {
                LastMeasured.AddSeconds(CustomGameOptions.ProtectKCReset);

                if (CustomGameOptions.DisgCooldownsLinked)
                    LastDisguised.AddSeconds(CustomGameOptions.ProtectKCReset);
            }
        }

        //Morphling Stuff
        public CustomButton MorphButton;
        public DateTime LastMorphed;
        public PlayerControl MorphedPlayer;
        public PlayerControl SampledPlayer;
        public DateTime LastSampled;
        public CustomButton SampleButton;
        public bool IsMorph => FormerRole?.RoleType == RoleEnum.Morphling;

        public void Morph()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
            Utils.Morph(Player, MorphedPlayer);

            if (IsDead || Utils.Meeting)
                TimeRemaining = 0f;
        }

        public void Unmorph()
        {
            Enabled = false;
            MorphedPlayer = null;
            Utils.DefaultOutfit(Player);
            LastMorphed = DateTime.UtcNow;

            if (CustomGameOptions.MorphCooldownsLinked)
                LastSampled = DateTime.UtcNow;
        }

        public float MorphTimer()
        {
            var timespan = DateTime.UtcNow - LastMorphed;
            var num = Player.GetModifiedCooldown(CustomGameOptions.MorphlingCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public float SampleTimer()
        {
            var timespan = DateTime.UtcNow - LastSampled;
            var num = Player.GetModifiedCooldown(CustomGameOptions.SampleCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void HitMorph()
        {
            if (MorphTimer() != 0f || SampledPlayer == null || OnEffect)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.GodfatherAction);
            writer.Write((byte)GodfatherActionsRPC.Morph);
            writer.Write(PlayerId);
            writer.Write(SampledPlayer.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            TimeRemaining = CustomGameOptions.MorphlingDuration;
            MorphedPlayer = SampledPlayer;
            Morph();
        }

        public void Sample()
        {
            if (SampleTimer() != 0f || Utils.IsTooFar(Player, SampleButton.TargetPlayer) || SampledPlayer == SampleButton.TargetPlayer)
                return;

            var interact = Utils.Interact(Player, SampleButton.TargetPlayer);

            if (interact[3])
                SampledPlayer = SampleButton.TargetPlayer;

            if (interact[0])
            {
                LastSampled = DateTime.UtcNow;

                if (CustomGameOptions.MorphCooldownsLinked)
                    LastMorphed = DateTime.UtcNow;
            }
            else if (interact[1])
            {
                LastSampled.AddSeconds(CustomGameOptions.ProtectKCReset);

                if (CustomGameOptions.MorphCooldownsLinked)
                    LastMorphed.AddSeconds(CustomGameOptions.ProtectKCReset);
            }
        }

        //Wraith Stuff
        public CustomButton InvisButton;
        public DateTime LastInvis;
        public bool IsWraith => FormerRole?.RoleType == RoleEnum.Wraith;

        public float InvisTimer()
        {
            var timespan = DateTime.UtcNow - LastInvis;
            var num = Player.GetModifiedCooldown(CustomGameOptions.InvisCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Invis()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
            Utils.Invis(Player, CustomPlayer.Local.Is(Faction.Intruder));

            if (IsDead || Utils.Meeting)
                TimeRemaining = 0f;
        }

        public void Uninvis()
        {
            Enabled = false;
            LastInvis = DateTime.UtcNow;
            Utils.DefaultOutfit(Player);
        }

        public void HitInvis()
        {
            if (InvisTimer() != 0f || OnEffect)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.GodfatherAction);
            writer.Write((byte)GodfatherActionsRPC.Invis);
            writer.Write(PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            TimeRemaining = CustomGameOptions.InvisDuration;
            Invis();
        }

        //Consigliere Stuff
        public List<byte> Investigated = new();
        public CustomButton InvestigateButton;
        public DateTime LastInvestigated;
        public bool IsConsig => FormerRole?.RoleType == RoleEnum.Consigliere;

        public float ConsigliereTimer()
        {
            var timespan = DateTime.UtcNow - LastInvestigated;
            var num = Player.GetModifiedCooldown(CustomGameOptions.ConsigCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Investigate()
        {
            if (ConsigliereTimer() != 0f || Utils.IsTooFar(Player, InvestigateButton.TargetPlayer) || Investigated.Contains(InvestigateButton.TargetPlayer.PlayerId))
                return;

            var interact = Utils.Interact(Player, InvestigateButton.TargetPlayer);

            if (interact[3])
                Investigated.Add(InvestigateButton.TargetPlayer.PlayerId);

            if (interact[0])
                LastInvestigated = DateTime.UtcNow;
            else if (interact[1])
                LastInvestigated.AddSeconds(CustomGameOptions.ProtectKCReset);
        }

        //Miner Stuff
        public CustomButton MineButton;
        public DateTime LastMined;
        public bool CanPlace;
        public bool IsMiner => FormerRole?.RoleType == RoleEnum.Miner;

        public float MineTimer()
        {
            var timespan = DateTime.UtcNow - LastMined;
            var num = Player.GetModifiedCooldown(CustomGameOptions.MineCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Mine()
        {
            if (!CanPlace || MineTimer() != 0f)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.Mine);
            var position = Player.transform.position;
            var id = Utils.GetAvailableId();
            writer.Write(id);
            writer.Write(PlayerId);
            writer.Write(position);
            writer.Write(position.z + 0.01f);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            Utils.SpawnVent(id, this, position, position.z + 0.01f);
            LastMined = DateTime.UtcNow;
        }

        //Teleporter Stuff
        public CustomButton TeleportButton;
        public DateTime LastTeleport;
        public Vector3 TeleportPoint = Vector3.zero;
        public DateTime LastMarked;
        public CustomButton MarkButton;
        public bool CanMark;
        public bool IsTele => FormerRole?.RoleType == RoleEnum.Teleporter;

        public float MarkTimer()
        {
            var timespan = DateTime.UtcNow - LastMarked;
            var num = Player.GetModifiedCooldown(CustomGameOptions.MarkCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public float TeleportTimer()
        {
            var timespan = DateTime.UtcNow - LastTeleport;
            var num = Player.GetModifiedCooldown(CustomGameOptions.TeleportCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Mark()
        {
            if (!CanMark || MarkTimer() != 0f || TeleportPoint == Player.transform.position)
                return;

            TeleportPoint = Player.transform.position;
            LastMarked = DateTime.UtcNow;

            if (CustomGameOptions.TeleCooldownsLinked)
                LastTeleport = DateTime.UtcNow;
        }

        public void Teleport()
        {
            if (TeleportTimer() != 0f || TeleportPoint == Player.transform.position)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.Teleport);
            writer.Write(PlayerId);
            writer.Write(TeleportPoint);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            LastTeleport = DateTime.UtcNow;
            Utils.Teleport(Player, TeleportPoint);

            if (CustomGameOptions.TeleCooldownsLinked)
                LastMarked = DateTime.UtcNow;
        }

        //Ambusher Stuff
        public DateTime LastAmbushed;
        public PlayerControl AmbushedPlayer;
        public CustomButton AmbushButton;
        public bool IsAmb => FormerRole?.RoleType == RoleEnum.Ambusher;

        public float AmbushTimer()
        {
            var timespan = DateTime.UtcNow - LastAmbushed;
            var num = Player.GetModifiedCooldown(CustomGameOptions.AmbushCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Ambush()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;

            if (IsDead || AmbushedPlayer.Data.IsDead || AmbushedPlayer.Data.Disconnected || Utils.Meeting)
                TimeRemaining = 0f;
        }

        public void UnAmbush()
        {
            Enabled = false;
            LastAmbushed = DateTime.UtcNow;
            AmbushedPlayer = null;
        }

        public void HitAmbush()
        {
            if (AmbushTimer() != 0f || Utils.IsTooFar(Player, AmbushButton.TargetPlayer) || AmbushButton.TargetPlayer == AmbushedPlayer)
                return;

            var interact = Utils.Interact(Player, AmbushButton.TargetPlayer);

            if (interact[3])
            {
                TimeRemaining = CustomGameOptions.AmbushDuration;
                AmbushedPlayer = AmbushButton.TargetPlayer;
                Ambush();
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.GodfatherAction);
                writer.Write((byte)GodfatherActionsRPC.Ambush);
                writer.Write(PlayerId);
                writer.Write(AmbushButton.TargetPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
            }
            else if (interact[0])
                LastAmbushed = DateTime.UtcNow;
            else if (interact[1])
                LastAmbushed.AddSeconds(CustomGameOptions.ProtectKCReset);
        }

        //Consort Stuff
        public DateTime LastBlock;
        public CustomButton BlockButton;
        public PlayerControl BlockTarget;
        public CustomMenu BlockMenu;
        public bool IsCons => FormerRole?.RoleType == RoleEnum.Consort;

        public void UnBlock()
        {
            Enabled = false;

            foreach (var layer in GetLayers(BlockTarget))
                layer.IsBlocked = false;

            BlockTarget = null;
            LastBlock = DateTime.UtcNow;
            Utils.DefaultOutfit(Player);
        }

        public void Block()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;

            foreach (var layer in GetLayers(BlockTarget))
                layer.IsBlocked = !GetRole(BlockTarget).RoleBlockImmune;

            if (IsDead || BlockTarget.Data.IsDead || BlockTarget.Data.Disconnected || Utils.Meeting || !BlockTarget.IsBlocked())
                TimeRemaining = 0f;
        }

        public float RoleblockTimer()
        {
            var timespan = DateTime.UtcNow - LastBlock;
            var num = Player.GetModifiedCooldown(CustomGameOptions.ConsRoleblockCooldown)
                * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void ConsClick(PlayerControl player)
        {
            var interact = Utils.Interact(Player, player);

            if (interact[3])
                BlockTarget = player;
            else if (interact[0])
                LastBlock = DateTime.UtcNow;
            else if (interact[1])
                LastBlock.AddSeconds(CustomGameOptions.ProtectKCReset);
        }

        public void Roleblock()
        {
            if (RoleblockTimer() != 0f)
                return;

            if (BlockTarget == null)
                BlockMenu.Open();
            else
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.GodfatherAction);
                writer.Write((byte)GodfatherActionsRPC.ConsRoleblock);
                writer.Write(PlayerId);
                writer.Write(BlockTarget.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                TimeRemaining = CustomGameOptions.ConsRoleblockDuration;
                Block();
            }
        }

        //Enforcer Stuff
        public CustomButton BombButton;
        public PlayerControl BombedPlayer;
        public DateTime LastBombed;
        public bool BombSuccessful;
        public bool IsEnf => FormerRole?.RoleType == RoleEnum.Enforcer;

        public float BombTimer()
        {
            var timespan = DateTime.UtcNow - LastBombed;
            var num = Player.GetModifiedCooldown(CustomGameOptions.EnforceCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Boom()
        {
            if (!Enabled && CustomPlayer.Local == BombedPlayer)
            {
                Utils.Flash(Color);
                GetRole(BombedPlayer).Bombed = true;
            }

            Enabled = true;
            TimeRemaining -= Time.deltaTime;

            if (IsDead || Utils.Meeting || BombSuccessful)
                TimeRemaining = 0f;
        }

        public void BombDelay()
        {
            TimeRemaining2 -= Time.deltaTime;

            if (IsDead || Utils.Meeting)
                TimeRemaining2 = 0f;
        }

        public void Unboom()
        {
            Enabled = false;
            LastBombed = DateTime.UtcNow;
            GetRole(BombedPlayer).Bombed = false;

            if (!BombSuccessful)
                Explode();

            BombedPlayer = null;
        }

        private void Explode()
        {
            foreach (var player in Utils.GetClosestPlayers(BombedPlayer.GetTruePosition(), CustomGameOptions.EnforceRadius))
            {
                Utils.Spread(BombedPlayer, player);

                if (player.IsVesting() || player.IsProtected() || player.IsOnAlert() || player.IsShielded() || player.IsRetShielded())
                    continue;

                if (!player.Is(RoleEnum.Pestilence))
                    Utils.RpcMurderPlayer(BombedPlayer, player, DeathReasonEnum.Bombed, false);
            }
        }

        public void Bomb()
        {
            if (BombTimer() != 0f || Utils.IsTooFar(Player, BombButton.TargetPlayer) || BombedPlayer == BombButton.TargetPlayer)
                return;

            var interact = Utils.Interact(Player, BombButton.TargetPlayer);

            if (interact[3])
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.GodfatherAction);
                writer.Write((byte)GodfatherActionsRPC.SetBomb);
                writer.Write(PlayerId);
                writer.Write(BombButton.TargetPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                TimeRemaining = CustomGameOptions.EnforceDuration;
                TimeRemaining2 = CustomGameOptions.EnforceDelay;
                BombedPlayer = BombButton.TargetPlayer;
                BombDelay();
            }
            else if (interact[0])
                LastBombed = DateTime.UtcNow;
            else if (interact[1])
                LastBombed.AddSeconds(CustomGameOptions.ProtectKCReset);
        }
    }
}
