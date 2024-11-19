using Application;
using AutoMapper;
using DegirmenciGida.Customer.Domain;
using MediatR;

namespace DegirmenciGida.Customer.Application.Commands.Create
{
    public class CreateCustomerCommand : IRequest<GenericServiceResponse<CreateCustomerResponse>>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, GenericServiceResponse<CreateCustomerResponse>>
        {
            private readonly ICustomerService _customerService;
            private readonly IMapper _mapper;

            public CreateCustomerCommandHandler(ICustomerService customerService, IMapper mapper)
            {
                _customerService = customerService;
                _mapper = mapper;
            }

            public async Task<GenericServiceResponse<CreateCustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                GenericServiceResponse<CreateCustomerResponse> serviceResponse = new GenericServiceResponse<CreateCustomerResponse>();

                Customers customers = _mapper.Map<Customers>(request);
                customers.IsDeleted = false;
                customers.CreatedDate = DateTime.Now;

                try
                {
                    customers = await _customerService.AddAsync(customers);
                }
                catch (Exception ex)
                {
                    serviceResponse.Errors.Add(ex.Message.ToString());
                    serviceResponse.Message = "CreateCustomerOp Error";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                serviceResponse.Message = "CreateCustomerOp Success";
                serviceResponse.Success = true;
                serviceResponse.Data = _mapper.Map<CreateCustomerResponse>(customers);
                return serviceResponse;
            }
        }
    }
}
