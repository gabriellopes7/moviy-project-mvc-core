using AutoMapper;
using Moviy.App.ViewModels;
using Moviy.Business.Models;

namespace Moviy.App.Automapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Bus, BusViewModel>().ReverseMap();
            CreateMap<Driver, DriverViewModel>().ReverseMap();
            CreateMap<LineRoute, LineRouteViewModel>().ReverseMap();
            CreateMap<Local, LocalViewModel>().ReverseMap();
            CreateMap<Travel, TravelViewModel>().ReverseMap();
        }
    }
}
