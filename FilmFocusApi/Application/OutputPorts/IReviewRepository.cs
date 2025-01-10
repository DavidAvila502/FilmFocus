using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.OutputPorts
{
    public interface IReviewRepository
    {
        public Task<List<Review>> GetAllReviews();

        public Task<Review?> GetReviewById(int id);

        public Task CreateReview(Review newReview);

        public Task DeleteReview(Review review);
    }
}
