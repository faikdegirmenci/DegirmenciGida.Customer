using Application;
using Application.Response;
using AutoMapper;
using DegirmenciGida.Customer.Domain;
using MediatR;
using Persistence.Paging;

namespace DegirmenciGida.Customer.Application.Queries.GetList
{
    public class GetAllCustomersQuery : IRequest<GetListResponse<GetAllCustomersResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, GetListResponse<GetAllCustomersResponse>>
        {
            private readonly ICustomerService _customerService;
            private readonly IMapper _mapper;

            public GetAllCustomersQueryHandler(ICustomerService customerService, IMapper mapper)
            {
                _customerService = customerService;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetAllCustomersResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
            {
                Paginate<Customers> customers = await _customerService.GetListAsync(
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);

                GetListResponse<GetAllCustomersResponse> response = _mapper.Map<GetListResponse<GetAllCustomersResponse>>(customers);
                return response;
            }
        }
    }
}
