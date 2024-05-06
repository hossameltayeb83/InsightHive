using AutoMapper;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Application.UseCases.Categories.Query.GetAllCategories;
using InsightHive.Application.UseCases.Categories.Query.GetCategoryById;
using InsightHive.Application.UseCases.Categories.Query.GetCtegoryByName;
using InsightHive.Application.UseCases.SubCategories.Query;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>()
                .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.SubCategories)); CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryByNameDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.SubCategories));

            CreateMap<SubCategory, SubcategoryDto>()
                 .ForMember(dest => dest.SubcategoryId, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(src => src.Name));

        }
    }
}
