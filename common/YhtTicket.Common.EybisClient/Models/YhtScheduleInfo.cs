using System.Collections.Generic;

namespace YhtTicket.Common.EybisClient.Models
{
    public class YhtScheduleInfo
    {
        public long SeferId { get; set; }
        public string TrenAdi { get; set; }
        public string TrenTipi { get; set; }
        public string BinisTarih { get; set; }
        public string InisTarih { get; set; }
        public List<YhtVagonTipi> VagonTipleriBosYerUcret { get; set; }
    }
}
