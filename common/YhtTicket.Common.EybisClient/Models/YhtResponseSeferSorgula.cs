using System.Collections.Generic;

namespace YhtTicket.Common.EybisClient.Models
{
    class YhtResponseSeferSorgula : YhtBaseResponse
    {
        public List<YhtScheduleInfo> SeferSorgulamaSonucList { get; set; }
    }
}
