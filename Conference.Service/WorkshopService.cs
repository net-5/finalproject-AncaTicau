using Conference.Domain.Entities;
using System.Collections.Generic;
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
        private readonly IWorkshopRepository _workshopRepository;

        public WorkshopService(IWorkshopRepository workshopRepository)
        {
            _workshopRepository = workshopRepository;
        }

        public Workshops AddWorkshop(Workshops workshopToBeAdded)
        {
            if (IsUniqueWorkshop(workshopToBeAdded.Name))
            {
                return _workshopRepository.AddWorkshop(workshopToBeAdded);
            }

            return null;
        }

        public IEnumerable<Workshops> GetAllWorkshops()
        {
            return _workshopRepository.GetAllWorkshops();
        }

        public Workshops GetWorkshopById(int id)
        {
            return _workshopRepository.GetWorkshopById(id);
        }

        public Workshops UpdateWorkshop(Workshops workshopToUpdate)
        {
            return _workshopRepository.Update(workshopToUpdate);
        }

        private bool IsUniqueWorkshop(string workshopName)
        {
            return _workshopRepository.IsUniqueWorkshop(workshopName);
        }
        public void Delete(Workshops workshopToDelete)
        {
            _workshopRepository.Delete(workshopToDelete);

        }
        public void Save()
        {
            _workshopRepository.Save();
        }
    }
}