using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Domain.Enums;
using InsightHive.PersistenceDemo.Data;
using Moq;
using Moq.EntityFrameworkCore;

namespace InsightHive.PersistenceDemo.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly List<Review> _reviewList;
        private readonly List<Comment> _commentList;
        private readonly List<ReviewReaction> _reviewReactionList;
        private readonly List<Reaction> _reactionList;
        private readonly Mock<FakeContext> _context;
        public ReviewRepository()
        {
            _reactionList = new List<Reaction>
            {
               new Reaction
               {
                   Id = 1,
                   Name = ReactionValue.Like
               },
               new Reaction
               {
                   Id = 2,
                   Name = ReactionValue.Dislike
               },
               new Reaction
               {
                   Id = 3,
                   Name = ReactionValue.Helpful
               },
               new Reaction
               {
                   Id = 4,
                   Name = ReactionValue.Exciting
               },
            };
            _reviewReactionList = new List<ReviewReaction>
            {
               new ReviewReaction
               {
                   ReviewId = 2,
                   ReviewerId = 5,
                   ReactionId = 1,
                   Reaction = _reactionList[0]
               },
               new ReviewReaction
               {
                   ReviewId = 2,
                   ReviewerId = 6,
                   ReactionId = 1,
                   Reaction = _reactionList[0]
               },
               new ReviewReaction
               {
                   ReviewId = 2,
                   ReviewerId = 11,
                   ReactionId = 2,
                   Reaction = _reactionList[1]
               },
               new ReviewReaction
               {
                   ReviewId = 2,
                   ReviewerId = 15,
                   ReactionId = 3,
                   Reaction = _reactionList[2]
               },
            };
            _commentList = new List<Comment>
            {
               new Comment
               {
                   Id = 1,
                   ReviewId = 2,
                   ReviewerId = 4,
                   Content = "nice"
               },
               new Comment
               {
                   Id = 2,
                   ReviewId = 2,
                   ReviewerId = 4,
                   Content = "good eye"
               },
               new Comment
               {
                   Id = 3,
                   ReviewId = 2,
                   ReviewerId = 4,
                   Content = "helpful maybe"
               },
               new Comment
               {
                   Id = 4,
                   ReviewId = 2,
                   ReviewerId = 4,
                   Content = "not enough"
               },
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
                    Comments = _commentList,
                    ReviewReactions = _reviewReactionList
                },
            };
            _context = new Mock<FakeContext>();
            _context.Setup(e => e.Reviews).ReturnsDbSet(_reviewList);
            _context.Setup(e => e.Comments).ReturnsDbSet(_commentList);
        }

        public Task<Review?> GetReviewByIdAsync(int reviewId, int maxComments)
        {
            var review = _context.Object.Reviews.Where(e => e.Id == reviewId)
                                                 .Select(e => new Review
                                                 {
                                                     Id = e.Id,
                                                     Content = e.Content,
                                                     Rate = e.Rate,
                                                     Image = e.Image,
                                                     BusinessId = e.BusinessId,
                                                     ReviewerId = e.ReviewerId,
                                                     Comments = e.Comments.Take(maxComments).ToList()
                                                 })
                                                 .FirstOrDefault();
            return Task.FromResult(review);
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

        public Task<Comment?> GetCommentAsync(int commentId)
        {
            return Task.FromResult(_context.Object.Comments.FirstOrDefault(e => e.Id == commentId));
        }

        public Task<IQueryable<Comment>> GetCommentListAsync(int reviewId)
        {
            return Task.FromResult(_context.Object.Comments.Where(e => e.ReviewId == reviewId));
        }

        public Task<bool> AddReviewCommentAsync(Comment comment)
        {
            _context.Object.Comments.Add(comment);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateReviewCommentAsync(Comment comment)
        {
            _context.Object.Comments.Update(comment);
            return Task.FromResult(false);
        }
    }
}
