using Readify.Data;
using Readify.DTOs.Review;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddReview(InsertReviewDto reviewDto)
        {
            try
            {
                var review = new Review
                {
                    BookId = reviewDto.BookId,
                    ReviewDate = reviewDto.ReviewDate,
                    PersonId = reviewDto.PersonId,
                    Rating = reviewDto.Rating,
                };

                _context.Reviews.Add(review);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding review: " + ex.Message);
            }
        }

        public void DeleteReview(Guid id)
        {
            try
            {
                var review = _context.Reviews.FirstOrDefault(r => r.Id == id);
                if (review == null)
                    throw new Exception("Review not found");

                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting announcement: " + ex.Message);
            }
        }

        public List<GetAllReview> GetAllReview()
        {
            try
            {
                var review = _context.Reviews.ToList();
                if (review == null || !review.Any())
                    throw new Exception("No review found");

                return review.Select(r => new GetAllReview
                {
                    Rating = r.Rating,
                    ReviewDate = r.ReviewDate,
                    PersonId = r.PersonId,
                    BookId = r.BookId,
                    Id = r.Id
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching review: " + ex.Message);
            }
        }

        public GetAllReview GetById(Guid id)
        {
            try
            {
                var review = _context.Reviews.FirstOrDefault(a => a.Id == id);
                if (review == null)
                    throw new Exception("Review not found");

                return new GetAllReview
                {
                    Rating = review.Rating,
                    ReviewDate = review.ReviewDate,
                    PersonId = review.PersonId,
                    BookId = review.BookId,
                    Id = review.Id
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching review: " + ex.Message);
            }
        }

        public void UpdateReview(Guid id, UpdateReviewDto reviewDto)
        {
            try
            {
                var review = _context.Reviews.FirstOrDefault(a => a.Id == id);
                if (review == null)
                    throw new Exception("Review not found");

                review.ReviewDate = reviewDto.ReviewDate;
                review.PersonId = reviewDto.PersonId;
                review.BookId = reviewDto.BookId;
                review.Id = reviewDto.Id; 


                _context.Reviews.Update(review);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating review: " + ex.Message);
            }
        }
    }
}
