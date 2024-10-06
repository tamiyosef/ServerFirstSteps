namespace TaskManagmentServer.DTO
{
    public class TaskCommentDTO
    {
        public int CommentId { get; set; }

        public int? TaskId { get; set; }

        public string Comment { get; set; } = null!;

        public DateOnly CommentDate { get; set; }

        public TaskCommentDTO() { }
        public TaskCommentDTO(Models.TaskComment modelComment)
        {
            this.CommentId = modelComment.CommentId;
            this.TaskId = modelComment.TaskId;
            this.Comment = modelComment.Comment;
            this.CommentDate = modelComment.CommentDate;
        }
    }
}
