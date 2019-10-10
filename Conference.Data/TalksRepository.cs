using Conference.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Conference.Data
{
    public interface ITalksRepository
    {
        List<Talks> GetAllTalks();
        Talks GetTalkById(int id);
        Talks Update(Talks talkToUpdate);
        Talks AddTalk(Talks talkToBeAdded);
        bool IsUniqueTalk(string talkName);
        void Delete(Talks talkToDelete);
        void Save();
    }

    public class TalksRepository : ITalksRepository
    {
        private readonly ConferenceContext _conferenceContext;

        public TalksRepository(ConferenceContext conferenceContext)
        {
            _conferenceContext = conferenceContext;
        }

        public List<Talks> GetAllTalks()
        {
            // Get also the navigation properties(speaker and schedules)
            return _conferenceContext.Talks.Include(x => x.Speaker).Include(x => x.Schedules).ToList();
        }

        public Talks AddTalk(Talks talkToBeAdded)
        {
            EntityEntry<Talks> addedTalk = _conferenceContext.Add(talkToBeAdded);
            _conferenceContext.SaveChanges();

            return addedTalk.Entity;
        }

        public Talks GetTalkById(int id)
        {
            return _conferenceContext.Talks.Find(id);
        }

        public Talks Update(Talks talkToUpdate)
        {
            EntityEntry<Talks> updatedTalk = _conferenceContext.Update(talkToUpdate);
            _conferenceContext.SaveChanges();

            return updatedTalk.Entity;
        }

        public bool IsUniqueTalk(string talkName)
        {
            int nr = _conferenceContext.Talks.Count(x => x.Name == talkName);

            return nr == 0;
        }

        public void Delete(Talks talkToDelete)
        {
            talkToDelete = _conferenceContext.Talks.Find(talkToDelete.Id);

            _conferenceContext.Talks.Remove(talkToDelete);
        }

        public void Save()
        {
            _conferenceContext.SaveChanges();
        }
    }
}