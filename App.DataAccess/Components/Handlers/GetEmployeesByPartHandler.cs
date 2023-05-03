using App.DataAccess.Components.Requests;
using App.DataAccess.Components.Responses;
using App.DataAccess.Repositories.Abstractions;
using MediatR;

namespace App.DataAccess.Components.Handlers
{
    public class GetEmployeesByPartHandler : IRequestHandler<GetEmployeesByPartRequest, ICollection<GetEmployeesByPartResponse>>
    {
        private readonly IReadOnlyRepository _readRepository;

        public GetEmployeesByPartHandler(IReadOnlyRepository readOnlyRepository)
        {
            _readRepository = readOnlyRepository;
        }

        public async Task<ICollection<GetEmployeesByPartResponse>> Handle(GetEmployeesByPartRequest request, CancellationToken cancellationToken)
        {
            var employeesWithDepartmentModel = await _readRepository.GetEmployeesByPart(request);

            var employeesWithDepartment = employeesWithDepartmentModel.Select(x => new GetEmployeesByPartResponse()
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName
            });

            return employeesWithDepartment.ToList();
        }
    }
}
