using PhoneBookApp.Models.Phone;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookApp.Services.Interfaces
{
    public interface IPhoneBookService
    {
        public Task<PhoneBook> GetPhoneBook(PhoneBook model);
        public Task<PhoneBookEntry> AddEntry(PhoneBookEntry model);
        public Task<bool> DeleteEntry(string id);
    }
}
