using App.DataAccess.Components.Requests;
using App.DataAccess.Components.Responses;
using App.DataAccess.Repositories.Abstractions;
using MediatR;

namespace App.DataAccess.Components.Handlers
{
    public class MoveEmployeesToNewDepartmentHandler : IRequestHandler<MoveEmployeesToNewDepartmentRequest, IQueryable<MoveEmployeesToNewDepartmentResponse>>
    {
        private readonly IWriteOnlyRepository _writeOnlyRepository;

        public MoveEmployeesToNewDepartmentHandler(IWriteOnlyRepository writeOnlyRepository)
        {
            _writeOnlyRepository = writeOnlyRepository;
        }

        public async Task<IQueryable<MoveEmployeesToNewDepartmentResponse>> Handle(MoveEmployeesToNewDepartmentRequest request, CancellationToken cancellationToken)
        {
            var movedEmployeesModel = await _writeOnlyRepository.MoveEmployeesInNewDepartment(request);

            var movedEmployees = movedEmployeesModel.Select(x => new MoveEmployeesToNewDepartmentResponse()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DepartmentId = x.DepartmentId,
            });

            return movedEmployees;
        }
    }
}
