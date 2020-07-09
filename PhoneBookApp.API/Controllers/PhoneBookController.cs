using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Models.Phone;
using PhoneBookApp.Services.Interfaces;

namespace PhoneBookApp.API.Controllers
{
    [Route("api/phonebook")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private IPhoneBookService phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            this.phoneBookService = phoneBookService;
        }

        public async Task<PhoneBook> Get()
        {
            return await phoneBookService.GetPhoneBook(new PhoneBook());
        }

        [HttpPost]
        public async Task<PhoneBookEntry> Post(PhoneBookEntry model)
        {
            return await phoneBookService.AddEntry(model);
        }

        [HttpGet("DeleteEntry")]
        public async Task<bool> DeleteEntry(string id)
        {
            return await phoneBookService.DeleteEntry(id);
        }
    }
}