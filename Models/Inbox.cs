using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingAppReact.Models
{
    public class Inbox
    {
        [Key]
        public int ID { get; set; }

        // trackingnumber 
        [Column(TypeName = "nvarchar(40)")]
        public string TrackingNumber { get; set; }

        // status
        [Column(TypeName = "nvarchar(40)")]
        public string? Status { get; set; }

        // handhabung
        [Column(TypeName = "nvarchar(40)")]
        public string? Handling { get; set; }

        // rutsche
        [Column(TypeName = "nvarchar(40)")]
        public string? Delay { get; set; }


        // lieferschein
        [Column(TypeName = "nvarchar(40)")]
        public string? DispatchNote { get; set; }
    }
}
