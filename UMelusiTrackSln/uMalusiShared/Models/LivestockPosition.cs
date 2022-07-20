using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UMelusiTrackApi.Models
{
    [Table("LivestockPosition")]
    public class LivestockPosition
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int LivestockPositionId { get; set; }

        public string LivestockName { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("Livestock")]
        public int LivestockId { get; set; }

        public Livestock? Livestock { get; set; }
    }
}
