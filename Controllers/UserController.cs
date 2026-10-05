using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizMgmt.Models;

namespace QuizMgmt.Controllers
{
    public class UserController : Controller
    {
        Dbhandle dbhandle=new Dbhandle();
        // GET: User
        public ActionResult Index()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Create", "User");
            }
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User umodel)
        {
            //try
            //{
                //if (ModelState.IsValid)
                //{
                    if (dbhandle.u_login(umodel.user_name, umodel.user_password) != 0)
                    {
                        Session["uid"] = (int)dbhandle.u_login(umodel.user_name, umodel.user_password);
                        Session["uname"]= umodel.user_name;
                        return RedirectToAction("Index","Result");
                    }
                    else
                        return RedirectToAction("Index","Home");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
