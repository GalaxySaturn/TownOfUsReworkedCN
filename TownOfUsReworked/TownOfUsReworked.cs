global using AmongUs.Data;
global using AmongUs.GameOptions;

global using BepInEx;
global using BepInEx.Unity.IL2CPP;

global using HarmonyLib;
global using Hazel;

global using Il2CppInterop.Runtime;
global using Il2CppInterop.Runtime.Attributes;
global using Il2CppInterop.Runtime.InteropTypes;
global using Il2CppInterop.Runtime.InteropTypes.Arrays;
global using Il2CppInterop.Runtime.Injection;

global using Reactor;
global using Reactor.Utilities;
global using Reactor.Utilities.Extensions;
global using Reactor.Networking.Attributes;
global using Reactor.Networking.Extensions;
global using Reactor.Networking;

global using TownOfUsReworked.Classes;
global using TownOfUsReworked.Data;
global using TownOfUsReworked.CustomOptions;
global using TownOfUsReworked.Cosmetics;
global using TownOfUsReworked.Monos;
global using TownOfUsReworked.Patches;
global using TownOfUsReworked.Custom;
global using TownOfUsReworked.MultiClientInstancing;
global using TownOfUsReworked.Objects;
global using TownOfUsReworked.Modules;
global using TownOfUsReworked.Extensions;
global using TownOfUsReworked.PlayerLayers;
global using TownOfUsReworked.Functions;
global using TownOfUsReworked.PlayerLayers.Roles;
global using TownOfUsReworked.PlayerLayers.Abilities;
global using TownOfUsReworked.PlayerLayers.Modifiers;
global using TownOfUsReworked.PlayerLayers.Objectifiers;
global using TownOfUsReworked.BetterMaps.Airship;

global using System.Linq;
global using System;
global using System.IO;
global using System.Text;
global using SRandom = System.Random;
global using System.Reflection;
global using System.Collections.Generic;
global using System.Collections;

global using UnityEngine;
global using URandom = UnityEngine.Random;
global using UObject = UnityEngine.Object;

global using TMPro;

global using InnerNet;

namespace TownOfUsReworked
{
    [BepInPlugin(Id, Name, VersionString)]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency(SubmergedCompatibility.SUBMERGED_GUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("gg.reactor.debugger", BepInDependency.DependencyFlags.SoftDependency)]
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    [BepInProcess("Among Us.exe")]
    public class TownOfUsReworked : BasePlugin
    {
        public const string Id = "me.alchlcdvl.reworked";
        public const string Name = "TownOfUsReworked";
        public const string VersionString = "0.2.3.0";
        public const string CompleteVersionString = "0.2.3.0";
        public readonly static Version Version = new(VersionString);

        private readonly static string dev = VersionString[6..];
        private readonly static string test = CompleteVersionString[7..];
        private readonly static string version = VersionString.Length == 8 ? VersionString.Remove(VersionString.Length - 3) : VersionString.Remove(VersionString.Length - 2);
        private readonly static bool isDev = dev != "0";
        public readonly static bool isTest = VersionString != CompleteVersionString && test != "";
        private readonly static string devString = isDev ? $"-dev{dev}" : "";
        private readonly static string testString = isTest ? "_test" : "";
        public readonly static string versionFinal = $"v{version}{devString}{testString}";

        public readonly static string Resources = "TownOfUsReworked.Resources.";
        public readonly static string Buttons = $"{Resources}Buttons.";
        public readonly static string Sounds = $"{Resources}Sounds.";
        public readonly static string Misc = $"{Resources}Misc.";
        public readonly static string Presets = $"{Resources}Presets.";
        public readonly static string Languages = $"{Resources}Languages.";

        public static Assembly Assembly => typeof(TownOfUsReworked).Assembly;
        public static Assembly Executing => Assembly.GetExecutingAssembly();

        public static NormalGameOptionsV07 VanillaOptions => GameOptionsManager.Instance.currentNormalGameOptions;

        #pragma warning disable
        public static bool LobbyCapped = true;
        public static bool Persistence = true;
        public static bool MCIActive = false;
        public static Debugger Debugger;
        #pragma warning restore

        private readonly Harmony Harmony = new(Id);

        public override void Load()
        {
            Utils.LogSomething("Loading...");

            var maxImpostors = (Il2CppStructArray<int>)Enumerable.Repeat(255, 255).ToArray();
            GameOptionsData.MaxImpostors = maxImpostors;
            NormalGameOptionsV07.MaxImpostors = maxImpostors;
            HideNSeekGameOptionsV07.MaxImpostors = maxImpostors;

            var minPlayers = (Il2CppStructArray<int>)Enumerable.Repeat(1, 1).ToArray();
            GameOptionsData.MinPlayers = minPlayers;
            NormalGameOptionsV07.MinPlayers = minPlayers;
            HideNSeekGameOptionsV07.MinPlayers = minPlayers;

            if (!File.Exists("steam_appid.txt"))
                File.WriteAllText("steam_appid.txt", "945360");

            SubmergedCompatibility.Initialize();
            PalettePatch.Load();
            Generate.GenerateAll();
            UpdateNames.PlayerNames.Clear();
            AssetManager.Load();
            RoleGen.ResetEverything();

            ClassInjector.RegisterTypeInIl2Cpp<MissingSubmergedBehaviour>();
            ClassInjector.RegisterTypeInIl2Cpp<AbstractPagingBehaviour>();
            ClassInjector.RegisterTypeInIl2Cpp<ShapeShifterPagingBehaviour>();
            ClassInjector.RegisterTypeInIl2Cpp<MeetingHudPagingBehaviour>();
            ClassInjector.RegisterTypeInIl2Cpp<VitalsPagingBehaviour>();
            ClassInjector.RegisterTypeInIl2Cpp<ColorBehaviour>();
            ClassInjector.RegisterTypeInIl2Cpp<Debugger>();
            ClassInjector.RegisterTypeInIl2Cpp<Tasks>();

            Debugger = AddComponent<Debugger>();

            Harmony.PatchAll();

            Utils.LogSomething("Mod Loaded!");
            Utils.LogSomething($"Mod Version {versionFinal}");
        }
    }
}