using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        //一つのRoleの中に複数のユーザーを持つ
        public virtual ICollection<User> Users { get; set; }
    }
}