using Conference.Domain.Entities;
using System.Collections.Generic;
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
        private readonly ISponsorsRepository _sponsorsRepository;

        public SponsorService(ISponsorsRepository sponsorsRepository)
        {
            _sponsorsRepository = sponsorsRepository;
        }

        private bool IsUniqueSponsor(string sponsorName)
        {
            return _sponsorsRepository.IsUniqueSponsor(sponsorName);
        }
        public Sponsors AddSponsor(Sponsors sponsorToBeAdded)
        {
            if (IsUniqueSponsor(sponsorToBeAdded.Name))
            {
                return _sponsorsRepository.AddSponsor(sponsorToBeAdded);
            }

            return null;
        }

        public void Delete(Sponsors sponsorToDelete)
        {
            _sponsorsRepository.Delete(sponsorToDelete);
        }

        public IEnumerable<Sponsors> GetAllSponsors()
        {
            return _sponsorsRepository.GetAllSponsors();
        }

        public Sponsors GetSponsorById(int id)
        {
            return _sponsorsRepository.GetSponsorsById(id);
        }

        public void Save()
        {
            _sponsorsRepository.Save();
        }

        public Sponsors UpdateSponsor(Sponsors sponsorToUpdate)
        {
            return _sponsorsRepository.Update(sponsorToUpdate);
        }
    }
}