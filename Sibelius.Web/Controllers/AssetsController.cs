using Sibelius.Web.Behavior;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Controllers
{
    public class AssetsController : Controller
    {
        AssetBehavior assetBehavior = new AssetBehavior();
        CollaboratorBehavior collaboratorBehavior = new CollaboratorBehavior();

        public ActionResult Show(string id)
        {
            var asset = assetBehavior.GetById(id);
           
            return View(asset);
        }
    }
}