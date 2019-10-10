using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        private readonly ConferenceContext _conferenceContext;

        public EditionRepository(ConferenceContext conferenceContext)
        {
            _conferenceContext = conferenceContext;
        }

        public List<Editions> GetAllEditions()
        {
            return _conferenceContext.Editions.ToList();
        }

        public Editions AddEdition(Editions editionToBeAdded)
        {
            EntityEntry<Editions> addedEdition = _conferenceContext.Add(editionToBeAdded);
            _conferenceContext.SaveChanges();

            return addedEdition.Entity;
        }


        public Editions GetEditionById(int id)
        {
            return _conferenceContext.Editions.Find(id);
        }


        public Editions Update(Editions editionToUpdate)
        {
            EntityEntry<Editions> updatedEdition = _conferenceContext.Update(editionToUpdate);
            _conferenceContext.SaveChanges();

            return updatedEdition.Entity;
        }

        public bool IsUniqueEdition(string editionName)
        {
            int nr = _conferenceContext.Editions.Count(x => x.Name == editionName);

            return nr == 0;
        }

        public void Delete(Editions editionToDelete)
        {
            editionToDelete = _conferenceContext.Editions.Find(editionToDelete.Id);

            _conferenceContext.Editions.Remove(editionToDelete);
        }

        public void Save()
        {
            _conferenceContext.SaveChanges();
        }
    }
}