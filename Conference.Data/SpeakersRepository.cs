using System.Collections.Generic;
using Conference.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Conference.Data
{
    public interface ISpeakersRepository
    {
        List<Speakers> GetAllSpeakers();
        Speakers GetSpeakersById(int id);
        Speakers Update(Speakers speakerToUpdate);
        Speakers AddSpeaker(Speakers speakerToBeAdded);
        bool IsUniqueSpeaker(string speakerName);
        void Delete(Speakers speakerToDelete);
        void Save();
    }

    public class SpeakersRepository : ISpeakersRepository
    {
        private readonly ConferenceContext _conferenceContext;

        public SpeakersRepository(ConferenceContext conferenceContext)
        {
            _conferenceContext = conferenceContext;
        }

        public List<Speakers> GetAllSpeakers()
        {
            return _conferenceContext.Speakers.Include(x => x.Workshops).ToList();
        }

        public Speakers AddSpeaker(Speakers speakerToBeAdded)
        {
            EntityEntry<Speakers> addedSpeaker = _conferenceContext.Add(speakerToBeAdded);
            _conferenceContext.SaveChanges();

            return addedSpeaker.Entity;
        }

        public Speakers GetSpeakersById(int id)
        {
            return _conferenceContext.Speakers.Include(x => x.Workshops).FirstOrDefault(x => x.Id == id);
        }

        public Speakers Update(Speakers speakerToUpdate)
        {
            EntityEntry<Speakers> updatedSpeaker = _conferenceContext.Update(speakerToUpdate);
            _conferenceContext.SaveChanges();

            return updatedSpeaker.Entity;
        }

        public bool IsUniqueSpeaker(string speakerName)
        {
            int nr = _conferenceContext.Speakers.Count(x => x.Name == speakerName);

            return nr == 0;
        }

        public void Delete(Speakers speakerToDelete)
        {
            speakerToDelete = _conferenceContext.Speakers.Find(speakerToDelete.Id);

            _conferenceContext.Speakers.Remove(speakerToDelete);
        }

        public void Save()
        {
            _conferenceContext.SaveChanges();
        }
    }
}