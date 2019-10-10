using System.Collections.Generic;
using Conference.Models;
using Conference.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Interfaces
{
    public interface ISpeakerAppService
    {
        IList<SpeakerListItemViewModel> GetSpeakerListViewModel(IUrlHelper url);

        SpeakerListItemViewModel GetSpeakerListItemViewModel(IUrlHelper url, Speakers speaker);
    }
}