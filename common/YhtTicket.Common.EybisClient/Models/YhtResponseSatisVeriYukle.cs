using System.Collections.Generic;

namespace YhtTicket.Common.EybisClient.Models
{
    class YhtResponseSatisVeriYukle : YhtBaseResponse
    {
        public List<YhtStationInfo> IstasyonBilgileriList { get; set; }
    }
}
