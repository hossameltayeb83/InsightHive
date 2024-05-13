using AutoMapper;
using InsightHive.Application.Exceptions;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Filters.Command.DeleteFilter
{
    internal class DeleteFilterCommandHandler : IRequestHandler<DeleteFilterCommand, BaseResponse<bool>>
    {
        private readonly IRepository<Filter> _filterRepository;
        public DeleteFilterCommandHandler(IRepository<Filter> filterRepository)
        {
            _filterRepository = filterRepository;
        }
        public async Task<BaseResponse<bool>> Handle(DeleteFilterCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            var filter= await _filterRepository.GetByIdAsync(request.Id);
            if (filter == null)
                throw new NotFoundException("No Filter with the provided Id.");
            response.Result = await _filterRepository.DeleteAsync(filter);
            return response;
        }
    }
}
