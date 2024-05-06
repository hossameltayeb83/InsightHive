using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Categories.Query.GetCategoryById
{
    public class GetCategoryByIdQuery:IRequest<GetCategoryByIdDto>
    {
        public int CategoryId { get; set; } 
    }
}
