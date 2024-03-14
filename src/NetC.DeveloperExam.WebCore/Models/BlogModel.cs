using System.Runtime.CompilerServices;

namespace NetC.DeveloperExam.WebCore.Models
{
    public class BlogModel
    {
        public int id { get; set; }
        public DateTime date { get; set; }

        public string title { get; set; }

        public string image { get; set; }

        public string htmlContent { get; set; }

        public List<Comment> comments { get; set; }

    }
}
