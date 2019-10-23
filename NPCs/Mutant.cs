using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Mutant : ModNPC
    {
        public static bool shop1;
        public static bool shop2;
        public static bool shop3;
        public static int shopnum = 1;
        
        public bool spawned;

        public override bool Autoload(ref string name)
        {
            name = "Mutant";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutant");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.breathCounter = 9999;

            npc.defense = NPC.downedMoonlord ? 50 : 15;
            npc.lifeMax = NPC.downedMoonlord ? 5000 : 250;

            if (Fargowiltas.instance.fargoLoaded && FargoDownedMutant)
            {
                npc.lifeMax = 7700000;
                npc.defense = 400;
            }

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)mod.ItemType("Mutant");
        }

        #region other mod bools

        //fargo bools
        public bool FargoDownedFishEX => FargowiltasSouls.FargoSoulsWorld.downedFishronEX;
        public bool FargoDownedMutant => FargowiltasSouls.FargoSoulsWorld.downedMutant;
        public bool MutantsDiscountCard => Main.player[Main.myPlayer].GetModPlayer<FargowiltasSouls.FargoPlayer>().MutantsDiscountCard;
        public bool MutantsPact => Main.player[Main.myPlayer].GetModPlayer<FargowiltasSouls.FargoPlayer>().MutantsPact;

        //thorium bools
        public bool ThoriumDownedBird => ThoriumMod.ThoriumWorld.downedThunderBird;
        public bool ThoriumDownedJelly => ThoriumMod.ThoriumWorld.downedJelly;
        public bool ThoriumDownedStorm => ThoriumMod.ThoriumWorld.downedStorm;
        public bool ThoriumDownedChamp => ThoriumMod.ThoriumWorld.downedChampion;
        public bool ThoriumDownedScout => ThoriumMod.ThoriumWorld.downedScout;
        public bool ThoriumDownedStrider => ThoriumMod.ThoriumWorld.downedStrider;
        public bool ThoriumDownedBeholder => ThoriumMod.ThoriumWorld.downedFallenBeholder;
        public bool ThoriumDownedLich => ThoriumMod.ThoriumWorld.downedLich;
        public bool ThoriumDownedAbyss => ThoriumMod.ThoriumWorld.downedDepthBoss;
        public bool ThoriumDownedRag => ThoriumMod.ThoriumWorld.downedRealityBreaker;
        public bool ThoriumDownedViscount => ThoriumMod.ThoriumWorld.downedBat;

        //calamity bools
        public bool CalamityDownedScourge => CalamityMod.World.CalamityWorld.downedDesertScourge;
        public bool CalamityDownedHive => CalamityMod.World.CalamityWorld.downedHiveMind;
        public bool CalamityDownedPerfor => CalamityMod.World.CalamityWorld.downedPerforator;
        public bool CalamityDownedSlime => CalamityMod.World.CalamityWorld.downedSlimeGod;
        public bool CalamityDownedCryo => CalamityMod.World.CalamityWorld.downedCryogen;
        public bool CalamityDownedBrim => CalamityMod.World.CalamityWorld.downedBrimstoneElemental;
        public bool CalamityDownedCalamitas => CalamityMod.World.CalamityWorld.downedCalamitas;
        public bool CalamityDownedLevi => CalamityMod.World.CalamityWorld.downedLeviathan;
        public bool CalamityDownedPlague => CalamityMod.World.CalamityWorld.downedPlaguebringer;
        public bool CalamityDownedGuardian => CalamityMod.World.CalamityWorld.downedGuardians;
        public bool CalamityDownedProv => CalamityMod.World.CalamityWorld.downedProvidence;
        public bool CalamityDownedDOG => CalamityMod.World.CalamityWorld.downedDoG;
        public bool CalamityDownedYharon => CalamityMod.World.CalamityWorld.downedYharon;
        public bool CalamityDownedSCAL => CalamityMod.World.CalamityWorld.downedSCal;
        public bool CalamityDownedRav => CalamityMod.World.CalamityWorld.downedScavenger;
        public bool CalamityDownedCrab => CalamityMod.World.CalamityWorld.downedCrabulon;
        public bool CalamityDownedAstrum => CalamityMod.World.CalamityWorld.downedStarGod;
        public bool CalamityDownedBirb => CalamityMod.World.CalamityWorld.downedBumble;
        public bool CalamityDownedPolter => CalamityMod.World.CalamityWorld.downedPolterghast;
        public bool CalamityDownedAquatic => CalamityMod.World.CalamityWorld.downedAquaticScourge;
        public bool CalamityDownedAstragel => CalamityMod.World.CalamityWorld.downedAstrageldon;

        //sacred tools bools
        public bool SacredDownedHarpy => SacredTools.ModdedWorld.downedHarpy;
        public bool SacredDownedHarpy2 => SacredTools.ModdedWorld.downedRaynare;
        public bool SacredDownedAbbadon => SacredTools.ModdedWorld.OblivionSpawns;
        public bool SacredDownedSerpent => SacredTools.ModdedWorld.FlariumSpawns;
        public bool SacredDownedLunar => SacredTools.ModdedWorld.downedLunarians;
        public bool SacredDownedPump => SacredTools.ModdedWorld.downedPumpboi;
        public bool SacreddownedDecree => SacredTools.ModdedWorld.downedDecree;
        public bool SacreddownedPrimordia => SacredTools.ModdedWorld.downedPrimordia;
        public bool SacreddownedAraneas => SacredTools.ModdedWorld.downedAraneas;

        //grealm bools
        public bool GRealmDownedFolivine => GRealm.MWorld.downedFolivine;
        public bool GRealmDownedMantid => GRealm.MWorld.downedMatriarch;

        //pumpking
        public bool PumpkingDownedHorse => Pumpking.PumpkingWorld.downedPumpkingHorseman;
        public bool PumpkingDownedTerra => Pumpking.PumpkingWorld.downedTerraLord;

        //joost
        public bool JoostDownedCactuar => JoostMod.JoostWorld.downedJumboCactuar;
        public bool JoostDownedSAX => JoostMod.JoostWorld.downedSAX;
        public bool JoostDownedGilga => JoostMod.JoostWorld.downedGilgamesh;

        //tremor
        public bool TremorDownedCorn => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.EvilCorn];
        public bool TremorDownedRukh => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Rukh];
        public bool TremorDownedFungus => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FungusBeetle];
        public bool TremorDownedWhale => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.SpaceWhale];
        public bool TremorDownedTrinity => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Trinity];
        public bool TremorDownedTotem => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.TikiTotem];
        public bool TremorDownedJelly => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.StormJellyfish];
        public bool TremorDownedCyber => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CyberKing];
        public bool TremorDownedHeater => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.HeaterofWorlds];
        public bool TremorDownedFrost => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FrostKing];
        public bool TremorDownedEmperor => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.DarkEmperor];
        public bool TremorDownedPixie => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.PixieQueen];
        public bool TremorDownedAlchemaster => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Alchemaster];
        public bool TremorDownedBrutallisk => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Brutallisk];
        public bool TremorDownedCog => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CogLord];
        public bool TremorDownedWall => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.WallOfShadow];
        public bool TremorDownedMotherboard => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Motherboard];
        public bool TremorDownedDragon => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.AncientDragon];
        public bool TremorDownedAndas => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Andas];

        //spirit
        public bool SpiritDownedScarab => SpiritMod.MyWorld.downedScarabeus;
        public bool SpiritDownedFlier => SpiritMod.MyWorld.downedAncientFlier;
        public bool SpiritDownedRaider => SpiritMod.MyWorld.downedRaider;
        public bool SpiritDownedInfer => SpiritMod.MyWorld.downedInfernon;
        public bool SpiritDownedDusking => SpiritMod.MyWorld.downedDusking;
        public bool SpiritDownedIlluminant => SpiritMod.MyWorld.downedIlluminantMaster;
        public bool SpiritDownedAtlas => SpiritMod.MyWorld.downedAtlas;
        public bool SpiritDownedOverseer => SpiritMod.MyWorld.downedOverseer;
        public bool SpiritDownedVine => SpiritMod.MyWorld.downedReachBoss;
        public bool SpiritDownedUmbra => SpiritMod.MyWorld.downedSpiritCore;

        //BTFA
        public bool BtfaTitan => ForgottenMemories.TGEMWorld.downedTitanRock;
        public bool BtfaAcheron => ForgottenMemories.TGEMWorld.downedAcheron;
        public bool BtfaArtery => ForgottenMemories.TGEMWorld.downedArterius;
        public bool BtfaGhastly => ForgottenMemories.TGEMWorld.downedGhastlyEnt;

        //Bluemagics
        public bool BlueDownedPhantom => Bluemagic.BluemagicWorld.downedPhantom;
        public bool BlueDownedAbom => Bluemagic.BluemagicWorld.downedAbomination;

        //Eota
        public bool AncientsDownedWorms => EchoesoftheAncients.AncientWorld.downedWyrms;

        //Crystilium
        public bool CrystiliumDownedKing => CrystiliumMod.CrystalWorld.downedCrystalKing;

        //W1K
        public bool W1KDownedKutku => W1KModRedux.MWorld.downedKutKu;
        public bool W1KDownedArdorix => W1KModRedux.MWorld.downedArdorix;
        public bool W1KDownedArborix => W1KModRedux.MWorld.downedArborix;
        public bool W1KDownedAquatix => W1KModRedux.MWorld.downedAquatix;
        public bool W1KDownedIvy => W1KModRedux.MWorld.downedIvy;
        public bool W1KDownedDeath => W1KModRedux.MWorld.downedDeath;
        public bool W1KDownedRathalos => W1KModRedux.MWorld.downedRathalos;
        public bool W1KDownedRidley => W1KModRedux.MWorld.downedRidley;
        public bool W1KDownedOkiku => W1KModRedux.MWorld.downedOkiku;

        //fernium
        /*public bool FerniumDownedMargrama => Fernium.world.downedMargrama;
        public bool FerniumDownedLunarRex => Fernium.world.downedLunarRex;
        public bool FerniumFernite => Fernium.world.downedFerniteTheUnpleasant;*/

        //elements awoken
        public bool ElementsDownedWaste => ElementsAwoken.MyWorld.downedWasteland;
        public bool ElementsDownedInfern => ElementsAwoken.MyWorld.downedInfernace;
        public bool ElementsDownedScourge => ElementsAwoken.MyWorld.downedScourgeFighter;
        public bool ElementsDownedReg => ElementsAwoken.MyWorld.downedRegaroth;
        public bool ElementsDownedCelestial => ElementsAwoken.MyWorld.downedCelestial;
        public bool ElementsDownedObsid => ElementsAwoken.MyWorld.downedObsidious;
        public bool ElementsDownedPerma => ElementsAwoken.MyWorld.downedPermafrost;
        public bool ElementsDownedAque => ElementsAwoken.MyWorld.downedAqueous;
        public bool ElementsDownedDragon => ElementsAwoken.MyWorld.downedAncientWyrm;
        public bool ElementsDownedGuardian => ElementsAwoken.MyWorld.downedGuardian;
        public bool ElementsDownedVoid => ElementsAwoken.MyWorld.downedVoidLeviathan;

        public bool ElementsDownedVolcanox => ElementsAwoken.MyWorld.downedVolcanox;
        public bool ElementsDownedAzana => ElementsAwoken.MyWorld.downedAzana;

        //antiaris
        public bool AntiarisDownedAntlion => Antiaris.AntiarisWorld.DownedAntlionQueen;
        public bool AntiarisDownedKeeper => Antiaris.AntiarisWorld.DownedTowerKeeper;

        //disarray
        public bool DisarrayDownedPlant => Disarray.DisarrayWorld.downedPlantKing;
        public bool DisarrayDownedCrusher => Disarray.DisarrayWorld.downedDesertCrusher;
        public bool DisarrayDownedProbe => Disarray.DisarrayWorld.downedProbeMother;
        public bool DisarrayDownedGeneral => Disarray.DisarrayWorld.downedTheGeneral;
        public bool DisarrayDownedSerpent => Disarray.DisarrayWorld.downedLunarSerpent;
        public bool DisarrayDownedCold => Disarray.DisarrayWorld.downedColdBoss;
        public bool DisarrayDownedShadows => Disarray.DisarrayWorld.downedShadows;
        public bool DisarrayDownedLuna => Disarray.DisarrayWorld.downedLuna;
        public bool DisarrayDownedBell => Disarray.DisarrayWorld.downedBell;
        public bool DisarrayDownedMech => Disarray.DisarrayWorld.downedMech;
        public bool DisarrayDownedSludge => Disarray.DisarrayWorld.downedCosmicSludge;
        public bool DisarrayDownedDeva => Disarray.DisarrayWorld.downedCoreOfTheDevastator;
        public bool DisarrayDownedMeteor => Disarray.DisarrayWorld.downedMeteorzoid;
        public bool DisarrayDownedDungeon => Disarray.DisarrayWorld.downedDungeon;

        //cookie
        public bool CookieDownedCookie => CookieMod.CookieModWorld.downedCookieBoss;
        public bool CookieDownedBunny => CookieMod.CookieModWorld.downedBunny;

        //enigma
        public bool EnigmaDownedAnnih => Laugicality.LaugicalityWorld.downedAnnihilator;
        public bool EnigmaDownedSlyber => Laugicality.LaugicalityWorld.downedSlybertron;
        public bool EnigmaDownedTrain => Laugicality.LaugicalityWorld.downedSteamTrain;
        public bool EnigmaDownedShark => Laugicality.LaugicalityWorld.downedDuneSharkron;
        public bool EnigmaDownedHypo => Laugicality.LaugicalityWorld.downedHypothema;
        public bool EnigmaDownedRagnar => Laugicality.LaugicalityWorld.downedRagnar;
        public bool EnigmaDownedRocks => Laugicality.LaugicalityWorld.downedRocks;
        public bool EnigmaDownedEther => Laugicality.LaugicalityWorld.downedTrueEtheria;
        public bool EnigmaDownedDio => Laugicality.LaugicalityWorld.downedAnDio;

        //trelamium 
        public bool TrelamiumAzolinth => TrelamiumMod.TrelamiumModWorld.downedAzolinth;
        public bool TrelamiumSerpent => TrelamiumMod.TrelamiumModWorld.downedCrystallineSerpent;
        public bool TrelamiumCumulor => TrelamiumMod.TrelamiumModWorld.downedCumulor;
        public bool TrelamiumParadox => TrelamiumMod.TrelamiumModWorld.downedParadoxHive;
        public bool TrelamiumPermafrost => TrelamiumMod.TrelamiumModWorld.downedPermafrost;
        public bool TrelamiumGoliath => TrelamiumMod.TrelamiumModWorld.downedPholiotaGoliath;
        public bool TrelamiumPyron => TrelamiumMod.TrelamiumModWorld.downedPyron;
        public bool TrelamiumSymphony => TrelamiumMod.TrelamiumModWorld.downedSymphony;

        //Ancients Awakened
        public bool AAMonarch => AAMod.AAWorld.downedMonarch;
        public bool AAFungus => AAMod.AAWorld.downedFungus;
        public bool AAGrips => AAMod.AAWorld.downedGrips;
        public bool AABrood => AAMod.AAWorld.downedBrood;
        public bool AAHydra => AAMod.AAWorld.downedHydra;
        public bool AAToad => AAMod.AAWorld.downedToad;
        public bool AADjinn => AAMod.AAWorld.downedDjinn;
        public bool AASerpent => AAMod.AAWorld.downedSerpent;
        public bool AASag => AAMod.AAWorld.downedSag;
        public bool AARetriever => AAMod.AAWorld.downedRetriever;
        public bool AARaider => AAMod.AAWorld.downedRaider;
        public bool AAOrthrus => AAMod.AAWorld.downedOrthrus;
        public bool AATruffle => AAMod.AAWorld.downedTruffle;
        public bool AARajah => AAMod.AAWorld.downedRajah;
        public bool AAEquinox => AAMod.AAWorld.downedEquinox;
        public bool AASisters => AAMod.AAWorld.downedSisters;
        public bool AAYamata => AAMod.AAWorld.downedYamata;
        public bool AAYamataA => AAMod.AAWorld.downedYamata && Main.expertMode;
        public bool AAAkuma => AAMod.AAWorld.downedAkuma;
        public bool AAAkumaA => AAMod.AAWorld.downedAkuma && Main.expertMode;
        public bool AAZero => AAMod.AAWorld.downedZero;
        public bool AAZeroA => AAMod.AAWorld.downedZero && Main.expertMode;
        public bool AAShen => AAMod.AAWorld.downedShen;
        public bool AAShenA => AAMod.AAWorld.downedShen && Main.expertMode;
        public bool AAIZ => AAMod.AAWorld.downedIZ;
        public bool AASoC => AAMod.AAWorld.downedSoC;

        //pinky
        public bool PinkySlime => pinkymod.Global.Pinkyworld.downedMythrilSlime;
        public bool PinkyValdaris => pinkymod.Global.Pinkyworld.downedValdaris;
        public bool PinkySunlight => pinkymod.Global.Pinkyworld.downedSunlightTrader;
        public bool PinkyAbyssmal => pinkymod.Global.Pinkyworld.downedAbyssmalDuo;

        //Redemption
        public bool RedeChicken => Redemption.RedeWorld.downedKingChicken;
        public bool RedeThorn => Redemption.RedeWorld.downedThorn;
        public bool RedeKeeper => Redemption.RedeWorld.downedTheKeeper;
        public bool RedeXeno => Redemption.RedeWorld.downedXenomiteCrystal;
        public bool RedeEye => Redemption.RedeWorld.downedInfectedEye;
        public bool RedePortal => Redemption.RedeWorld.downedStrangePortal;
        public bool RedeGigipede => Redemption.RedeWorld.downedVlitch2;
        public bool RedeCleaver => Redemption.RedeWorld.downedVlitch1;
        public bool RedeSlayer => Redemption.RedeWorld.downedSlayer;
        public bool RedeOmega => Redemption.RedeWorld.downedVlitch3;
        public bool RedeThornPZ => Redemption.RedeWorld.downedThornPZ;
        public bool RedeEaglecrestPZ => Redemption.RedeWorld.downedEaglecrestGolemPZ;
        public bool RedeNeb => Redemption.RedeWorld.downedNebuleus;

        //Jetshift

        /*public bool JSSnake => Jetshift.JetshiftWorld.downedSnakeBoss;
        public bool JSReaper => Jetshift.JetshiftWorld.downedReaper;
        public bool JSViyilblud => Jetshift.JetshiftWorld.downedViyilblud;
        public bool JSWall => Jetshift.JetshiftWorld.downedWallofVoices;
        public bool JSArlenon => Jetshift.JetshiftWorld.downedArlenon;
        public bool JSAthazel => Jetshift.JetshiftWorld.downedAthazel;
        public bool JSPolypus => Jetshift.JetshiftWorld.downedPolypus;
        public bool JSFrezyn => Jetshift.JetshiftWorld.downedFrezyn;
        public bool JSMortalos => Jetshift.JetshiftWorld.downedMortalos;
        public bool JSShift => Jetshift.JetshiftWorld.downedShiftFinal;
        public bool JSAnnihilation => Jetshift.JetshiftWorld.downedAnnihilation;
        public bool JSCCP1 => Jetshift.JetshiftWorld.downedCCP1;
        public bool JSCCP2 => Jetshift.JetshiftWorld.downedCCP2;
        public bool JSCosmic => Jetshift.JetshiftWorld.downedCosmicMystery;*/

        //ocram
        public bool OcramOcram => Ocram.OcramWorld.downedOcram;

        #endregion other mod bools
        
        public override void AI()
        {
            if (!spawned)
            {
                spawned = true;
                if (Fargowiltas.instance.fargoLoaded && FargoDownedMutant)
                {
                    npc.life = 7700000;
                    npc.lifeMax = 7700000;
                    npc.defense = 400;
                    npc.defDefense = 400;
                }
            }
        }

        public override bool CanTownNPCSpawn(int numTownnpcs, int money)
        {
            return Fargowiltas.instance.fargoLoaded ? (FargoWorld.downedBoss && !NPC.AnyNPCs(ModLoader.GetMod("FargowiltasSouls").NPCType("MutantBoss"))) : FargoWorld.downedBoss;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(13))
            {
                case 0:
                    return "Flacken";

                case 1:
                    return "Dorf";

                case 2:
                    return "Bingo";

                case 3:
                    return "Hans";

                case 4:
                    return "Fargo";

                case 5:
                    return "Grim";

                case 6:
                    return "Furgo";

                case 7:
                    return "Fargu";

                case 8:
                    return "Terrance";

                case 9:
                    return "Catty N. Pem";

                case 10:
                    return "Tom";

                case 11:
                    return "Weirdus";

                default:
                    return "Polly";
            }
        }

        public override string GetChat()
        {
            if (Main.rand.Next(25) == 0)
            {
                if (Fargowiltas.instance.fargoLoaded)
                {
                    if (FargoDownedMutant)
                        return "What's that? You want to fight me? ...sure, I guess.";
                    if (FargoDownedFishEX)
                        return "What's that? You want to fight me? ...maybe if I had a reason.";
                }
                return "What's that? You want to fight me? ...you're not worthy you rat.";
            }
        
            if (NPC.downedMoonlord && Fargowiltas.instance.fargoLoaded && Main.rand.Next(32) == 0)
            {
                return "Now that you've defeated the big guy, I'd say it's time to start collecting those materials!";
            }

            if (Fargowiltas.instance.calamityLoaded && Main.rand.Next(63) == 0)
            {
                return "Why would you do this.";
            }

            if (Fargowiltas.instance.calamityLoaded && Fargowiltas.instance.thoriumLoaded && Main.rand.Next(62) == 0)
            {
                return "I feel a great imbalance in this world.";
            }

            if (Fargowiltas.instance.thoriumLoaded && Main.rand.Next(61) == 0)
            {
                return "A great choice, shame about that first desert boss thing though.";
            }

            if (Main.pumpkinMoon)
            {
                return "A bit spooky tonight, isn't it.";
            }

            if (Main.snowMoon)
            {
                return "I'd ask for a coat, but I don't think you have any my size.";
            }

            if (Main.slimeRain)
            {
                return "Weather seems odd today, wouldn't you agree?";
            }

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(1))
                {
                    case 0:
                        return "Lovely night, isn't it?";

                    default:
                        return "I hope the constant arguing I'm hearing isn't my fault.";
                }
            }

            //specific other npc quotes
            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
            int dryad = NPC.FindFirstNPC(NPCID.Dryad);
            int stylist = NPC.FindFirstNPC(NPCID.Stylist);
            int guide = NPC.FindFirstNPC(NPCID.Guide);
            int tax = NPC.FindFirstNPC(NPCID.TaxCollector);
            int truffle = NPC.FindFirstNPC(NPCID.Truffle);
            int cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            int demoman = NPC.FindFirstNPC(NPCID.Demolitionist);
            int tavernkeep = NPC.FindFirstNPC(NPCID.DD2Bartender);
            int dyeTrader = NPC.FindFirstNPC(NPCID.DyeTrader);
            int lumberJack = NPC.FindFirstNPC(mod.NPCType("LumberJack"));

            if (BirthdayParty.PartyIsUp)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return Main.npc[partyGirl].GivenName + " is the one who invited me, I don't understand why though.";

                    default:
                        return "I don't know what everyone's so happy about, but as long as nobody mistakes me for a Pigronata, I'm happy too.";
                }
            }

            if (lumberJack >= 0 && Main.rand.Next(60) == 0)
            {
                return "It's okay " + Main.npc[npc.whoAmI].GivenName + ", just don't look straight into " + Main.npc[lumberJack].GivenName + "'s eyes. He can't scare you that way...";
            }
            if (nurse >= 0 && Main.rand.Next(59) == 0)
            {
                return "Whenever we're alone, " + Main.npc[nurse].GivenName + " keeps throwing syringes at me, no matter how many times I tell her to stop!";
            }
            if (witchDoctor >= 0 && Main.rand.Next(58) == 0)
            {
                return "Please go tell " + Main.npc[witchDoctor].GivenName + " to drop the 'mystical' shtick, I mean, come on! I get it, you make tainted water or something.";
            }
            if (dryad >= 0 && Main.rand.Next(57) == 0)
            {
                return "Why does " + Main.npc[dryad].GivenName + "'s outfit make my wings flutter?";
            }
            if (stylist >= 0 && Main.rand.Next(56) == 0)
            {
                return Main.npc[stylist].GivenName + " once gave me a wig... I look hideous with long hair.";
            }
            if (truffle >= 0 && Main.rand.Next(55) == 0)
            {
                return "That mutated mushroom seems like my type of fella.";
            }
            if (tax >= 0 && Main.rand.Next(54) == 0)
            {
                return Main.npc[tax].GivenName + " keeps asking me for money, but he won't accept my spawners!";
            }
            if (guide >= 0 && Main.rand.Next(53) == 0)
            {
                return "Any idea why " + Main.npc[guide].GivenName + " is always cowering in fear when I get near him?";
            }
            if (truffle >= 0 && witchDoctor >= 0 && cyborg >= 0 && Main.rand.Next(52) == 0)
            {
                return "If any of us could play instruments, I'd totally start a band with " + Main.npc[witchDoctor].GivenName + ", " + Main.npc[truffle].GivenName + ", and " + Main.npc[cyborg].GivenName + ".";
            }
            if (partyGirl >= 0 && Main.rand.Next(51) == 0)
            {
                return "Man," + Main.npc[partyGirl].GivenName + "'s confetti keeps getting stuck to my wings";
            }
            if (demoman >= 0 && Main.rand.Next(50) == 0)
            {
                return "I'm surprised " + Main.npc[demoman].GivenName + " hasn't blown a hole in the floor yet, on second thought that sounds fun.";
            }
            if (tavernkeep >= 0 && Main.rand.Next(49) == 0)
            {
                return Main.npc[tavernkeep].GivenName + " keeps suggesting I drink some beer, something tells me he wouldn't like me when I'm drunk though.";
            }
            if (dyeTrader >= 0 && Main.rand.Next(48) == 0)
            {
                return Main.npc[dyeTrader].GivenName + " wants to see what I would look like in blue... I don't know how to feel.";
            }

            if (Main.dayTime != true && Main.rand.Next(20) == 0)
            {
                return "I'd follow and help, but I'd much rather sit around right now.";
            }

            switch (Main.rand.Next(45))
            {
                case 0:
                    return "Savagery, barbarism, bloodthirst, that's what I like seeing in people.";
                case 1:
                    return "The stronger you get, the more stuff I sell. Makes sense, right?";
                case 2:
                    return "There's something all of you have that I don't... Death perception, I think it's called?";
                case 3:
                    return "It would be pretty cool if I sold a summon for myself...";
                case 4:
                    return "The only way to get stronger is to keep buying from me and in bulk too!";
                case 5:
                    return "Why are you looking at me like that, all I did was eat an apple.";
                case 6:
                    return "Don't bother with anyone else, all you'll ever need is right here.";
                case 7:
                    return "You're lucky I'm on your side.";
                case 8:
                    return "Thanks for the house, I guess.";
                case 9:
                    return "Why yes I would love a ham and swiss sandwich.";
                case 10:
                    return "Should I start wearing clothes? ...Nah.";
                case 11:
                    return "It's not like I can actually use all the gold you're spending.";
                case 12:
                    return "Violence for violence is the law of the beast.";
                case 13:
                    return "Those guys really need to get more creative. All of their first bosses are desert themed!";
                case 14:
                    return "You say you want to know how a Mutant and Abominationn are brothers? You're better off not knowing.";
                case 15:
                    return "I'm all you need for a calamity.";
                case 16:
                    return "Everything shall bow before me! ...after you make this purchase.";
                case 17:
                    return "It's clear that I'm helping you out, but uh.. what's in this for me? A house you say? I eat zombies for breakfast.";
                case 18:
                    return "Can I jump? No, I don't have something called a 'spacebar'.";
                case 19:
                    return "Got your nose, I needed one to replace mine.";
                case 20:
                    return "What's a Terry?";
                case 21:
                    return "Why do so many creatures carry around a weird looking blue doll? The world may never know.";
                case 22:
                    return "Impending doom approaches. ...If you don't buy anything of course.";
                case 23:
                    return "I've heard of a '3rd dimension', I wonder what that looks like.";
                case 24:
                    return "Boy don't I look fabulous today.";
                case 25:
                    return "You have fewer friends than I do eyes.";
                case 26:
                    return "The ocean is a dangerous place, I wonder where Diver is?";
                case 27:
                    return "Do you know what an Ee-arth is?";
                case 28:
                    return "I can't even spell 'apotheosis', do you expect me to know what it is?";
                case 29:
                    return "Where do monsters get their gold from? ...I don't have pockets you know.";
                case 30:
                    return "Dogs are cool and all, but cats dont try to bite my brain.";
                case 31:
                    return "Beware the green dragon... What's that face mean?";
                case 32:
                    return "Where is this O-hi-o I keep hearing about.";
                case 33:
                    return "I've told you 56 times already, I'm busy... Oh wait you want to buy something, I suppose I have time.";
                case 34:
                    return "I've heard of a 'Soul of Souls' that only exists in 2015.";
                case 35:
                    return "Adding EX after everything makes it way more difficult.";
                case 36:
                    return "I think that all modern art looks great, especially the bloody stuff.";
                case 37:
                    return "How many guides does it take to change a lightbulb? ... I don't know, how about you ask him.";
                case 38:
                    return "Good thing I don't have a bed, I'd probably never leave it.";
                case 39:
                    return "What's this about an update? Sounds rare.";
                case 40:
                    return "If you need me I'll be slacking off somewhere.";
                case 41:
                    return "What do you mean who is Fargo!";
                case 42:
                    return "Have you seen the ech cat?";
                case 43:
                    return "I don't understand music nowadays, I prefer some smooth jazz... or the dying screams of monsters.";
                default:
                    return "Cthulhu's got nothing on me!";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            switch (shopnum)
            {
                case 1:
                    button = "Pre Hardmode";
                    break;
                case 2:
                    button = "Hardmode";
                    break;
                default:
                    button = "Post Moon Lord";
                    break;
            }

            if (Main.hardMode)
            {
                button2 = "Cycle Shop";
            }

            if (NPC.downedMoonlord)
            {
                if (shopnum >= 4)
                {
                    shopnum = 1;
                }
            }
            else
            {
                if (shopnum >= 3)
                {
                    shopnum = 1;
                }
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;

                switch (shopnum)
                {
                    case 1:
                        shop1 = true;
                        shop2 = false;
                        shop3 = false;
                        break;
                    case 2:
                        shop2 = true;
                        shop1 = false;
                        shop3 = false;
                        break;
                    default:
                        shop3 = true;
                        shop1 = false;
                        shop2 = false;
                        break;
                }
            }
            else if (!firstButton && Main.hardMode)
            {
                shopnum++;
            }
        }

        private void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (!check) return;
            shop.item[nextSlot].SetDefaults(ModLoader.GetMod(mod).ItemType(item));
            shop.item[nextSlot].value = price;
            if (Fargowiltas.instance.fargoLoaded) //lowered prices with discount card and pact
            {
                float modifier = 1f;
                if (MutantsDiscountCard)
                    modifier -= 0.2f;
                if (MutantsPact)
                    modifier -= 0.3f;
                shop.item[nextSlot].value = (int)(shop.item[nextSlot].value * modifier);
            }
            nextSlot++;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            AddItem(true, "Fargowiltas", "Overloader", 400000, ref shop, ref nextSlot);

            #region PREHARDMODE BOSSES

            if (shop1)
            {
                if (Fargowiltas.instance.fargoLoaded)
                {
                    AddItem(true, "FargowiltasSouls", "Masochist", 10000, ref shop, ref nextSlot); //mutants gift, dam meme namer
                }

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    //The Mighty King Chicken
                    AddItem(RedeChicken, "Redemption", "EggCrown", 50000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.aaLoaded)
                {
                    //Mushroom Monarch
                    AddItem(AAMonarch, "AAMod", "IntimidatingMushroom", 20000, ref shop, ref nextSlot);
                    AddItem(AAFungus, "AAMod", "ConfusingMushroom", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Scarabeus
                    AddItem(SpiritDownedScarab, "SpiritMod", "ScarabIdol", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedPlant, "Disarray", "YoungSapling", 20000, ref shop, ref nextSlot);
                }

                if(Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumGoliath, "TrelamiumMod", "MycelialCluster", 20000, ref shop, ref nextSlot);
                }

                //antlion queen - true eater

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Grand Thunderbird
                    AddItem(ThoriumDownedBird, "ThoriumMod", "StormFlare", 50000, ref shop, ref nextSlot);
                }
                
                //Slime King
                AddItem(NPC.downedSlimeKing, "Fargowiltas", "SlimyCrown", 60000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    AddItem(RedeThorn, "Redemption", "HeartOfTheThorns", 60000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedCrusher, "Disarray", "ScorpionIdol", 60000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Desert Scourge
                    AddItem(CalamityDownedScourge, "CalamityMod", "DriedSeafood", 60000, ref shop, ref nextSlot);
                }
                
                //Eye of Cthulhu
                AddItem(NPC.downedBoss1, "Fargowiltas", "SuspiciousEye", 80000, ref shop, ref nextSlot);

                if(Fargowiltas.instance.aaLoaded)
                {
                    //Grips of Chaos
                    AddItem(AAGrips, "AAMod", "CuriousClaw", 80000, ref shop, ref nextSlot);
                    AddItem(AAGrips, "AAMod", "InterestingClaw", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacreddownedDecree, "SacredTools", "DecreeSummon", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    //Keeper
                    if (WorldGen.crimson)
                    {
                        AddItem(RedeKeeper, "Redemption", "MysteriousTabletCrimson", 80000, ref shop, ref nextSlot);
                    }
                    else
                    {
                        AddItem(RedeKeeper, "Redemption", "MysteriousTabletCorrupt", 80000, ref shop, ref nextSlot);
                    }
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedKutku, "W1KModRedux", "GoldenFeather", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedShark, "Laugicality", "TastyMorsel", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedHypo, "Laugicality", "ChilledMesh", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedProbe, "Disarray", "ProbeCaller", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedRagnar, "Laugicality", "MoltenMess", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedWaste, "ElementsAwoken", "WastelandSummon", 80000, ref shop, ref nextSlot);
                }

                //The Spirit - Split

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Rukh
                    AddItem(TremorDownedRukh, "Tremor", "DesertCrown", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Crabulon
                    AddItem(CalamityDownedCrab, "CalamityMod", "DecapoditaSprout", 80000, ref shop, ref nextSlot);
                }
                
                //Eater of Worlds
                AddItem(NPC.downedBoss2, "Fargowiltas", "WormyFood", 100000, ref shop, ref nextSlot);
                //Brain of Cthulhu
                AddItem(NPC.downedBoss2, "Fargowiltas", "GoreySpine", 100000, ref shop, ref nextSlot);

                if(Fargowiltas.instance.aaLoaded)
                {
                    //Broodmother
                    AddItem(AABrood, "AAMod", "DragonBell", 100000, ref shop, ref nextSlot);
                    //Hydra
                    AddItem(AAHydra, "AAMod", "HydraChow", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    //Strange Portal
                    AddItem(RedePortal, "Redemption", "UnstableCrystal", 100000, ref shop, ref nextSlot);
                    AddItem(RedePortal, "Redemption", "GeigerCounter", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.cookieLoaded)
                {
                    AddItem(CookieDownedCookie, "CookieMod", "BloodyCookie", 100000, ref shop, ref nextSlot);
                    AddItem(CookieDownedCookie, "CookieMod", "CursedCookie", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumCumulor, "TrelamiumMod", "StormyCloud", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Queen Jellyfish
                    AddItem(ThoriumDownedJelly, "ThoriumMod", "JellyfishResonator", 100000, ref shop, ref nextSlot);
                    //Viscount
                    AddItem(ThoriumDownedViscount, "Fargowiltas", "ViscountSummon", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Tiki Totem
                    AddItem(TremorDownedTotem, "Tremor", "MysteriousDrum", 100000, ref shop, ref nextSlot);
                }

                //One Shot -Split

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Evil Corn
                    AddItem(TremorDownedCorn, "Tremor", "CursedPopcorn", 100000, ref shop, ref nextSlot);
                }

                /*if (Fargowiltas.instance.ferniumLoaded)
                {
                    AddItem(FerniumDownedMargrama, "Fernium", "LunarFlame", 100000, ref shop, ref nextSlot);
                }
                */
                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedGeneral, "Disarray", "TornBattleArmor", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Perforators
                    AddItem(CalamityDownedPerfor, "CalamityMod", "BloodyWormFood", 100000, ref shop, ref nextSlot);
                    //Hive Mind
                    AddItem(CalamityDownedHive, "CalamityMod", "Teratoma", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.grealmLoaded)
                {
                    //Folvine
                    AddItem(GRealmDownedFolivine, "GRealm", "JungleBait", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Storm Jellyfish
                    AddItem(TremorDownedJelly, "Tremor", "StormJelly", 100000, ref shop, ref nextSlot);
                }

                //Clampula - True Eater

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedVine, "SpiritMod", "ReachBossSummon", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Ancient Dragon
                    AddItem(TremorDownedDragon, "Tremor", "RustyLantern", 100000, ref shop, ref nextSlot);
                }
                if (Fargowiltas.instance.JSLoaded)
                {
                    //Viyilblud
                    //AddItem(JSViyilblud, "Jetshift", "CorruptedShard", 100000, ref shop, ref nextSlot);
                }

                //Queen Bee
                AddItem(NPC.downedQueenBee, "Fargowiltas", "Abeemination2", 150000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedSerpent, "Disarray", "MoonStone", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.nightmaresLoaded)
                {
                    AddItem(NPC.downedBoss3, "TrueEater", "SpitterSpawner", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.JSLoaded)
                {
                    //Serperannus
                    //AddItem(JSSnake, "Jetshift", "SoilBall", 100000, ref shop, ref nextSlot);
                }

                //magnoliac - btfa ?

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedFlier, "SpiritMod", "JewelCrown", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.antiarisLoaded)
                {
                    AddItem(AntiarisDownedAntlion, "Antiaris", "AntlionDoll", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    //Flaming Pumpkin
                    AddItem(SacredDownedPump, "SacredTools", "PumpkinLantern", 150000, ref shop, ref nextSlot);
                }
                //Skeletron
                AddItem(NPC.downedBoss3, "Fargowiltas", "SuspiciousSkull", 150000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.aaLoaded)
                {
                    AddItem(AADjinn, "AAMod", "DjinnLamp ", 150000, ref shop, ref nextSlot);
                    AddItem(AASerpent, "AAMod", "SubzeroCrystal ", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.cookieLoaded)
                {
                    AddItem(CookieDownedBunny, "CookieMod", "BunnyCrown ", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumSymphony, "TrelamiumMod", "LamentedPearl", 150000, ref shop, ref nextSlot);
                }
                
                if(Fargowiltas.instance.pinkyLoaded)
                {
                    AddItem(PinkySunlight, "pinkymod", "STItem", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedIvy, "W1KModRedux", "CursedFlower", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedArdorix, "W1KModRedux", "FieryEgg", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedArborix, "W1KModRedux", "GrassyEgg", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedAquatix, "W1KModRedux", "WateryEgg", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.aaLoaded)
                {
                    //
                    AddItem(AAToad, "AAMod", "Toadstool", 15000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Starplate Raider
                    AddItem(SpiritDownedRaider, "SpiritMod", "StarWormSummon", 150000, ref shop, ref nextSlot);
                }

                //the cluster -peculiarity

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Granite Core
                    AddItem(ThoriumDownedStorm, "ThoriumMod", "UnstableCore", 150000, ref shop, ref nextSlot);
                }

                /*if (Fargowiltas.instance.ferniumLoaded)
                {
                    AddItem(FerniumDownedMargrama, "Fernium", "HardenedSludge", 150000, ref shop, ref nextSlot);
                }*/

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedInfern, "ElementsAwoken", "InfernaceSummon", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedCold, "Disarray", "PermaFreeze", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Slime God
                    AddItem(CalamityDownedSlime, "CalamityMod", "OverloadedSludge", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.btfaLoaded)
                {
                    AddItem(BtfaAcheron, "ForgottenMemories", "Unstable_Wisp", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Heater of Worlds
                    AddItem(TremorDownedHeater, "Tremor", "MoltenHeart", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedHarpy, "SacredTools", "HarpySummon", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Buried Champion
                    AddItem(ThoriumDownedChamp, "ThoriumMod", "AncientBlade", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedDio, "Laugicality", "AncientAwakener", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Fungus Beetle
                    AddItem(TremorDownedFungus, "Tremor", "MushroomCrystal", 150000, ref shop, ref nextSlot);
                }

                //alpha cactus worm - joost

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Star Scouter
                    AddItem(ThoriumDownedScout, "ThoriumMod", "StarCaller", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.JSLoaded)
                {
                    //Torvames 
                    //AddItem(JSReaper, "Jetshift", "Curse", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.aaLoaded)
                {
                    //Sagittarius
                    AddItem(AASag, "AAMod", "Lifescanner", 150000, ref shop, ref nextSlot);
                }

                //Wall of Flesh
                AddItem(Main.hardMode, "Fargowiltas", "FleshyDoll", 250000, ref shop, ref nextSlot);
                //All Pre-HM bosses
                AddItem(Main.hardMode, "Fargowiltas", "DeathBringerFairy", 500000, ref shop, ref nextSlot);
            }

            #endregion PREHARDMODE BOSSES

            #region HARDMODE BOSSES

            else if (shop2)
            {
                if (Fargowiltas.instance.fargoLoaded)
                {
                    AddItem(true, "FargowiltasSouls", "PandorasBox", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    AddItem(RedeEye, "Redemption", "XenoEye", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Borean Strider
                    AddItem(ThoriumDownedStrider, "ThoriumMod", "StriderTear", 250000, ref shop, ref nextSlot);
                }
                if (Fargowiltas.instance.JSLoaded)
                {
                    //Wall of Voices 
                    //AddItem(JSWall, "Jetshift", "CursedWall", 250000, ref shop, ref nextSlot);
                }

                /*if(Fargowiltas.instance.ferniumLoaded)
                {
                    AddItem(FerniumFernite, "Fernium", "FerniumCore ", 250000, ref shop, ref nextSlot);
                }*/

                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumPyron, "TrelamiumMod", "SolarMandibleTotem", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.btfaLoaded)
                {
                    AddItem(BtfaArtery, "ForgottenMemories", "BloodClot", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.antiarisLoaded)
                {
                    AddItem(AntiarisDownedKeeper, "Antiaris", "PocketCursedMirror", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Alchemaster
                    AddItem(TremorDownedAlchemaster, "Tremor", "AncientMosaic", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Infernon
                    AddItem(SpiritDownedInfer, "SpiritMod", "CursedCloth", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Cryogen
                    AddItem(CalamityDownedCryo, "CalamityMod", "CryoKey", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedShadows, "Disarray", "EnhancedShadowFragment", 250000, ref shop, ref nextSlot);
                }

                //ichor blaster/ grasper - true eater

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Coznix
                    AddItem(ThoriumDownedBeholder, "ThoriumMod", "VoidLens", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.btfaLoaded)
                {
                    AddItem(BtfaTitan, "ForgottenMemories", "anomalydetector", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedRathalos, "W1KModRedux", "MysteryTicket", 250000, ref shop, ref nextSlot);
                    AddItem(W1KDownedRidley, "W1KModRedux", "MetroidCapsule", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.aaLoaded)
                {
                    //Retriever
                    AddItem(AARetriever, "AAMod", "CyberneticClaw", 250000, ref shop, ref nextSlot);
                    //Raider Ultima
                    AddItem(AARaider, "AAMod", "CyberneticBell", 250000, ref shop, ref nextSlot);
                    //Orthrus X
                    AddItem(AAOrthrus, "AAMod", "ScrapHeap", 250000, ref shop, ref nextSlot);
                    //Techno Truffle
                    AddItem(AATruffle, "AAMod", "CyberneticShroom", 250000, ref shop, ref nextSlot);
                    //All Storm bosses
                    //AddItem((AARetriever && AARaider && AAOrthrus), "Fargowiltas", "CyberneticAmalgam", 600000, ref shop, ref nextSlot);
                }

                //Destroyer
                AddItem(NPC.downedMechBoss1, "Fargowiltas", "MechWorm", 400000, ref shop, ref nextSlot);
                //Twins
                AddItem(NPC.downedMechBoss2, "Fargowiltas", "MechEye", 400000, ref shop, ref nextSlot);
                //Skeletron Prime
                AddItem(NPC.downedMechBoss3, "Fargowiltas", "MechSkull", 400000, ref shop, ref nextSlot);
                //All Mechs
                AddItem((NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3), "Fargowiltas", "MechanicalAmalgam", 1000000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.ocramLoaded)
                {
                    AddItem(OcramOcram, "Ocram", "item_suspicious_looking_skull", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.JSLoaded)
                {
                    //Arlenon  
                    //AddItem(JSArlenon, "Jetshift", "PearlOfTheSky", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.JSLoaded)
                {
                    //Athazel  
                    //AddItem(JSAthazel, "Jetshift", "TridentOfDoom", 400000, ref shop, ref nextSlot);
                }
                
                if(Fargowiltas.instance.pinkyLoaded)
                {
                    AddItem(PinkySlime, "pinkymod", "MythrilGel", 400000, ref shop, ref nextSlot);
                }
                
                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumPermafrost, "TrelamiumMod", "TemporalLens", 400000, shop: ref shop, nextSlot: ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Dusking
                    AddItem(SpiritDownedDusking, "SpiritMod", "DuskCrown", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedLuna, "Disarray", "MastersPresent", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Brimstone Elemental
                    AddItem(CalamityDownedBrim, "CalamityMod", "CharredIdol", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Etheral Umbra
                    AddItem(SpiritDownedUmbra, "SpiritMod", "UmbraSummon", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Motherboard
                    AddItem(TremorDownedMotherboard, "Tremor", "MechanicalBrain", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedBell, "Disarray", "ABell", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Aquatic Scourge
                    AddItem(CalamityDownedAquatic, "CalamityMod", "Seafood", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedAnnih, "Laugicality", "MechanicalMonitor", 400000, ref shop, ref nextSlot);
                    AddItem(EnigmaDownedSlyber, "Laugicality", "SteamCrown", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedScourge, "ElementsAwoken", "ScourgeFighterSummon", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedReg, "ElementsAwoken", "RegarothSummon", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedTrain, "Laugicality", "SuspiciousTrainWhistle", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedMech, "Disarray", "MechPrism", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedHarpy2, "SacredTools", "HarpySummon2", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Lich
                    AddItem(ThoriumDownedLich, "ThoriumMod", "LichCatalyst", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Fairy Queen
                    AddItem(TremorDownedPixie, "Tremor", "PixieinaJar", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Calamitas
                    AddItem(CalamityDownedCalamitas, "CalamityMod", "BlightedEyeball", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {  
                    //Illumant Master
                    AddItem(SpiritDownedIlluminant, "SpiritMod", "ChaosFire", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedOkiku, "W1KModRedux", "OminousMask", 400000, ref shop, ref nextSlot);
                }
                
                //Plantera
                AddItem(NPC.downedPlantBoss, "Fargowiltas", "Plantera", 500000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    AddItem(RedeSlayer, "Redemption", "KingSummon", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.pinkyLoaded)
                {
                    AddItem(PinkyValdaris, "pinkymod", "ValdarisItem", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Leviathan
                    AddItem(CalamityDownedLevi, "Fargowiltas", "LeviathanSummon", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedEther, "Laugicality", "EmblemOfEtheria", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {  
                    //Frost King
                    AddItem(TremorDownedFrost, "Tremor", "FrostCrown", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Astrageldon
                    AddItem(CalamityDownedAstragel, "CalamityMod", "AstralChunk", 500000, ref shop, ref nextSlot);
                    //Astrum Deus
                    AddItem(CalamityDownedAstrum, "CalamityMod", "Starcore", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Wall of Shadows
                    AddItem(TremorDownedWall, "Tremor", "ShadowRelic", 500000, ref shop, ref nextSlot);
                }
                
                //Golem
                AddItem(NPC.downedGolemBoss, "Fargowiltas", "LihzahrdPowerCell2", 600000, ref shop, ref nextSlot);
                
                if(Fargowiltas.instance.pinkyLoaded)
                {
                    AddItem(PinkyAbyssmal, "pinkymod", "MindGodItem", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.JSLoaded)
                {
                    //Shift
                    //AddItem(JSShift, "Jetshift", "ForbiddenGem", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacreddownedPrimordia, "SacredTools", "PrimordiaSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedCelestial, "ElementsAwoken", "CelestialSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedPerma, "ElementsAwoken", "PermafrostSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedObsid, "ElementsAwoken", "ObsidiousSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Abyssion
                    AddItem(ThoriumDownedAbyss, "Fargowiltas", "AbyssionSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Cog Lord
                    AddItem(TremorDownedCog, "Tremor", "ArtifactEngine", 600000, ref shop, ref nextSlot);
                    //Mothership/Cyber King
                    AddItem(TremorDownedCyber, "Tremor", "AdvancedCircuit", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.nightmaresLoaded)
                {
                    AddItem(NPC.downedPlantBoss, "TrueEater", "MimicKey", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Plaguebringer Goliath
                    AddItem(CalamityDownedPlague, "CalamityMod", "Abomination", 600000, ref shop, ref nextSlot);
                }

                //behemoth - true eater

                if (Fargowiltas.instance.crystiliumLoaded)
                {
                    //Crystal King
                    AddItem(CrystiliumDownedKing, "CrystiliumMod", "CrypticCrystal", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedDeath, "W1KModRedux", "DungeonMasterGuide", 600000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedFishron, "Fargowiltas", "TruffleWorm2", 600000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.blueMagicLoaded)
                {
                    AddItem(BlueDownedPhantom, "Bluemagic", "PaladinEmblem", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedAque, "ElementsAwoken", "AqueousSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.pumpkingLoaded)
                {
                    AddItem(PumpkingDownedHorse, "Pumpking", "PumpkingSoul", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {   
                    //Atlas
                    AddItem(SpiritDownedAtlas, "SpiritMod", "StoneSkin", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Ravager
                    AddItem(CalamityDownedRav, "CalamityMod", "AncientMedallion", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.blueMagicLoaded)
                {
                    AddItem(BlueDownedAbom, "Bluemagic", "FoulOrb", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.JSLoaded)
                {
                    //Polypus
                    //AddItem(JSPolypus, "Jetshift", "RottenShrimp", 600000, ref shop, ref nextSlot);
                }

                //Lunatic Cultist
                AddItem(NPC.downedAncientCultist, "Fargowiltas", "CultistSummon", 750000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedDragon, "ElementsAwoken", "AncientDragonSummon", 750000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    AddItem(RedeCleaver, "Redemption", "CorruptedHeroSword", 750000, ref shop, ref nextSlot);
                    AddItem(RedeGigipede, "Redemption", "CorruptedWormMedallion", 750000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.aaLoaded)
                {
                    AddItem(AARajah, "AAMod", "GoldenCarrot", 750000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedGuardian, "ElementsAwoken", "GuardianSummon", 750000, ref shop, ref nextSlot);
                }
                
                //Moon Lord
                AddItem(NPC.downedMoonlord, "Fargowiltas", "CelestialSigil2", 1000000, ref shop, ref nextSlot);
                //All Vanilla Bosses
                AddItem(NPC.downedMoonlord, "Fargowiltas", "MutantVoodoo", 2000000, ref shop, ref nextSlot);
            }

            #endregion HARDMODE BOSSES

            #region POST MOONLORD BOSSES

            else
            {
                if (Fargowiltas.instance.aaLoaded)
                {
                    AddItem(AASisters, "AAMod", "FlamesOfAnarchy", 1000000, ref shop, ref nextSlot);
                    //Equinox Worms
                    AddItem(AAEquinox, "AAMod", "EquinoxWorm", 1000000, ref shop, ref nextSlot);
                    //sisters
                    AddItem(AASisters, "AAMod", "FlamesOfAnarchy ", 1000000, ref shop, ref nextSlot);
                    //Akuma
                    AddItem(AAAkuma, "AAMod", "DraconianSigil", 1000000, ref shop, ref nextSlot);
                    //Yamata
                    AddItem(AAYamata, "AAMod", "DreadSigil", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.JSLoaded)
                {
                    //Oculus
                    //Frezyn 
                    //AddItem(JSFrezyn, "Jetshift", "Cryogen", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    //Omega Obliterator
                    AddItem(RedeOmega, "Redemption", "OmegaRadar", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumAzolinth, "TrelamiumMod", "PlanetaryBeacon", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedSludge, "Disarray", "VileSlimeBall", 1000000, ref shop, ref nextSlot);
                }
                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Overseer
                    AddItem(SpiritDownedOverseer, "SpiritMod", "SpiritIdol", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.pumpkingLoaded)
                {
                    AddItem(PumpkingDownedTerra, "Pumpking", "TerraCore", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedEmperor, "Tremor", "EmperorCrown", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumParadox, "TrelamiumMod", "WarpedMirror", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedVolcanox, "ElementsAwoken", "VolcanoxSummon", 1000000, ref shop, ref nextSlot);
                    AddItem(ElementsDownedVoid, "ElementsAwoken", "VoidLeviathanSummon", 1000000, ref shop, ref nextSlot);
                    AddItem(ElementsDownedAzana, "ElementsAwoken", "AzanaSummon", 1000000, ref shop, ref nextSlot);
                }

                //abomination rematch - blue

                if (Fargowiltas.instance.JSLoaded)
                {
                    //Mortalos
                    //AddItem(JSMortalos, "Jetshift", "TheVoid", 1000000, ref shop, ref nextSlot);
                    //Shift Rematch
                    //AddItem(JSMortalos, "Jetshift", "ArtifactOfTheVoid", 1000000, ref shop, ref nextSlot);
                }


                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Brutalisk
                    AddItem(TremorDownedBrutallisk, "Tremor", "RoyalEgg", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {   
                    //Abbadon
                    AddItem(SacredDownedAbbadon, "SacredTools", "ShadowWrathSummonItem", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Profaned Guardians
                    AddItem(CalamityDownedGuardian, "CalamityMod", "ProfanedShard", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.joostLoaded)
                {
                    //Cactuar
                    AddItem(JoostDownedCactuar, "JoostMod", "Cactusofdoom", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Space Whale
                    AddItem(TremorDownedWhale, "Tremor", "CosmicKrill", 5000000, ref shop, ref nextSlot);
                    //Trinity
                    AddItem(TremorDownedTrinity, "Tremor", "StoneofKnowledge", 5000000, ref shop, ref nextSlot);
                    //Andas
                    AddItem(TremorDownedAndas, "Tremor", "InfernoSkull", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedDeva, "Disarray", "EyeOfSouls", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Providence
                    AddItem(CalamityDownedProv, "CalamityMod", "ProfanedCore", 10000000, ref shop, ref nextSlot);
                }

                //void marshal -true eater

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedSerpent, "SacredTools", "SerpentSummon", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.grealmLoaded)
                {
                    //Mantid Matriarch
                    AddItem(GRealmDownedMantid, "GRealm", "CrownOfMantodea", 10000000, ref shop, ref nextSlot);
                    //Rift Daemon - When he's released
                }

                if (Fargowiltas.instance.joostLoaded)
                {
                    AddItem(JoostDownedSAX, "JoostMod", "InfectedArmCannon", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedMeteor, "Disarray", "RandomSpaceRock", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    //Lunarians
                    AddItem(SacredDownedLunar, "SacredTools", "MoonEmblem", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Ragnorok
                    AddItem(ThoriumDownedRag, "ThoriumMod", "RagSymbol", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.ancientsLoaded)
                {
                    AddItem(AncientsDownedWorms, "EchoesoftheAncients", "Wyrm_Rune", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.joostLoaded)
                {
                    AddItem(JoostDownedGilga, "JoostMod", "Excalipoor", 15000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedDungeon, "Disarray", "DungeonAmalgamation", 15000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    //Thorn Rematch
                    AddItem(RedeThornPZ, "Redemption", "LifeFruitOfThorns", 15000000, ref shop, ref nextSlot);
                    //Eaglecrest Rematch
                    AddItem(RedeEaglecrestPZ, "Redemption", "AncientSigil", 15000000, ref shop, ref nextSlot);
                    //Nebuleus
                    AddItem(RedeNeb, "Redemption", "NebSummon", 15000000, ref shop, ref nextSlot);
                }

                //spirit of purity

                if (Fargowiltas.instance.aaLoaded)
                {
                    AddItem(AASoC, "AAMod", "SpatialWheel ", 1500000, ref shop, ref nextSlot);
                    //Zero
                    AddItem(AAZero, "AAMod", "ZeroTesseract", 15000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Bumblebirb
                    AddItem(CalamityDownedBirb, "CalamityMod", "BirbPheromones", 20000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.JSLoaded)
                {
                    //Crystal Conflict
                    //AddItem(JSCCP2, "Jetshift", "CrownOfConflict", 20000000, ref shop, ref nextSlot);
                }

                //spirit of chaos

                //spirit of purity rematch

                if (Fargowiltas.instance.aaLoaded)
                {
                    //Shen Doragon
                    AddItem(AAShen, "AAMod", "ChaosSigil", 20000000, ref shop, ref nextSlot);
                    //Infinity Zero
                    AddItem(AAIZ, "AAMod", "InfinityOverloader", 30000000, ref shop, ref nextSlot);
                }

                //Fishron EX
                if (Fargowiltas.instance.fargoLoaded)
                {
                    AddItem(FargoDownedFishEX, "FargowiltasSouls", "TruffleWormEX", 10000000, ref shop, ref nextSlot);
                }

                //Mutant
                if (Fargowiltas.instance.fargoLoaded)
                {
                    AddItem(FargoDownedMutant, "FargowiltasSouls", "MutantsCurse", 20000000, ref shop, ref nextSlot);
                }

                AddItem(true, "Fargowiltas", "AncientSeal", 100000000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.fargoLoaded)
                {
                    Player player = Main.player[Main.myPlayer];

                    foreach (Item item in player.armor)
                    {
                        if (item != null && item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("EternitySoul"))
                        {
                            AddItem(true, "FargowiltasSouls", "EternitySoul", 99000000, ref shop, ref nextSlot);
                        }
                    }
                }
            }

            #endregion POST MOONLORD BOSSES
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (Fargowiltas.instance.fargoLoaded && FargoDownedMutant)
            {
                damage = 360;
                knockback = 10f;
            }
            else if (NPC.downedMoonlord)
            {
                damage = 500;
                knockback = 10f;
            }
            else if (Main.hardMode)
            {
                damage = 60;
                knockback = 5f;
            }
            else
            {
                damage = 20;
                knockback = 4f;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            if (NPC.downedMoonlord)
            {
                cooldown = 1;
            }
            else if (Main.hardMode)
            {
                cooldown = 20;
                randExtraCooldown = 25;
            }
            else
            {
                cooldown = 30;
                randExtraCooldown = 30;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (Fargowiltas.instance.fargoLoaded && FargoDownedMutant)
            {
                projType = ModLoader.GetMod("FargowiltasSouls").ProjectileType("MutantSpearThrownFriendly");
            }
            else if (NPC.downedMoonlord)
            {
                projType = mod.ProjectileType("PhantasmalEyeProjectile");
            }
            else if (Main.hardMode)
            {
                projType = mod.ProjectileType("MechEyeProjectile");
            }
            else
            {
                projType = mod.ProjectileType("EyeProjectile");
            }

            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            if (Fargowiltas.instance.fargoLoaded && FargoDownedMutant)
            {
                multiplier = 25f;
                randomOffset = 0f;
            }
            else
            {
                multiplier = 12f;
                randomOffset = 2f;
            }
        }

        //gore
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.8f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore3"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore2"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore1"));
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 0.6f);
                }
            }
        }
    }
}
