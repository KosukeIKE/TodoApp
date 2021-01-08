using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class LoginViewModel
    {
        [Required]//必須項目にする
        [DisplayName("ユーザー名")]//表示名の変更

        public string UserName { get; set; }//プロパティ

        [Required]
        [DataType(DataType.Password)]//登録したものをパスワードにする
        [DisplayName("パスワード")]
        public string Password { get; set; }
    }
}