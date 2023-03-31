using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingAppReact.Models
{
    public class OrderChange
    {
        [Key]
        public int ID { get; set; }

        // trackingnumber 
        [Column(TypeName = "nvarchar(40)")]
        public string TrackingNumber { get; set; }
        
        // Container ID 
        [Column(TypeName = "int")]
        public int ContainerID { get; set; }
    }
}
