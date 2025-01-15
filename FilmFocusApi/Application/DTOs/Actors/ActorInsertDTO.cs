namespace FilmFocusApi.Application.DTOs.Actors
{
    public class ActorInsertDTO

    {
        public required int ActorId { get; set; }

        public required string ActorName { get; set; }

        public IFormFile? Image { get; set; }

    }
}
