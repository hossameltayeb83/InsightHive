using AutoMapper;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Search.Query
{
    internal class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<Business, BusinessSearchDto>();
        }
    }
}
