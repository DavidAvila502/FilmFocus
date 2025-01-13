using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFocusApi.Domain.Entities
{

    [Table("Acotrs")]
    public class Actor
    {
        [Column("actorId")]
       public int Id { get; set; }
        
        [Column("actorName")]
        public required string  Name { get; set; }

        [Column("imageUrl")]
        public string? ImageUrl { get; set; }

    }
}
