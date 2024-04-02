using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Command
{
    public class ReviewsManager
    {
        public List<Review> beforeReview;
        public List<Review> afterReview;
        static ReviewsManager reviewsManager;

        public static object locker;

        static ReviewsManager()
        {
            locker = new object();
        }
        public static ReviewsManager GetInstance()
        {
            if (reviewsManager == null)
            {
                lock (locker)
                {
                    if (reviewsManager == null)
                    {
                        reviewsManager = new ReviewsManager();
                    }
                }
            }
            return reviewsManager;
        }

        private ReviewsManager()
        {
            beforeReview = new List<Review>();
            afterReview = new List<Review>();
        }

        public void AddReview(Review review)
        {
            beforeReview.Add(review);
        }
        public void DoReviews(Collabrator collabrator)
        {
            Queue<Review> reviewsQueue = new Queue<Review>();
            foreach (Review review in beforeReview)
            {
                if (review.collabrators.Contains(collabrator))
                {
                    reviewsQueue.Enqueue(review);
                }
            }
            foreach (Review review in reviewsQueue)
            {
                var reviewToDo = review;
                beforeReview.Remove(reviewToDo);
                reviewsQueue.Dequeue();
                bool permisssion = reviewToDo.execute(collabrator, reviewToDo.file);
                reviewToDo.ReviewPermission = permisssion;
                afterReview.Add(reviewToDo);
            }
        }
        public bool CheckPermission(Composite.File file)
        {
            
            foreach (var item in afterReview)
            {
                if (item.file == file)
                    return item.ReviewPermission;
            }
            return false;
        }


    }
}

