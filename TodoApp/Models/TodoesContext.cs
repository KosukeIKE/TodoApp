

using System.Data.Entity;

namespace TodoApp.Models
{
    public class TodoesContext :DbContext
    {
        //定型文。これで接続する。buildしてデータを反映させる。共通レイアウトへ
        public DbSet<Todo> Todoes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; } 
    }
}