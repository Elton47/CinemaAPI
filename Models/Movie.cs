namespace CinemaAPI.Models {
  public class Movie {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Director { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
    public int Year { get; set; }
    public Category Category { get; set; }
  }
}