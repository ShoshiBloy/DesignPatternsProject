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
            for (int i = 0; i < beforeReview.Count; i++) {
                if (beforeReview[i].collabrators.Contains(collabrator)) { 
                    var reviewToDo = beforeReview[i];
                    beforeReview.Remove(reviewToDo);
                    bool permisssion=reviewToDo.execute(collabrator,reviewToDo.file);
                    reviewToDo.ReviewPermission = permisssion;
                    afterReview.Add(reviewToDo);}
            }
        }
    }
}
