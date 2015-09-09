using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Behavior
{
    public class CollaboratorBehavior
    {
        UnitOfWork unit = new UnitOfWork();
        

        #region Basic Behavior
        public void Insert(Collaborator collaborator)
        {
            unit.Collaborators.Add(collaborator);
        }

        public Collaborator GetById(string id)
        {
            return unit.Collaborators.GetById(id);
        }

        public IEnumerable<Collaborator> GetAll()
        {
            return unit.Collaborators.OrderByDescending(p => p.Answers);
        }

        public Collaborator GetByUsername(string username)
        {
            return unit.Collaborators.Where(c => c.Username == username).FirstOrDefault();
        }

        public void Update(Collaborator collaborator)
        {
            unit.Collaborators.Update(collaborator);
        }

        public void Delete(Collaborator collaborator)
        {
            unit.Collaborators.Delete(collaborator);
        }
        #endregion        
    }
}