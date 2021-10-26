using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Categories.Core.DTO
{
    public class CategoryUpdateDto
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid Id")]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid Name length (Max = 100, Min = 1)")]
        public string Name { get; set; }
        
        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Invalid ParentId")]
        public int ParentId { get; set; }
    }
}