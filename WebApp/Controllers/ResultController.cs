using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Model.Model;
using WebApp.BLL.BLL;

namespace WebApp.Controllers
{
    public class ResultController : Controller
    {
        ResultManager _resultManager = new ResultManager();
        // GET: Result
        [HttpGet]
        public ActionResult Add()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Add(Result result)
        {
            result = new Result()
            {
                StudentName = "Monzur Hasan",
                ResultDetailses = new List<ResultDetails>()
                {
                    new ResultDetails{Subject = "CSE", Marks = 80},
                    new ResultDetails{Subject = "EEE", Marks = 75},
                    new ResultDetails{Subject = "Math", Marks = 85}
                }
            };

            _resultManager.Add(result);
            return View();
        }
    }
}
