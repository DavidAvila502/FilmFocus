using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFocusApi.Domain.Entities
{
    [Table("MoviesAtors")]
    public class MoviesActors
    {
        [Column("movieId")]
        public required int movieId;

        [Column("actorId")]
        public required int actorId;
    }
}
