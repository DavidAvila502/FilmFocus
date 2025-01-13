using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFocusApi.Domain.Entities
{
    [Table("MoviesActors")]
    public class MoviesActors
    {
        [Column("movieId")]
        public required int movieId;

        [Column("actorId")]
        public required int actorId;
    }
}
