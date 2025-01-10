using FilmFocusApi.Application.DTOs.Reviews;
using FilmFocusApi.Application.InputPorts;
using FilmFocusApi.Application.Interfaces.ReviewInterfaces;
using FilmFocusApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmFocusApi.Infrastructure.Adapters.Input
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController:ControllerBase,IReviewPort
    {
        public readonly ICreateReviewService _createReviewService;
        public readonly IDeleteReviewService _deleteReviewService;
        public readonly IGetAllReviewsService _getAllReviewsService;
        public readonly IGetReviewByIdService _getReviewByIdService;


        public ReviewController(
            ICreateReviewService createReviewService,
            IDeleteReviewService deleteReviewService,
            IGetAllReviewsService getAllReviewsService,
            IGetReviewByIdService getReviewByIdService)
        {
             _createReviewService = createReviewService;
            _deleteReviewService = deleteReviewService;
            _getAllReviewsService = getAllReviewsService;
            _getReviewByIdService = getReviewByIdService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetAllReviews()
        {
            try
            {
               List<Review> reviews = await _getAllReviewsService.GetAllReviews();
                return reviews;
            }
            catch (ApplicationException ex) {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Review?>> GetReviewById([FromRoute] int id)
        {
            try
            {
                Review review = await _getReviewByIdService.GetReviewById(id);

                return review;
            }

            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            catch (ApplicationException ex) {
                
                return StatusCode(500, new {message = ex.Message});
            }

        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview([FromBody] ReviewInsertDTO reviewInsert)
        {
            try 
            {
                Review review = await _createReviewService.CreateReview(reviewInsert);

                return review;

            }catch(ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "User")]
        [HttpDelete("{IdReview}")]
        public async Task<ActionResult> DeleteReview([FromRoute] int IdReview, [FromQuery] int IdUser)
        {
            try
            {
                await _deleteReviewService.DeleteReview(IdReview, IdUser);

                return Ok();

            }catch(KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
