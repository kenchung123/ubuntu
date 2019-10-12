using System.ComponentModel.DataAnnotations;

namespace ApiLoggin.Models
{
    public class RequestTransferWork
    {
        [Key]
        public string IdEmployee { get; set; }
        public string RequestFactoryId { get; set; }
        public string OldUnit { get; set; }
        public string NewUnit { get; set; }
        public string OldFactory { get; set; }
        public string NewFactory { get; set; }
        public string Reason { get; set; }
    }
}