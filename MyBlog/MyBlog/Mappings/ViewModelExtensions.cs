using MyBlog.Models;
using MyBlog.ViewModels;

namespace MyBlog.Mappings
{
    public static class ViewModelExtensions
    {

        public static Event ToModel(this EventCreateModel viewModel)
        {
            return new Event
            {
                Name = viewModel.Name,
                ImgUrl = viewModel.ImgUrl,
                Location = viewModel.Location,
                Date = viewModel.Date,
                OrganizedBy = viewModel.OrganizedBy,
                Description = viewModel.Description,
            };
        }

        public static Event ToModel (this EventUpdateModel viewModel)
        {
            return new Event
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ImgUrl = viewModel.ImgUrl,
                Location = viewModel.Location,
                Date = viewModel.Date,
                OrganizedBy = viewModel.OrganizedBy,
                Description = viewModel.Description,
            };
        }
        public static User ToModel(this UserUpdateModel updateModel)
        {
            return new User
            {
                Username = updateModel.Username,
                Email = updateModel.Email,
            };
        }

        public static User ToModel(this SignUpModel signUpModel)
        {
            return new User
            {
                Username = signUpModel.Username,
                Email = signUpModel.Email,
                Password = signUpModel.Password,
            };
        }
    }
}
