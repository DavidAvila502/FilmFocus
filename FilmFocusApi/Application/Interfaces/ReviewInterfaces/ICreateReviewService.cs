using FilmFocusApi.Application.DTOs.Reviews;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Interfaces.ReviewInterfaces
{
    public interface ICreateReviewService
    {
        public Task<Review> CreateReview(ReviewInsertDTO reviewInsertDTO);


    }
}
