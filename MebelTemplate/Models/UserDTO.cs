using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MebelTemplate.Models
{
    [Table("tblUsers")]
    public class UserDTO
    {
        public UserDTO()
        {
            UserRols = new HashSet<UserRolsDTO>();
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UserRolsDTO> UserRols { get; set; }
    }
}