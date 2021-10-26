using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Categories.Core.DTO
{
    public class CategoryReadDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public List<CategoryReadDto> Subcategories { get; set; } = new List<CategoryReadDto>();
    }
}