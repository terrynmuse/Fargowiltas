﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadPirates : ModItem
    {
        public override string Texture => "Terraria/Item_1315";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overloaded Pirate Map");
            Tooltip.SetDefault("Summons an Overloaded Pirate Invasion\nUse again to stop the event");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 1000;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = false;
        }

        public override bool UseItem(Player player)
        {
            if (FargoWorld.OverloadPirates)
            {
                // cancel it
                Main.invasionSize = 1;
                FargoWorld.OverloadPirates = false;

                if (Main.netMode == 2)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The pirates have calmed down!"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText("The pirates have calmed down!", 175, 75, 255);
                }
            }
            else
            {
                if (Main.netMode != 1)
                {
                    Main.invasionDelay = 0;
                    Main.StartInvasion(3);
                    Main.invasionSize = 15000;
                    Main.invasionSizeStart = 15000;
                }
                else
                {
                    NetMessage.SendData(61, -1, -1, null, player.whoAmI, -3f);
                }

                FargoWorld.OverloadPirates = true;
                Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PirateMap);
            recipe.AddIngredient(null, "Overloader", 10);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
