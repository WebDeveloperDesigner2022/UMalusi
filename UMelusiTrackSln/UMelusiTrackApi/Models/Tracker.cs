using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMelusiTrackApi.Models
{
    [Table("Tracker")]
    public class Tracker
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TrackerId { get; set; }
        public string Description { get; set; }
    }
}
