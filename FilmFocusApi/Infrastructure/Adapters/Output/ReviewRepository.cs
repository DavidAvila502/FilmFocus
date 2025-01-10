using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FilmFocusApi.Infrastructure.Adapters.Output
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context) 
        { 
            
            _context = context;
        }

        public async Task<List<Review>> GetAllReviews()
        {

            List<Review> reviews = await _context.Reviews.ToListAsync();
            return reviews;
        }

        public async Task<Review?> GetReviewById(int id)
        {

            Review? reviewFound = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            return reviewFound;
        }

        public async Task CreateReview(Review review)
        {
            await _context.Reviews.AddAsync(review);

            await _context.SaveChangesAsync();

        }


        public async Task DeleteReview(Review review)
        {
            _context.Reviews.Remove(review);

            await _context.SaveChangesAsync();
        }

    }
}
