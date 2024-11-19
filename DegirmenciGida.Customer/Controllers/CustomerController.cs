using Application;
using Application.Response;
using DegirmenciGida.Customer.Application;
using DegirmenciGida.Customer.Application.Commands.Create;
using DegirmenciGida.Customer.Application.Commands.Delete;
using DegirmenciGida.Customer.Application.Commands.Update;
using DegirmenciGida.Customer.Application.Queries.GetById;
using DegirmenciGida.Customer.Application.Queries.GetList;
using DegirmenciGida.Customer.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DegirmenciGida.Customer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand request)
        {
            GenericServiceResponse<CreateCustomerResponse> response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand() { Id=id};
            GenericServiceResponse<DeletedCustomerResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers([FromQuery] PageRequest request)
        {
            GetAllCustomersQuery command = new GetAllCustomersQuery() { PageRequest = request};
            GetListResponse<GetAllCustomersResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid id)
        {
            GetCustomerByIdQuery query = new GetCustomerByIdQuery() { Id = id };
            GenericServiceResponse<GetCustomerByIdResponse> response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand request)
        {
            GenericServiceResponse<UpdateCustomerResponse> response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
