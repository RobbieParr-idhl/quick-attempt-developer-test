namespace NetC.DeveloperExam.WebCore.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string emailAddress { get; set; }

        public string? message { get; set; }

        public List<Comment>? replys { get; set; }

    }
}
