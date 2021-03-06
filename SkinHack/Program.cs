﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;
using LeagueSharp;
using LeagueSharp.Common;

namespace SkinHack
{
    internal class Program
    {
        public static Menu Config;
        public static String DataDragonBase = "http://ddragon.leagueoflegends.com/";
        public static bool HaveDied;
        public static string CurrentModel;
        public static int CurrentSkin;

        #region ModelList

        public static List<string> ModelList = new List<string>
        {
            "Aatrox",
            "Ahri",
            "Akali",
            "Alistar",
            "Amumu",
            "AncientGolem",
            "Anivia",
            "AniviaEgg",
            "AniviaIceblock",
            "Annie",
            "AnnieTibbers",
            "ARAMChaosNexus",
            "ARAMChaosTurretFront",
            "ARAMChaosTurretInhib",
            "ARAMChaosTurretNexus",
            "ARAMChaosTurretShrine",
            "ARAMOrderNexus",
            "ARAMOrderTurretFront",
            "ARAMOrderTurretInhib",
            "ARAMOrderTurretNexus",
            "ARAMOrderTurretShrine",
            "AramSpeedShrine",
            "AscRelic",
            "AscWarpIcon",
            "AscXerath",
            "Ashe",
            "Azir",
            "AzirSoldier",
            "AzirSunDisc",
            "AzirTowerClicker",
            "AzirUltSoldier",
            "Bard",
            "BardFollower",
            "BardHealthShrine",
            "BardPickup",
            "BardPickupNoIcon",
            "Blitzcrank",
            "BlueTrinket",
            "Blue_Minion_Basic",
            "Blue_Minion_MechCannon",
            "Blue_Minion_MechMelee",
            "Blue_Minion_Wizard",
            "Brand",
            "Braum",
            "brush_A_SR",
            "brush_B_SR",
            "brush_C_SR",
            "brush_D_SR",
            "brush_E_SR",
            "brush_F_SR",
            "brush_SRU_A",
            "brush_SRU_B",
            "brush_SRU_C",
            "brush_SRU_D",
            "brush_SRU_E",
            "brush_SRU_F",
            "brush_SRU_G",
            "brush_SRU_H",
            "brush_SRU_I",
            "brush_SRU_J",
            "Caitlyn",
            "CaitlynTrap",
            "Cassiopeia",
            "Cassiopeia_Death",
            "ChaosInhibitor",
            "ChaosInhibitor_D",
            "ChaosNexus",
            "ChaosTurretGiant",
            "ChaosTurretNormal",
            "ChaosTurretShrine",
            "ChaosTurretTutorial",
            "ChaosTurretWorm",
            "ChaosTurretWorm2",
            "Chogath",
            "Corki",
            "crystal_platform",
            "Darius",
            "DestroyedInhibitor",
            "DestroyedNexus",
            "DestroyedTower",
            "Diana",
            "Dragon",
            "Draven",
            "DrMundo",
            "Elise",
            "EliseSpider",
            "EliseSpiderling",
            "Evelynn",
            "Ezreal",
            "Ezreal_cyber_1",
            "Ezreal_cyber_2",
            "Ezreal_cyber_3",
            "FiddleSticks",
            "Fiora",
            "Fizz",
            "FizzBait",
            "FizzShark",
            "Galio",
            "Gangplank",
            "Garen",
            "GhostWard",
            "GiantWolf",
            "Gnar",
            "GnarBig",
            "Golem",
            "GolemODIN",
            "Gragas",
            "Graves",
            "GreatWraith",
            "HA_AP_BannerMidBridge",
            "HA_AP_BridgeLaneStatue",
            "HA_AP_Chains",
            "HA_AP_Chains_Long",
            "HA_AP_ChaosTurret",
            "HA_AP_ChaosTurret2",
            "HA_AP_ChaosTurret3",
            "HA_AP_ChaosTurretRubble",
            "HA_AP_ChaosTurretShrine",
            "HA_AP_ChaosTurretTutorial",
            "HA_AP_Cutaway",
            "HA_AP_HealthRelic",
            "HA_AP_Hermit",
            "HA_AP_Hermit_Robot",
            "HA_AP_HeroTower",
            "HA_AP_OrderCloth",
            "HA_AP_OrderShrineTurret",
            "HA_AP_OrderTurret",
            "HA_AP_OrderTurret2",
            "HA_AP_OrderTurret3",
            "HA_AP_OrderTurretRubble",
            "HA_AP_OrderTurretTutorial",
            "HA_AP_PeriphBridge",
            "HA_AP_Poro",
            "HA_AP_PoroSpawner",
            "HA_AP_ShpNorth",
            "HA_AP_ShpSouth",
            "HA_AP_Viking",
            "HA_FB_HealthRelic",
            "Hecarim",
            "Heimerdinger",
            "HeimerTBlue",
            "HeimerTYellow",
            "Irelia",
            "Janna",
            "JarvanIV",
            "JarvanIVStandard",
            "JarvanIVWall",
            "Jax",
            "Jayce",
            "Jinx",
            "JinxMine",
            "Kalista",
            "KalistaAltar",
            "KalistaSpawn",
            "Karma",
            "Karthus",
            "Kassadin",
            "Katarina",
            "Kayle",
            "Kennen",
            "Khazix",
            "KingPoro",
            "KINGPORO_HiddenUnit",
            "KINGPORO_PoroFollower",
            "KogMaw",
            "KogMawDead",
            "Leblanc",
            "LeeSin",
            "Leona",
            "LesserWraith",
            "Lissandra",
            "Lizard",
            "LizardElder",
            "Lucian",
            "Lulu",
            "LuluCupcake",
            "LuluDragon",
            "LuluFaerie",
            "LuluKitty",
            "LuluLadybug",
            "LuluPig",
            "LuluSnowman",
            "LuluSquill",
            "Lux",
            "Malphite",
            "Malzahar",
            "MalzaharVoidling",
            "Maokai",
            "MaokaiSproutling",
            "MasterYi",
            "MissFortune",
            "MonkeyKing",
            "MonkeyKingClone",
            "MonkeyKingFlying",
            "Mordekaiser",
            "Morgana",
            "Nami",
            "Nasus",
            "NasusUlt",
            "Nautilus",
            "Nidalee",
            "Nidalee_Cougar",
            "Nidalee_Spear",
            "Nocturne",
            "Nunu",
            "OdinBlueSuperminion",
            "OdinCenterRelic",
            "OdinChaosTurretShrine",
            "OdinClaw",
            "OdinCrane",
            "OdinMinionGraveyardPortal",
            "OdinMinionSpawnPortal",
            "OdinNeutralGuardian",
            "OdinOpeningBarrier",
            "OdinOrderTurretShrine",
            "OdinQuestBuff",
            "OdinQuestIndicator",
            "OdinRedSuperminion",
            "OdinRockSaw",
            "OdinShieldRelic",
            "OdinSpeedShrine",
            "OdinTestCubeRender",
            "Odin_Blue_Minion_Caster",
            "Odin_Drill",
            "Odin_Lifts_Buckets",
            "Odin_Lifts_Crystal",
            "Odin_Minecart",
            "Odin_Red_Minion_Caster",
            "Odin_skeleton",
            "Odin_SoG_Chaos",
            "Odin_SOG_Chaos_Crystal",
            "Odin_SoG_Order",
            "Odin_SOG_Order_Crystal",
            "Odin_Windmill_Gears",
            "Odin_Windmill_Propellers",
            "Olaf",
            "OlafAxe",
            "OrderInhibitor",
            "OrderInhibitor_D",
            "OrderNexus",
            "OrderTurretAngel",
            "OrderTurretDragon",
            "OrderTurretNormal",
            "OrderTurretNormal2",
            "OrderTurretShrine",
            "OrderTurretTutorial",
            "Orianna",
            "OriannaBall",
            "OriannaNoBall",
            "Pantheon",
            "Poppy",
            "Quinn",
            "QuinnValor",
            "Rammus",
            "RammusDBC",
            "RammusPB",
            "redDragon",
            "Red_Minion_Basic",
            "Red_Minion_MechCannon",
            "Red_Minion_MechMelee",
            "Red_Minion_Wizard",
            "RekSai",
            "RekSaiTunnel",
            "Renekton",
            "Rengar",
            "Riven",
            "Rumble",
            "Ryze",
            "Sejuani",
            "Shaco",
            "ShacoBox",
            "Shen",
            "Shop",
            "ShopKeeper",
            "ShopMale",
            "Shyvana",
            "ShyvanaDragon",
            "SightWard",
            "Singed",
            "Sion",
            "Sivir",
            "Skarner",
            "SmallGolem",
            "Sona",
            "SonaDJGenre01",
            "SonaDJGenre02",
            "SonaDJGenre03",
            "Soraka",
            "SpellBook1",
            "SRUAP_Building",
            "SRUAP_ChaosInhibitor",
            "sruap_chaosinhibitor_rubble",
            "SRUAP_ChaosNexus",
            "Sruap_Chaosnexus_Rubble",
            "Sruap_Esports_Banner",
            "sruap_flag",
            "SRUAP_MageCrystal",
            "sruap_mage_vines",
            "SRUAP_OrderInhibitor",
            "sruap_orderinhibitor_rubble",
            "SRUAP_OrderNexus",
            "Sruap_Ordernexus_Rubble",
            "Sruap_Pali_Statue_Banner",
            "SRUAP_Turret_Chaos1",
            "sruap_turret_chaos1_rubble",
            "SRUAP_Turret_Chaos2",
            "SRUAP_Turret_Chaos3",
            "SRUAP_Turret_Chaos3_Test",
            "SRUAP_Turret_Chaos4",
            "SRUAP_Turret_Chaos5",
            "SRUAP_Turret_Order1",
            "SRUAP_Turret_Order1_Rubble",
            "SRUAP_Turret_Order2",
            "SRUAP_Turret_Order3",
            "SRUAP_Turret_Order3_Test",
            "SRUAP_Turret_Order4",
            "SRUAP_Turret_Order5",
            "Sru_Antlermouse",
            "SRU_Baron",
            "SRU_BaronSpawn",
            "SRU_Bird",
            "SRU_Blue",
            "SRU_BlueMini",
            "SRU_BlueMini2",
            "Sru_Butterfly",
            "SRU_ChaosMinionMelee",
            "SRU_ChaosMinionRanged",
            "SRU_ChaosMinionSiege",
            "SRU_ChaosMinionSuper",
            "Sru_Crab",
            "Sru_CrabWard",
            "SRU_Dragon",
            "Sru_Dragonfly",
            "sru_dragon_prop",
            "Sru_Duck",
            "SRU_Es_Banner",
            "Sru_Es_Bannerplatform_Chaos",
            "Sru_Es_Bannerplatform_Order",
            "Sru_Es_Bannerwall_Chaos",
            "Sru_Es_Bannerwall_Order",
            "SRU_Gromp",
            "Sru_Gromp_Prop",
            "SRU_Krug",
            "SRU_KrugMini",
            "Sru_Lizard",
            "SRU_Murkwolf",
            "SRU_MurkwolfMini",
            "SRU_OrderMinionMelee",
            "SRU_OrderMinionRanged",
            "SRU_OrderMinionSiege",
            "SRU_OrderMinionSuper",
            "SRU_Razorbeak",
            "SRU_RazorbeakMini",
            "SRU_Red",
            "SRU_RedMini",
            "SRU_RiverDummy",
            "Sru_Snail",
            "SRU_SnailSpawner",
            "SRU_Spiritwolf",
            "sru_storekeepernorth",
            "sru_storekeepersouth",
            "SRU_WallVisionBearer",
            "SummonerBeacon",
            "Summoner_Rider_Chaos",
            "Summoner_Rider_Order",
            "Swain",
            "SwainBeam",
            "SwainNoBird",
            "SwainRaven",
            "Syndra",
            "SyndraOrbs",
            "SyndraSphere",
            "Talon",
            "Taric",
            "Teemo",
            "TeemoMushroom",
            "TestCube",
            "TestCubeRender",
            "TestCubeRender10Vision",
            "TestCubeRenderwCollision",
            "Thresh",
            "ThreshLantern",
            "Tristana",
            "Trundle",
            "TrundleWall",
            "Tryndamere",
            "TT_Brazier",
            "TT_Buffplat_L",
            "TT_Buffplat_R",
            "TT_Chains_Bot_Lane",
            "TT_Chains_Order_Base",
            "TT_Chains_Order_Periph",
            "TT_Chains_Xaos_Base",
            "TT_ChaosInhibitor",
            "TT_ChaosInhibitor_D",
            "TT_ChaosTurret1",
            "TT_ChaosTurret2",
            "TT_ChaosTurret3",
            "TT_ChaosTurret4",
            "TT_DummyPusher",
            "TT_Flytrap_A",
            "TT_Nexus_Gears",
            "TT_NGolem",
            "TT_NGolem2",
            "TT_NWolf",
            "TT_NWolf2",
            "TT_NWraith",
            "TT_NWraith2",
            "TT_OrderInhibitor",
            "TT_OrderInhibitor_D",
            "TT_OrderTurret1",
            "TT_OrderTurret2",
            "TT_OrderTurret3",
            "TT_OrderTurret4",
            "TT_Relic",
            "TT_Shopkeeper",
            "TT_Shroom_A",
            "TT_SpeedShrine",
            "TT_Speedshrine_Gears",
            "TT_Spiderboss",
            "TT_SpiderLayer_Web",
            "TT_Tree1",
            "TT_Tree_A",
            "Tutorial_Blue_Minion_Basic",
            "Tutorial_Blue_Minion_Wizard",
            "Tutorial_Red_Minion_Basic",
            "Tutorial_Red_Minion_Wizard",
            "TwistedFate",
            "Twitch",
            "Udyr",
            "UdyrPhoenix",
            "UdyrPhoenixUlt",
            "UdyrTiger",
            "UdyrTigerUlt",
            "UdyrTurtle",
            "UdyrTurtleUlt",
            "UdyrUlt",
            "Urf",
            "Urgot",
            "Varus",
            "Vayne",
            "Veigar",
            "Velkoz",
            "Vi",
            "Viktor",
            "ViktorSingularity",
            "VisionWard",
            "Vladimir",
            "VoidGate",
            "VoidSpawn",
            "VoidSpawnTracer",
            "Volibear",
            "Warwick",
            "wolf",
            "Worm",
            "Wraith",
            "Xerath",
            "XerathArcaneBarrageLauncher",
            "XinZhao",
            "Yasuo",
            "YellowTrinket",
            "YellowTrinketUpgrade",
            "Yonkey",
            "Yorick",
            "YorickDecayedGhoul",
            "YorickRavenousGhoul",
            "YorickSpectralGhoul",
            "YoungLizard",
            "Zac",
            "ZacRebirthBloblet",
            "Zed",
            "ZedShadow",
            "Ziggs",
            "Zilean",
            "Zyra",
            "ZyraGraspingPlant",
            "ZyraPassive",
            "ZyraSeed",
            "ZyraThornPlant"
        };

