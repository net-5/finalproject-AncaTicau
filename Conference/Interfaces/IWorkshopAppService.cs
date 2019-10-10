using System.Collections.Generic;
using Conference.Models;
using Conference.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Interfaces
{
    public interface IWorkshopAppService
    {
        IList<WorkshopListItemViewModel> GetWorkshopListViewModel(IUrlHelper url);

        WorkshopListItemViewModel GetWorkshopListItemViewModel(IUrlHelper url, Workshops workshop);
    }
}