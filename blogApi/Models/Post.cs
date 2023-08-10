using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace blogApi.Models;

public class Post :BaseEntity {

    public Post() {
        Comments = new HashSet<Comment>();
    }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;

    public virtual ICollection<Comment> Comments{get; set;}
}