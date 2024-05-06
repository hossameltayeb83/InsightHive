using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses.Command.UpdateBusssniss
{
    public class UpdateBussnissCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string SubCategoryName { get; set; }
        public int SubCategoryId { get; set; }


    }
}
