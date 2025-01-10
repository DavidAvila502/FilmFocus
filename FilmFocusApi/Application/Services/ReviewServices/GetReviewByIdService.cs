using FilmFocusApi.Application.Interfaces.ReviewInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Services.ReviewServices
{
    public class GetReviewByIdService:IGetReviewByIdService
    {
        public readonly IReviewRepository _repository;

        public GetReviewByIdService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<Review> GetReviewById(int id)
        {
            try
            {
                Review? review = await _repository.GetReviewById(id);


                return review == null ? throw new NotFiniteNumberException("The requested review was not found.") : review;
            }
            catch (Exception ex) {

                throw new ApplicationException("Something went wrong trying to get the review.");
            }
        }
    }
}
