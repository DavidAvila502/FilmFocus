using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFocusApi.Domain.Entities
{
    [Table("Movies")]
    public class Movie
    {
        [Column("movieId")]
        public  int Id { get; set; }
        [Column("movieName")]
        public required string Name { get; set; }
        [Column("score")]
        public Decimal  Score { get; set; }
        [Column("releaseDate")]
        public DateOnly ReleaseDate {  get; set; }
        [Column("synopsis")]
        public string Synopsis { get; set; }
        [Column("imageUrl")]
        public string? ImageUrl { get; set; }

    }
}
