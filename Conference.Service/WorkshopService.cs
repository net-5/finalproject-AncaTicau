using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Conference.Data;

namespace Conference.Service
{
    public interface IWorkshopService
    {
        IEnumerable<Workshops> GetAllWorkshops();
        Workshops GetWorkshopById(int id);
        Workshops AddWorkshop(Workshops workshopToBeAdded);
        Workshops UpdateWorkshop(Workshops workshopToUpdate);
        void Delete(Workshops workshopToDelete);
        void Save();
    }

    public class WorkshopService : IWorkshopService
    {
        private readonly IWorkshopRepository workshopRepository;
        public WorkshopService(IWorkshopRepository workshopRepository)
        {
            this.workshopRepository = workshopRepository;
        }
        public Workshops AddWorkshop(Workshops workshopToBeAdded)
        {
            if (IsUniqueWorkshop(workshopToBeAdded.Name))
            {
                return workshopRepository.AddWorkshop(workshopToBeAdded);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Workshops> GetAllWorkshops()
        {
            return workshopRepository.GetAllWorkshops();
        }

        public Workshops GetWorkshopById(int id)
        {
            return workshopRepository.GetWorkshopById(id);
        }

        public Workshops UpdateWorkshop(Workshops workshopToUpdate)
        {
            return workshopRepository.Update(workshopToUpdate);
        }
        private bool IsUniqueWorkshop(string workshopName)
        {
            if (workshopRepository.IsUniqueWorkshop(workshopName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Delete(Workshops workshopToDelete)
        {
            workshopRepository.Delete(workshopToDelete);

        }
        public void Save()
        {
            workshopRepository.Save();
        }
    }
}
