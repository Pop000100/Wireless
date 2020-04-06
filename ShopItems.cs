
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Wireless
{
	public class ShopItems : GlobalNPC
	{
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
            if ((type == NPCID.Steampunker) && (ModContent.GetInstance<Config>().sellerNPC == (Sellers)0))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.WirelessTransmitter>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.WirelessReceiver>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.CoordinateConfigurator>());
                nextSlot++;
            }
            else if ((type == NPCID.Mechanic) && (ModContent.GetInstance<Config>().sellerNPC == (Sellers)1))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.WirelessTransmitter>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.WirelessReceiver>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.CoordinateConfigurator>());
                nextSlot++;
            }
            else if ((type == NPCID.Cyborg) && (ModContent.GetInstance<Config>().sellerNPC == (Sellers)2))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.WirelessTransmitter>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.WirelessReceiver>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.CoordinateConfigurator>());
                nextSlot++;
            }
        }
	}
}
