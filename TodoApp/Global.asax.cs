using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using TodoApp.Migrations;
using TodoApp.Models;

namespace TodoApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //アプリが起動したときに最初に呼ばれるメソッド
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //enitityframeworkの初期化処理を行う
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodoesContext, Configuration>());
        }
    }
}
