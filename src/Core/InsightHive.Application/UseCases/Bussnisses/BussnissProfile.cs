﻿using AutoMapper;
using InsightHive.Application.UseCases.Bussnisses.Command.CreateBussniss;
using InsightHive.Application.UseCases.Bussnisses.Command.UpdateBusssniss;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using InsightHive.Application.UseCases.Categories.Query.GetAllCategories;
using InsightHive.Application.UseCases.SubCategories.Query;
using InsightHive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses
{
    public class BussnissProfile : Profile
    {
        public BussnissProfile()
        {
            CreateMap<Business, BussniessDto>()
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name));

            CreateMap<Business, UpdateBussnissCommand>().ReverseMap();
            CreateMap<CreateBussnissCommand, Business>().ReverseMap();
            


        }
    }
    
}
