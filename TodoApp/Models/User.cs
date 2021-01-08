using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique =true)]//重複を防ぐため
        [StringLength(256)]//重複を作るときにセットで書く。長さの設定
        [DisplayName("ユーザー名")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]//
        [DisplayName("パスワード")]
        public string Password { get; set; }


        //一人のユーザーは複数Role持てるようにする(ナビゲーションプロパティ)
        public virtual ICollection<Role> Roles { get; set; }

        [NotMapped]
        [DisplayName("ロール")]
        public List<int> RoleIds { get; set; }

        //1対nの関係を持つことができる
        public virtual ICollection<Todo> Todoes { get; set; }
    }
}