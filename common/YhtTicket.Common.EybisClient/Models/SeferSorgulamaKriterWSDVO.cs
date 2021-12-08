using System;
using System.Globalization;

namespace YhtTicket.Common.EybisClient.Models
{
    class SeferSorgulamaKriterWSDVO
    {
        public int SatisKanali { get; set; } = 3;
        public string BinisIstasyonu { get; set; }
        public string InisIstasyonu { get; set; }
        public int SeyahatTuru { get; set; } = 1;
        public string GidisTarih { get; set; }
        public bool BolgeselGelsin { get; set; } = false;
        public int IslemTipi { get; set; } = 0;
        public int YolcuSayisi { get; set; } = 1;

        public SeferSorgulamaKriterWSDVO(string departure, string destination, DateTime departureDate)
        {
            BinisIstasyonu = departure;
            InisIstasyonu = destination;
            GidisTarih = departureDate.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture) + " 00:00:00 AM";
        }
    }
}
