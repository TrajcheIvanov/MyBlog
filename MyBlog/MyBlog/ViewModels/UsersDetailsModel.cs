

using System.Collections.Generic;

namespace MyBlog.ViewModels
{
    public class UsersDetailsModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public List<CommentUserDetailsModel> Comments { get; set; }
    }
}
