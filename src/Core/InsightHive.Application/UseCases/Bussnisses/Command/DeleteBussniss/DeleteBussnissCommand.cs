using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses.Command.DeleteBussniss
{
    public class DeleteBussnissCommand:IRequest
    {
        public int Id { get; set; }
    }
}
