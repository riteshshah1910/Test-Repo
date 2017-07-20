using MVCTraining.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTraining.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork = null;

        //public HomeController()
        //{
        //    this.unitOfWork = new UnitOfWork();
        //}

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult List()
        {
            var data = unitOfWork.Repository<Category>().GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.BeginTransaction();

                    unitOfWork.Repository<Category>().Add(model);
                    unitOfWork.SaveChanges();

                    unitOfWork.Repository<BlogPost>().Add(new BlogPost { CategoryId = model.Id, Content = "Ahmedabad", PublishDate = DateTime.UtcNow, Title = "City" });
                    unitOfWork.SaveChanges();

                    unitOfWork.Repository<StudentModel>().Add(new StudentModel { StudentName = "Ritesh", StudentAddress = "Gandhinagar", StudentPhoneNo = "9974103593" });
                    unitOfWork.SaveChanges();

                    unitOfWork.CommitTransaction();
                }
                catch
                {
                    unitOfWork.RollBackTransaction();
                }
                return RedirectToAction("List", "Home");
            }

            return View(model);
        }

        public ActionResult Student()
        {
            StudentModel model = new StudentModel();
            model.StudentName = "Ritesh";
            return View(model);
        }

        public ActionResult Customer()
        {
            StudentModel model = new StudentModel();
            model.StudentName = "Ritesh";
            return View(model);
        }

        [HttpPost]
        public ActionResult Student(StudentModel model)
        {
            return View(model);
        }
    }
}
