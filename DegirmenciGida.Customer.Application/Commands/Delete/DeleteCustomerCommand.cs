using Application;
using AutoMapper;
using DegirmenciGida.Customer.Domain;
using MediatR;

namespace DegirmenciGida.Customer.Application.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<GenericServiceResponse<DeletedCustomerResponse>>
    {
        public Guid Id { get; set; }

        
        public class DeleteCustomerCommandHandler:IRequestHandler<DeleteCustomerCommand,GenericServiceResponse<DeletedCustomerResponse>>
        {
            private readonly ICustomerService _customerService;
            private readonly IMapper _mapper;

            public DeleteCustomerCommandHandler(ICustomerService customerService, IMapper mapper)
            {
                _customerService = customerService;
                _mapper = mapper;
            }

            public async Task<GenericServiceResponse<DeletedCustomerResponse>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                GenericServiceResponse<DeletedCustomerResponse> response = new GenericServiceResponse<DeletedCustomerResponse>();

                try
                {
                    Customers customers = await _customerService.GetAsync(predicate: c=>c.Id == request.Id,cancellationToken:cancellationToken);
                    await _customerService.DeleteAsync(customers);
                    response.Success = true;
                    response.Data = _mapper.Map<DeletedCustomerResponse>(customers);
                    response.Message = "Successful!";
                }
                catch (Exception ex)
                {
                    response.Errors.Add(ex.Message.ToString());
                    response.Success = false;
                    return response;
                }

                return response;
            }
        }
    }
}
