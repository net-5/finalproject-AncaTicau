using Conference.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Conference.Data
{
    public interface IWorkshopRepository
    {
        List<Workshops> GetAllWorkshops();
        Workshops GetWorkshopById(int id);
        Workshops Update(Workshops workshopToUpdate);
        Workshops AddWorkshop(Workshops workshopToBeAdded);
        bool IsUniqueWorkshop(string workshopName);
        void Delete(Workshops workshopToDelete);
        void Save();
    }

    public class WorkshopRepository : IWorkshopRepository
    {
        private readonly ConferenceContext _conferenceContext;

        public WorkshopRepository(ConferenceContext conferenceContext)
        {
            _conferenceContext = conferenceContext;
        }

        public List<Workshops> GetAllWorkshops()
        {
            return _conferenceContext.Workshops.Include(x => x.Speaker).ToList();
        }

        public Workshops AddWorkshop(Workshops workshopToBeAdded)
        {
            EntityEntry<Workshops> addedWorkshop = _conferenceContext.Add(workshopToBeAdded);
            _conferenceContext.SaveChanges();

            return addedWorkshop.Entity;
        }

        public Workshops GetWorkshopById(int id)
        {
            return _conferenceContext.Workshops.Include(x => x.Speaker).FirstOrDefault(x => x.Id == id);
        }

        public Workshops Update(Workshops workshopToUpdate)
        {
            EntityEntry<Workshops> updatedWorkshop = _conferenceContext.Update(workshopToUpdate);
            _conferenceContext.SaveChanges();

            return updatedWorkshop.Entity;
        }

        public bool IsUniqueWorkshop(string workshopName)
        {
            int nr = _conferenceContext.Workshops.Count(x => x.Name == workshopName);

            return nr == 0;
        }

        public void Delete(Workshops workshopToDelete)
        {
            workshopToDelete = _conferenceContext.Workshops.Find(workshopToDelete.Id);

            _conferenceContext.Workshops.Remove(workshopToDelete);

        }

        public void Save()
        {
            _conferenceContext.SaveChanges();
        }
    }
}