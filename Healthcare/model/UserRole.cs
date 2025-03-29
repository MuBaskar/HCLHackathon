using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{

    public class UserRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRoleMappingID { get; set; }
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role role { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
