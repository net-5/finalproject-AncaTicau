using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
        private readonly ConferenceContext conferenceContext;
        public TalksRepository(ConferenceContext conferenceContext)
        {
            this.conferenceContext = conferenceContext;
        }
        public List<Talks> GetAllTalks()
        {
            // Get also the navigation properties(speaker and schedules)
            return conferenceContext.Talks.Include(x => x.Speaker).Include(x => x.Schedules).ToList();
        }
        public Talks AddTalk(Talks talkToBeAdded)
        {
            var addedTalk = conferenceContext.Add(talkToBeAdded);
            conferenceContext.SaveChanges();
            return addedTalk.Entity;
        }


        public Talks GetTalkById(int id)
        {
            return conferenceContext.Talks.Find(id);
        }


        public Talks Update(Talks talkToUpdate)
        {
            var updatedTalk = conferenceContext.Update(talkToUpdate);
            conferenceContext.SaveChanges();
            return updatedTalk.Entity;
        }
        public bool IsUniqueTalk(string talkName)
        {
            int nr = conferenceContext.Talks.Count(x => x.Name == talkName);
            if (nr == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Delete(Talks talkToDelete)
        {
            talkToDelete = conferenceContext.Talks.Find(talkToDelete.Id);
            conferenceContext.Talks.Remove(talkToDelete);

        }
        public void Save()
        {
            conferenceContext.SaveChanges();
        }
    }
}
