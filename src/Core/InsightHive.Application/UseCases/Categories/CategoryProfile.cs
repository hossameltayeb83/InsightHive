using AutoMapper;
using InsightHive.Application.UseCases.Categories.Query.GetAllCategories;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