        #endregion

        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            CurrentModel = ObjectManager.Player.BaseSkinName;
            Game.OnInput += Game_OnInput;
            Game.OnUpdate += Game_OnUpdate;

            new Thread(
                () =>
                {
                    Config = new Menu("SkinHack", "SkinHack", true);
                    var versionJson = new WebClient().DownloadString(DataDragonBase + "realms/na.json");
                    var gameVersion =
                        (String)
                            ((Dictionary<String, Object>)
                                new JavaScriptSerializer().Deserialize<Dictionary<String, Object>>(versionJson)["n"])[
                                    "champion"];
                    foreach (var hero in ObjectManager.Get<Obj_AI_Hero>())
                    {
                        var champJson =
                            new WebClient().DownloadString(
                                DataDragonBase + "cdn/" + gameVersion + "/data/en_US/champion/" + hero.ChampionName +
                                ".json");
                        var skins =
                            (ArrayList)
                                ((Dictionary<String, Object>)
                                    ((Dictionary<String, Object>)
                                        new JavaScriptSerializer().Deserialize<Dictionary<String, Object>>(champJson)[
                                            "data"])[hero.ChampionName])["skins"];
                        var champMenu = new Menu(hero.ChampionName, hero.ChampionName, false);
                        foreach (Dictionary<string, object> skin in skins)
                        {
                            var skinName = skin["name"].ToString();
                            if (skinName.Equals("default"))
                            {
                                skinName = hero.ChampionName;
                            }
                            var changeSkin = champMenu.AddItem(new MenuItem(skinName, skinName).SetValue(false));

                            if (changeSkin.IsActive())
                            {
                                hero.SetSkin(hero.BaseSkinName, (int) skin["num"]);
                            }
                            changeSkin.ValueChanged += (s, e) =>
                            {
                                if (e.GetNewValue<bool>())
                                {
                                    champMenu.Items.ForEach(
                                        p =>
                                        {
                                            if (p.GetValue<bool>() && p.Name != skinName)
                                            {
                                                p.SetValue(false);
                                            }
                                        });
                                    CurrentModel = hero.ChampionName;
                                    CurrentSkin = (int) skin["num"];
                                    hero.SetSkin(CurrentModel, CurrentSkin);
                                }
                            };
                        }
                        Config.AddSubMenu(champMenu);
                    }
                    Config.AddToMainMenu();
                }).Start();
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            if (!HaveDied || ObjectManager.Player.IsDead)
            {
                HaveDied = ObjectManager.Player.IsDead;
                return;
            }

            ObjectManager.Player.SetSkin(CurrentModel, CurrentSkin);
        }

        private static void Game_OnInput(GameInputEventArgs args)
        {
            if (args.Input.StartsWith("/model"))
            {
                args.Process = false;
                var model = args.Input.Replace("/model ", string.Empty);

                if (!ModelList.Contains(model))
                {
                    return;
                }

                CurrentModel = model;
                CurrentSkin = 0;
                ObjectManager.Player.SetSkin(CurrentModel, CurrentSkin);
                return;
            }

            if (args.Input.StartsWith("/skin"))
            {
                args.Process = false;
                CurrentModel = ObjectManager.Player.BaseSkinName;
                CurrentSkin = Convert.ToInt32(args.Input.Replace("/skin ", string.Empty));
                ObjectManager.Player.SetSkin(CurrentModel, CurrentSkin);
            }
        }
    }
}