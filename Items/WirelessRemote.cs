﻿
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Wireless.Items
{
	public class WirelessRemote : CoordinateConfigurator
	{

        public override bool Autoload(ref string name)
        {
            return ModContent.GetInstance<Config>().wirelessRemote;
        }

        public override void SetDefaults()
		{
			item.width = 14;
			item.height = 30;
			item.useAnimation = 30;
			item.useTime = 30;
			item.UseSound = new LegacySoundStyle(SoundID.Mech, 0);
			item.useStyle = 4;
			item.value = Item.sellPrice(0, 2);
			item.rare = 5;
			item.mech = true;
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.AddIngredient(ModContent.ItemType<CoordinateConfigurator>());
			recipe.AddIngredient(ModContent.ItemType<WirelessTransmitter>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool CanUseItem(Player player)
		{
			if(WirelessUtils.DoesPlayerReach(player) && WirelessUtils.IsReceiver(new Point16(Player.tileTargetX, Player.tileTargetY)))
			{
				item.UseSound = SoundID.Item1;
				item.useStyle = 1;
				return true;
			}
			if(Coordinates != Point16.NegativeOne)
			{
				item.UseSound = new LegacySoundStyle(SoundID.Mech, 0);
				item.useStyle = 4;
				return true;
			}
			return false;
		}
		
		public override bool UseItem(Player player)
		{
			var tileClicked = new Point16(Player.tileTargetX, Player.tileTargetY);
			if(WirelessUtils.IsReceiver(tileClicked))
			{
				Coordinates = tileClicked;
				Main.NewText(Language.GetTextValue("Mods.Wireless.SuccessLink"), Colors.RarityLime);
				return true;
			}
			if(WirelessUtils.IsReceiver(Coordinates))
			{
				ModContent.GetInstance<Wireless>().SyncActivate(Coordinates);
				return true;
			}
			return false;
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if(Coordinates != Point16.NegativeOne)
				tooltips.Insert(2, new TooltipLine(mod, "LinkingCoord", Language.GetTextValue("Mods.Wireless.StoredCoords", Coordinates)));
		}
	}
}
