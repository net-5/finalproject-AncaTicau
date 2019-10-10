using System.Collections.Generic;
using Conference.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Conference.Data
{
    public interface ISponsorTypesRepository
    {
        List<SponsorTypes> GetAllSponsorTypes();
        SponsorTypes GetSponsorTypesById(int id);
        SponsorTypes Update(SponsorTypes sponsorTypeToUpdate);
        SponsorTypes AddSponsorType(SponsorTypes sponsorTypeToBeAdded);
        bool IsUniqueSponsorType(string sponsorTypeName);
        void Delete(SponsorTypes sponsorTypeToDelete);
        void Save();
    }

    public class SponsorTypesRepository : ISponsorTypesRepository
    {
        private readonly ConferenceContext _conferenceContext;

        public SponsorTypesRepository(ConferenceContext conferenceContext)
        {
            _conferenceContext = conferenceContext;
        }

        public List<SponsorTypes> GetAllSponsorTypes()
        {
            return _conferenceContext.SponsorTypes.ToList();
        }

        public SponsorTypes AddSponsorType(SponsorTypes sponsorTypeToBeAdded)
        {
            EntityEntry<SponsorTypes> addedSponsorType = _conferenceContext.Add(sponsorTypeToBeAdded);
            _conferenceContext.SaveChanges();

            return addedSponsorType.Entity;
        }

        public SponsorTypes GetSponsorTypesById(int id)
        {
            return _conferenceContext.SponsorTypes.Find(id);
        }

        public SponsorTypes Update(SponsorTypes sponsorTypeToUpdate)
        {
            EntityEntry<SponsorTypes> updatedSponsorType = _conferenceContext.Update(sponsorTypeToUpdate);
            _conferenceContext.SaveChanges();

            return updatedSponsorType.Entity;
        }

        public bool IsUniqueSponsorType(string sponsorTypeName)
        {
            int nr = _conferenceContext.SponsorTypes.Count(x => x.Name == sponsorTypeName);

            return nr == 0;
        }

        public void Delete(SponsorTypes sponsorTypeToDelete)
        {
            sponsorTypeToDelete = _conferenceContext.SponsorTypes.Find(sponsorTypeToDelete.Id);

            _conferenceContext.SponsorTypes.Remove(sponsorTypeToDelete);
        }

        public void Save()
        {
            _conferenceContext.SaveChanges();
        }
    }
}