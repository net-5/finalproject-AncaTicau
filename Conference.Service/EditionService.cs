using Conference.Data;
using Conference.Domain.Entities;
using System.Collections.Generic;

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
        private readonly IEditionRepository _editionRepository;

        public EditionService(IEditionRepository editionRepository)
        {
            _editionRepository = editionRepository;
        }

        public Editions AddEdition(Editions editionToBeAdded)
        {
            if (IsUniqueEdition(editionToBeAdded.Name))
            {
                return _editionRepository.AddEdition(editionToBeAdded);
            }

            return null;
        }

        public IEnumerable<Editions> GetAllEditions()
        {
            return _editionRepository.GetAllEditions();
        }

        public Editions GetEditionById(int id)
        {
            return _editionRepository.GetEditionById(id);
        }

        public Editions UpdateEdition(Editions editionToUpdate)
        {
            return _editionRepository.Update(editionToUpdate);
        }

        private bool IsUniqueEdition(string editionName)
        {
            return _editionRepository.IsUniqueEdition(editionName);
        }

        public void Delete(Editions editionToDelete)
        {
            _editionRepository.Delete(editionToDelete);

        }

        public void Save()
        {
            _editionRepository.Save();
        }
    }
}