using Conference.Data;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Service
{
    public interface IEditionService
    {
        IEnumerable<Editions> GetAllEditions();
        Editions GetEditionById(int id);
        Editions AddEdition(Editions editionToBeAdded);
        Editions UpdateEdition(Editions editionToUpdate);
        void Delete(Editions editionToDelete);
        void Save();
    }
    public class EditionService : IEditionService
    {
        private readonly IEditionRepository editionRepository;
        public EditionService(IEditionRepository editionRepository)
        {
            this.editionRepository = editionRepository;
        }
        public Editions AddEdition(Editions editionToBeAdded)
        {
            if (IsUniqueEdition(editionToBeAdded.Name))
            {
                return editionRepository.AddEdition(editionToBeAdded);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Editions> GetAllEditions()
        {
            return editionRepository.GetAllEditions();
        }

        public Editions GetEditionById(int id)
        {
            return editionRepository.GetEditionById(id);
        }

        public Editions UpdateEdition(Editions editionToUpdate)
        {
            return editionRepository.Update(editionToUpdate);
        }
        private bool IsUniqueEdition(string editionName)
        {
            if (editionRepository.IsUniqueEdition(editionName) == true)
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
            editionRepository.Delete(editionToDelete);

        }
        public void Save()
        {
            editionRepository.Save();
        }
    }
}
