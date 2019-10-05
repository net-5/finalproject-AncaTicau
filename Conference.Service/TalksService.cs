using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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
        private readonly ITalksRepository talksRepository;
        public TalkService(ITalksRepository talksRepository)
        {
            this.talksRepository = talksRepository;
        }

        private bool IsUniqueSpeaker(string talkName)
        {
            if (talksRepository.IsUniqueTalk(talkName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Talks AddTalk(Talks talkToBeAdded)
        {
            if (IsUniqueSpeaker(talkToBeAdded.Name))
            {
                return talksRepository.AddTalk(talkToBeAdded);
            }
            else
            {
                return null;
            }
        }

        public void Delete(Talks talkToDelete)
        {
            talksRepository.Delete(talkToDelete);
        }

        public IEnumerable<Talks> GetAllTalks()
        {
            return talksRepository.GetAllTalks();
        }

        public Talks GetTalkById(int id)
        {
            return talksRepository.GetTalkById(id);
        }

        public void Save()
        {
            talksRepository.Save();
        }

        public Talks UpdateTalk(Talks talkToUpdate)
        {
            return talksRepository.Update(talkToUpdate);
        }
    }
}
