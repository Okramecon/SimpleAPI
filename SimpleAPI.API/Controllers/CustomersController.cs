﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Api.Attributes;
using SimpleAPI.BLL.Contracts;
using SimpleAPI.BLL.Services;
using SimpleAPI.DAL.Contracts;
using SimpleAPI.DAL.Entities;
using SimpleAPI.DTO.CustomerDTOs;
using static SimpleAPI.Api.Attributes.AuthAttribute;

namespace SimpleAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IEntityRepository<Customer> _customerRepository;
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Auth(RoleTypes.None, RoleTypes.User)]
        public async Task<int> Create(CustomerAddDto customer)
        {
            if (customer == null || string.IsNullOrEmpty(customer.Email))
            {
                throw new Exception("Customer model is invalid. Please check input data.");
            }

            var id = await _customerService.CreateAsync(customer);

            return id;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<CustomerGetDto> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(5);

            var test = customer.FirstName;

            return customer;
        }
    }
}
