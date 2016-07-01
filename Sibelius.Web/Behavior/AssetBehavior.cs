using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sibelius.Web.Common;

namespace Sibelius.Web.Behavior
{
    public class AssetBehavior
    {        
        UnitOfWork unit = new UnitOfWork();
        LicenseableBehavior<Asset> licenseableBehavior = new LicenseableBehavior<Asset>();

        #region Basic Behavior
        public void Insert(Asset asset)
        {
            unit.Assets.Add(asset);
        }

        public Asset GetById(string id)
        {
            var asset = unit.Assets.GetById(id);

            licenseableBehavior.AddLicense(asset);
            return asset;
        }

        public List<Asset> GetVisible()
        {
            var assets = unit.Assets
                .Where(c => c.Visible == true)
                .OrderByDescending(c => c.Date).ToList();

            licenseableBehavior.AddLicense(assets);
            return assets;
        }

        public List<Asset> GetAll()
        {
            var assets = unit.Assets.OrderByDescending(c => c.Date).ToList();

            licenseableBehavior.AddLicense(assets);          
            return assets;
        }

        public void Update(Asset asset)
        {
            unit.Assets.Update(asset);
        }

        public void Delete(Asset asset)
        {
            unit.Assets.Delete(asset);
        }
        #endregion       
    }
}