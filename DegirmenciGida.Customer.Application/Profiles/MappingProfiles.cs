using Application;
using Application.Response;
using AutoMapper;
using DegirmenciGida.Customer.Application.Commands.Create;
using DegirmenciGida.Customer.Application.Commands.Delete;
using DegirmenciGida.Customer.Application.Commands.Update;
using DegirmenciGida.Customer.Application.Queries.GetById;
using DegirmenciGida.Customer.Application.Queries.GetList;
using DegirmenciGida.Customer.Domain;

namespace DegirmenciGida.Customer.Application.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customers, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customers, CreateCustomerResponse>().ReverseMap();
            CreateMap<Customers, GenericServiceResponse<CreateCustomerResponse>>().ReverseMap();


            CreateMap<Customers, DeleteCustomerCommand>().ReverseMap();
            CreateMap<Customers, DeletedCustomerResponse>().ReverseMap();
            CreateMap<Customers, GenericServiceResponse<DeletedCustomerResponse>>().ReverseMap();

            CreateMap<Customers, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customers, UpdateCustomerResponse>().ReverseMap();
            CreateMap<Customers, GenericServiceResponse<UpdateCustomerResponse>>().ReverseMap();

            CreateMap<Customers, GetCustomerByIdResponse>().ReverseMap();
            CreateMap<Customers, GenericServiceResponse<GetCustomerByIdResponse>>().ReverseMap();


            CreateMap<Customers, GetAllCustomersResponse>().ReverseMap();
            CreateMap<Customers, GetListResponse<GetAllCustomersResponse>>().ReverseMap();
        }
    }
}
