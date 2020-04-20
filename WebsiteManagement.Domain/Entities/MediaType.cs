using System.Collections.Generic;

namespace WebsiteManagement.Domain.Entities
{
    public class MediaType
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public int Size { get; set; }
        public string StoredLocation { get; set; }
        public int WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
