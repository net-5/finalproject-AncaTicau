using Conference.Domain.Entities;
using System.Collections.Generic;
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
        private readonly ISpeakersRepository _speakersRepository;

        public SpeakerService(ISpeakersRepository speakersRepository)
        {
            _speakersRepository = speakersRepository;
        }

        private bool IsUniqueSpeaker(string speakerName)
        {
            return _speakersRepository.IsUniqueSpeaker(speakerName);
        }

        public Speakers AddSpeaker(Speakers speakerToBeAdded)
        {
            if (IsUniqueSpeaker(speakerToBeAdded.Name))
            {
                return _speakersRepository.AddSpeaker(speakerToBeAdded);
            }

            return null;
        }

        public void Delete(Speakers speakerToDelete)
        {
            _speakersRepository.Delete(speakerToDelete);
        }

        public IEnumerable<Speakers> GetAllSpeakers()
        {
            return _speakersRepository.GetAllSpeakers();
        }

        public Speakers GetSpeakerById(int id)
        {
            return _speakersRepository.GetSpeakersById(id);
        }

        public void Save()
        {
            _speakersRepository.Save();
        }

        public Speakers UpdateSpeaker(Speakers speakerToUpdate)
        {
            return _speakersRepository.Update(speakerToUpdate);
        }
    }
}