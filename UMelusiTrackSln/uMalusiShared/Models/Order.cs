using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMelusiTrackApi.Models
{
    [Table("Order")]
    public class Order
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ReferenceNo { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }

        [ForeignKey("Farmer")]
        public int FarmerId { get; set; }

        public Farmer? Farmer { get; set; }




    }
}
