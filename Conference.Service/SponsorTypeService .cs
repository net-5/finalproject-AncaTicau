using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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
        private readonly ISponsorTypesRepository sponsorTypesRepository;
        public SponsorTypeService(ISponsorTypesRepository sponsorTypesRepository)
        {
            this.sponsorTypesRepository = sponsorTypesRepository;
        }

        private bool IsUniqueSponsorType(string sponsorTypeName)
        {
            if (sponsorTypesRepository.IsUniqueSponsorType(sponsorTypeName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public SponsorTypes AddSponsorType(SponsorTypes sponsorTypeToBeAdded)
        {
            if (IsUniqueSponsorType(sponsorTypeToBeAdded.Name))
            {
                return sponsorTypesRepository.AddSponsorType(sponsorTypeToBeAdded);
            }
            else
            {
                return null;
            }
        }

        public void Delete(SponsorTypes sponsorTypeToDelete)
        {
            sponsorTypesRepository.Delete(sponsorTypeToDelete);
        }

        public IEnumerable<SponsorTypes> GetAllSponsorTypes()
        {
            return sponsorTypesRepository.GetAllSponsorTypes();
        }

        public SponsorTypes GetSponsorTypeById(int id)
        {
            return sponsorTypesRepository.GetSponsorTypesById(id);
        }

        public void Save()
        {
            sponsorTypesRepository.Save();
        }

        public SponsorTypes UpdateSponsorType(SponsorTypes sponsorTypeToUpdate)
        {
            return sponsorTypesRepository.Update(sponsorTypeToUpdate);
        }
    }
}
