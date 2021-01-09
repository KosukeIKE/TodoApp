using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoApp;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Authorize]//認証されている状態のみ確認できる
    public class TodoesController : Controller
    {
        private TodoesContext db = new TodoesContext();//controllerでDBを操作するために初期化
        //これらはアクションメソッドと言う
        //アクセスするときは必ずDBを通して行う

        // GET: Todoes にアクセスがあるとこのメソッドが呼ばれる
        public ActionResult Index()//アクションクラスを呼ぶ
        {
            //UserNameを表示する
            var user = db.Users.Where(item => item.UserName == User.Identity.Name).FirstOrDefault();

            if(user !=null)
            {
                return View(user.Todoes);
            }
            return View(new List<Todo>());

            //return View(db.Todoes.ToList());//index.cshtmlにtodoのリストを与えて表示する
        }

        // GET: Todoes/Details/5
        public ActionResult Details(int? id)//idが未指定の場合はnull、違う場合はIdがセットされる
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Todo todo = db.Todoes.Find(id);//データのIdを変数に入れ込む。
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // GET: Todoes/Create.cshtml
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todoes/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        [HttpPost]//クライアントがPostされたら呼ばれるアノテーション（属性）
        [ValidateAntiForgeryToken]//CSRF対策のためにPostされたトークン(Viewで生成されたもの)を検証する
        public ActionResult Create([Bind(Include = "Id,Summary,Detail,Limit,Done")] Todo todo)//[Bind(Include = "Id,Summary,Detail,Limit,Done")]過多ポスティング攻撃を防いでいる
        {
            if (ModelState.IsValid)//入力内容が適切の場合
            {

                var user = db.Users.Where(item => item.UserName == User.Identity.Name).FirstOrDefault();

                //if (user != null)
                //{
                    todo.User = user;


                    db.Todoes.Add(todo);//sbsetに値を登録する
                    db.SaveChanges();//dbに変更を反映する
                    return RedirectToAction("Index");//指定されたアクションに転送するHelpermethod
                //}

            }

            return View(todo);
        }

        // GET: Todoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Edit/5

        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Summary,Detail,Limit,Done")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified;//該当のデータをセットして更新できる
                db.SaveChanges();//更新を反映する
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Todo todo = db.Todoes.Find(id);
            db.Todoes.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);//Disposeは終了処理のこと
        }
    }
}
