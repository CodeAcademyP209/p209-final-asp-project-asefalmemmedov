using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MebelTemplate.Models
{
    [Table("tblBanner")]
    public class BannerDTO
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Image { get; set; }
        [Required]
        [StringLength(maximumLength: 500, MinimumLength = 10)]
        public string BannerContent { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryDTO Category { get; set; }

      
    }
}