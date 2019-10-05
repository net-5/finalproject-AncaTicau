using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface IEditionRepository
    {
        List<Editions> GetAllEditions();
        Editions GetEditionById(int id);
        Editions Update(Editions editionToUpdate);
        Editions AddEdition(Editions editionToBeAdded);
        bool IsUniqueEdition(string editionName);
        void Delete(Editions editionToDelete);
        void Save();
    }
    public class EditionRepository : IEditionRepository
    {
        private readonly ConferenceContext conferenceContext;
        public EditionRepository(ConferenceContext conferenceContext)
        {
            this.conferenceContext = conferenceContext;
        }
        public List<Editions> GetAllEditions()
        {
            return conferenceContext.Editions.ToList();
        }
        public Editions AddEdition(Editions editionToBeAdded)
        {
            var addedEdition = conferenceContext.Add(editionToBeAdded);
            conferenceContext.SaveChanges();
            return addedEdition.Entity;
        }


        public Editions GetEditionById(int id)
        {
            return conferenceContext.Editions.Find(id);
        }


        public Editions Update(Editions editionToUpdate)
        {
            var updatedEdition = conferenceContext.Update(editionToUpdate);
            conferenceContext.SaveChanges();
            return updatedEdition.Entity;
        }
        public bool IsUniqueEdition(string editionName)
        {
            int nr = conferenceContext.Editions.Count(x => x.Name == editionName);
            if (nr == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Delete(Editions editionToDelete)
        {
            editionToDelete = conferenceContext.Editions.Find(editionToDelete.Id);
            conferenceContext.Editions.Remove(editionToDelete);

        }
        public void Save()
        {
            conferenceContext.SaveChanges();
        }
    }
}
