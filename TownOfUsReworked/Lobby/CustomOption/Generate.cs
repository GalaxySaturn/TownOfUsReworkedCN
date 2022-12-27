using System;

namespace TownOfUsReworked.Lobby.CustomOption
{
    public class Generate
    {
        //Global Options
        public static CustomHeaderOption GlobalSettings;
        public static CustomNumberOption PlayerSpeed;
        public static CustomNumberOption GhostSpeed;
        public static CustomNumberOption InteractionDistance;
        public static CustomNumberOption EmergencyButtonCount;
        public static CustomNumberOption EmergencyButtonCooldown;
        public static CustomNumberOption InitialCooldowns;
        public static CustomNumberOption DiscussionTime;
        public static CustomNumberOption VotingTime;
        public static CustomToggleOption ConfirmEjects;
        public static CustomToggleOption EjectionRevealsRole;
        public static CustomStringOption TaskBarMode;
        public static CustomNumberOption LobbySize;

        //CI Role Spawn
        public static CustomHeaderOption CrewInvestigativeRoles;
        public static CustomNumberOption DetectiveOn;
        public static CustomNumberOption InvestigatorOn;
        public static CustomNumberOption CoronerOn;
        public static CustomNumberOption SheriffOn;
        public static CustomNumberOption MediumOn;
        public static CustomNumberOption AgentOn;
        public static CustomNumberOption TrackerOn;
        public static CustomNumberOption InspectorOn;
        public static CustomNumberOption OperativeOn;

        //CSv Role Spawn
        public static CustomHeaderOption CrewSovereignRoles;
        public static CustomNumberOption MayorOn;
        public static CustomNumberOption SwapperOn;

        //CP Role Spawn
        public static CustomHeaderOption CrewProtectiveRoles;
        public static CustomNumberOption AltruistOn;
        public static CustomNumberOption MedicOn;
        public static CustomNumberOption TimeLordOn;

        //CA Role Spawn
        public static CustomHeaderOption CrewAuditorRoles;
        public static CustomNumberOption VampireHunterOn;

        //CK Role Spawn
        public static CustomHeaderOption CrewKillingRoles;
        public static CustomNumberOption VeteranOn;
        public static CustomNumberOption VigilanteOn;

        //CS Role Spawn
        public static CustomHeaderOption CrewSupportRoles;
        public static CustomNumberOption EngineerOn;
        public static CustomNumberOption ShifterOn;
        public static CustomNumberOption EscortOn;
        public static CustomNumberOption TransporterOn;

        //CU Role Spawn
        public static CustomHeaderOption CrewUtilityRoles;
        public static CustomNumberOption CrewmateOn;

        //NB Role Spawn
        public static CustomHeaderOption NeutralBenignRoles;
        public static CustomNumberOption AmnesiacOn;
        public static CustomNumberOption GuardianAngelOn;
        public static CustomNumberOption SurvivorOn;
        public static CustomNumberOption ThiefOn;

        //NN Role Spawn
        public static CustomHeaderOption NeutralNeophyteRoles;
        public static CustomNumberOption DraculaOn;
        public static CustomNumberOption JackalOn;

        //NE Role Spawn
        public static CustomHeaderOption NeutralEvilRoles;
        public static CustomNumberOption ExecutionerOn;
        public static CustomNumberOption JesterOn;
        public static CustomNumberOption CannibalOn;
        public static CustomNumberOption TrollOn;
        public static CustomNumberOption PirateOn;

        //NK Role Spawn
        public static CustomHeaderOption NeutralKillingRoles;
        public static CustomNumberOption ArsonistOn;
        public static CustomNumberOption CryomaniacOn;
        public static CustomNumberOption PlaguebearerOn;
        public static CustomNumberOption GlitchOn;
        public static CustomNumberOption MurdererOn;
        public static CustomNumberOption WerewolfOn;
        public static CustomNumberOption SerialKillerOn;
        public static CustomNumberOption JuggernautOn;

        //IC Role Spawn
        public static CustomHeaderOption IntruderConcealingRoles;
        public static CustomNumberOption BlackmailerOn;
        public static CustomNumberOption CamouflagerOn;
        public static CustomNumberOption GrenadierOn;
        public static CustomNumberOption UndertakerOn;
        public static CustomNumberOption JanitorOn;

        //ID Role Spawn
        public static CustomHeaderOption IntruderDeceptionRoles;
        public static CustomNumberOption MorphlingOn;
        public static CustomNumberOption DisguiserOn;
        public static CustomNumberOption PoisonerOn;
        public static CustomNumberOption WraithOn;

        //IK Role Spawn
        public static CustomHeaderOption IntruderKillingRoles;

        //IS Role Spawn
        public static CustomHeaderOption IntruderSupportRoles;
        public static CustomNumberOption ConsigliereOn;
        public static CustomNumberOption GodfatherOn;
        public static CustomNumberOption ConsortOn;
        public static CustomNumberOption MinerOn;
        public static CustomNumberOption TimeMasterOn;
        public static CustomNumberOption TeleporterOn;

        //IU Role Spawn
        public static CustomHeaderOption IntruderUtilityRoles;
        public static CustomNumberOption ImpostorOn;

        //SSu Role Spawn
        public static CustomHeaderOption SyndicateSupportRoles;
        public static CustomNumberOption WarperOn;
        public static CustomNumberOption RebelOn;
        public static CustomNumberOption ConcealerOn;

        //SD Role Spawn
        public static CustomHeaderOption SyndicateDisruptionRoles;
        public static CustomNumberOption PuppeteerOn;
        public static CustomNumberOption ShapeshifterOn;

        //SyK Role Spawn
        public static CustomHeaderOption SyndicateKillingRoles;
        public static CustomNumberOption GorgonOn;

        //SU Role Spawn
        public static CustomHeaderOption SyndicateUtilityRoles;
        public static CustomNumberOption AnarchistOn;

        //Modifier Spawn
        public static CustomHeaderOption Modifiers;
        public static CustomNumberOption BaitOn;
        public static CustomNumberOption DiseasedOn;
        public static CustomNumberOption GiantOn;
        public static CustomNumberOption DwarfOn;
        public static CustomNumberOption CowardOn;
        public static CustomNumberOption VIPOn;
        public static CustomNumberOption ShyOn;
        public static CustomNumberOption InsiderOn;
        public static CustomNumberOption DrunkOn;
        public static CustomNumberOption FlincherOn;
        public static CustomNumberOption VolatileOn;
        public static CustomNumberOption ProfessionalOn;

        //Ability Spawn
        public static CustomHeaderOption Abilities;
        public static CustomNumberOption AssassinOn;
        public static CustomNumberOption TorchOn;
        public static CustomNumberOption LighterOn;
        public static CustomNumberOption ButtonBarryOn;
        public static CustomNumberOption TiebreakerOn;
        public static CustomNumberOption TunnelerOn;
        public static CustomNumberOption UnderdogOn;
        public static CustomNumberOption SnitchOn;
        public static CustomNumberOption RevealerOn;
        public static CustomNumberOption RadarOn;
        public static CustomNumberOption MultitaskerOn;

        //Objectifier Spawn
        public static CustomHeaderOption Objectifiers;
        public static CustomNumberOption LoversOn;
        public static CustomNumberOption PhantomOn;
        public static CustomNumberOption TraitorOn;
        public static CustomNumberOption RivalsOn;
        public static CustomNumberOption FanaticOn;
        public static CustomNumberOption TaskmasterOn;

        //Map Settings
        public static CustomHeaderOption MapSettings;
        public static CustomToggleOption RandomMapEnabled;
        public static CustomNumberOption RandomMapSkeld;
        public static CustomNumberOption RandomMapMira;
        public static CustomNumberOption RandomMapPolus;
        public static CustomNumberOption RandomMapAirship;
        public static CustomNumberOption RandomMapSubmerged;
        public static CustomToggleOption AutoAdjustSettings;
        public static CustomToggleOption SmallMapHalfVision;
        public static CustomNumberOption SmallMapDecreasedCooldown;
        public static CustomNumberOption LargeMapIncreasedCooldown;
        public static CustomNumberOption SmallMapIncreasedShortTasks;
        public static CustomNumberOption SmallMapIncreasedLongTasks;
        public static CustomNumberOption LargeMapDecreasedShortTasks;
        public static CustomNumberOption LargeMapDecreasedLongTasks;
        public static CustomStringOption Map;
        
        //Game Modifier Options
        public static CustomHeaderOption GameModifiers;
        public static CustomToggleOption ColourblindComms;
        public static CustomToggleOption MeetingColourblind;
        public static CustomToggleOption AnonymousVoting;
        public static CustomStringOption WhoCanVent;
        public static CustomStringOption NoSolo;
        public static CustomStringOption SkipButtonDisable;
        public static CustomToggleOption FactionSeeRoles;
        public static CustomToggleOption ParallelMedScans;
        public static CustomToggleOption VisualTasks;
        public static CustomStringOption RolesVisible;
        public static CustomToggleOption LocationReports;

        //QoL Options
        public static CustomHeaderOption QualityChanges;
        public static CustomToggleOption DeadSeeEverything;
        public static CustomToggleOption DisableLevels;
        public static CustomToggleOption WhiteNameplates;
        public static CustomToggleOption LighterDarker;
        public static CustomToggleOption PlayerNumbers;
        public static CustomToggleOption SeeTasks;
        public static CustomToggleOption AppearanceAnimation;
        public static CustomToggleOption CustomEject;

        //Better Polus Options
        public static CustomHeaderOption BetterPolusSettings;
        public static CustomToggleOption VentImprovements;
        public static CustomToggleOption VitalsLab;
        public static CustomToggleOption ColdTempDeathValley;
        public static CustomToggleOption WifiChartCourseSwap;

        //Game Modes
        public static CustomHeaderOption GameModeSettings;
        public static CustomStringOption GameMode;

        //Classic Options
        public static CustomHeaderOption ClassicSettings;
        public static CustomNumberOption MinNeutralNonKillingRoles;
        public static CustomNumberOption MaxNeutralNonKillingRoles;
        public static CustomNumberOption MinNeutralKillingRoles;
        public static CustomNumberOption MaxNeutralKillingRoles;

        //Killing Only Options
        public static CustomHeaderOption KillingOnlySettings;
        public static CustomNumberOption NeutralRoles;
        public static CustomToggleOption AddArsonist;
        public static CustomToggleOption AddCryomaniac;
        public static CustomToggleOption AddPlaguebearer;

        //Crew Options
        public static CustomHeaderOption CrewSettings;
        public static CustomToggleOption CustomCrewColors;
        public static CustomNumberOption ShortTasks;
        public static CustomNumberOption LongTasks;
        public static CustomNumberOption CommonTasks;
        public static CustomNumberOption CrewVision;
        public static CustomToggleOption GhostTasksCountToWin;

        //CSv Options
        public static CustomHeaderOption CrewSovereignSettings;

        //Mayor Options
        public static CustomHeaderOption Mayor;
        public static CustomNumberOption MayorCount;
        public static CustomNumberOption MayorVoteBank;
        public static CustomToggleOption MayorAnonymous;

        //Swapper Options
        public static CustomHeaderOption Swapper;
        public static CustomNumberOption SwapperCount;
        public static CustomToggleOption SwapperButton;
        public static CustomToggleOption SwapAfterVoting;
        
        //CA Options
        public static CustomHeaderOption CrewAuditorSettings;

        //Vampire Hunter Options
        public static CustomHeaderOption VampireHunter;
        public static CustomNumberOption VampireHunterCount;
        public static CustomNumberOption StakeCooldown;
        
        //CK Options
        public static CustomHeaderOption CrewKillingSettings;

        //Vigilante Options
        public static CustomHeaderOption Vigilante;
        public static CustomNumberOption VigilanteCount;
        public static CustomStringOption VigiOptions;
        public static CustomToggleOption VigiKnowsInno;
        public static CustomNumberOption VigiKillCd;

        //Veteran Options
        public static CustomHeaderOption Veteran;
        public static CustomNumberOption VeteranCount;
        public static CustomNumberOption AlertCooldown;
        public static CustomNumberOption AlertDuration;
        public static CustomNumberOption MaxAlerts;
        
        //CS Options
        public static CustomHeaderOption CrewSupportSettings;

        //Engineer Options
        public static CustomHeaderOption Engineer;
        public static CustomNumberOption EngineerCount;
        public static CustomStringOption EngineerPer;

        //Transporter Options
        public static CustomHeaderOption Transporter;
        public static CustomNumberOption TransporterCount;
        public static CustomNumberOption TransportCooldown;
        public static CustomNumberOption TransportMaxUses;

        //Escort Options
        public static CustomHeaderOption Escort;
        public static CustomNumberOption EscortCount;
        public static CustomNumberOption EscRoleblockCooldown;
        public static CustomNumberOption EscRoleblockDuration;

        //Shifter Options
        public static CustomHeaderOption Shifter;
        public static CustomNumberOption ShifterCount;
        public static CustomNumberOption ShifterCd;
        public static CustomStringOption ShiftedBecomes;
        
        //CI Options
        public static CustomHeaderOption CrewInvestigativeSettings;

        //Investigator Options
        public static CustomHeaderOption Investigator;
        public static CustomNumberOption InvestigatorCount;
        public static CustomNumberOption FootprintSize;
        public static CustomNumberOption FootprintInterval;
        public static CustomNumberOption FootprintDuration;
        public static CustomToggleOption AnonymousFootPrint;
        public static CustomToggleOption VentFootprintVisible;

        //Tracker Options
        public static CustomHeaderOption Tracker;
        public static CustomNumberOption TrackerCount;
        public static CustomNumberOption UpdateInterval;
        public static CustomNumberOption TrackCooldown;
        public static CustomToggleOption ResetOnNewRound;
        public static CustomNumberOption MaxTracks;

        //Operative Options
        public static CustomHeaderOption Operative;
        public static CustomNumberOption OperativeCount;
        public static CustomNumberOption BugCooldown;
        public static CustomToggleOption BugsRemoveOnNewRound;
        public static CustomNumberOption MaxBugs;
        public static CustomNumberOption MinAmountOfTimeInBug;
        public static CustomNumberOption BugRange;
        public static CustomNumberOption MinAmountOfPlayersInBug;

        //Detective Options
        public static CustomHeaderOption Detective;
        public static CustomNumberOption DetectiveCount;
        public static CustomNumberOption InitialExamineCooldown;
        public static CustomNumberOption ExamineCooldown;
        public static CustomNumberOption RecentKill;
        public static CustomToggleOption DetectiveReportOn;
        public static CustomNumberOption DetectiveRoleDuration;
        public static CustomNumberOption DetectiveFactionDuration;

        //Coroner Options
        public static CustomHeaderOption Coroner;
        public static CustomNumberOption CoronerCount;
        public static CustomNumberOption CoronerArrowDuration;
        public static CustomToggleOption CoronerReportName;
        public static CustomToggleOption CoronerReportRole;

