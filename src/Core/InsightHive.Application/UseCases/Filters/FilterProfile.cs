using AutoMapper;
using InsightHive.Application.UseCases.Filters.Command.CreateFilter;
using InsightHive.Application.UseCases.Filters.Command.UpdateFilter;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Filters
{
    internal class FilterProfile : Profile
    {
        public FilterProfile()
        {
            CreateMap<Filter, FilterDto>();
            CreateMap<Option, OptionDto>().ReverseMap();
            CreateMap<CreateFilterCommand, Filter>();
            CreateMap<Filter, CreateFilterDto>();
            CreateMap<Option, CreateOptionDto>().ReverseMap();
            CreateMap<UpdateFilterCommand, Filter>();
            CreateMap<Filter, UpdateFilterDto>();
            CreateMap<Option, UpdateOptionDto>().ReverseMap();
        }
    }
}
