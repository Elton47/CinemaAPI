using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Models {
  public class Movie {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Director { get; set; }
    public string Description { get; set; }
    [Required]
    public string Duration { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
  }
}