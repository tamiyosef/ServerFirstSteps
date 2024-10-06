using TaskManagmentServer.Models;

namespace TaskManagmentServer.DTO
{
    public class UserTaskDTO
    {
        public int TaskId { get; set; }

        public int? UserId { get; set; }

        public int? UrgencyLevelId { get; set; }

        public string TaskDescription { get; set; } = null!;

        public DateOnly TaskDueDate { get; set; }

        public DateOnly? TaskActualDate { get; set; }

        public virtual ICollection<TaskCommentDTO> TaskComments { get; set; } = new List<TaskCommentDTO>();

        public UserTaskDTO() { }
        public UserTaskDTO(Models.UserTask modelTask)
        {
            this.TaskId = modelTask.TaskId;
            this.UserId = modelTask.UserId;
            this.UrgencyLevelId = modelTask.UrgencyLevelId;
            this.TaskDescription = modelTask.TaskDescription;
            this.TaskDueDate = modelTask.TaskDueDate;
            this.TaskActualDate = modelTask.TaskActualDate;
            this.TaskComments = new List<TaskCommentDTO>();
            foreach (var comment in modelTask.TaskComments)
            {
                this.TaskComments.Add(new TaskCommentDTO(comment));
            }
        }
    }
}
