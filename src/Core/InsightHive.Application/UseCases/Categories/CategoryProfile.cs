using AutoMapper;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Application.UseCases.Categories.Command.UpdateCategory;
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
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryByNameDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<SubCategory, SubcategoryDto>().ReverseMap();

        }
    }
}
