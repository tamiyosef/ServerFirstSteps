using TaskManagmentServer.Models;

namespace TaskManagmentServer.DTO
{
    public class AppUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string UserLastName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public bool IsManager { get; set; }

        // ProfileImagePath is a virtual path to the user's profile image
        // not excist in the model
        public string ProfileImagePath { get; set; } = "";
        public virtual ICollection<UserTaskDTO> UserTasks { get; set; } = new List<UserTaskDTO>();

        public AppUserDTO() { }
        public AppUserDTO(Models.AppUser modelUser)
        {
            this.Id = modelUser.Id;
            this.UserName = modelUser.UserName;
            this.UserLastName = modelUser.UserLastName;
            this.UserEmail = modelUser.UserEmail;
            this.UserPassword = modelUser.UserPassword;
            this.IsManager = modelUser.IsManager;
            this.UserTasks = new List<UserTaskDTO>();
            foreach (var task in modelUser.UserTasks)
            {
                this.UserTasks.Add(new UserTaskDTO(task));
            }
        }
    }
}
