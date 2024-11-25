namespace FilmFocusApi.Application.DTOs.Movies
{
    public class MovieInsertDTO
    {
        public required string Name { get; set; }

        public decimal Score  { get; set; }

        public DateTime ReleaseDate { get; set; }

        public  string Synopsis { get; set; }

        public IFormFile? Image { get; set; }
    }
}
