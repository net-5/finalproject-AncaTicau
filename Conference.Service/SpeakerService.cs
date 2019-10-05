using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Conference.Data;

namespace Conference.Service
{
    public interface ISpeakerService
    {
        IEnumerable<Speakers> GetAllSpeakers();
        Speakers GetSpeakerById(int id);
        Speakers AddSpeaker(Speakers speakerToBeAdded);
        Speakers UpdateSpeaker(Speakers speakerToUpdate);
        void Delete(Speakers speakerToDelete);
        void Save();
    }
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakersRepository speakersRepository;
        public SpeakerService(ISpeakersRepository speakersRepository)
        {
            this.speakersRepository = speakersRepository;
        }

        private bool IsUniqueSpeaker(string speakerName)
        {
            if (speakersRepository.IsUniqueSpeaker(speakerName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Speakers AddSpeaker(Speakers speakerToBeAdded)
        {
            if (IsUniqueSpeaker(speakerToBeAdded.Name))
            {
                return speakersRepository.AddSpeaker(speakerToBeAdded);
            }
            else
            {
                return null;
            }
        }

        public void Delete(Speakers speakerToDelete)
        {
            speakersRepository.Delete(speakerToDelete);
        }

        public IEnumerable<Speakers> GetAllSpeakers()
        {
            return speakersRepository.GetAllSpeakers();
        }

        public Speakers GetSpeakerById(int id)
        {
            return speakersRepository.GetSpeakersById(id);
        }

        public void Save()
        {
            speakersRepository.Save();
        }

        public Speakers UpdateSpeaker(Speakers speakerToUpdate)
        {
            return speakersRepository.Update(speakerToUpdate);
        }
    }
}
