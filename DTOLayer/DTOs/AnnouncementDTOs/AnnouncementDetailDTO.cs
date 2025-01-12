using System;

namespace DTOLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementDetailDTO
    {
        public int AnnouncementID { get; set; }  // Duyuru ID'si
        public string Title { get; set; }        // Başlık
        public string Content { get; set; }      // İçerik
        public DateTime Date { get; set; }       // Yayınlanma tarihi
        public string CreatedBy { get; set; }    // Duyuruyu oluşturan kişi 
    }
}
