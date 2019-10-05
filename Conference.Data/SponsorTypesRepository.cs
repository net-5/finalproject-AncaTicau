using System;
using System.Collections.Generic;
using System.Text;
using Conference.Domain.Entities;
using System.Linq;

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
        private readonly ConferenceContext conferenceContext;

        public SponsorTypesRepository(ConferenceContext conferenceContext)
        {
            this.conferenceContext = conferenceContext;
        }

        public List<SponsorTypes> GetAllSponsorTypes()
        {
            return conferenceContext.SponsorTypes.ToList();
        }

        public SponsorTypes AddSponsorType(SponsorTypes sponsorTypeToBeAdded)
        {
            var addedSponsorType = conferenceContext.Add(sponsorTypeToBeAdded);
            conferenceContext.SaveChanges();
            return addedSponsorType.Entity;
        }

        public SponsorTypes GetSponsorTypesById(int id)
        {
            return conferenceContext.SponsorTypes.Find(id);
        }

        public SponsorTypes Update(SponsorTypes sponsorTypeToUpdate)
        {
            var updatedSponsorType = conferenceContext.Update(sponsorTypeToUpdate);
            conferenceContext.SaveChanges();
            return updatedSponsorType.Entity;
        }

        public bool IsUniqueSponsorType(string sponsorTypeName)
        {
            int nr = conferenceContext.SponsorTypes.Count(x => x.Name == sponsorTypeName);
            if (nr == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public void Delete(SponsorTypes sponsorTypeToDelete)
        {
            sponsorTypeToDelete = conferenceContext.SponsorTypes.Find(sponsorTypeToDelete.Id);
            conferenceContext.SponsorTypes.Remove(sponsorTypeToDelete);

        }
        public void Save()
        {
            conferenceContext.SaveChanges();
        }


    }
}
