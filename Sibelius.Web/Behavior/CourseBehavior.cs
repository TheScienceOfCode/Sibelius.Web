using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Behavior
{
    public class CourseBehavior
    {
        UnitOfWork unit = new UnitOfWork();

        #region Basic Behavior
        public void Insert(Course course)
        {            
            unit.Courses.Add(course);
        }

        public Course GetById(string id)
        {
            return unit.Courses.GetById(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return unit.Courses;
        }

        public void Update(Course course)
        {
            unit.Courses.Update(course);
        }

        public void Delete(Course course)
        {
            unit.Courses.Delete(course);
        }
        #endregion

    }
}