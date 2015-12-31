using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Behavior
{
    public class LicenseBehavior
    {
        UnitOfWork unit = new UnitOfWork();

        #region Basic Behavior
        public void Insert(License license)
        {
            unit.Licenses.Add(license);
        }

        public License GetById(string id)
        {
            return unit.Licenses.GetById(id);
        }

        public IEnumerable<License> GetAll()
        {
            return unit.Licenses;
        }

        public void Update(License license)
        {
            unit.Licenses.Update(license);
        }

        public void Delete(License license)
        {
            unit.Licenses.Delete(license);
        }
        #endregion

        public SelectList GetSelectList()
        {
            return new SelectList(GetAll(), Global.IdProperty, License.DescProperty);
        }
    }
}