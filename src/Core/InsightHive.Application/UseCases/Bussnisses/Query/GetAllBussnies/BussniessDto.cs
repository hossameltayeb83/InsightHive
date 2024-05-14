using InsightHive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies
{
    public class BussniessDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int OwnerId { get; set; }

    }
}
