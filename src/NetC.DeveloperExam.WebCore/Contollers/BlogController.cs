using Microsoft.AspNetCore.Mvc;
using NetC.DeveloperExam.WebCore.Models;
using NetC.DeveloperExam.WebCore.Utils;
using Newtonsoft.Json;
using System.IO;

namespace NetC.DeveloperExam.WebCore.Contollers
{
    [Route("Blog")]
    public class BlogController : Controller
    {
        [Route("{id}")]
        public IActionResult BlogArticle(int id)
        {
            

            BlogModel blog = BlogData.GetBlogData(id);

            return View(blog);
        }

        [Route("{id}/comment/")]
        [HttpPost]
        public void FormPost(int id)
        {
            BlogModel blog = BlogData.GetBlogData(id);


            Comment result = new Comment() {
                id = blog.comments.Count(),
                name = Request.Form["Name"],
                emailAddress = Request.Form["EmailAddress"],
                message = Request.Form["Message"],
                date = DateTime.Now,
                replys = [],
            };

            
            blog.comments.Add(result);

            BlogData.SaveBlogData(blog);
            Response.Redirect("/blog/"+id);

            
        }


        [Route("{id}/reply/{commentId}")]
        [HttpPost]
        public void FormPost(int id, int commentId)
        {
            BlogModel blog = BlogData.GetBlogData(id);
            Comment currentComment = blog.comments.Where(comment => comment.id == commentId).SingleOrDefault();
            int size;
            if (currentComment.replys == null)
            {
                size = 0;
            }
            else
            {
                size = currentComment.replys.Count();
            }
            
            Comment result = new Comment()
            {
                id=int.Parse(commentId+""+size),
                name = Request.Form["Name"],
                emailAddress = Request.Form["EmailAddress"],
                message = Request.Form["Message"],
                date = DateTime.Now,
            };
            if (currentComment.replys != null)
            {
                currentComment.replys.Add(result);
            }
            else
            {
                currentComment.replys = [result];
            }

            BlogData.SaveBlogData(blog);
            Response.Redirect("/blog/" + id);
            
        }

    }
}
