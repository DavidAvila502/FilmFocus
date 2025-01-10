using FilmFocusApi.Application.DTOs.Reviews;
using FilmFocusApi.Application.Interfaces.ReviewInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Services.ReviewServices
{
    public class CreateReviewService:ICreateReviewService
    {
        public readonly IReviewRepository _repository;

        public CreateReviewService(IReviewRepository repository) {

            _repository = repository;
        }

        public async Task<Review> CreateReview(ReviewInsertDTO reviewDto)
        {
            try
            {
                Review newReview = new Review() {Content=reviewDto.Content,MovieId=reviewDto.MovieId,UserId=reviewDto.UserId };

                await _repository.CreateReview(newReview);

                return newReview;

            }
            catch (Exception ex) {

                throw new ApplicationException("Something went wrong trying to create the review.");
            }

        }
    }
}
