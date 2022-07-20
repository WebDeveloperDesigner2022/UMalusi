using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMelusiTrackApi.Models
{
    [Table("Livestock")]
    public class Livestock
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int LivestockId { get; set; }
        public string LivestockName { get; set; }
        public string DOB { get; set; }
        public string Color { get; set; }
        public byte[] Image { get; set; }



        [ForeignKey("Farmer")]
        public int FarmerId { get; set; }

        public Farmer? Farmer { get; set; }


        [ForeignKey("Tracker")]
        public int TrackerId { get; set; }

        public Tracker? Tracker { get; set; }


        [ForeignKey("LivestockType")]
        public int LivestockTypeId { get; set; }

        public LivestockType? LivestockType { get; set; }

        public ICollection<LivestockPosition>? LivestockPosition { get; set; }

    }
}
