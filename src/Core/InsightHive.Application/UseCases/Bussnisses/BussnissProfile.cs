using AutoMapper;
using InsightHive.Application.UseCases.Bussnisses.Command.CreateBussniss;
using InsightHive.Application.UseCases.Bussnisses.Command.UpdateBusssniss;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Bussnisses
{
    public class BussnissProfile : Profile
    {
        public BussnissProfile()
        {
            CreateMap<Business, BussniessDto>().ReverseMap();
            CreateMap<Business, UpdateBussnissCommand>().ReverseMap();
            CreateMap<CreateBussnissCommand, Business>().ReverseMap();
            CreateMap<UpdateBussnissCommand, Business>();



        }
    }

}
