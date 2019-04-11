using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MebelTemplate.Models
{
    [Table("tblCategory")]
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            Banners = new HashSet<BannerDTO>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 4)] 
        public string CatName { get; set; }

        public virtual ICollection<BannerDTO> Banners { get; set; }
    }
}