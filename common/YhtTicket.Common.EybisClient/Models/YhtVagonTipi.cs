using System.Collections.Generic;

namespace YhtTicket.Common.EybisClient.Models
{
    public class YhtVagonTipi
    {
        public string VagonTip { get; set; }
        public decimal StandartBiletFiyati { get; set; }
        public List<YhtVagonBilgi> VagonListesi { get; set; }
    }
}
