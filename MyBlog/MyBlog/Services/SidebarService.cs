using MyBlog.Mappings;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using System.Linq;

namespace MyBlog.Services
{
    public class SidebarService : ISidebarService
    {
        private IEventsService _service;
        public SidebarService(IEventsService service)
        {
            _service = service;
        }

        public EventSidebarDataModel GetSideBarData()
        {
            var sideBarDataModel = new EventSidebarDataModel();

            var topEvents = _service.GetTopEvents(5);
            var mostRecentEvents = _service.GetMostRecentEvents(5);

            sideBarDataModel.MostRecentEvents = mostRecentEvents.Select(x => x.ToRecipeSidebarModel()).ToList();
            sideBarDataModel.TopEvents = topEvents.Select(x => x.ToRecipeSidebarModel()).ToList();

            return sideBarDataModel;
        }
    }
}
