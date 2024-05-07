using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace InsightHive.PersistenceDemo
{
    public class ReviewsContext : DbContext
    {
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ReviewComment> ReviewComments { get; set; }
    }

    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly List<Review> _reviewList;
        private readonly Mock<ReviewsContext> _context;
        public ReviewRepository()
        {
            var reviewComments = new List<ReviewComment>
            {
               new ReviewComment
               {
                   ReviewId = 2,
                   ReviewerId = 2,
                   CommentId = 1,
                   Comment = new Comment{Id = 1, Content= "nice"}
               },
                new ReviewComment
               {
                   ReviewId = 2,
                   ReviewerId = 3,
                   CommentId = 2,
                   Comment = new Comment{Id = 2, Content= "good to know"}
               },
                 new ReviewComment
               {
                   ReviewId = 2,
                   ReviewerId = 4,
                   CommentId = 3,
                   Comment = new Comment{Id = 3, Content= "i don't think so"}
               },
                  new ReviewComment
               {
                   ReviewId = 2,
                   ReviewerId = 5,
                   CommentId = 4,
                   Comment = new Comment{Id = 4, Content= "wow"}
               },
                   new ReviewComment
               {
                   ReviewId = 2,
                   ReviewerId = 6,
                   CommentId = 5,
                   Comment = new Comment{Id = 5, Content= "ok"}
               }
            };

            _reviewList = new List<Review>()
            {
                new Review {
                    Id = 1,
                    Content = "voolaa",
                    Rate = 4.5f,
                    ReviewerId = 2,
                    BusinessId = 3,
                    CreatedDate = DateTime.Now - TimeSpan.FromHours(1)
                },
                new Review {
                    Id = 2,
                    Content = "voolaa",
                    Rate = 4.5f,
                    ReviewerId = 3,
                    BusinessId = 4,
                    CreatedDate = DateTime.Now - TimeSpan.FromHours(1),
                    ReviewComments = reviewComments
                },
            };
            _context = new Mock<ReviewsContext>();
            _context.Setup(e => e.Reviews).ReturnsDbSet(_reviewList);
            _context.Setup(e => e.ReviewComments).ReturnsDbSet(reviewComments);
        }

        public Task<IQueryable<Review>> GetReviewsByBusinessIdAsync(int businessId, int maxComments)
        {
            //return Task.FromResult(_reviewList.Where(e => e.BusinessId == businessId).AsQueryable());
            var reviews = _context.Object.Reviews.Where(e => e.BusinessId == businessId);
            return Task.FromResult(reviews);
        }

        public Task<Review?> GetReviewByIdAsync(int id)
        {
            return Task.FromResult(_reviewList.FirstOrDefault(review => review.Id == id));
        }

        public Task<bool> AddReviewAsync(Review review)
        {
            review.Id = 20;
            review.CreatedDate = DateTime.Now;
            _reviewList.Add(review);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateReviewAsync(Review review)
        {
            var index = _reviewList.FindIndex(e => e.Id == review.Id);
            if (index != -1)
            {
                review.CreatedDate = _reviewList[index].CreatedDate;
                review.LastModifiedDate = DateTime.Now;
                _reviewList[index] = review;
                return Task.FromResult(true);
            }
            else return Task.FromResult(false);
        }

        public Task<bool> DeleteReviewAsync(Review review)
        {
            int oldCount = _reviewList.Count;
            _reviewList.Remove(review);
            return Task.FromResult(oldCount == _reviewList.Count - 1);
        }
    }
}
