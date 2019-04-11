using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MebelTemplate.Models
{
    [Table("tblServices")]
    public class ServicesDTO
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 155, MinimumLength = 5)]
        [Required]
        public string ServicesTitle { get; set; }

        [StringLength(maximumLength: 300, MinimumLength = 10)]
        [Required]
        public string ServicesContent { get; set; }

        public string Image { get; set; }

    }
}