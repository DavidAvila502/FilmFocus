using FilmFocusApi.Application.Interfaces.ReviewInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Services.ReviewServices
{
    public class GetAllReviewsService:IGetAllReviewsService
    {

        public readonly IReviewRepository _repository;

        public GetAllReviewsService( IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Review>> GetAllReviews()
        {
            try
            {
                List<Review> reviews = await _repository.GetAllReviews();

                return reviews;
            }
            catch (Exception ex) {

                throw new ApplicationException("Something went wrong trying to get the reviews.");
            
            }


        }
    }
}
