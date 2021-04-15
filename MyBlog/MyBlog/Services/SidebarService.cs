using Microsoft.Extensions.Options;
using MyBlog.Common.Options;
using MyBlog.Mappings;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using System.Linq;

namespace MyBlog.Services
{
    public class SidebarService : ISidebarService
    {
        private IEventsService _service;
        private SidebarConfig _sidebarConfig;
        public SidebarService(IEventsService service, IOptions<SidebarConfig> sidebarConfig)
        {
            _service = service;
            _sidebarConfig = sidebarConfig.Value;
        }

        public EventSidebarDataModel GetSideBarData()
        {
            var sideBarDataModel = new EventSidebarDataModel();

            var topEvents = _service.GetTopEvents(_sidebarConfig.TopEventsCount);
            var mostRecentEvents = _service.GetMostRecentEvents(_sidebarConfig.MostRecentEventsCount);

            sideBarDataModel.MostRecentEvents = mostRecentEvents.Select(x => x.ToRecipeSidebarModel()).ToList();
            sideBarDataModel.TopEvents = topEvents.Select(x => x.ToRecipeSidebarModel()).ToList();

            return sideBarDataModel;
        }
    }
}
