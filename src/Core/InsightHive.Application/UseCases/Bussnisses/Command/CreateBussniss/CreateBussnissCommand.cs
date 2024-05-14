using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses.Command.CreateBussniss
{
    public class CreateBussnissCommand:IRequest<BaseResponse<BussniessDto>>
    {
        public BussniessDto? bussniessDto { get; set; }
    }
}
