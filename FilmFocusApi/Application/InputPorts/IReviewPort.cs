using FilmFocusApi.Application.DTOs.Reviews;
using FilmFocusApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmFocusApi.Application.InputPorts
{
    public interface IReviewPort
    {

        public Task<ActionResult<List<Review>>> GetAllReviews();

        public Task<ActionResult<Review?>> GetReviewById(int id);

        public Task<ActionResult<Review>> CreateReview(ReviewInsertDTO reviewInsert);

        public Task<ActionResult> DeleteReview(int IdUser, int IdReview);


    }
}
