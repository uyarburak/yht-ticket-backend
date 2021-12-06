using System.Collections.Generic;

namespace YhtTicket.Common.EybisClient.Models
{
    class YhtRequest
    {
        public string KanalKodu { get; set; } = "3";
        public Dictionary<string, object> MobilWsDetay { get; set; } = new Dictionary<string, object>()
        {
            { "MobilKanali", 1 },
            { "MobilVersiyon", 173 },
            { "OsVersiyon", "7.0" },
            { "Model", "LG-H960" },
            { "YeniMobil", true },
        };
        public int Dil { get; set; } = 0;
        public string Tarih { get; set; } = "Jan 01, 2011 12:00:00 AM";
    }
}
