using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MebelTemplate.Models
{
    [Table("tblRolesUsers")]
    public class UserRolsDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual UserDTO User { get; set; }

        public int RoleId { get; set; }
        public virtual RoleDTO Role { get; set; }

    }
}