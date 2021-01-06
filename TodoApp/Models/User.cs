﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Index(IsUnique =true)]
        [StringLength(256)]
        [DisplayName("ユーザー名")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("パスワード")]
        public string Password { get; set; }

        //一人のユーザーは複数持てる
        public ICollection<Role> Roles { get; set; }
    }
}