        //Inspector Options
        public static CustomHeaderOption Inspector;
        public static CustomNumberOption InspectorCount;
        public static CustomNumberOption InspectCooldown;

        //Medium Options
        public static CustomHeaderOption Medium;
        public static CustomNumberOption MediumCount;
        public static CustomNumberOption MediateCooldown;
        public static CustomToggleOption ShowMediatePlayer;
        public static CustomToggleOption ShowMediumToDead;
        public static CustomStringOption DeadRevealed;

        //Sheriff Options
        public static CustomHeaderOption Sheriff;
        public static CustomNumberOption SheriffCount;
        public static CustomNumberOption InterrogateCooldown;
        public static CustomToggleOption NeutEvilRed;
        public static CustomToggleOption NeutKillingRed;
        public static CustomStringOption InterrogatePer;
        public static CustomToggleOption TraitorColourSwap;

        //Agent Options
        public static CustomHeaderOption Agent;
        public static CustomNumberOption AgentCount;
        
        //CP Options
        public static CustomHeaderOption CrewProtectiveSettings;

        //Time Lord Options
        public static CustomHeaderOption TimeLord;
        public static CustomNumberOption TimeLordCount;
        public static CustomToggleOption RewindRevive;
        public static CustomToggleOption TLImmunity;
        public static CustomNumberOption RewindDuration;
        public static CustomNumberOption RewindCooldown;
        public static CustomNumberOption RewindMaxUses;

        //Altruist Options
        public static CustomHeaderOption Altruist;
        public static CustomNumberOption AltruistCount;
        public static CustomNumberOption ReviveDuration;
        public static CustomToggleOption AltruistTargetBody;

        //Medic Options
        public static CustomHeaderOption Medic;
        public static CustomNumberOption MedicCount;
        public static CustomStringOption ShowShielded;
        public static CustomStringOption WhoGetsNotification;
        public static CustomToggleOption ShieldBreaks;
        public static CustomToggleOption MedicReportSwitch;
        
        //CU Options
        public static CustomHeaderOption CrewUtilitySettings;

        //Crewmate Options
        public static CustomHeaderOption Crewmate;
        public static CustomNumberOption CrewCount;
        
        //Intruder Options
        public static CustomHeaderOption IntruderSettings;
        public static CustomToggleOption CustomIntColors;
        public static CustomNumberOption IntruderVision;
        public static CustomToggleOption IntrudersVent;
        public static CustomToggleOption IntrudersCanSabotage;
        public static CustomNumberOption IntruderKillCooldown;
        public static CustomNumberOption IntruderSabotageCooldown;
        public static CustomNumberOption IntruderCount;

        //IC Options
        public static CustomHeaderOption IntruderConcealingSettings;

        //Janitor Options
        public static CustomHeaderOption Janitor;
        public static CustomNumberOption JanitorCount;
        public static CustomNumberOption JanitorCleanCd;
        public static CustomToggleOption SoloBoost;

        //Blackmailer Options
        public static CustomHeaderOption Blackmailer;
        public static CustomNumberOption BlackmailerCount;
        public static CustomNumberOption BlackmailCooldown;

        //Grenadier Options
        public static CustomHeaderOption Grenadier;
        public static CustomNumberOption GrenadierCount;
        public static CustomNumberOption GrenadeCooldown;
        public static CustomNumberOption GrenadeDuration;
        public static CustomToggleOption GrenadierIndicators;
        public static CustomToggleOption GrenadierVent;
        public static CustomNumberOption FlashRadius;

        //Camouflager Options
        public static CustomHeaderOption Camouflager;
        public static CustomNumberOption CamouflagerCount;
        public static CustomNumberOption CamouflagerCooldown;
        public static CustomNumberOption CamouflagerDuration;
        public static CustomToggleOption CamoHideSpeed;
        public static CustomToggleOption CamoHideSize;

        //Undertaker Options
        public static CustomHeaderOption Undertaker;
        public static CustomNumberOption UndertakerCount;
        public static CustomNumberOption DragCooldown;
        public static CustomStringOption UndertakerVentOptions;
        public static CustomNumberOption DragModifier;

        //ID Options
        public static CustomHeaderOption IntruderDeceptionSettings;

        //Morphling Options
        public static CustomHeaderOption Morphling;
        public static CustomNumberOption MorphlingCount;
        public static CustomNumberOption MorphlingCooldown;
        public static CustomNumberOption MorphlingDuration;
        public static CustomToggleOption MorphlingVent;
        
        //Disguiser Options
        public static CustomHeaderOption Disguiser;
        public static CustomNumberOption DisguiserCount;
        public static CustomNumberOption DisguiseCooldown;
        public static CustomNumberOption TimeToDisguise;
        public static CustomNumberOption DisguiseDuration;
        public static CustomStringOption DisguiseTarget;

        //Wraith Options
        public static CustomHeaderOption Wraith;
        public static CustomNumberOption WraithCount;
        public static CustomNumberOption InvisCooldown;
        public static CustomNumberOption InvisDuration;
        public static CustomToggleOption WraithVent;

        //Poisoner Options
        public static CustomHeaderOption Poisoner;
        public static CustomNumberOption PoisonerCount;
        public static CustomNumberOption PoisonCooldown;
        public static CustomNumberOption PoisonDuration;
        public static CustomToggleOption PoisonerVent;

        //IS Options
        public static CustomHeaderOption IntruderSupportSettings;

        //Teleporter Options
        public static CustomHeaderOption Teleporter;
        public static CustomNumberOption TeleporterCount;
        public static CustomNumberOption TeleportCd;
        public static CustomToggleOption TeleVent;

        //Consigliere Options
        public static CustomHeaderOption Consigliere;
        public static CustomNumberOption ConsigCount;
        public static CustomNumberOption RevealCooldown;
        public static CustomStringOption ConsigInfo;

        //Time Master Options
        public static CustomHeaderOption TimeMaster;
        public static CustomNumberOption TMCount;
        public static CustomNumberOption FreezeDuration;
        public static CustomNumberOption FreezeCooldown;

        //Consort Options
        public static CustomHeaderOption Consort;
        public static CustomNumberOption ConsortCount;
        public static CustomNumberOption ConsRoleblockCooldown;
        public static CustomNumberOption ConsRoleblockDuration;

        //Godfather Options
        public static CustomHeaderOption Godfather;
        public static CustomNumberOption GodfatherCount;
        public static CustomNumberOption DeclareCooldown;

        //Miner Options
        public static CustomHeaderOption Miner;
        public static CustomNumberOption MinerCount;
        public static CustomNumberOption MineCooldown;

        //IK Options
        public static CustomHeaderOption IntruderKillingSettings;

        //IU Options
        public static CustomHeaderOption IntruderUtilitySettings;

        //Impostor Options
        public static CustomHeaderOption Impostor;
        public static CustomNumberOption ImpCount;

        //Mafioso Options
        public static CustomHeaderOption Mafioso;
        public static CustomNumberOption MafiosoAbilityCooldownDecrease;
        public static CustomToggleOption PromotedMafiosoCanPromote;

        //Syndicate Options
        public static CustomHeaderOption SyndicateSettings;
        public static CustomToggleOption CustomSynColors;
        public static CustomNumberOption SyndicateVision;
        public static CustomToggleOption SyndicateVent;
        public static CustomNumberOption ChaosDriveMeetingCount;
        public static CustomNumberOption ChaosDriveKillCooldown;
        public static CustomNumberOption SyndicateCount;
        public static CustomToggleOption AltImps;

        //SD Options
        public static CustomHeaderOption SyndicateDisruptionSettings;

        //Shapeshifter Options
        public static CustomHeaderOption Shapeshifter;
        public static CustomNumberOption ShapeshifterCount;
        public static CustomNumberOption ShapeshiftCooldown;
        public static CustomNumberOption ShapeshiftDuration;

        //Puppeteer Options
        public static CustomHeaderOption Puppeteer;
        public static CustomNumberOption PossessCooldown;
        public static CustomNumberOption PossessDuration;
        public static CustomNumberOption PuppeteerCount;
        
        //SyK Options
        public static CustomHeaderOption SyndicateKillingSettings;

        //Gorgon Options
        public static CustomHeaderOption Gorgon;
        public static CustomNumberOption GorgonCount;
        public static CustomNumberOption GazeTime;
        public static CustomNumberOption GazeCooldown;

        //SSu Options
        public static CustomHeaderOption SyndicateSupportSettings;

        //Concealer Options
        public static CustomHeaderOption Concealer;
        public static CustomNumberOption ConcealerCount;
        public static CustomNumberOption ConcealCooldown;
        public static CustomNumberOption ConcealDuration;

        //Rebel Options
        public static CustomHeaderOption Rebel;
        public static CustomNumberOption RebelCount;
        public static CustomNumberOption SidekickCooldown;

        //Warper Options
        public static CustomHeaderOption Warper;
        public static CustomNumberOption WarperCount;
        public static CustomNumberOption WarpCooldown;

        //SU Options
        public static CustomHeaderOption SyndicateUtilitySettings;

        //Sidekick Options
        public static CustomHeaderOption Sidekick;
        public static CustomNumberOption SidekickAbilityCooldownDecrease;
        public static CustomToggleOption PromotedSidekickCanPromote;

        //Anarchist Options
        public static CustomHeaderOption Anarchist;
        public static CustomNumberOption AnarchistCount;

        //SP Options
        public static CustomHeaderOption SyndicatePowerSettings;
        
        //Neutral Options
        public static CustomHeaderOption NeutralSettings;
        public static CustomToggleOption CustomNeutColors;
        public static CustomNumberOption NeutralVision;
        public static CustomToggleOption LightsAffectNeutrals;

        //NB Options
        public static CustomHeaderOption NeutralBenignSettings;
        public static CustomToggleOption VigiKillsNB;

        //Amnesiac Options
        public static CustomHeaderOption Amnesiac;
        public static CustomNumberOption AmnesiacCount;
        public static CustomToggleOption RememberArrows;
        public static CustomNumberOption RememberArrowDelay;
        public static CustomToggleOption AmneVent;
        public static CustomToggleOption AmneSwitchVent;
        public static CustomToggleOption AmneTurnAssassin;

        //Survivor Options
        public static CustomHeaderOption Survivor;
        public static CustomNumberOption SurvivorCount;
        public static CustomNumberOption VestCd;
        public static CustomNumberOption VestDuration;
        public static CustomNumberOption VestKCReset;
        public static CustomToggleOption SurvVent;
        public static CustomToggleOption SurvSwitchVent;
        public static CustomNumberOption MaxVests;

        //Guardian Angel Options
        public static CustomHeaderOption GuardianAngel;
        public static CustomNumberOption GuardianAngelCount;
        public static CustomNumberOption ProtectCd;
        public static CustomNumberOption ProtectDuration;
        public static CustomNumberOption ProtectKCReset;
        public static CustomNumberOption MaxProtects;
        public static CustomStringOption ShowProtect;
        public static CustomStringOption GaOnTargetDeath;
        public static CustomToggleOption GATargetKnows;
        public static CustomToggleOption ProtectBeyondTheGrave;
        public static CustomToggleOption GAKnowsTargetRole;
        public static CustomToggleOption GAVent;
        public static CustomToggleOption GASwitchVent;

        //Thief Options
        public static CustomHeaderOption Thief;
        public static CustomNumberOption ThiefCount;
        public static CustomToggleOption ThiefVent;
        public static CustomNumberOption ThiefKillCooldown;

        //NE Options
        public static CustomHeaderOption NeutralEvilSettings;

        //Jester Options
        public static CustomHeaderOption Jester;
        public static CustomNumberOption JesterCount;
        public static CustomToggleOption JesterButton;
        public static CustomToggleOption JesterVent;
        public static CustomToggleOption JestSwitchVent;
        public static CustomToggleOption JestEjectScreen;
        public static CustomToggleOption VigiKillsJester;

        //Troll Options
        public static CustomHeaderOption Troll;
        public static CustomNumberOption TrollCount;
        public static CustomNumberOption InteractCooldown;
        public static CustomToggleOption TrollVent;
        public static CustomToggleOption TrollSwitchVent;

        //Cannibal Options
        public static CustomHeaderOption Cannibal;
        public static CustomNumberOption CannibalCount;
        public static CustomNumberOption CannibalCd;
        public static CustomNumberOption CannibalBodyCount;
        public static CustomToggleOption CannibalVent;
        public static CustomToggleOption EatArrows;
        public static CustomNumberOption EatArrowDelay;
        public static CustomToggleOption VigiKillsCannibal;

        //Executioner Options
        public static CustomHeaderOption Executioner;
        public static CustomNumberOption ExecutionerCount;
        public static CustomStringOption OnTargetDead;
        public static CustomToggleOption ExecutionerButton;
        public static CustomToggleOption ExeVent;
        public static CustomToggleOption ExeSwitchVent;
        public static CustomToggleOption ExeTargetKnows;
        public static CustomToggleOption ExeKnowsTargetRole;
        public static CustomToggleOption ExeCanHaveIntruderTargets;
        public static CustomToggleOption ExeCanHaveSyndicateTargets;
        public static CustomToggleOption ExeCanHaveNeutralTargets;
        public static CustomToggleOption ExeEjectScreen;
        public static CustomToggleOption ExeCanWinBeyondDeath;
        public static CustomToggleOption VigiKillsExecutioner;

        /*//Pirate Options
        public static CustomHeaderOption Pirate;
        public static CustomNumberOption PirateCount;
        public static CustomNumberOption PlunderCooldown;
        public static CustomNumberOption PlunderDuration;
        public static CustomToggleOption LoserDies;
        public static CustomToggleOption PirateVent;*/

        //NK Options
        public static CustomHeaderOption NeutralKillingSettings;
        public static CustomToggleOption NKHasImpVision;

        //Glitch Options
        public static CustomHeaderOption Glitch;
        public static CustomNumberOption GlitchCount;
        public static CustomNumberOption MimicCooldownOption;
        public static CustomNumberOption MimicDurationOption;
        public static CustomNumberOption HackCooldownOption;
        public static CustomNumberOption HackDurationOption;
        public static CustomNumberOption GlitchKillCooldownOption;
        public static CustomToggleOption GlitchVent;

        //Juggernaut Options
        public static CustomHeaderOption Juggernaut;
        public static CustomNumberOption JuggernautCount;
        public static CustomToggleOption JuggVent;
        public static CustomNumberOption JuggKillCooldownOption;
        public static CustomNumberOption JuggKillBonus;

        //Cryomaniac Options
        public static CustomHeaderOption Cryomaniac;
        public static CustomNumberOption CryomaniacCount;
        public static CustomNumberOption CryoDouseCooldown;
        public static CustomToggleOption CryoVent;

