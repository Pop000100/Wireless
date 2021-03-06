﻿
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Wireless
{
	public static class WirelessUtils
	{
		public static bool DoesPlayerReach(Player player)
		{
			return player.position.X / 16f - (float)Player.tileRangeX - (float)player.inventory[player.selectedItem].tileBoost - (float)player.blockRange <= (float)Player.tileTargetX &&
				(player.position.X + (float)player.width) / 16f + (float)Player.tileRangeX + (float)player.inventory[player.selectedItem].tileBoost - 1f + (float)player.blockRange >= (float)Player.tileTargetX &&
				player.position.Y / 16f - (float)Player.tileRangeY - (float)player.inventory[player.selectedItem].tileBoost - (float)player.blockRange <= (float)Player.tileTargetY &&
				(player.position.Y + (float)player.height) / 16f + (float)Player.tileRangeY + (float)player.inventory[player.selectedItem].tileBoost - 2f + (float)player.blockRange >= (float)Player.tileTargetY;
		}
		
		public static bool IsReceiver(Point16 point, Mod mod, bool notTransciever = false)
		{
			if(!WorldGen.InWorld(point.X, point.Y))
				return false;
			
			var tile = Main.tile[point.X, point.Y];
			if(tile.active() && tile.frameY == 18)
				return tile.type == mod.TileType(Names.WirelessReceiver) || (!notTransciever && tile.type == mod.TileType(Names.WirelessTransceiver));
			return false;
		}
		
		public static bool IsTransmitter(Point16 point, Mod mod, bool notTransciever = false)
		{
			if(!WorldGen.InWorld(point.X, point.Y))
				return false;
			
			var tile = Main.tile[point.X, point.Y];
			if(tile.active() && tile.frameY == 18)
				return tile.type == mod.TileType(Names.WirelessTransmitter) || (!notTransciever && tile.type == mod.TileType(Names.WirelessTransceiver));
			return false;
		}
	}
}
