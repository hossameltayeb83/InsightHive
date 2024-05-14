using MediatR;

namespace InsightHive.Application.UseCases.Bussnisses.Command.DeleteBussniss
{
    public class DeleteBussnissCommand : IRequest
    {
        public int Id { get; set; }
    }
}