        //Plaguebearer Options
        public static CustomHeaderOption Plaguebearer;
        public static CustomNumberOption PlaguebearerCount;
        public static CustomNumberOption InfectCooldown;
        public static CustomToggleOption PBVent;

        //Pestilence Options
        public static CustomHeaderOption Pestilence;
        public static CustomToggleOption PestSpawn;
        public static CustomToggleOption PlayersAlerted;
        public static CustomNumberOption PestKillCooldown;
        public static CustomToggleOption PestVent;

        //Arsonist Options
        public static CustomHeaderOption Arsonist;
        public static CustomNumberOption ArsonistCount;
        public static CustomNumberOption DouseCooldown;
        public static CustomNumberOption IgniteCooldown;
        public static CustomToggleOption ArsoVent;
        public static CustomToggleOption ArsoIgniteNeedsCooldown;

        //Murderer Options
        public static CustomHeaderOption Murderer;
        public static CustomNumberOption MurdCount;
        public static CustomToggleOption MurdVent;
        public static CustomNumberOption MurdKillCooldownOption;

        //Serial Killer Options
        public static CustomHeaderOption SerialKiller;
        public static CustomNumberOption SKCount;
        public static CustomNumberOption BloodlustCooldown;
        public static CustomNumberOption BloodlustDuration;
        public static CustomNumberOption LustKillCooldown;
        public static CustomStringOption SKVentOptions;

        //Werewolf Options
        public static CustomHeaderOption Werewolf;
        public static CustomNumberOption WerewolfCount;
        public static CustomNumberOption MaulCooldown;
        public static CustomNumberOption MaulRadius;
        public static CustomToggleOption WerewolfVent;

        //NN Options
        public static CustomHeaderOption NeutralNeophyteSettings;

        //Dracula Options
        public static CustomHeaderOption Dracula;
        public static CustomNumberOption DraculaCount;
        public static CustomNumberOption BiteCooldown;
        public static CustomToggleOption DraculaConvertNeuts;
        public static CustomNumberOption AliveVampCount;
        public static CustomToggleOption DracVent;

        //Jackal Options
        public static CustomHeaderOption Jackal;
        public static CustomNumberOption JackalCount;
        public static CustomNumberOption RecruitCooldown;
        public static CustomToggleOption JackConvertNeuts;
        public static CustomToggleOption JackalVent;

        //NP Options
        public static CustomHeaderOption NeutralProselyteSettings;

        //Vampire Options
        public static CustomHeaderOption Vampire;
        public static CustomToggleOption VampVent;

        //Dampyr Options
        public static CustomHeaderOption Dampyr;
        public static CustomNumberOption DampBiteCooldown;
        public static CustomToggleOption DampVent;

        //Recruit Options
        public static CustomHeaderOption Recruit;
        public static CustomToggleOption RecruitVent;

        //Ability Options
        public static CustomHeaderOption AbilitySettings;
        public static CustomToggleOption CustomAbilityColors;

        //Snitch Options
        public static CustomHeaderOption Snitch;
        public static CustomNumberOption SnitchCount;
        public static CustomToggleOption SnitchSeesNeutrals;
        public static CustomToggleOption SnitchSeesCrew;
        public static CustomToggleOption SnitchSeesRoles;
        public static CustomNumberOption SnitchTasksRemaining;
        public static CustomToggleOption SnitchSeesImpInMeeting;
        public static CustomToggleOption SnitchSeesTraitor;
        public static CustomToggleOption SnitchKnows;

        //Assassin Options
        public static CustomHeaderOption Assassin;
        public static CustomNumberOption NumberOfImpostorAssassins;
        public static CustomNumberOption NumberOfNeutralAssassins;
        public static CustomNumberOption NumberOfCrewAssassins;
        public static CustomNumberOption NumberOfSyndicateAssassins;
        public static CustomNumberOption AssassinKills;
        public static CustomToggleOption AssassinMultiKill;
        public static CustomToggleOption AssassinGuessNeutralBenign;
        public static CustomToggleOption AssassinGuessNeutralEvil;
        public static CustomToggleOption AssassinGuessPest;
        public static CustomToggleOption AssassinGuessModifiers;
        public static CustomToggleOption AssassinGuessObjectifiers;
        public static CustomToggleOption AssassinGuessAbilities;
        public static CustomToggleOption AssassinateAfterVoting;

        //Underdog Options
        public static CustomHeaderOption Underdog;
        public static CustomNumberOption UnderdogCount;
        public static CustomToggleOption UnderdogKnows;
        public static CustomNumberOption UnderdogKillBonus;
        public static CustomToggleOption UnderdogIncreasedKC;

        //Revealer Options
        public static CustomHeaderOption Revealer;
        public static CustomNumberOption RevealerCount;
        public static CustomToggleOption RevealerKnows;
        public static CustomNumberOption RevealerTasksRemainingClicked;
        public static CustomNumberOption RevealerTasksRemainingAlert;
        public static CustomToggleOption RevealerRevealsNeutrals;
        public static CustomToggleOption RevealerRevealsCrew;
        public static CustomToggleOption RevealerRevealsRoles;
        public static CustomToggleOption RevealerRevealsTraitor;
        public static CustomStringOption RevealerCanBeClickedBy;

        //Multitasker Options
        public static CustomHeaderOption Multitasker;
        public static CustomNumberOption MultitaskerCount;
        public static CustomNumberOption Transparancy;

        //Button Barry Options
        public static CustomHeaderOption ButtonBarry;
        public static CustomNumberOption BBCount;
        public static CustomNumberOption ButtonCount;

        //Tiebreaker Options
        public static CustomHeaderOption Tiebreaker;
        public static CustomToggleOption TiebreakerKnows;
        public static CustomNumberOption TiebreakerCount;

        //Torch Options
        public static CustomHeaderOption Torch;
        public static CustomNumberOption TorchCount;

        //Tunneler Options
        public static CustomHeaderOption Tunneler;
        public static CustomToggleOption TunnelerKnows;
        public static CustomNumberOption TunnelerCount;

        //Radar Options
        public static CustomHeaderOption Radar;
        public static CustomNumberOption RadarCount;

        //Lighter Options
        public static CustomHeaderOption Lighter;
        public static CustomNumberOption LighterCount;

        //Insider Options
        public static CustomHeaderOption Insider;
        public static CustomToggleOption InsiderKnows;
        public static CustomNumberOption InsiderCount;
        
        //Objectifier Options
        public static CustomHeaderOption ObjectifierSettings;
        public static CustomToggleOption CustomObjectifierColors;

        //Traitor Options
        public static CustomHeaderOption Traitor;
        public static CustomNumberOption TraitorCount;
        public static CustomToggleOption TraitorKnows;
        public static CustomToggleOption TraitorCanAssassin;

        //Phantom Options
        public static CustomHeaderOption Phantom;
        public static CustomNumberOption PhantomCount;
        public static CustomNumberOption PhantomTasksRemaining;
        public static CustomToggleOption PhantomKnows;

        //Fanatic Options
        public static CustomHeaderOption Fanatic;
        public static CustomNumberOption FanaticCount;
        public static CustomToggleOption FanaticKnows;
        public static CustomToggleOption FanaticCanAssassin;

        //Lovers Options
        public static CustomHeaderOption Lovers;
        public static CustomNumberOption LoversCount;
        public static CustomToggleOption BothLoversDie;
        public static CustomToggleOption LoversChat;
        public static CustomToggleOption LoversFaction;
        public static CustomToggleOption LoversRoles;

        //Rivals Options
        public static CustomHeaderOption Rivals;
        public static CustomNumberOption RivalsCount;
        public static CustomToggleOption RivalsChat;
        public static CustomToggleOption RivalsFaction;
        public static CustomToggleOption RivalsRoles;

        //Taskmaster Options
        public static CustomHeaderOption Taskmaster;
        public static CustomNumberOption TaskmasterCount;
        public static CustomNumberOption TMTasksRemaining;

        //Modifier Options
        public static CustomHeaderOption ModifierSettings;
        public static CustomToggleOption CustomModifierColors;

        //Giant Options
        public static CustomHeaderOption Giant;
        public static CustomNumberOption GiantCount;
        public static CustomNumberOption GiantSpeed;
        public static CustomNumberOption GiantScale;

        //Dwarf Options
        public static CustomHeaderOption Dwarf;
        public static CustomNumberOption DwarfCount;
        public static CustomNumberOption DwarfSpeed;
        public static CustomNumberOption DwarfScale;

        //Diseased Options
        public static CustomHeaderOption Diseased;
        public static CustomNumberOption DiseasedCount;
        public static CustomNumberOption DiseasedKillMultiplier;
        public static CustomToggleOption DiseasedKnows;

        //Bait Options
        public static CustomHeaderOption Bait;
        public static CustomNumberOption BaitCount;
        public static CustomNumberOption BaitMinDelay;
        public static CustomNumberOption BaitMaxDelay;
        public static CustomToggleOption BaitKnows;

        //Drunk Options
        public static CustomHeaderOption Drunk;
        public static CustomNumberOption DrunkCount;
        public static CustomToggleOption DrunkControlsSwap;
        public static CustomNumberOption DrunkInterval;

        //Coward Options
        public static CustomHeaderOption Coward;
        public static CustomNumberOption CowardCount;

        //Professional Options
        public static CustomHeaderOption Professional;
        public static CustomToggleOption ProfessionalKnows;
        public static CustomNumberOption ProfessionalCount;

        //Shy Options
        public static CustomHeaderOption Shy;
        public static CustomNumberOption ShyCount;

        //VIP Options
        public static CustomHeaderOption VIP;
        public static CustomNumberOption VIPCount;
        public static CustomToggleOption VIPKnows;

        //Flincher Options
        public static CustomHeaderOption Flincher;
        public static CustomNumberOption FlincherCount;
        public static CustomNumberOption FlinchInterval;

        //Volatile Options
        public static CustomHeaderOption Volatile;
        public static CustomNumberOption VolatileCount;
        public static CustomNumberOption VolatileInterval;

        public static Func<object, string> PercentFormat { get; } = value => $"{value:0}%";
        public static Func<object, string> CooldownFormat { get; } = value => $"{value:0.0#}s";
        public static Func<object, string> MultiplierFormat { get; } = value => $"{value:0.0#}x";

