namespace Vismy
{
    enum LikeStatus
    {
        Viewed,
        Liked,
        Disliked
    }

    class ViewedPost
    {
        public readonly User Viewer;
        public LikeStatus Status { get; set; }

        ViewedPost(in User viewer, in LikeStatus status = LikeStatus.Viewed)
        {
            Viewer = viewer;
            Status = status;
        }
    }
}