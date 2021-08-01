namespace Vismy.Application.DTOs
{
    // Report's detail info
    public class ReportInfoDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public int ScoreApproved { get; set; }
        public int ScoreDisapproved { get; set; }

        public PostInfoDTO Post { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
    }
}