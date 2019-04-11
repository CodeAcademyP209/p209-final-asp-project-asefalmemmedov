using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MebelTemplate.Models
{
    [Table("tblHome")]
    public class HomeDTO
    {
        public int Id { get; set; }
        [StringLength(maximumLength:35,MinimumLength =4)]
        [Required]
        public string HeaderTitle { get; set; }

        [StringLength(maximumLength: 35)]
        [Required]
        public string HeaderPrice { get; set; }

        [StringLength(150)]
        public string Image { get; set; }
    }
}