using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blogApi.Models;

public class Comment : BaseEntity
{
    
        public virtual Post Post { get; set; }

         public int PostId { get; set; }
        public string? Text { get; set; } 
    
         
}