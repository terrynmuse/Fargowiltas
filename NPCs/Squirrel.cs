using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
	[AutoloadHead]
	public class Squirrel : ModNPC
	{
		public override bool Autoload(ref string name)
		{
			name = "Squirrel";
			return ModLoader.GetMod("FargowiltasSouls") != null;
		}

		private readonly Mod fargosouls = ModLoader.GetMod("FargowiltasSouls");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squirrel");
			Main.npcFrameCount[npc.type] = 6;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 50;
			npc.height = 32;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = .25f;

			animationType = NPCID.Squirrel;
			npc.aiStyle = 7;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				foreach (Item item in player.inventory)
				{
					if (item.type == fargosouls.ItemType("TophatSquirrel"))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(3))
			{
				case 0:
					return "Rick";
				case 1:
					return "Acorn";
				default:
					return "Squeaks";
			}
		}

		public override string GetChat()
		{
            if (Main.rand.Next(10) == 0)
                return "You will suffer.";

            switch (Main.rand.Next(3))
			{
				case 0:
					return "*squeak*";
				case 1:
					return "*chitter*";
				default:
					return "*crunch crunch*";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}

		}

        private void TryAddItem(Item item, Chest shop, ref int nextSlot)
        {
            const int maxShop = 40;

            if (item.modItem == null || !item.modItem.mod.Name.Equals("FargowiltasSouls") || nextSlot >= maxShop)
                return;

            bool duplicateItem = false;

            if (item.Name.EndsWith("Enchantment"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
            else if (item.Name.Contains("Force"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item item2 in exactRecipe.requiredItem)
                {
                    foreach (Item item3 in shop.item)
                    {
                        if (item3.type == item2.type)
                        {
                            duplicateItem = true;
                            break;
                        }
                    }
                    if (duplicateItem == false && nextSlot < maxShop)
                    {
                        if (item2.Name.Contains("Enchantment"))
                        {
                            shop.item[nextSlot].SetDefaults(item2.type);
                            nextSlot++;
                        }
                    }
                }
            }
            else if (item.Name.StartsWith("Soul"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item item2 in exactRecipe.requiredItem)
                {
                    foreach (Item item3 in shop.item)
                    {
                        if (item3.type == item2.type)
                        {
                            duplicateItem = true;
                            break;
                        }
                    }
                    if (duplicateItem == false && nextSlot < maxShop)
                    {
                        if (item2.Name.Contains("Force") || item2.Name.Contains("Soul"))
                        {
                            shop.item[nextSlot].SetDefaults(item2.type);
                            nextSlot++;
                        }
                    }
                }
            }
            else if (item.Name.EndsWith("Essence"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
            else if (item.Name.EndsWith("Soul"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item item2 in exactRecipe.requiredItem)
                {
                    foreach (Item item3 in shop.item)
                    {
                        if (item3.type == item2.type)
                        {
                            duplicateItem = true;
                            break;
                        }
                    }
                    if (duplicateItem == false && nextSlot < maxShop)
                    {
                        if (item2.Name.EndsWith("Essence"))
                        {
                            shop.item[nextSlot].SetDefaults(item2.type);
                            nextSlot++;
                        }
                    }
                }
                duplicateItem = false;
                foreach (Item item4 in shop.item)
                {
                    if (item4.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
            else if (item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("AeolusBoots"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == ItemID.FrostsparkBoots || item2.type == ItemID.BalloonHorseshoeFart)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FrostsparkBoots);
                    nextSlot++;
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.BalloonHorseshoeFart);
                    nextSlot++;
                }
            }
        }

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("FargowiltasSouls").ItemType("EurusSock"));
                nextSlot++;
            }

			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				foreach (Item item in player.inventory)
				{
                    TryAddItem(item, shop, ref nextSlot);
				}

				foreach (Item item in player.armor)
				{
                    TryAddItem(item, shop, ref nextSlot);
                }
			}
		}
	}
}