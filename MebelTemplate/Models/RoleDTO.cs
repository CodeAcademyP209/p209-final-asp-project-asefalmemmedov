using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MebelTemplate.Models
{
    [Table("tblRoles")]
    public class RoleDTO
    {
        public RoleDTO()
        {
            UserRols = new HashSet<UserRolsDTO>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserRolsDTO> UserRols { get; set; }
    }
}