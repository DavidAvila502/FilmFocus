using FilmFocusApi.Application.Interfaces.ReviewInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Services.ReviewServices
{
    public class DeleteReviewService:IDeleteReviewService
    {
        public readonly IReviewRepository _repository;
        
        public DeleteReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteReview(int IdUser,int IdReview)
        {
          
            Review? review = await _repository.GetReviewById(IdReview);

            if (review == null) 
            {
                throw new KeyNotFoundException("The requested review doesn't exist.");
            }

            if (review.UserId != IdUser)
            {
                throw new KeyNotFoundException("This review doesn't belong to the especified user.");
            }

            try
            {
                await _repository.DeleteReview(review);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Something went wrong trying to delete the requested review.");
            }
        }

    }
}
