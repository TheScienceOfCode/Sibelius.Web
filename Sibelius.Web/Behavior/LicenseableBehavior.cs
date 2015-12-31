using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Behavior
{
    public class LicenseableBehavior<T> where T : LicenseableEntity
    {
        LicenseBehavior licenseBehavior = new LicenseBehavior();

        #region Licensing
        public void AddLicense(T entity)
        {
            if (entity.LicenseId != null)
                entity.License = licenseBehavior.GetById(entity.LicenseId);
        }

        public void AddLicense(List<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.LicenseId != null)
                    entity.License = licenseBehavior.GetById(entity.LicenseId);
            }
        }
        #endregion
    }
}