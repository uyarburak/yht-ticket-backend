namespace YhtTicket.Common.EybisClient.Models
{
    class YhtBaseResponse
    {
        public bool HasError => CevapBilgileri.CevapKodu != "000";
        public YhtResponseInfo CevapBilgileri { get; set; }
    }

    class YhtResponseInfo
    {
        public string CevapKodu { get; set; }
        public string CevapMsj { get; set; }
    }
}
