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
        LicenseableBehavior<Course> licenseableBehavior =  new LicenseableBehavior<Course>();

        #region Basic Behavior
        public void Insert(Course course)
        {            
            unit.Courses.Add(course);
        }

        public Course GetById(string id)
        {
            var course = unit.Courses.GetById(id);

            licenseableBehavior.AddLicense(course);
            return course;
        }

        public List<Course> GetAll()
        {
            var courses = unit.Courses
                .OrderByDescending(c => c.Year)
                .ThenByDescending(c => c.Semester)
                .ToList();

            licenseableBehavior.AddLicense(courses);
            return courses;
        }

        public List<Course> GetVisible()
        {
            var courses = unit.Courses
                .Where(c => c.Visible == true)
                .OrderByDescending(c => c.Year)
                .ThenByDescending(c => c.Semester)
                .ToList();

            licenseableBehavior.AddLicense(courses);
            return courses;
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