        public static void GenerateAll()
        {
            var num = 0;

            Patches.ExportButton = new Export(-1);
            Patches.ImportButton = new Import(-1);

            GlobalSettings = new CustomHeaderOption(num++, MultiMenu.main, "Global Settings");
            PlayerSpeed = new CustomNumberOption(true, num++, MultiMenu.main, "Player Speed", 1f, 0.25f, 10f, 0.25f, MultiplierFormat);
            GhostSpeed = new CustomNumberOption(true, num++, MultiMenu.main, "Ghost Speed", 1f, 0.25f, 10f, 0.25f, MultiplierFormat);
            InteractionDistance = new CustomNumberOption(true, num++, MultiMenu.main, "Interaction Distance", 1f, 0.25f, 10f, 0.25f, MultiplierFormat);
            EmergencyButtonCount = new CustomNumberOption(true, num++, MultiMenu.main, "Emergency Count", 1, 0, 100, 1);
            EmergencyButtonCooldown = new CustomNumberOption(true, num++, MultiMenu.main, "Emergency Button Cooldown", 20f, 0f, 300f, 5f, CooldownFormat);
            DiscussionTime = new CustomNumberOption(true, num++, MultiMenu.main, "Discussion Time", 30f, 0f, 300f, 15f, CooldownFormat);
            VotingTime = new CustomNumberOption(true, num++, MultiMenu.main, "Voting Time", 60f, 5f, 600f, 15f, CooldownFormat);
            LobbySize = new CustomNumberOption(true, num++, MultiMenu.main, "Lobby Size", 15, 4, 127, 1);
            TaskBarMode = new CustomStringOption(true, num++, MultiMenu.main, "Taskbar Updates", new[] {"Normal", "Meeting Only", "Invisible"});
            ConfirmEjects = new CustomToggleOption(true, num++, MultiMenu.main, "Confirm Ejects", false);
            EjectionRevealsRole = new CustomToggleOption(true, num++, MultiMenu.main, "Ejection Reveals Roles", false);
            InitialCooldowns = new CustomNumberOption(true, num++, MultiMenu.main, "Game Start Cooldowns", 10f, 10f, 30f, 2.5f, CooldownFormat);

            GameModifiers = new CustomHeaderOption(num++, MultiMenu.main, "Game Modifiers");
            ColourblindComms = new CustomToggleOption(true, num++, MultiMenu.main, "Camouflaged Comms", true);
            MeetingColourblind = new CustomToggleOption(true, num++, MultiMenu.main, "Camouflaged Meetings", false);
            WhoCanVent = new CustomStringOption(true, num++, MultiMenu.main, "Serial Venters", new[] {"Default", "Everyone", "No One" });
            ParallelMedScans = new CustomToggleOption(true, num++, MultiMenu.main, "Parallel Medbay Scans", false);
            AnonymousVoting = new CustomToggleOption(true, num++, MultiMenu.main, "Anonymous Voting", false);
            SkipButtonDisable = new CustomStringOption(true, num++, MultiMenu.main, "No Skipping", new[] {"Never", "Emergency", "Always"});
            NoSolo = new CustomStringOption(true, num++, MultiMenu.main, "Neutrals Together, Strong", new[] {"Never", "Same Roles", "All NKs", "All Neutrals"});
            FactionSeeRoles = new CustomToggleOption(true, num++, MultiMenu.main, "Factioned Evils See The Roles Of Their Team", false);
            VisualTasks = new CustomToggleOption(true, num++, MultiMenu.main, "Visual Tasks", false);
            LocationReports = new CustomToggleOption(true, num++, MultiMenu.main, "Body Reports Now Display The Body's Location", false);

            QualityChanges = new CustomHeaderOption(num++, MultiMenu.main, "Quality Additions");
            DeadSeeEverything = new CustomToggleOption(true, num++, MultiMenu.main, "Dead Can See Everyone's Roles & Votes", false);
            LighterDarker = new CustomToggleOption(true, num++, MultiMenu.main, "Enable Lighter Darker Colors", false);
            PlayerNumbers = new CustomToggleOption(true, num++, MultiMenu.main, "Enable Player Numbers", false);
            DisableLevels = new CustomToggleOption(true, num++, MultiMenu.main, "Disable Level Icons", false);
            WhiteNameplates = new CustomToggleOption(true, num++, MultiMenu.main, "Disable Player Nameplates", false);
            SeeTasks = new CustomToggleOption(true, num++, MultiMenu.main, "See Tasks During The Game", false);
            AppearanceAnimation = new CustomToggleOption(true, num++, MultiMenu.main, "Kill Animations Show Morphed Player", true);
            CustomEject = new CustomToggleOption(true, num++, MultiMenu.main, "Custom Ejection Messages", false);

            GameModeSettings = new CustomHeaderOption(num++, MultiMenu.main, "Game Mode Settings");
            GameMode = new CustomStringOption(true, num++, MultiMenu.main, "Game Mode", new[] {"Classic", "All Any", "Killing Only", "Custom"});

            KillingOnlySettings = new CustomHeaderOption(num++, MultiMenu.main, "<color=#1D7CF2FF>Killing</color> Only Mode Settings");
            NeutralRoles = new CustomNumberOption(true, num++, MultiMenu.main, "<color=#B3B3B3FF>Neutral</color> Count", 1f, 0f, 5f, 1f);
            AddArsonist = new CustomToggleOption(true, num++, MultiMenu.main, "Add <color=#EE7600FF>Arsonist</color>", true);
            AddCryomaniac = new CustomToggleOption(true, num++, MultiMenu.main, "Add <color=#642DEAFF>Cryomaniac</color>", true);
            AddPlaguebearer = new CustomToggleOption(true, num++, MultiMenu.main, "Add <color=#CFFE61FF>Plaguebearer</color>", true);

            ClassicSettings = new CustomHeaderOption(num++, MultiMenu.main, "Classic And Custom Mode Settings");
            MinNeutralNonKillingRoles = new CustomNumberOption(true, num++, MultiMenu.main, "Min <color=#B3B3B3FF>Neutral</color> Non-<color=#1D7CF2FF>Killings</color>", 1f, 0f, 13f, 1f);
            MaxNeutralNonKillingRoles = new CustomNumberOption(true, num++, MultiMenu.main, "Max <color=#B3B3B3FF>Neutral</color> Non-<color=#1D7CF2FF>Killings</color>", 1f, 0f, 13f, 1f);
            MinNeutralKillingRoles = new CustomNumberOption(true, num++, MultiMenu.main, "Min <color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Killings</color>", 1f, 0f, 13f, 1f);
            MaxNeutralKillingRoles = new CustomNumberOption(true, num++, MultiMenu.main, "Max <color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Killings</color>", 1f, 0f, 13f, 1f);

            MapSettings = new CustomHeaderOption(num++, MultiMenu.main, "Map Settings");
            Map = new CustomStringOption(true, num++, MultiMenu.main, "Map", new[] {"Skeld", "Mira HQ", "Polus", "Airship", "Submerged"});
            RandomMapEnabled = new CustomToggleOption(true, num++, MultiMenu.main, "Choose Random Map", false);
            RandomMapSkeld = new CustomNumberOption(true, num++, MultiMenu.main, "Skeld Chance", 0f, 0f, 100f, 10f, PercentFormat);
            RandomMapMira = new CustomNumberOption(true, num++, MultiMenu.main, "Mira Chance", 0f, 0f, 100f, 10f, PercentFormat);
            RandomMapPolus = new CustomNumberOption(true, num++, MultiMenu.main, "Polus Chance", 0f, 0f, 100f, 10f, PercentFormat);
            RandomMapAirship = new CustomNumberOption(true, num++, MultiMenu.main, "Airship Chance", 0f, 0f, 100f, 10f, PercentFormat);
            RandomMapSubmerged = new CustomNumberOption(true, num++, MultiMenu.main, "Submerged Chance", 0f, 0f, 100f, 10f, PercentFormat);
            AutoAdjustSettings = new CustomToggleOption(true, num++, MultiMenu.main, "Auto Adjust Settings", false);
            SmallMapHalfVision = new CustomToggleOption(true, num++, MultiMenu.main, "Half Vision On Skeld/Mira HQ", false);
            SmallMapDecreasedCooldown = new CustomNumberOption(true, num++, MultiMenu.main, "Mira HQ Decreased Cooldowns", 0f, 0f, 15f, 2.5f, CooldownFormat);
            LargeMapIncreasedCooldown = new CustomNumberOption(true, num++, MultiMenu.main, "Airship/Submerged Increased Cooldowns", 0f, 0f, 15f, 2.5f, CooldownFormat);
            SmallMapIncreasedShortTasks = new CustomNumberOption(true, num++, MultiMenu.main, "Skeld/Mira HQ Increased Short Tasks", 0, 0, 5, 1);
            SmallMapIncreasedLongTasks = new CustomNumberOption(true, num++, MultiMenu.main, "Skeld/Mira HQ Increased Long Tasks", 0, 0, 3, 1);
            LargeMapDecreasedShortTasks = new CustomNumberOption(true, num++, MultiMenu.main, "Airship/Submerged Decreased Short Tasks", 0, 0, 5, 1);
            LargeMapDecreasedLongTasks = new CustomNumberOption(true, num++, MultiMenu.main, "Airship/Submerged Decreased Long Tasks", 0, 0, 3, 1);

            BetterPolusSettings = new CustomHeaderOption(num++, MultiMenu.main, "Better Polus Settings");
            VentImprovements = new CustomToggleOption(true, num++, MultiMenu.main, "Better Polus Vent Layout", false);
            VitalsLab = new CustomToggleOption(true, num++, MultiMenu.main, "Vitals Moved To Lab", false);
            ColdTempDeathValley = new CustomToggleOption(true, num++, MultiMenu.main, "Cold Temp Moved To Death Valley", false);
            WifiChartCourseSwap = new CustomToggleOption(true, num++, MultiMenu.main, "Reboot Wifi And Chart Course Swapped", false);

            CrewAuditorRoles = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Auditor</color> <color=#FFD700FF>Roles</color>");
            VampireHunterOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#C0C0C0FF>Vampire Hunter</color>", 0f, 0f, 100f, 10f, PercentFormat);

            CrewInvestigativeRoles = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Investigative</color> <color=#FFD700FF>Roles</color>");
            AgentOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#CCA3CCFF>Agent</color>", 0f, 0f, 100f, 10f, PercentFormat);
            CoronerOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#4D99E6FF>Coroner</color>", 0f, 0f, 100f, 10f, PercentFormat);
            DetectiveOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#4D4DFFFF>Detective</color>", 0f, 0f, 100f, 10f, PercentFormat);
            InvestigatorOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#00B3B3FF>Investigator</color>", 0f, 0f, 100f, 10f, PercentFormat);
            InspectorOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#7E3C64FF>Inspector</color>", 0f, 0f, 100f, 10f, PercentFormat);
            MediumOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#A680FFFF>Medium</color>", 0f, 0f, 100f, 10f, PercentFormat);
            OperativeOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#A7D1B3FF>Operative</color>", 0f, 0f, 100f, 10f, PercentFormat);
            SheriffOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#FFCC80FF>Sheriff</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TrackerOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#009900FF>Tracker</color>", 0f, 0f, 100f, 10f, PercentFormat);

            CrewKillingRoles = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Killing</color> <color=#FFD700FF>Roles</color>");
            VeteranOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#998040FF>Veteran</color>", 0f, 0f, 100f, 10f, PercentFormat);
            VigilanteOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#FFFF00FF>Vigilante</color>", 0f, 0f, 100f, 10f, PercentFormat);

            CrewProtectiveRoles = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Protective</color> <color=#FFD700FF>Roles</color>");
            AltruistOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#660000FF>Altruist</color>", 0f, 0f, 100f, 10f, PercentFormat);
            MedicOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#006600FF>Medic</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TimeLordOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#0000FFFF>Time Lord</color>", 0f, 0f, 100f, 10f, PercentFormat);

            CrewSovereignRoles = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Sovereign</color> <color=#FFD700FF>Roles</color>");
            MayorOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#704FA8FF>Mayor</color>", 0f, 0f, 100f, 10f, PercentFormat);
            SwapperOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#66E666FF>Swapper</color>", 0f, 0f, 100f, 10f, PercentFormat);

            CrewSupportRoles = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Support</color> <color=#FFD700FF>Roles</color>");
            EngineerOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#FFA60AFF>Engineer</color>", 0f, 0f, 100f, 10f, PercentFormat);
            EscortOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#803333FF>Escort</color>", 0f, 0f, 100f, 10f, PercentFormat);
            ShifterOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#DF851FFF>Shifter</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TransporterOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#00EEFFFF>Transporter</color>", 0f, 0f, 100f, 10f, PercentFormat);

            CrewUtilityRoles = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Utility</color> <color=#FFD700FF>Roles</color>");
            CrewmateOn = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#8BFDFDFF>Crewmate</color>", 0f, 0f, 100f, 10f, PercentFormat);

            NeutralBenignRoles = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Benign</color> <color=#FFD700FF>Roles</color>");
            AmnesiacOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#22FFFFFF>Amnesiac</color>", 0f, 0f, 100f, 10f, PercentFormat);
            GuardianAngelOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#FFFFFFFF>Guardian Angel</color>", 0f, 0f, 100f, 10f, PercentFormat);
            SurvivorOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#DDDD00FF>Survivor</color>", 0f, 0f, 100f, 10f, PercentFormat);
            ThiefOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#80FF00FF>Thief</color>", 0f, 0f, 100f, 10f, PercentFormat);

            NeutralEvilRoles = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Evil</color> <color=#FFD700FF>Roles</color>");
            CannibalOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#8C4005FF>Cannibal</color>", 0f, 0f, 100f, 10f, PercentFormat);
            ExecutionerOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color>", 0f, 0f, 100f, 10f, PercentFormat);
            JesterOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#F7B3DAFF>Jester</color>", 0f, 0f, 100f, 10f, PercentFormat);
            //PirateOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#EDC240FF>Pirate</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TrollOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#678D36FF>Troll</color>", 0f, 0f, 100f, 10f, PercentFormat);

            NeutralKillingRoles = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Killing</color> <color=#FFD700FF>Roles</color>");
            ArsonistOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#EE7600FF>Arsonist</color>", 0f, 0f, 100f, 10f, PercentFormat);
            CryomaniacOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#642DEAFF>Cryomaniac</color>", 0f, 0f, 100f, 10f, PercentFormat);
            GlitchOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#00FF00FF>Glitch</color>", 0f, 0f, 100f, 10f, PercentFormat);
            JuggernautOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#A12B56FF>Juggernaut</color>", 0f, 0f, 100f, 10f, PercentFormat);
            MurdererOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#6F7BEAFF>Murderer</color>", 0f, 0f, 100f, 10f, PercentFormat);
            PlaguebearerOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#CFFE61FF>Plaguebearer</color>", 0f, 0f, 100f, 10f, PercentFormat);
            SerialKillerOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#336EFFFF>Serial Killer</color>", 0f, 0f, 100f, 10f, PercentFormat);
            WerewolfOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#9F703AFF>Werewolf</color>", 0f, 0f, 100f, 10f, PercentFormat);

            NeutralNeophyteRoles = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Neophyte</color> <color=#FFD700FF>Roles</color>");
            DraculaOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#AC8A00FF>Dracula</color>", 0f, 0f, 100f, 10f, PercentFormat);
            JackalOn = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#45076AFF>Jackal</color>", 0f, 0f, 100f, 10f, PercentFormat);

            IntruderConcealingRoles = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> <color=#1D7CF2FF>Concealing</color> <color=#FFD700FF>Roles</color>");
            BlackmailerOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#02A752FF>Blackmailer</color>", 0f, 0f, 100f, 10f, PercentFormat);
            CamouflagerOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#378AC0FF>Camouflager</color>", 0f, 0f, 100f, 10f, PercentFormat);
            GrenadierOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#85AA5BFF>Grenadier</color>", 0f, 0f, 100f, 10f, PercentFormat);
            JanitorOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#2647A2FF>Janitor</color>", 0f, 0f, 100f, 10f, PercentFormat);
            UndertakerOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#005643FF>Undertaker</color>", 0f, 0f, 100f, 10f, PercentFormat);

            IntruderDeceptionRoles = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> <color=#1D7CF2FF>Deception</color> <color=#FFD700FF>Roles</color>");
            DisguiserOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#40B4FFFF>Disguiser</color>", 0f, 0f, 100f, 10f, PercentFormat);
            MorphlingOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#BB45B0FF>Morphling</color>", 0f, 0f, 100f, 10f, PercentFormat);
            PoisonerOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#B5004CFF>Poisoner</color>", 0f, 0f, 100f, 10f, PercentFormat);
            WraithOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#FFB875FF>Wraith</color>", 0f, 0f, 100f, 10f, PercentFormat);

            //IntruderKillingRoles = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> <color=#1D7CF2FF>Killing</color> <color=#FFD700FF>Roles</color>");

            IntruderSupportRoles = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> <color=#1D7CF2FF>Support</color> <color=#FFD700FF>Roles</color>");
            ConsigliereOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#FFFF99FF>Consigliere</color>", 0f, 0f, 100f, 10f, PercentFormat);
            ConsortOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#801780FF>Consort</color>", 0f, 0f, 100f, 10f, PercentFormat);
            GodfatherOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#404C08FF>Godfather</color>", 0f, 0f, 100f, 10f, PercentFormat);
            MinerOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#AA7632FF>Miner</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TeleporterOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#6AA84FFF>Teleporter</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TimeMasterOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#0000A7FF>Time Master</color>", 0f, 0f, 100f, 10f, PercentFormat);

            IntruderUtilityRoles = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> <color=#1D7CF2FF>Utility</color> <color=#FFD700FF>Roles</color>");
            ImpostorOn = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#FF0000FF>Impostor</color>", 0f, 0f, 100f, 10f, PercentFormat);

            SyndicateDisruptionRoles = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> <color=#1D7CF2FF>Disruption</color> <color=#FFD700FF>Roles</color>");
            PuppeteerOn = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#00FFFFFF>Puppeteer</color>", 0f, 0f, 100f, 10f, PercentFormat);
            ShapeshifterOn = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#311C45FF>Shapeshifter</color>", 0f, 0f, 100f, 10f, PercentFormat);

            SyndicateKillingRoles = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> <color=#1D7CF2FF>Killing</color> <color=#FFD700FF>Roles</color>");
            GorgonOn = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#7E4D00FF>Gorgon</color>", 0f, 0f, 100f, 10f, PercentFormat);

            SyndicateSupportRoles = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> <color=#1D7CF2FF>Support</color> <color=#FFD700FF>Roles</color>");
            ConcealerOn = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#C02525FF>Concealer</color>", 0f, 0f, 100f, 10f, PercentFormat);
            RebelOn = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#FFFCCEFF>Rebel</color>", 0f, 0f, 100f, 10f, PercentFormat);
            WarperOn = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#8C7140FF>Warper</color>", 0f, 0f, 100f, 10f, PercentFormat);

            SyndicateUtilityRoles = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> <color=#1D7CF2FF>Utility</color> <color=#FFD700FF>Roles</color>");
            AnarchistOn = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#008000FF>Anarchist</color>", 0f, 0f, 100f, 10f, PercentFormat);

            Modifiers = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#7F7F7FFF>Modifiers</color>");
            BaitOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#00B3B3FF>Bait</color>", 0f, 0f, 100f, 10f, PercentFormat);
            CowardOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#456BA8FF>Coward</color>", 0f, 0f, 100f, 10f, PercentFormat);
            DiseasedOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#374D1EFF>Diseased</color>", 0f, 0f, 100f, 10f, PercentFormat);
            DrunkOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#758000FF>Drunk</color>", 0f, 0f, 100f, 10f, PercentFormat);
            DwarfOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FF8080FF>Dwarf</color>", 0f, 0f, 100f, 10f, PercentFormat);
            FlincherOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#80B3FFFF>Flincher</color>", 0f, 0f, 100f, 10f, PercentFormat);
            GiantOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FFB34DFF>Giant</color>", 0f, 0f, 100f, 10f, PercentFormat);
            ProfessionalOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#860B7AFF>Professional</color>", 0f, 0f, 100f, 10f, PercentFormat);
            ShyOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#1002C5FF>Shy</color>", 0f, 0f, 100f, 10f, PercentFormat);
            VIPOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#DCEE85FF>VIP</color>", 0f, 0f, 100f, 10f, PercentFormat);
            VolatileOn = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FFA60AFF>Volatile</color>", 0f, 0f, 100f, 10f, PercentFormat);

            Abilities = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#FF9900FF>Abilities</color>");
            AssassinOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#073763FF>Assassin</color>", 0f, 0f, 100f, 10f, PercentFormat);
            ButtonBarryOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#E600FFFF>Button Barry</color>", 0f, 0f, 100f, 10f, PercentFormat);
            InsiderOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#26FCFBFF>Insider</color>", 0f, 0f, 100f, 10f, PercentFormat);
            LighterOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#1AFF74FF>Lighter</color>", 0f, 0f, 100f, 10f, PercentFormat);
            MultitaskerOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#FF804DFF>Multitasker</color>", 0f, 0f, 100f, 10f, PercentFormat);
            RadarOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#FF0080FF>Radar</color>", 0f, 0f, 100f, 10f, PercentFormat);
            RevealerOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#D3D3D3FF>Revealer</color>", 0f, 0f, 100f, 10f, PercentFormat);
            SnitchOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#D4AF37FF>Snitch</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TiebreakerOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#99E699FF>Tiebreaker</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TorchOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#FFFF99FF>Torch</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TunnelerOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#E91E63FF>Tunneler</color>", 0f, 0f, 100f, 10f, PercentFormat);
            UnderdogOn = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#841A7FFF>Underdog</color>", 0f, 0f, 100f, 10f, PercentFormat);

            Objectifiers = new CustomHeaderOption(num++, MultiMenu.objectifier, "<color=#DD585BFF>Objectifiers</color>");
            FanaticOn = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#678D36FF>Fanatic</color>", 0f, 0f, 100f, 10f, PercentFormat);
            LoversOn = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#FF66CCFF>Lovers</color>", 0f, 0f, 100f, 10f, PercentFormat);
            PhantomOn = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#662962FF>Phantom</color>", 0f, 0f, 100f, 10f, PercentFormat);
            RivalsOn = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#3D2D2CFF>Rivals</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TaskmasterOn = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#ABABFFFF>Taskmaster</color>", 0f, 0f, 100f, 10f, PercentFormat);
            TraitorOn = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#370D43FF>Traitor</color>", 0f, 0f, 100f, 10f, PercentFormat);

            CrewSettings = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> Settings");
            CustomCrewColors = new CustomToggleOption(true, num++, MultiMenu.crew, "Enable Custom <color=#8BFDFDFF>Crew</color> Colors", true);
            ShortTasks = new CustomNumberOption(true, num++, MultiMenu.crew, "Short Task Count", 1f, 0f, 100f, 10f);
            LongTasks = new CustomNumberOption(true, num++, MultiMenu.crew, "Long Task Count", 1f, 0f, 100f, 10f);
            CommonTasks = new CustomNumberOption(true, num++, MultiMenu.crew, "Common Task Count", 1f, 0f, 100f, 10f);
            GhostTasksCountToWin = new CustomToggleOption(true, num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> Ghost Tasks Count To Win", true);
            CrewVision = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> Vision", 1f, 0.25f, 5f, 0.25f, MultiplierFormat);

            CrewAuditorSettings = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Auditor</color> Settings");

            VampireHunter = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#C0C0C0FF>Vampire Hunter</color>");
            VampireHunterCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#C0C0C0FF>Vampire Hunter</color> Count", 1, 1, 14, 1);
            StakeCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Stake Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);

            CrewInvestigativeSettings = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Investigative</color> Settings");

            Agent = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#CCA3CCFF>Agent</color>");
            AgentCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#CCA3CCFF>Agent</color> Count", 1, 1, 14, 1);

            Detective = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#4D4DFFFF>Detective</color>");
            DetectiveCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#4D4DFFFF>Detective</color> Count", 1, 1, 14, 1);
            InitialExamineCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Initial Examine Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            ExamineCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Examine Cooldown", 10f, 1f, 15f, 1f, CooldownFormat);
            RecentKill = new CustomNumberOption(true, num++, MultiMenu.crew, "Bloody Player Duration", 25f, 10f, 60f, 2.5f, CooldownFormat);

            Inspector = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#7E3C64FF>Inspector</color>");
            InspectorCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#7E3C64FF>Inspector</color> Count", 1, 1, 14, 1);
            InspectCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Inspect Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);

