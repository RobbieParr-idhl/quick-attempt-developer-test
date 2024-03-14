using NetC.DeveloperExam.WebCore.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NetC.DeveloperExam.WebCore.Utils
{
    public static class BlogData
    {
        public static BlogModel GetBlogData(int id)
        {
            Dictionary<string,List<BlogModel>> data = JsonConvert.DeserializeObject<Dictionary<string,List<BlogModel>>>(File.ReadAllText(@".\\App_Data\\Blog-Posts - Copy.json"));
            List<BlogModel> list = new List<BlogModel>();
            data.TryGetValue("blogPosts" ,out list);

            return (list.Where(item => item.id == id).SingleOrDefault());
        }

        public static void SaveBlogData(BlogModel blog)
        {

            Dictionary<string, List<BlogModel>> data = JsonConvert.DeserializeObject<Dictionary<string, List<BlogModel>>>(File.ReadAllText(@".\\App_Data\\Blog-Posts - Copy.json"));
            List<BlogModel> list = new List<BlogModel>();
            data.TryGetValue("blogPosts", out list);


            List<BlogModel> newList = new List<BlogModel>();
            list.ForEach(item => { 
            if(item.id == blog.id)
                {
                    newList.Add(blog);
                }
                else
                {
                    newList.Add(item);
                }
               });

            Dictionary<string, List<BlogModel>> dataToSave = new Dictionary<string, List<BlogModel>>();
            dataToSave.Add("blogPosts", newList);

            File.WriteAllText(@".\\App_Data\\Blog-Posts - Copy.json",JsonConvert.SerializeObject(dataToSave));

        }


    }
}
