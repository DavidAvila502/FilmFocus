namespace FilmFocusApi.Application.DTOs.Reviews
{
    public class ReviewInsertDTO
    {
        public required int UserId { get; set; }

        public required int MovieId { get; set; }

        public int Stars { get; set; }

        public required string Content { get; set; }

    }
}
