using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFocusApi.Domain.Entities
{
    [Table("Reviews")]
    public class Review
    {
        [Column("reviewId")]
        public int Id { get; set; }

        [Column("userId")]
        public required int UserId { get; set; }

        [Column("movieId")]
        public required int MovieId { get; set; }

        [Column("stars")]
        public int Stars {  get; set; }

        [Column("Content")]
        public required string Content { get; set; }

        [Column("reviewDate")]
        public DateOnly ReviewDate { get; set; }
    }
}
