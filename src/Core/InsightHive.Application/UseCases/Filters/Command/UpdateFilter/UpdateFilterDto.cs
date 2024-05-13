using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Filters.Command.UpdateFilter
{
    public class UpdateFilterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UpdateOptionDto> Options { get; set; }
    }
}
