namespace WebApplication.FeedbackFeature
{
    public class FeedbackValidation
    {
        public static bool isNewFeedbackValid(NewFeedbackDTO feedback)
            => feedback != null && feedback.Comment != null;
    }
}
