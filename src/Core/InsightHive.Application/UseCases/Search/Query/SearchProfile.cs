using AutoMapper;
using InsightHive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Search.Query
{
    internal class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<Business,BusinessSearchDto>();
        }
    }
}
