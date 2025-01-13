namespace FilmFocusApi.Application.DTOs.Actors
{
    public class ActorUpdateDTO
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
