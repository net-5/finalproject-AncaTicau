using System.Collections.Generic;
using Conference.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Conference.Data
{
    public interface ISponsorsRepository
    {
        List<Sponsors> GetAllSponsors();
        Sponsors GetSponsorsById(int id);
        Sponsors Update(Sponsors sponsorToUpdate);
        Sponsors AddSponsor(Sponsors sponsorToBeAdded);
        bool IsUniqueSponsor(string sponsorName);
        void Delete(Sponsors sponsorToDelete);
        void Save();
    }

    public class SponsorsRepository : ISponsorsRepository
    {
        private readonly ConferenceContext _conferenceContext;

        public SponsorsRepository(ConferenceContext conferenceContext)
        {
            _conferenceContext = conferenceContext;
        }

        public List<Sponsors> GetAllSponsors()
        {
            return _conferenceContext.Sponsors.Include(x => x.SponsorType).ToList();
        }

        public Sponsors AddSponsor(Sponsors sponsorToBeAdded)
        {
            EntityEntry<Sponsors> addedSponsor = _conferenceContext.Add(sponsorToBeAdded);
            _conferenceContext.SaveChanges();

            return addedSponsor.Entity;
        }

        public Sponsors GetSponsorsById(int id)
        {
            return _conferenceContext.Sponsors.Find(id);
        }

        public Sponsors Update(Sponsors sponsorToUpdate)
        {
            EntityEntry<Sponsors> updatedSponsor = _conferenceContext.Update(sponsorToUpdate);
            _conferenceContext.SaveChanges();

            return updatedSponsor.Entity;
        }

        public bool IsUniqueSponsor(string sponsorName)
        {
            int nr = _conferenceContext.Sponsors.Count(x => x.Name == sponsorName);

            return nr == 0;
        }

        public void Delete(Sponsors sponsorToDelete)
        {
            sponsorToDelete = _conferenceContext.Sponsors.Find(sponsorToDelete.Id);

            _conferenceContext.Sponsors.Remove(sponsorToDelete);
        }

        public void Save()
        {
            _conferenceContext.SaveChanges();
        }
    }
}