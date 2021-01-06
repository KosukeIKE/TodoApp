using System.Web.Mvc;
using System.Web.Security;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [AllowAnonymous]//認証されてない状態で見れるようにする
    public class LoginController : Controller
    {
        readonly CustomMembershipProvider membershipProvider = new CustomMembershipProvider();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //ログイン処理
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post;
        public ActionResult Index([Bind(Include = "UserName, Password")] LoginViewModel model)
        {
            if(ModelState.IsValid)            {

                if(this.membershipProvider.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);//認証を保持する
                    return RedirectToAction("Index", "Todoes");
                }
            }
            //認証時の処理
            ViewBag.Message = "ログインに失敗しました。";//エラー時にメッセージ
            return View(model);
        }

        //ログアウト処理
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();//認証Cokieの削除
            return RedirectToAction("Index");
        }

    }
}