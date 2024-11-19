using Application;
using AutoMapper;
using DegirmenciGida.Customer.Domain;
using MediatR;

namespace DegirmenciGida.Customer.Application.Queries.GetById
{


    public class GetCustomerByIdQuery : IRequest<GenericServiceResponse<GetCustomerByIdResponse>>
    {
        public Guid Id { get; set; }

        public class GetCustomerByIdQueryHandler:IRequestHandler<GetCustomerByIdQuery,GenericServiceResponse<GetCustomerByIdResponse>>
        {
            private readonly ICustomerService _customerService;
            private readonly IMapper _mapper;

            public GetCustomerByIdQueryHandler(ICustomerService customerService, IMapper mapper)
            {
                _customerService = customerService;
                _mapper = mapper;
            }

            public async Task<GenericServiceResponse<GetCustomerByIdResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                GenericServiceResponse<GetCustomerByIdResponse> genericServiceResponse = new GenericServiceResponse<GetCustomerByIdResponse>();

                try
                {
                    Customers customers = await _customerService.GetAsync(predicate:g=>g.Id == request.Id,cancellationToken:cancellationToken);

                    genericServiceResponse.Success = true;
                    genericServiceResponse.Message = "Ok";
                    genericServiceResponse.Data = _mapper.Map<GetCustomerByIdResponse>(customers);
                }
                catch (Exception ex)
                {
                    genericServiceResponse.Success = false;
                    genericServiceResponse.Errors.Add(ex.Message);
                    return genericServiceResponse;
                }

                return genericServiceResponse;
            }
        }
    }
}
