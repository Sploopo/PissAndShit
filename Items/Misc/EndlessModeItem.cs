using PissAndShit.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc
{
    public class EndlessModeItem : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Mode");
            Tooltip.SetDefault("Changes all bosses\nCan only be used in expert mode\nHave fun!");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 45;
            item.useAnimation = 45;
            item.consumable = false;
            item.rare = ItemRarityID.Red;
        }

        public override bool CanUseItem(Player player)
        {
            return Main.expertMode && !PaSWorld.endlesserModeSave;
        }

        public override bool UseItem(Player player)
        {
            if (!PaSWorld.endlessModeSave)
            {
                PaSGlobalNPC.hardDifficulty = PaSWorld.endlessModeSave = true;
                Main.NewText("GET READY FOR A CHALLENGE", 135, 16, 22);
            }
            else
            {
                PaSGlobalNPC.hardDifficulty = PaSWorld.endlessModeSave = false;
                Main.NewText("noob", 48, 248, 255);
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
