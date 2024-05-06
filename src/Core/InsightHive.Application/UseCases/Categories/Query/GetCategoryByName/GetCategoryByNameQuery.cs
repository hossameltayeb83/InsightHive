using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Categories.Query.GetCtegoryByName
{
    public class GetCategoryByNameQuery:IRequest<CategoryByNameDto>
    {
        public string Name { get; set; }=string.Empty;
    }
}
