using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest<BaseResponse<CategoryDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
