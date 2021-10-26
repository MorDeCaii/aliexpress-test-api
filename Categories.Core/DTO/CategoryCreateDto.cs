using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Categories.Core.DTO
{
    public class CategoryCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid Name length (Max = 100, Min = 1)")]
        public string Name { get; set; }
        
        [Range(0, long.MaxValue, ErrorMessage = "Invalid ParentId")]
        public int ParentId { get; set; }
    }
}