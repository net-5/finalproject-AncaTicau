using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Conference.Data;

namespace Conference.Service
{
    public interface ISponsorService
    {
        IEnumerable<Sponsors> GetAllSponsors();
        Sponsors GetSponsorById(int id);
        Sponsors AddSponsor(Sponsors sponsorToBeAdded);
        Sponsors UpdateSponsor(Sponsors sponsorToUpdate);
        void Delete(Sponsors sponsorToDelete);
        void Save();
    }
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorsRepository sponsorsRepository;
        public SponsorService(ISponsorsRepository sponsorsRepository)
        {
            this.sponsorsRepository = sponsorsRepository;
        }

        private bool IsUniqueSponsor(string sponsorName)
        {
            if (sponsorsRepository.IsUniqueSponsor(sponsorName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Sponsors AddSponsor(Sponsors sponsorToBeAdded)
        {
            if (IsUniqueSponsor(sponsorToBeAdded.Name))
            {
                return sponsorsRepository.AddSponsor(sponsorToBeAdded);
            }
            else
            {
                return null;
            }
        }

        public void Delete(Sponsors sponsorToDelete)
        {
            sponsorsRepository.Delete(sponsorToDelete);
        }

        public IEnumerable<Sponsors> GetAllSponsors()
        {
            return sponsorsRepository.GetAllSponsors();
        }

        public Sponsors GetSponsorById(int id)
        {
            return sponsorsRepository.GetSponsorsById(id);
        }

        public void Save()
        {
            sponsorsRepository.Save();
        }

        public Sponsors UpdateSponsor(Sponsors sponsorToUpdate)
        {
            return sponsorsRepository.Update(sponsorToUpdate);
        }
    }
}
