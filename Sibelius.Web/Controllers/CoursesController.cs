﻿using Sibelius.Web.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        CourseBehavior courseBehavior = new CourseBehavior();

        // GET: Class
        public ActionResult Index()
        {
            return View(courseBehavior.GetVisible());
        }

        public ActionResult Show(string id)
        {
            var course = courseBehavior.GetById(id);
            return View(course);
        }
    }
}