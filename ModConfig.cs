using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria.ModLoader.Config;

namespace Wireless
{

    public class Config : ModConfig
    {

        public override ConfigScope Mode => ConfigScope.ServerSide;
        
        [Label("$Mods.Wireless.Config.WirelessRemote")]
        [Tooltip("$Mods.Wireless.Config.WirelessRemote.Desc")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool wirelessRemote;

        [Label("$Mods.Wireless.Config.WirelessTransceiver")]
        [Tooltip("$Mods.Wireless.Config.WirelessTransceiver.Desc")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool wirelessTransceiver;

        [Label("$Mods.Wireless.Config.SellerNPC")]
        [Tooltip("$Mods.Wireless.Config.SellerNPC.Desc")]
        [DefaultValue(Sellers.Steampunker)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Sellers sellerNPC { get; set; }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if ((sellerNPC != ((Sellers)0)) && (sellerNPC != ((Sellers)1)) && (sellerNPC != ((Sellers)2)))
            {
                sellerNPC = 0;
            }
        }

    }

    public enum Sellers
    {
        Steampunker,
        Mechanic,
        Cyborg
    }

}
