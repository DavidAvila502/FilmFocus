using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Interfaces.ReviewInterfaces
{
    public interface IGetAllReviewsService
    {
        public Task<List<Review>> GetAllReviews();
    }
}
