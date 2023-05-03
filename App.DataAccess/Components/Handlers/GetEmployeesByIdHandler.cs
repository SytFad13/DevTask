using App.DataAccess.Components.Requests;
using App.DataAccess.Components.Responses;
using App.DataAccess.Repositories.Abstractions;
using MediatR;

namespace App.DataAccess.Components.Handlers
{
	public class GetEmployeesByIdHandler : IRequestHandler<GetEmployeesByIdRequest, ICollection<GetEmployeesByIdResponse>>
	{
        private readonly IReadOnlyRepository _readRepository;

        public GetEmployeesByIdHandler(IReadOnlyRepository readOnlyRepository)
        {
            _readRepository = readOnlyRepository;
        }

        public async Task<ICollection<GetEmployeesByIdResponse>> Handle(GetEmployeesByIdRequest request, CancellationToken cancellationToken)
        {
            var employeesWithDepartmentModel = await _readRepository.GetEmployeesById(request);

            var employeesWithDepartment = employeesWithDepartmentModel.Select(x => new GetEmployeesByIdResponse()
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