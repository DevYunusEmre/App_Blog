namespace App_Application.Concretes.VMs
{
    public class ReadStoryVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? ViewCount { get; set; }
        public int? Likes { get; set; }
        public string CurrentUserId { get; set; }
        public bool IsUserLiked { get; set; }
        public string? ImageUrl { get; set; }

        public string? UserImageUrl { get; set; }
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
