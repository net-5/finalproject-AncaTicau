using Conference.Domain.Entities;
using System.Collections.Generic;
using Conference.Data;

namespace Conference.Service
{
    public interface ISponsorTypeService
    {
        IEnumerable<SponsorTypes> GetAllSponsorTypes();
        SponsorTypes GetSponsorTypeById(int id);
        SponsorTypes AddSponsorType(SponsorTypes sponsorTypeToBeAdded);
        SponsorTypes UpdateSponsorType(SponsorTypes sponsorTypeToUpdate);
        void Delete(SponsorTypes sponsorTypeToDelete);
        void Save();
    }

    public class SponsorTypeService : ISponsorTypeService
    {
        private readonly ISponsorTypesRepository _sponsorTypesRepository;

        public SponsorTypeService(ISponsorTypesRepository sponsorTypesRepository)
        {
            _sponsorTypesRepository = sponsorTypesRepository;
        }

        private bool IsUniqueSponsorType(string sponsorTypeName)
        {
            return _sponsorTypesRepository.IsUniqueSponsorType(sponsorTypeName);
        }
        public SponsorTypes AddSponsorType(SponsorTypes sponsorTypeToBeAdded)
        {
            if (IsUniqueSponsorType(sponsorTypeToBeAdded.Name))
            {
                return _sponsorTypesRepository.AddSponsorType(sponsorTypeToBeAdded);
            }

            return null;
        }

        public void Delete(SponsorTypes sponsorTypeToDelete)
        {
            _sponsorTypesRepository.Delete(sponsorTypeToDelete);
        }

        public IEnumerable<SponsorTypes> GetAllSponsorTypes()
        {
            return _sponsorTypesRepository.GetAllSponsorTypes();
        }

        public SponsorTypes GetSponsorTypeById(int id)
        {
            return _sponsorTypesRepository.GetSponsorTypesById(id);
        }

        public void Save()
        {
            _sponsorTypesRepository.Save();
        }

        public SponsorTypes UpdateSponsorType(SponsorTypes sponsorTypeToUpdate)
        {
            return _sponsorTypesRepository.Update(sponsorTypeToUpdate);
        }
    }
}