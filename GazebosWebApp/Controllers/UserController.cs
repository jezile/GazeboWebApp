using GazebosWebApp.Models;
using GazebosWebApp.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GazebosWebApp.Controllers
{
    public class UserController : Controller
    {
        private IGenericRepository<UserModel> repository = null;

        public UserController()
        {
            this.repository = new UserRepository();
        }

        public UserController(IGenericRepository<UserModel> repository)
        {
            this.repository = repository;
        }



        public ActionResult Index()
        {
            List<UserModel> model = (List<UserModel>)repository.SelectAll();
            return View(model);
        }

        public ActionResult Details()
        {
            var model = repository.SelectByID(1000);
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Index(int UserID)
        //{
        //    var model = repository.SelectByID(UserID);
        //    return View(model);
        //}
    }
}