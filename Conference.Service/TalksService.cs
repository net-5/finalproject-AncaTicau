using Conference.Domain.Entities;
using System.Collections.Generic;
using Conference.Data;

namespace Conference.Service
{
    public interface ITalkService
    {
        IEnumerable<Talks> GetAllTalks();
        Talks GetTalkById(int id);
        Talks AddTalk(Talks talkToBeAdded);
        Talks UpdateTalk(Talks talkToUpdate);
        void Delete(Talks talkToDelete);
        void Save();
    }

    public class TalkService : ITalkService
    {
        private readonly ITalksRepository _talksRepository;

        public TalkService(ITalksRepository talksRepository)
        {
            _talksRepository = talksRepository;
        }

        private bool IsUniqueSpeaker(string talkName)
        {
            return _talksRepository.IsUniqueTalk(talkName);
        }

        public Talks AddTalk(Talks talkToBeAdded)
        {
            if (IsUniqueSpeaker(talkToBeAdded.Name))
            {
                return _talksRepository.AddTalk(talkToBeAdded);
            }

            return null;
        }

        public void Delete(Talks talkToDelete)
        {
            _talksRepository.Delete(talkToDelete);
        }

        public IEnumerable<Talks> GetAllTalks()
        {
            return _talksRepository.GetAllTalks();
        }

        public Talks GetTalkById(int id)
        {
            return _talksRepository.GetTalkById(id);
        }

        public void Save()
        {
            _talksRepository.Save();
        }

        public Talks UpdateTalk(Talks talkToUpdate)
        {
            return _talksRepository.Update(talkToUpdate);
        }
    }
}