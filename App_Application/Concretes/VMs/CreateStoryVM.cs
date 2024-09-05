using App_Domain.Concretes.Composites;
using App_Domain.Concretes;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App_Application.Concretes.VMs
{
    public class CreateStoryVM
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        [DisplayName("Başlık")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int? ViewCount { get; set; }
        public int? Likes { get; set; }
        public bool IsUserLiked { get; set; }
        public string CurrentUserId { get; set; }

        public string? UserImageUrl { get; set; }

        public int TopicId { get; set; }
        public List<SelectListItem>? SelectForTopicId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
