using NetC.DeveloperExam.WebCore.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;

namespace NetC.DeveloperExam.WebCore.Utils
{
    public static class Format
    {

        public static string FormatDate(DateTime date)
        {
            return $"{date.Month} {date.Day}, {date.Year}";
        }

        public static string FormatComments(List<Comment>? comments,int id)
        { 
            
            if (comments == null) return "";
            string returnResult = "";
            comments.ForEach(comment =>
                 returnResult = returnResult+ @"
                <form  method='post' action='"+id+@"/reply/"+comment.id+@"'>
                <div class='media mb-4'>
                    <img class='d-flex mr-3 rounded-circle user-avatar' src='https://eu.ui-avatars.com/api/?name=" + comment.name.Replace(" ","-")+@"' alt='"+comment.name+@"'>
                    <div class='media-body'>
                        <h5 class='mt-0'>"+comment.name+@"<small><em>("+comment.date.ToLongTimeString()+@")</em></small></h5>
                        "+comment.message+@"
                    </div>
                    
                        <div style='padding-left:20px'>
                    "+FormatComments(comment.replys, comment.id) + @"

                            <div class='form-row'>
                                <div class='form-group col-md-6'>
                                    <label for='Name'>Name</label>
                                    <input class='form-control' id='Name' placeholder='Name' name='Name' required>
                                </div>
                                <div class='form-group col-md-6'>
                                    <label for='EmailAddress'>Email Address</label>
                                    <input type='email' class='form-control' id='EmailAddress' 
                                    placeholder='Email Address' 
                                    name='EmailAddress'
                                    required>
                                </div>
                                <div class='form-group'>
                                    <label for='Message'>Message</label>
                                    <textarea id='Message' class='form-control' rows='3' name='Message'></textarea>
                                </div>
                            </div>
                     <button type='submit' class='btn btn-primary'>Reply</button>
                    </div>
                </div>
                </form>
                "
            );
            return returnResult;
        }

    }
}
