using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Interfaces.ReviewInterfaces
{
    public interface IGetReviewByIdService
    {
        public Task<Review> GetReviewById(int id);
    }
}
