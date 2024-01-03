using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Movie Title")]
        public string? MovieTitle { get; set; }
        public string? Genre { get; set; }
        [DisplayName("Price. Please try numeric values")]
        public float? Price { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
    }
}
