using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapcuoimonweb.Models;
namespace baitapcuoimonweb.Areas.Cms.Controllers
{
    [Authorize]
    public class HomeCmsController : Controller
    {
        // GET: Cms/HomeCms
        public ActionResult Index()
        {

            return View();
        }
    }
}