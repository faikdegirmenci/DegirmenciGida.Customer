using Application;
using AutoMapper;
using DegirmenciGida.Customer.Domain;
using MediatR;

namespace DegirmenciGida.Customer.Application.Commands.Update
{
    public class UpdateCustomerCommand : IRequest<GenericServiceResponse<UpdateCustomerResponse>>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommand,GenericServiceResponse<UpdateCustomerResponse>>
        {
            private readonly ICustomerService _customerService;
            private readonly IMapper _mapper;

            public UpdateCustomerCommandHandler(ICustomerService customerService, IMapper mapper)
            {
                _customerService = customerService;
                _mapper = mapper;
            }

            public async Task<GenericServiceResponse<UpdateCustomerResponse>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                GenericServiceResponse<UpdateCustomerResponse> response = new GenericServiceResponse<UpdateCustomerResponse>();

                try
                {
                    var customer = await _customerService.GetAsync(predicate:u=>u.Id == request.Id,cancellationToken:cancellationToken);
                    customer = _mapper.Map(request,customer);
                    customer.UpdatedDate = DateTime.Now;
                    await _customerService.UpdateAsync(customer);
                    response.Data = _mapper.Map<UpdateCustomerResponse>(customer);
                }
                catch (Exception ex)
                {
                    response.Errors.Add(ex.Message.ToString());
                    response.Success = false;
                    response.Message = "failed";
                    return response;
                }
                response.Success = true;
                response.Message = "Updated customer successful!";
                return response;
            }
        }
    }
}
