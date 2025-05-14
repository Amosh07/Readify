using Readify.DTOs.Review;

namespace Readify.Service.Interface
{
    public interface IReviewService
    {
        void AddReview(InsertReviewDto reviewDto);

        List<GetAllReview> GetAllReview();

        GetAllReview GetById(Guid id);

        void DeleteReview(Guid id);

        void UpdateReview(Guid id, UpdateReviewDto reviewDto);

    }
}
