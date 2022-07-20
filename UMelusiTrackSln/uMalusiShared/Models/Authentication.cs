using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMelusiTrackApi.Models
{
    [Table("Authentication")]
    public class Authentication
    {

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AuthenticationId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
     
    }
}
