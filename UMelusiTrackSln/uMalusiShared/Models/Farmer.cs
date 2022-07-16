using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMelusiTrackApi.Models
{
    [Table("Farmer")]
    public class Farmer
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int FarmerId { get; set; }
        public string Names { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        [ForeignKey("Authentication")]
        public int AuthenticationId { get; set; }

        public Authentication? Authentication { get; set; }

        public ICollection<Livestock>? Livestocks { get; set; }



    }
}
