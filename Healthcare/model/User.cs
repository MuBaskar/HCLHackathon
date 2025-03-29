using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool Isconsent { get; set; }

        public DateTime CreateDate { get; set; }

        public UserRole userRole { get; set; }

    }
}
