﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Renewals
{
    public class MushroomRenewal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Renewal");
            Tooltip.SetDefault("Shroomifies a large radius");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("MushroomNukeProj");
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.DarkBlueSolution, 100);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}