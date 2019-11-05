using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class GrandCross : DevianttSummon
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";
        public override int summonType => NPCID.Paladin;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grand Cross");
            Tooltip.SetDefault("Summons Paladin");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}