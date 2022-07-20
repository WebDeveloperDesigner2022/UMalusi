using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMelusiTrackApi.Models
{
    [Table("LivestockType")]
    public class LivestockType
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int LivestockTypeId { get; set; }

        public string Description { get; set; }
    }
}