            Investigator = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#00B3B3FF>Investigator</color>");
            InvestigatorCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#00B3B3FF>Investigator</color> Count", 1, 1, 14, 1);
            FootprintSize = new CustomNumberOption(true, num++, MultiMenu.crew, "Footprint Size", 4f, 1f, 10f, 1f);
            FootprintInterval = new CustomNumberOption(true, num++, MultiMenu.crew, "Footprint Interval", 0.1f, 0.05f, 1f, 0.05f, CooldownFormat);
            FootprintDuration = new CustomNumberOption(true, num++, MultiMenu.crew, "Footprint Duration", 10f, 1f, 10f, 0.5f, CooldownFormat);
            AnonymousFootPrint = new CustomToggleOption(true, num++, MultiMenu.crew, "Anonymous Footprint", false);
            VentFootprintVisible = new CustomToggleOption(true, num++, MultiMenu.crew, "Footprint Vent Visible", false);

            Medium = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#A680FFFF>Medium</color>");
            MediumCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#A680FFFF>Medium</color> Count", 1, 1, 14, 1);
            MediateCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Mediate Cooldown", 10f, 1f, 15f, 1f, CooldownFormat);
            ShowMediatePlayer = new CustomToggleOption(true, num++, MultiMenu.crew, "Reveal Appearance Of Mediate Target", true);
            ShowMediumToDead = new CustomToggleOption(true, num++, MultiMenu.crew, "Reveal The <color=#A680FFFF>Medium</color> To The Mediate Target", true);
            DeadRevealed = new CustomStringOption(true, num++, MultiMenu.crew, "Who Is Revealed With Mediate", new[] {"Oldest Dead", "Newest Dead", "All Dead"});

            Coroner = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#4D99E6FF>Coroner</color>");
            CoronerCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#4D99E6FF>Coroner</color> Count", 1, 1, 14, 1);
            CoronerArrowDuration = new CustomNumberOption(true, num++, MultiMenu.crew, "Dead Body Arrow Duration", 0.1f, 0f, 2f, 0.05f, CooldownFormat);
            CoronerReportRole = new CustomToggleOption(true, num++, MultiMenu.crew, "<color=#4D99E6FF>Coroner</color> Gets Killer's Role", false);
            CoronerReportName = new CustomToggleOption(true, num++, MultiMenu.crew, "<color=#4D99E6FF>Coroner</color> Gets Killer's Name", false);

