using App.DataAccess.Components.Requests;
using App.DataAccess.Components.Responses;
using App.DataAccess.Repositories.Abstractions;
using MediatR;

namespace App.DataAccess.Components.Handlers
{
	public class GetEmployeesByIdHandler : IRequestHandler<GetEmployeesByDepartmentIdRequest, ICollection<GetEmployeesByDepartmentIdResponse>>
	{
        private readonly IReadOnlyRepository _readRepository;

        public GetEmployeesByIdHandler(IReadOnlyRepository readOnlyRepository)
        {
            _readRepository = readOnlyRepository;
        }

        public async Task<ICollection<GetEmployeesByDepartmentIdResponse>> Handle(GetEmployeesByDepartmentIdRequest request, CancellationToken cancellationToken)
        {
            var employeesWithDepartmentModel = await _readRepository.GetEmployeesByDepartmentId(request);

            var employeesWithDepartment = employeesWithDepartmentModel.Select(x => new GetEmployeesByDepartmentIdResponse()
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