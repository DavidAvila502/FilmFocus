
namespace FilmFocusApi.Application.Interfaces.ReviewInterfaces
{
    public interface IDeleteReviewService
    {
        public Task DeleteReview(int IdUser, int IdReview);
    }
}