            Sheriff = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#FFCC80FF>Sheriff</color>");
            SheriffCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#FFCC80FF>Sheriff</color> Count", 1, 1, 14, 1);
            InterrogateCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Interrogate Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            NeutEvilRed = new CustomToggleOption(true, num++, MultiMenu.crew, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Evils</color> Show Evil", false);
            NeutKillingRed = new CustomToggleOption(true, num++, MultiMenu.crew, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Killings</color> Show Evil", false);
            InterrogatePer = new CustomStringOption(true, num++, MultiMenu.crew, "<color=#FFCC80FF>Sheriff</color> Reveals Per", new[] {"Round", "Game"});
            TraitorColourSwap = new CustomToggleOption(true, num++, MultiMenu.crew, "<color=#370D43FF>Traitor</color> Does Not Swap Colours", false);

            Tracker = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#009900FF>Tracker</color>");
            TrackerCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#009900FF>Tracker</color> Count", 1, 1, 14, 1);
            UpdateInterval = new CustomNumberOption(true, num++, MultiMenu.crew, "Arrow Update Interval", 5f, 0.5f, 15f, 0.5f, CooldownFormat);
            TrackCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Track Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            ResetOnNewRound = new CustomToggleOption(true, num++, MultiMenu.crew, "<color=#009900FF>Tracker</color> Arrows Reset After Each Round", false);
            MaxTracks = new CustomNumberOption(true, num++, MultiMenu.crew, "Track Count Per Round", 5, 1, 15, 1);

            Operative = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#A7D1B3FF>Operative</color>");
            OperativeCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#A7D1B3FF>Operative</color> Count", 1, 1, 14, 1);
            MinAmountOfTimeInBug = new CustomNumberOption(true, num++, MultiMenu.crew, "Min Amount Of Time In Bug To Register", 1f, 0f, 15f, 0.5f, CooldownFormat);
            BugCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Bug Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            BugsRemoveOnNewRound = new CustomToggleOption(true, num++, MultiMenu.crew, "Bugs Are Removed Each Round", true);
            MaxBugs = new CustomNumberOption(true, num++, MultiMenu.crew, "Bug Count", 5, 1, 15, 1);
            BugRange = new CustomNumberOption(true, num++, MultiMenu.crew, "Bug Range", 1f, 0.5f, 5f, 0.5f, MultiplierFormat);
            MinAmountOfPlayersInBug = new CustomNumberOption(true, num++, MultiMenu.crew, "Number Of Roles Required To Trigger Bug", 3, 1, 5, 1);

            CrewKillingSettings = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Killing</color> Settings");

            Veteran = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#998040FF>Veteran</color>");
            VeteranCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#998040FF>Veteran</color> Count", 1, 1, 14, 1);
            AlertCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Alert Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            AlertDuration = new CustomNumberOption(true, num++, MultiMenu.crew, "Alert Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            MaxAlerts = new CustomNumberOption(true, num++, MultiMenu.crew, "Number Of Alerts", 5, 1, 15, 1);

            Vigilante = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#FFFF00FF>Vigilante</color>");
            VigilanteCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#FFFF00FF>Vigilante</color> Count", 1, 1, 14, 1);
            VigiOptions = new CustomStringOption(true, num++, MultiMenu.crew, "How Does <color=#FFFF00FF>Vigilante</color> Die", new[] {"Immediately", "Pre-Meeting", "Post-Meeting"});
            VigiKnowsInno = new CustomToggleOption(true, num++, MultiMenu.crew, "<color=#FFFF00FF>Vigilante</color> Knows Target Was Innocent", false);
            VigiKillCd = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#FFFF00FF>Vigilante</color> Kill Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);

            CrewProtectiveSettings = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Protective</color> Settings");

            Altruist = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#660000FF>Altruist</color>");
            AltruistCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#660000FF>Altruist</color> Count", 1, 1, 14, 1);
            ReviveDuration = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#660000FF>Altruist</color> Revive Duration", 10f, 1f, 15f, 1f, CooldownFormat);
            AltruistTargetBody = new CustomToggleOption(true, num++, MultiMenu.crew, "Target's Body Disappears On Beginning Of Revive", false);

            Medic = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#006600FF>Medic</color>");
            MedicCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#006600FF>Medic</color> Count", 1, 1, 14, 1);
            ShowShielded = new CustomStringOption(true, num++, MultiMenu.crew, "Show Shielded Player", new[] {"Self", "Medic", "Self+Medic", "Everyone"});
            WhoGetsNotification = new CustomStringOption(true, num++, MultiMenu.crew, "Who Gets Murder Attempt Indicator", new[] {"Medic", "Shielded", "Everyone", "Nobody"});
            ShieldBreaks = new CustomToggleOption(true, num++, MultiMenu.crew, "Shield Breaks On Murder Attempt", false);

            TimeLord = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#0000FFFF>Time Lord</color>");
            TimeLordCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#0000FFFF>Time Lord</color> Count", 1, 1, 14, 1);
            RewindRevive = new CustomToggleOption(true, num++, MultiMenu.crew, "Revive During Rewind", false);
            TLImmunity = new CustomToggleOption(true, num++, MultiMenu.crew, "<color=#0000FFFF>Time Lord</color> Immunity", false);
            RewindDuration = new CustomNumberOption(true, num++, MultiMenu.crew, "Rewind Duration", 2f, 2f, 5f, 0.5f, CooldownFormat);
            RewindCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Rewind Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            RewindMaxUses = new CustomNumberOption(true, num++, MultiMenu.crew, "Maximum Number Of Rewinds", 5, 1, 15, 1);

            CrewSovereignSettings = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Sovereign</color> Settings");

            Mayor = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#704FA8FF>Mayor</color>");
            MayorCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#704FA8FF>Mayor</color> Count", 1, 1, 14, 1);
            MayorVoteBank = new CustomNumberOption(true, num++, MultiMenu.crew, "Initial <color=#704FA8FF>Mayor</color> Vote Bank", 1, 1, 5, 1);
            MayorAnonymous = new CustomToggleOption(true, num++, MultiMenu.crew, "Anonymous <color=#704FA8FF>Mayor</color> Votes", false);

            Swapper = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#66E666FF>Swapper</color>");
            SwapperCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#66E666FF>Swapper</color> Count", 1, 1, 14, 1);
            SwapperButton = new CustomToggleOption(true, num++, MultiMenu.crew, "<color=#66E666FF>Swapper</color> Can Button", true);

            CrewSupportSettings = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Support</color> Settings");

            Engineer = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#FFA60AFF>Engineer</color>");
            EngineerCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#FFA60AFF>Engineer</color> Count", 1, 1, 14, 1);
            EngineerPer = new CustomStringOption(true, num++, MultiMenu.crew, "<color=#FFA60AFF>Engineer</color> Fixes Once Per", new[] {"Round", "Game"});

            Escort = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#803333FF>Escort</color>");
            EscortCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#803333FF>Escort</color> Count", 1, 1, 14, 1);
            EscRoleblockCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Roleblock Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            EscRoleblockDuration = new CustomNumberOption(true, num++, MultiMenu.crew, "Roleblock Duration", 25f, 10f, 60f, 2.5f, CooldownFormat);

            Shifter = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#DF851FFF>Shifter</color>");
            ShifterCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#DF851FFF>Shifter</color> Count", 1, 1, 14, 1);
            ShifterCd = new CustomNumberOption(true, num++, MultiMenu.crew, "Shift Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            ShiftedBecomes = new CustomStringOption(true, num++, MultiMenu.crew, "Shifted Becomes", new[] {"Shifter", "Crewmate"});

            Transporter = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#00EEFFFF>Transporter</color>");
            TransporterCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#00EEFFFF>Transporter</color> Count", 1, 1, 14, 1);
            TransportCooldown = new CustomNumberOption(true, num++, MultiMenu.crew, "Transport Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            TransportMaxUses = new CustomNumberOption(true, num++, MultiMenu.crew, " Number Of Transports", 5, 1, 15, 1);

            CrewUtilitySettings = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crew</color> <color=#1D7CF2FF>Utility</color> Settings");

            Crewmate = new CustomHeaderOption(num++, MultiMenu.crew, "<color=#8BFDFDFF>Crewmate</color>");
            CrewCount = new CustomNumberOption(true, num++, MultiMenu.crew, "<color=#8BFDFDFF>Crewmate</color> Count", 1, 1, 14, 1);

            NeutralSettings = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> Settings");
            CustomNeutColors = new CustomToggleOption(true, num++, MultiMenu.neutral, "Enable Custom <color=#B3B3B3FF>Neutral</color> Colors", true);
            NeutralVision = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> Vision", 1f, 0.25f, 5f, 0.25f, MultiplierFormat);
            LightsAffectNeutrals = new CustomToggleOption(true, num++, MultiMenu.neutral, "Lights Sabotage Affects <color=#B3B3B3FF>Neutral</color> Vision", true);

            NeutralBenignSettings = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Benign</color> Settings");
            VigiKillsNB = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#FFFF00FF>Vigilante</color> Kills <color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Benigns</color>", false);

            Amnesiac = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#22FFFFFF>Amnesiac</color>");
            AmnesiacCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#22FFFFFF>Amnesiac</color> Count", 1, 1, 14, 1);
            RememberArrows = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#22FFFFFF>Amnesiac</color> Gets Arrows To Dead Bodies", false);
            RememberArrowDelay = new CustomNumberOption(true, num++, MultiMenu.neutral, "Time After Death Arrow Appears", 5f, 0f, 15f, 1f, CooldownFormat);
            AmneVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#22FFFFFF>Amnesiac</color> Can Hide In Vents", false);
            AmneSwitchVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#22FFFFFF>Amnesiac</color> Can Switch Vents", false);
            AmneTurnAssassin = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#22FFFFFF>Amnesiac</color> Gets Ability", false);

            GuardianAngel = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#FFFFFFFF>Guardian Angel</color>");
            GuardianAngelCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#FFFFFFFF>Guardian Angel</color> Count", 1, 1, 14, 1);
            ProtectCd = new CustomNumberOption(true, num++, MultiMenu.neutral, "Protect Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            ProtectDuration = new CustomNumberOption(true, num++, MultiMenu.neutral, "Protect Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            ProtectKCReset = new CustomNumberOption(true, num++, MultiMenu.neutral, "Kill Cooldown Reset When Protected", 2.5f, 0f, 15f, 0.5f, CooldownFormat);
            MaxProtects = new CustomNumberOption(true, num++, MultiMenu.neutral, "Maximum Number Of Protects", 5, 1, 15, 1);
            ShowProtect = new CustomStringOption(true, num++, MultiMenu.neutral, "Show Protected Player", new[] {"Self", "Guardian Angel", "Self+GA", "Everyone"});
            GaOnTargetDeath = new CustomStringOption(true, num++, MultiMenu.neutral, "<color=#FFFFFFFF>Guardian Angel</color> Becomes On Target Dead", new[]{"Crewmate", "Amnesiac", "Survivor", "Jester"});
            GATargetKnows = new CustomToggleOption(true, num++, MultiMenu.neutral, "Target Knows <color=#FFFFFFFF>Guardian Angel</color> Exists", false);
            ProtectBeyondTheGrave = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#FFFFFFFF>Guardian Angel</color> Can Protect After Death", false);
            GAKnowsTargetRole = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#FFFFFFFF>Guardian Angel</color> Knows Target's Role", false);
            GAVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#FFFFFFFF>Guardian Angel</color> Can Hide In Vents", false);
            GASwitchVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#FFFFFFFF>Guardian Angel</color> Can Switch Vents", false);

            Survivor = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#DDDD00FF>Survivor</color>");
            SurvivorCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#DDDD00FF>Survivor</color> Count", 1, 1, 14, 1);
            VestCd = new CustomNumberOption(true, num++, MultiMenu.neutral, "Vest Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            VestDuration = new CustomNumberOption(true, num++, MultiMenu.neutral, "Vest Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            VestKCReset = new CustomNumberOption(true, num++, MultiMenu.neutral, "Kill Cooldown Reset On Attack", 2.5f, 0f, 15f, 0.5f, CooldownFormat);
            MaxVests = new CustomNumberOption(true, num++, MultiMenu.neutral, "Number Of Vests", 5, 1, 15, 1);
            SurvVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#DDDD00FF>Survivor</color> Can Hide In Vents", false);
            SurvSwitchVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#DDDD00FF>Survivor</color> Can Switch Vents", false);

            Thief = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#80FF00FF>Thief</color>");
            ThiefCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#80FF00FF>Thief</color> Count", 1, 1, 14, 1);
            ThiefKillCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Kill Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            ThiefVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#80FF00FF>Thief</color> Can Vent", false);

            NeutralEvilSettings = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Evil</color> Settings");

            Cannibal = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#8C4005FF>Cannibal</color>"); 
            CannibalCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#8C4005FF>Cannibal</color> Count", 1, 1, 14, 1);
            CannibalCd = new CustomNumberOption(true, num++, MultiMenu.neutral, "Eat Cooldown", 10f, 10f, 60f, 2.5f, CooldownFormat);
            CannibalBodyCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "Number Of Bodies To Eat", 1, 1, 5, 1);
            CannibalVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#8C4005FF>Cannibal</color> Can Vent", false);
            EatArrows = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#8C4005FF>Cannibal</color> Gets Arrows To Dead Bodies", false);
            EatArrowDelay = new CustomNumberOption(true, num++, MultiMenu.neutral, "Time After Death Arrow Appears", 5f, 0f, 15f, 1f, CooldownFormat);
            VigiKillsCannibal = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#FFFF00FF>Vigilante</color> Kills <color=#8C4005FF>Cannibal</color>", false);

            Executioner = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color>");
            ExecutionerCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Count", 1, 1, 14, 1);
            OnTargetDead = new CustomStringOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Becomes On Target Dead", new[] {"Crewmate", "Amnesiac", "Survivor", "Jester"});
            ExecutionerButton = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Can Button", true);
            ExeVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Can Hide In Vents", false);
            ExeSwitchVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Can Switch Vents", false);
            ExeTargetKnows = new CustomToggleOption(true, num++, MultiMenu.neutral, "Target Knows <color=#CCCCCCFF>Executioner</color> Exists", false);
            ExeKnowsTargetRole = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Knows Target's Role", false);
            ExeEjectScreen = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Target Ejection Reveals Existence Of <color=#CCCCCCFF>Executioner</color>", false);
            ExeCanHaveIntruderTargets = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Can Have <color=#FF0000FF>Intruder</color> Targets", false);
            ExeCanHaveSyndicateTargets = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Can Have <color=#008000FF>Syndicate</color> Targets", false);
            ExeCanHaveNeutralTargets = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Can Have <color=#B3B3B3FF>Neutral</color> Targets", false);
            ExeCanWinBeyondDeath = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#CCCCCCFF>Executioner</color> Can Win After Death", false);
            VigiKillsExecutioner = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#FFFF00FF>Vigilante</color> Kills <color=#CCCCCCFF>Executioner</color>", false);

            Jester = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#F7B3DAFF>Jester</color>");
            JesterCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#F7B3DAFF>Jester</color> Count", 1, 1, 14, 1);
            JesterButton = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#F7B3DAFF>Jester</color> Can Button", true);
            JesterVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#F7B3DAFF>Jester</color> Can Hide In Vents", false);
            JestSwitchVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#F7B3DAFF>Jester</color> Can Switch Vents", false);
            JestEjectScreen = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#F7B3DAFF>Jester</color> Target Ejection Reveals Existence Of <color=#F7B3DAFF>Jester</color>", false);
            VigiKillsJester = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#FFFF00FF>Vigilante</color> Kills <color=#F7B3DAFF>Jester</color>", false);

            Troll = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#678D36FF>Troll</color>");
            TrollCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#678D36FF>Troll</color> Count", 1, 1, 14, 1);
            InteractCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Interact Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            TrollVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#678D36FF>Troll</color> Can Vent", false);
            TrollSwitchVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#678D36FF>Troll</color> Can Switch Vents", false);

            NeutralKillingSettings = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Killing</color> Settings");
            NKHasImpVision = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Killers</color> Have <color=#FF0000FF>Intruder</color> Vision", true);
            NoSolo = new CustomStringOption(true, num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Killers</color> Know Each Other", new[] {"Never", "Same Roles", "All NKs", "All Neutrals"});

            Arsonist = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#EE7600FF>Arsonist</color>");
            ArsonistCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#EE7600FF>Arsonist</color> Count", 1, 1, 14, 1);
            DouseCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Douse Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            IgniteCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Ignite Cooldown", 25f, 0f, 60f, 2.5f, CooldownFormat);
            ArsoIgniteNeedsCooldown = new CustomToggleOption(true, num++, MultiMenu.neutral, "Ignite Cooldown Removed When <color=#EE7600FF>Arsonist</color> Is Last Killer", false);
            ArsoVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#EE7600FF>Arsonist</color> Can Vent", false);

            Cryomaniac = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#642DEAFF>Cryomaniac</color>");
            CryomaniacCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#642DEAFF>Cryomaniac</color> Count", 1, 1, 14, 1);
            CryoDouseCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Douse Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            CryoVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#642DEAFF>Cryomaniac</color> Can Vent", false);

            Glitch = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#00FF00FF>Glitch</color>");
            GlitchCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#00FF00FF>Glitch</color> Count", 1, 1, 14, 1);
            MimicCooldownOption = new CustomNumberOption(true, num++, MultiMenu.neutral, "Mimic Cooldown", 25f, 10f, 120f, 2.5f, CooldownFormat);
            MimicDurationOption = new CustomNumberOption(true, num++, MultiMenu.neutral, "Mimic Duration", 10f, 1f, 30f, 1f, CooldownFormat);
            HackCooldownOption = new CustomNumberOption(true, num++, MultiMenu.neutral, "Hack Cooldown", 25f, 10f, 120f, 2.5f, CooldownFormat);
            HackDurationOption = new CustomNumberOption(true, num++, MultiMenu.neutral, "Hack Duration", 10f, 1f, 30f, 1f, CooldownFormat);
            GlitchKillCooldownOption = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#00FF00FF>Glitch</color> Kill Cooldown", 25f, 10f, 120f, 2.5f, CooldownFormat);
            GlitchVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#00FF00FF>Glitch</color> Can Vent", false);

            Juggernaut = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#A12B56FF>Juggernaut</color>");
            JuggernautCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#A12B56FF>Juggernaut</color> Count", 1, 1, 14, 1);
            JuggKillCooldownOption = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#A12B56FF>Juggernaut</color> Kill Cooldown", 25f, 10f, 120f, 2.5f, CooldownFormat);
            JuggKillBonus = new CustomNumberOption(true, num++, MultiMenu.neutral, "Kill Cooldown Bonus", 5f, 2.5f, 30f, 2.5f, CooldownFormat);
            JuggVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#A12B56FF>Juggernaut</color> Can Vent", false);

            Murderer = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#6F7BEAFF>Murderer</color>");
            MurdCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#6F7BEAFF>Murderer</color> Count", 1, 1, 14, 1);
            MurdKillCooldownOption = new CustomNumberOption(true, num++, MultiMenu.neutral, "Kill Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            MurdVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#6F7BEAFF>Murderer</color> Can Vent", false);

            Plaguebearer = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#CFFE61FF>Plaguebearer</color>");
            PlaguebearerCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#CFFE61FF>Plaguebearer</color> Count", 1, 1, 14, 1);
            InfectCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Infect Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            PBVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#CFFE61FF>Plaguebearer</color> Can Vent", false);

            Pestilence = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#424242FF>Pestilence</color>");
            PestSpawn = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#424242FF>Pestilence</color> Can Spawn Directly", false);
            PlayersAlerted = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#424242FF>Pestilence</color> Transform Alerts Everyone", false);
            PestKillCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#424242FF>Pestilence</color> Kill Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            PestVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#424242FF>Pestilence</color> Can Vent", false);

            SerialKiller = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#336EFFFF>Serial Killer</color>");
            SKCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#336EFFFF>Serial Killer</color> Count", 1, 1, 14, 1);
            BloodlustCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Bloodlust Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            BloodlustDuration = new CustomNumberOption(true, num++, MultiMenu.neutral, "Bloodlust Duration", 25f, 10f, 60f, 2.5f, CooldownFormat);
            LustKillCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Stab Cooldown", 10f, 0.5f, 15f, 0.5f, CooldownFormat);
            SKVentOptions = new CustomStringOption(true, num++, MultiMenu.neutral, "<color=#336EFFFF>Serial Killer</color> Can Vent", new[] {"Always", "Bloodlust", "No Lust", "Never"});

            Werewolf = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#9F703AFF>Werewolf</color>");
            WerewolfCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#9F703AFF>Werewolf</color> Count", 1, 1, 14, 1);
            MaulCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Maul Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat);
            MaulRadius = new CustomNumberOption(true, num++, MultiMenu.neutral, "Maul Radius", 1f, 0.25f, 5f, 0.25f, MultiplierFormat);
            WerewolfVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#9F703AFF>Werewolf</color> Can Vent", false);

            NeutralNeophyteSettings = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Neophyte</color> Settings");
            
            Dracula = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#AC8A00FF>Dracula</color>");
            DraculaCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#AC8A00FF>Dracula</color> Count", 1, 1, 14, 1);
            BiteCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Bite Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            DraculaConvertNeuts = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#AC8A00FF>Dracula</color> Can Convert <color=#B3B3B3FF>Neutrals</color>", false);
            DracVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#AC8A00FF>Dracula</color> Can Vent", false);
            AliveVampCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "Alive <color=#7B8968FF>Undead</color> Count", 3, 1, 14, 1);
            
            Jackal = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#45076AFF>Jackal</color>");
            JackalCount = new CustomNumberOption(true, num++, MultiMenu.neutral, "<color=#45076AFF>Jackal</color> Count", 1, 1, 14, 1);
            RecruitCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Bite Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            JackConvertNeuts = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#45076AFF>Jackal</color> Can Convert <color=#B3B3B3FF>Neutrals</color>", false);
            JackalVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#45076AFF>Jackal</color> Can Vent", false);

            NeutralProselyteSettings = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Proselyte</color> Settings");
            
            Vampire = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#2BD29CFF>Vampire</color>");
            VampVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#2BD29CFF>Vampire</color> Can Vent", false);
            
            Dampyr = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#DF7AE8FF>Dampyr</color>");
            DampBiteCooldown = new CustomNumberOption(true, num++, MultiMenu.neutral, "Bite Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            DampVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#DF7AE8FF>Dampyr</color> Can Vent", false);
            
            Recruit = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#808000FF>Recruit</color>");
            RecruitVent = new CustomToggleOption(true, num++, MultiMenu.neutral, "<color=#808000FF>Recruit</color> Can Vent", false);

            IntruderSettings = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> Settings");
            CustomIntColors = new CustomToggleOption(true, num++, MultiMenu.intruder, "Enable Custom <color=#FF0000FF>Intruder</color> Colors", true);
            IntruderCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> Count", 1, 0, 4, 1);
            IntruderVision = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> Vision", 2f, 0.25f, 5f, 0.25f, MultiplierFormat);
            IntruderKillCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> Kill Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            IntruderSabotageCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> Sabotage Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            IntrudersVent = new CustomToggleOption(true, num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> Can Vent", true);
            IntrudersCanSabotage = new CustomToggleOption(true, num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> Can Sabotage", true);

            IntruderConcealingSettings = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> <color=#1D7CF2FF>Concealing</color> Settings");

            Blackmailer = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#02A752FF>Blackmailer</color>");
            BlackmailerCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#02A752FF>Blackmailer</color> Count", 1, 1, 14, 1);
            BlackmailCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Blackmail Cooldown", 10f, 1f, 15f, 1f, CooldownFormat);

            Camouflager = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#378AC0FF>Camouflager</color>");
            CamouflagerCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#378AC0FF>Camouflager</color> Count", 1, 1, 14, 1);
            CamouflagerCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Camouflage Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            CamouflagerDuration = new CustomNumberOption(true, num++, MultiMenu.intruder, "Camouflage Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            CamoHideSize = new CustomToggleOption(true, num++, MultiMenu.intruder, "Camouflage Hides Player Size", false);
            CamoHideSpeed = new CustomToggleOption(true, num++, MultiMenu.intruder, "Camouflage Hides Player Speed", false);

            Grenadier = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#85AA5BFF>Grenadier</color>");
            GrenadierCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#85AA5BFF>Grenadier</color> Count", 1, 1, 14, 1);
            GrenadeCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Flash Grenade Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            GrenadeDuration = new CustomNumberOption(true, num++, MultiMenu.intruder, "Flash Grenade Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            FlashRadius = new CustomNumberOption(true, num++, MultiMenu.intruder, "Flash Radius", 1f, 0.25f, 5f, 0.25f, MultiplierFormat);
            GrenadierIndicators = new CustomToggleOption(true, num++, MultiMenu.intruder, "Indicate Flashed <color=#8BFDFDFF>Crewmates</color>", false);
            GrenadierVent = new CustomToggleOption(true, num++, MultiMenu.intruder, "<color=#85AA5BFF>Grenadier</color> Can Vent", false);

            Janitor = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#2647A2FF>Janitor</color>");
            JanitorCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#2647A2FF>Janitor</color> Count", 1, 1, 14, 1);
            JanitorCleanCd = new CustomNumberOption (true, num++, MultiMenu.intruder, "<color=#2647A2FF>Janitor</color> Clean Cooldown", 25f, 0f, 40f, 2.5f, CooldownFormat);
            SoloBoost = new CustomToggleOption(true, num++, MultiMenu.intruder, "<color=#2647A2FF>Janitor</color> Has Lower Cooldown When Solo", false);

            Undertaker = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#005643FF>Undertaker</color>");
            UndertakerCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#005643FF>Undertaker</color> Count", 1, 1, 14, 1);
            DragCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Drag Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            UndertakerVentOptions = new CustomStringOption(true, num++, MultiMenu.intruder, "<color=#005643FF>Undertaker</color> Can Vent", new[] {"Never", "Body", "Bodyless", "Always"});
            DragModifier = new CustomNumberOption(true, num++, MultiMenu.intruder, "Drag Speed", 0.1f, 0.5f, 2f, 0.5f, MultiplierFormat);

            IntruderDeceptionSettings = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> <color=#1D7CF2FF>Deception</color> Settings");
            
            Disguiser = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#40B4FFFF>Disguiser</color>");
            DisguiserCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#40B4FFFF>Disguiser</color> Count", 1, 1, 14, 1);
            DisguiseCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Disguise Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat);
            TimeToDisguise = new CustomNumberOption(true, num++, MultiMenu.intruder, "Delay Before Disguising", 5f, 2.5f, 15f, 2.5f, CooldownFormat);
            DisguiseDuration = new CustomNumberOption(true, num++, MultiMenu.intruder, "Disguise Duration", 10f, 2.5f, 20f, 2.5f, CooldownFormat);

            Morphling = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#BB45B0FF>Morphling</color>");
            MorphlingCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#BB45B0FF>Morphling</color> Count", 1, 1, 14, 1);
            MorphlingCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Morph Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            MorphlingDuration = new CustomNumberOption(true, num++, MultiMenu.intruder, "Morph Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            MorphlingVent = new CustomToggleOption(true, num++, MultiMenu.intruder, "<color=#BB45B0FF>Morphling</color> Can Vent", false);

            Poisoner = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#B5004CFF>Poisoner</color>");
            PoisonerCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#B5004CFF>Poisoner</color> Count", 1, 1, 14, 1);
            PoisonCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Poison Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            PoisonDuration = new CustomNumberOption(true, num++, MultiMenu.intruder, "Poison Kill Delay", 5f, 1f, 15f, 1f, CooldownFormat);
            PoisonerVent = new CustomToggleOption(true, num++, MultiMenu.intruder, "<color=#B5004CFF>Poisoner</color> Can Vent", false);

            Wraith = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FFB875FF>Wraith</color>");
            WraithCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#FFB875FF>Wraith</color> Count", 1, 1, 14, 1);
            InvisCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Invis Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            InvisDuration = new CustomNumberOption(true, num++, MultiMenu.intruder, "Invis Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            WraithVent = new CustomToggleOption(true, num++, MultiMenu.intruder, "<color=#FFB875FF>Wraith</color> Can Vent", false);

            //IntruderKillingSettings = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Impostor</color> <color=#1D7CF2FF>Killing</color> Settings");

            IntruderSupportSettings = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> <color=#1D7CF2FF>Support</color> Settings");

            Consigliere = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FFFF99FF>Consigliere</color>");
            RevealCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Reveal Cooldown", 25f, 10f, 100f, 2.5f, CooldownFormat);
            ConsigInfo = new CustomStringOption(true, num++, MultiMenu.intruder, "Info That <color=#FFFF99FF>Consigliere</color> Sees", new[] {"Role", "Faction"});

            Consort = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#801780FF>Consort</color>");
            ConsortCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#801780FF>Consort</color> Count", 1, 1, 14, 1);
            ConsRoleblockCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Roleblock Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            ConsRoleblockDuration = new CustomNumberOption(true, num++, MultiMenu.intruder, "Roleblock Duration", 25f, 10f, 60f, 2.5f, CooldownFormat);

            Godfather = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#404C08FF>Godfather</color>");
            GodfatherCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#404C08FF>Godfather</color> Count", 1, 1, 14, 1);
            DeclareCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Declare Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);

            Miner = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#AA7632FF>Miner</color>");
            MinerCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#AA7632FF>Miner</color> Count", 1, 1, 14, 1);
            MineCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Mine Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);

            Teleporter = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#6AA84FFF>Teleporter</color>");
            TeleporterCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#6AA84FFF>Teleporter</color> Count", 1, 1, 14, 1);
            TeleportCd = new CustomNumberOption(true, num++, MultiMenu.intruder, "Teleport Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            TeleVent = new CustomToggleOption(true, num++, MultiMenu.intruder, "<color=#6AA84FFF>Teleporter</color> Can Vent", false);

            TimeMaster = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#0000A7FF>Time Master</color>");
            TMCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#0000A7FF>Time Master</color> Count", 1, 1, 14, 1);
            FreezeCooldown = new CustomNumberOption(true, num++, MultiMenu.intruder, "Freeze Cooldown", 25, 10, 40, 2.5f, CooldownFormat);
            FreezeDuration = new CustomNumberOption(true, num++, MultiMenu.intruder, "Freeze Duration", 20.0f, 5f, 60f, 5f, CooldownFormat);

            IntruderUtilitySettings = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Intruder</color> <color=#1D7CF2FF>Utility</color> Settings");

            Impostor = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#FF0000FF>Impostor</color>");
            ImpCount = new CustomNumberOption(true, num++, MultiMenu.intruder, "<color=#FF0000FF>Impostor</color> Count", 1, 1, 14, 1);

            Mafioso = new CustomHeaderOption(num++, MultiMenu.intruder, "<color=#6400FFFF>Mafioso</color>");
            MafiosoAbilityCooldownDecrease = new CustomNumberOption(true, num++, MultiMenu.intruder, "Ability Cooldown Bonus", 5f, 2.5f, 30f, 2.5f, CooldownFormat);
            PromotedMafiosoCanPromote = new CustomToggleOption(true, num++, MultiMenu.intruder, "Promoted <color=#6400FFFF>Mafioso</color> Can Declare Others", false);

            SyndicateSettings = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> Settings");
            CustomSynColors = new CustomToggleOption(true, num++, MultiMenu.syndicate, "Enable Custom <color=#008000FF>Syndicate</color> Colors", true);
            SyndicateCount = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> Count", 1, 0, 4, 1);
            SyndicateVision = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> Vision", 2f, 0.25f, 5f, 0.25f, MultiplierFormat);
            ChaosDriveMeetingCount = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Number Of Meetings Required For Chaos Drive Spawn", 1, 0, 4, 1);
            ChaosDriveKillCooldown = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Chaos Drive Holder Kill Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            SyndicateVent = new CustomToggleOption(true, num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> Can Vent", true);
            AltImps = new CustomToggleOption(true, num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> Replaces <color=#FF0000FF>Intruders</color>", false);

            SyndicateDisruptionSettings = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> <color=#1D7CF2FF>Disruption</color> Settings");

            Puppeteer = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#00FFFFFF>Puppeteer</color>");
            PuppeteerCount = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#00FFFFFF>Puppeteer</color> Count", 1, 1, 14, 1);
            PossessCooldown = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Possess Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            PossessDuration = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Possess Duration", 10f, 5f, 15f, 1f, CooldownFormat);

            Shapeshifter = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#311C45FF>Shapeshifter</color>");
            ShapeshifterCount = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#311C45FF>Shapeshifter</color> Count", 1, 1, 14, 1);
            ShapeshiftCooldown = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Shapeshift Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            ShapeshiftDuration = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Shapeshift Duration", 10f, 5f, 15f, 1f, CooldownFormat);

            SyndicateKillingSettings = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> <color=#1D7CF2FF>Killing</color> Settings");

            Gorgon = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#7E4D00FF>Gorgon</color>");
            GorgonCount = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#7E4D00FF>Gorgon</color> Count", 1, 1, 14, 1);
            GazeCooldown = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Gaze Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            GazeTime = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Gaze Time", 10f, 5f, 15f, 1f, CooldownFormat);

            SyndicateSupportSettings = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> <color=#1D7CF2FF>Support</color> Settings");

            Concealer = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#C02525FF>Concealer</color>");
            ConcealerCount = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#C02525FF>Concealer</color> Count", 1, 1, 14, 1);
            ConcealCooldown = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Conceal Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            ConcealDuration = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Conceal Duration", 10f, 5f, 15f, 1f, CooldownFormat);

            Rebel = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#FFFCCEFF>Rebel</color>");
            RebelCount = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#FFFCCEFF>Rebel</color> Count", 1, 1, 14, 1);
            SidekickCooldown = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Sidekick Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);

            Sidekick = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#979C9FFF>Sidekick</color>");
            SidekickAbilityCooldownDecrease = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Ability Cooldown Bonus", 5f, 2.5f, 30f, 2.5f, CooldownFormat);
            PromotedSidekickCanPromote = new CustomToggleOption(true, num++, MultiMenu.syndicate, "Promoted <color=#979C9FFF>Sidekick</color> Can Sidekick Others", false);

            Warper = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#8C7140FF>Warper</color>");
            WarperCount = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#8C7140FF>Warper</color> Count", 1, 1, 14, 1);
            WarpCooldown = new CustomNumberOption(true, num++, MultiMenu.syndicate, "Warp Cooldown", 25, 10, 40, 2.5f, CooldownFormat);

            SyndicateUtilitySettings = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#008000FF>Syndicate</color> <color=#1D7CF2FF>Utility</color> Settings");

            Anarchist = new CustomHeaderOption(num++, MultiMenu.syndicate, "<color=#008000FF>Anarchist</color>");
            AnarchistCount = new CustomNumberOption(true, num++, MultiMenu.syndicate, "<color=#008000FF>Anarchist</color> Count", 1, 1, 14, 1);

            ModifierSettings = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#7F7F7FFF>Modifier</color> Settings");
            CustomModifierColors = new CustomToggleOption(true, num++, MultiMenu.modifier, "Enable Custom <color=#7F7F7FFF>Modifier</color> Colors", true);

            Bait = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#00B3B3FF>Bait</color>");
            BaitCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#00B3B3FF>Bait</color> Count", 1, 1, 14, 1);
            BaitKnows = new CustomToggleOption(true, num++, MultiMenu.modifier, "<color=#00B3B3FF>Bait</color> Knows Who They Are On Game Start", false);
            BaitMinDelay = new CustomNumberOption(true, num++, MultiMenu.modifier, "Minimum Delay for <color=#00B3B3FF>Bait</color> Self Report", 0f, 0f, 15f, 0.5f, CooldownFormat);
            BaitMaxDelay = new CustomNumberOption(true, num++, MultiMenu.modifier, "Maximum Delay for <color=#00B3B3FF>Bait</color> Self Report", 1f, 0f, 15f, 0.5f, CooldownFormat);

            Coward = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#456BA8FF>Coward</color>");
            CowardCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#456BA8FF>Coward</color> Count", 1, 1, 14, 1);

            Diseased = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#374D1EFF>Diseased</color>");
            DiseasedCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#374D1EFF>Diseased</color> Count", 1, 1, 14, 1);
            DiseasedKnows = new CustomToggleOption(true, num++, MultiMenu.modifier, "<color=#374D1EFF>Diseased</color> Knows Who They Are On Game Start", false);
            DiseasedKillMultiplier = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#374D1EFF>Diseased</color> Kill Multiplier", 3f, 1.5f, 5f, 0.5f, MultiplierFormat);

            Dwarf = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#FF8080FF>Dwarf</color>");
            DwarfCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FF8080FF>Dwarf</color> Count", 1, 1, 14, 1);
            DwarfSpeed = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FF8080FF>Dwarf</color> Speed", 1.5f, 1.0f, 2f, 0.05f, MultiplierFormat);
            DwarfScale = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FF8080FF>Dwarf</color> Scale", 0.5f, 0.3f, 0.6f, 0.025f, MultiplierFormat);

            Giant = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#FFB34DFF>Giant</color>");
            GiantCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FFB34DFF>Giant</color> Count", 1, 1, 14, 1);
            GiantSpeed = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FFB34DFF>Giant</color> Speed", 0.75f, 0.5f, 1f, 0.05f, MultiplierFormat);
            GiantScale = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FFB34DFF>Giant</color> Scale", 1.5f, 1.5f, 3.0f, 0.025f, MultiplierFormat);
            
            Drunk = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#758000FF>Drunk</color>");
            DrunkCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#758000FF>Drunk</color> Count", 1, 1, 14, 1);
            DrunkControlsSwap = new CustomToggleOption(true, num++, MultiMenu.modifier, "<color=#758000FF>Drunk</color> Controls Reverse Over Time", false);
            DrunkInterval = new CustomNumberOption(true, num++, MultiMenu.modifier, "Reversed Controls Interval", 1f, 1f, 20f, 1f, CooldownFormat);

            Flincher = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#80B3FFFF>Flincher</color>");
            FlincherCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#80B3FFFF>Flincher</color> Count", 1, 1, 14, 1);
            FlinchInterval = new CustomNumberOption(true, num++, MultiMenu.modifier, "Flinch Interval", 1f, 1f, 20f, 1f, CooldownFormat);

            Professional = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#860B7AFF>Professional</color>");
            ProfessionalCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#860B7AFF>Professional</color> Count", 1, 1, 14, 1);
            ProfessionalKnows = new CustomToggleOption(true, num++, MultiMenu.modifier, "<color=#860B7AFF>Professional</color> Knows Who They Are On Game Start", false);

            Shy = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#1002C5FF>Shy</color>");
            ShyCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#1002C5FF>Shy</color> Count", 1, 1, 14, 1);

            VIP = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#DCEE85FF>VIP</color>");
            VIPCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#DCEE85FF>VIP</color> Count", 1, 1, 14, 1);
            VIPKnows = new CustomToggleOption(true, num++, MultiMenu.modifier, "<color=#DCEE85FF>VIP</color> Knows Who They Are On Game Start", false);

            Volatile = new CustomHeaderOption(num++, MultiMenu.modifier, "<color=#FFA60AFF>Volatile</color>");
            VolatileCount = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FFA60AFF>Volatile</color> Count", 1, 1, 14, 1);
            VolatileInterval = new CustomNumberOption(true, num++, MultiMenu.modifier, "<color=#FFA60AFF>Volatile</color> Interval", 15f, 10f, 30f, 1f, CooldownFormat);

            AbilitySettings = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#FF9900FF>Ability</color> Settings");
            CustomAbilityColors = new CustomToggleOption(true, num++, MultiMenu.ability, "Enable Custom <color=#FF9900FF>Ability</color> Colors", true);

            Assassin = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#073763FF>Assassin</color> Settings");
            NumberOfImpostorAssassins = new CustomNumberOption(true, num++, MultiMenu.ability, "Number Of <color=#FF0000FF>Intruder</color> <color=#073763FF>Assassins</color>", 1, 0, 14, 1);
            NumberOfCrewAssassins = new CustomNumberOption(true, num++, MultiMenu.ability, "Number Of <color=#8BFDFDFF>Crew</color> <color=#073763FF>Assassins</color>", 1, 0, 14, 1);
            NumberOfNeutralAssassins = new CustomNumberOption(true, num++, MultiMenu.ability, "Number Of <color=#B3B3B3FF>Neutral</color> <color=#073763FF>Assassins</color>", 1, 0, 14, 1);
            NumberOfSyndicateAssassins = new CustomNumberOption(true, num++, MultiMenu.ability, "Number Of <color=#008000FF>Syndicate</color> <color=#073763FF>Assassins</color>", 1, 0, 14, 1);
            AssassinKills = new CustomNumberOption(true, num++, MultiMenu.ability, "Number Of <color=#073763FF>Assassin</color> Kills", 1, 1, 15, 1);
            AssassinMultiKill = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#073763FF>Assassin</color> Can Kill More Than Once Per Meeting", false);
            AssassinGuessNeutralBenign = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#073763FF>Assassin</color> Can Guess <color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Benigns</color>", false);
            AssassinGuessNeutralEvil = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#073763FF>Assassin</color> Can Guess <color=#B3B3B3FF>Neutral</color> <color=#1D7CF2FF>Evils</color>", false);
            AssassinGuessPest = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#073763FF>Assassin</color> Can Guess <color=#424242FF>Pestilence</color>", false);
            AssassinGuessModifiers = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#073763FF>Assassin</color> Can Guess Select <color=#7F7F7FFF>Modifiers</color>", false);
            AssassinGuessObjectifiers = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#073763FF>Assassin</color> Can Guess Select <color=#DD585BFF>Objectifiers</color>", false);
            AssassinGuessAbilities = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#073763FF>Assassin</color> Can Guess <color=#FF9900FF>Abilities</color>", false);
            AssassinateAfterVoting = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#073763FF>Assassin</color> Can Guess After Voting", false);

            ButtonBarry = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#E600FFFF>Button Barry</color>");
            BBCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#E600FFFF>Button Barry</color> Count", 1, 1, 14, 1);
            ButtonCount = new CustomNumberOption(true, num++, MultiMenu.ability, "Button Count", 1, 1, 14, 1);

            Insider = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#26FCFBFF>Insider</color>");
            InsiderCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#26FCFBFF>Insider</color> Count", 1, 1, 14, 1);
            InsiderKnows = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#26FCFBFF>Insider</color> Knows Who They Are On Game Start", false);

            Lighter = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#1AFF74FF>Lighter</color>");
            LighterCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#1AFF74FF>Lighter</color> Count", 1, 1, 14, 1);

            Multitasker = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#FF804DFF>Multitasker</color>");
            MultitaskerCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#FF804DFF>Multitasker</color> Count", 1, 1, 14, 1);
            Transparancy = new CustomNumberOption(true, num++, MultiMenu.ability, "Task Transparancy", 50f, 10f, 80f, 5f, PercentFormat);

            Radar = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#FF0080FF>Radar</color>");
            RadarCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#FF0080FF>Radar</color> Count", 1, 1, 14, 1);

            Revealer = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#D3D3D3FF>Revealer</color>");
            RevealerCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#D3D3D3FF>Revealer</color> Count", 1, 1, 14, 1);
            RevealerKnows = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#D3D3D3FF>Revealer</color> Knows Who They Are On Game Start", false);
            RevealerTasksRemainingClicked = new CustomNumberOption(true, num++, MultiMenu.ability, "Tasks Remaining When <color=#D3D3D3FF>Revealer</color> Can Be Clicked", 5, 1, 10, 1);
            RevealerTasksRemainingAlert = new CustomNumberOption(true, num++, MultiMenu.ability, "Tasks Remaining When Revealed", 1, 1, 5, 1);
            RevealerRevealsNeutrals = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#D3D3D3FF>Revealer</color> Reveals <color=#B3B3B3FF>Neutrals</color>", false);
            RevealerRevealsCrew = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#D3D3D3FF>Revealer</color> Reveals <color=#8BFDFDFF>Crew</color>", false);
            RevealerRevealsRoles = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#D3D3D3FF>Revealer</color> Reveals Exact Roles", false);
            RevealerCanBeClickedBy = new CustomStringOption(true, num++, MultiMenu.ability, "Who Can Click <color=#D3D3D3FF>Revealer</color>", new[] {"All", "Non-Crew", "Imps Only"});

            Snitch = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#D4AF37FF>Snitch</color>");
            SnitchCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#D4AF37FF>Snitch</color> Count", 1, 1, 14, 1);
            SnitchKnows = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#D4AF37FF>Snitch</color> Knows Who They Are On Game Start", false);
            SnitchSeesNeutrals = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#D4AF37FF>Snitch</color> Sees <color=#B3B3B3FF>Neutrals</color>", false);
            SnitchSeesCrew = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#D4AF37FF>Snitch</color> Sees <color=#8BFDFDFF>Crew</color>", false);
            SnitchSeesRoles = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#D4AF37FF>Snitch</color> Sees Exact Roles", false);
            SnitchTasksRemaining = new CustomNumberOption(true, num++, MultiMenu.ability, "Tasks Remaining When Revealed", 1, 1, 5, 1);
            SnitchSeesImpInMeeting = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#D4AF37FF>Snitch</color> Sees <color=#FF0000FF>Intruders</color> In Meetings", true);

            Tiebreaker = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#99E699FF>Tiebreaker</color>");
            TiebreakerCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#99E699FF>Tiebreaker</color> Count", 1, 1, 14, 1);
            TiebreakerKnows = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#99E699FF>Tiebreaker</color> Knows Who They Are On Game Start", false);

            Torch = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#FFFF99FF>Torch</color>");
            TorchCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#FFFF99FF>Torch</color> Count", 1, 1, 14, 1);

            Tunneler = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#E91E63FF>Tunneler</color>");
            TunnelerCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#E91E63FF>Tunneler</color> Count", 1, 1, 14, 1);
            TunnelerKnows = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#E91E63FF>Tunneler</color> Knows Who They Are On Game Start", false);

            Underdog = new CustomHeaderOption(num++, MultiMenu.ability, "<color=#841A7FFF>Underdog</color>");
            UnderdogCount = new CustomNumberOption(true, num++, MultiMenu.ability, "<color=#841A7FFF>Underdog</color> Count", 1, 1, 14, 1);
            UnderdogKnows = new CustomToggleOption(true, num++, MultiMenu.ability, "<color=#841A7FFF>Underdog</color> Knows Who They Are On Game Start", false);
            UnderdogKillBonus = new CustomNumberOption(true, num++, MultiMenu.ability, "Kill Cooldown Bonus", 5f, 2.5f, 30f, 2.5f, CooldownFormat);
            UnderdogIncreasedKC = new CustomToggleOption(true, num++, MultiMenu.ability, "Increased Kill Cooldown When 2+ <color=#FF0000FF>Intruders</color>", true);

            ObjectifierSettings = new CustomHeaderOption(num++, MultiMenu.objectifier, "<color=#DD585BFF>Objectifier</color> Settings");
            CustomObjectifierColors = new CustomToggleOption(true, num++, MultiMenu.objectifier, "Enable Custom <color=#DD585BFF>Objectifier</color> Colors", true);

            Fanatic = new CustomHeaderOption(num++, MultiMenu.objectifier, "<color=#678D36FF>Fanatic</color>");
            FanaticCount = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#678D36FF>Fanatic</color> Count", 1, 1, 14, 1);
            FanaticKnows = new CustomToggleOption(true, num++, MultiMenu.objectifier, "<color=#678D36FF>Fanatic</color> Knows Who They Are On Game Start", false);
            FanaticCanAssassin = new CustomToggleOption(true, num++, MultiMenu.objectifier, "Turned <color=#678D36FF>Fanatic</color> Gets <color=#073763FF>Assassin</color>", false);

            Lovers = new CustomHeaderOption(num++, MultiMenu.objectifier, "<color=#FF66CCFF>Lovers</color>");
            LoversCount = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#FF66CCFF>Lovers</color> Count", 1, 1, 14, 1);
            BothLoversDie = new CustomToggleOption(true, num++, MultiMenu.objectifier, "Both <color=#FF66CCFF>Lovers</color> Die", true);
            LoversChat = new CustomToggleOption(true, num++, MultiMenu.objectifier, "Enable <color=#FF66CCFF>Lovers</color> Chat", true);
            LoversFaction = new CustomToggleOption(true, num++, MultiMenu.objectifier, "<color=#FF66CCFF>Lovers</color> Can Be From The Same Faction", true);
            LoversRoles = new CustomToggleOption(true, num++, MultiMenu.objectifier, "<color=#FF66CCFF>Lovers</color> Know Each Other's Roles", true);

            Phantom = new CustomHeaderOption(num++, MultiMenu.objectifier, "<color=#662962FF>Phantom</color>");
            PhantomCount = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#662962FF>Phantom</color> Count", 1, 1, 14, 1);
            PhantomKnows = new CustomToggleOption(true, num++, MultiMenu.objectifier, "<color=#662962FF>Phantom</color> Knows Who They Are On Game Start", false);
            PhantomTasksRemaining = new CustomNumberOption(true, num++, MultiMenu.objectifier, "Tasks Remaining When <color=#662962FF>Phantom</color> Can Be Clicked", 5, 1, 10, 1);

            Rivals = new CustomHeaderOption(num++, MultiMenu.objectifier, "<color=#3D2D2CFF>Rivals</color>");
            RivalsCount = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#3D2D2CFF>Rivals</color> Count", 1, 1, 14, 1);
            RivalsChat = new CustomToggleOption(true, num++, MultiMenu.objectifier, "Enable <color=#3D2D2CFF>Rivals</color> Chat", true);
            RivalsFaction = new CustomToggleOption(true, num++, MultiMenu.objectifier, "<color=#3D2D2CFF>Rivals</color> Can Be From The Same Faction", true);
            RivalsRoles = new CustomToggleOption(true, num++, MultiMenu.objectifier, "<color=#3D2D2CFF>Rivals</color> Know Each Other's Roles", true);

            Taskmaster = new CustomHeaderOption(num++, MultiMenu.objectifier, "<color=#ABABFFFF>Taskmaster</color>");
            TaskmasterCount = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#ABABFFFF>Taskmaster</color> Count", 1, 1, 14, 1);
            TMTasksRemaining = new CustomNumberOption(true, num++, MultiMenu.objectifier, "Tasks Remaining When Revealed", 1, 1, 5, 1);

            Traitor = new CustomHeaderOption(num++, MultiMenu.objectifier, "<color=#370D43FF>Traitor</color>");
            TraitorCount = new CustomNumberOption(true, num++, MultiMenu.objectifier, "<color=#370D43FF>Traitor</color> Count", 1, 1, 14, 1);
            TraitorKnows = new CustomToggleOption(true, num++, MultiMenu.objectifier, "<color=#370D43FF>Traitor</color> Knows Who They Are On Game Start", false);
            TraitorCanAssassin = new CustomToggleOption(true, num++, MultiMenu.objectifier, "Turned <color=#FF0000FF>Traitor</color> Gets <color=#073763FF>Assassin</color>", false);
            SnitchSeesTraitor = new CustomToggleOption(true, num++, MultiMenu.objectifier, "<color=#D4AF37FF>Snitch</color> Sees <color=#370D43FF>Traitor</color>", true);
            RevealerRevealsTraitor = new CustomToggleOption(true, num++, MultiMenu.objectifier, "<color=#D3D3D3FF>Revealer</color> Reveals <color=#370D43FF>Traitor</color>", false);
        }
    }
}