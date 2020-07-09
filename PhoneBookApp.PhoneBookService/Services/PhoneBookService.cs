using MongoDB.Driver;
using PhoneBookApp.Common.Services;
using PhoneBookApp.Models.Phone;
using PhoneBookApp.Services.Interfaces;
using System;
using System.Threading.Tasks;
using PhoneBookApp.Interfaces;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Bson;

namespace PhoneBookApp.Services.Services
{
    public class PhoneBookService : BaseService, IPhoneBookService
    {
        private readonly IMongoCollection<PhoneBook> phoneBooks;
        private readonly IMongoCollection<PhoneBookEntry> phoneBookEntries;
        private readonly string defaultPhoneBookName = "My PhoneBook";

        public PhoneBookService(IPhoneBookCollectionSettings collectionBookSettings, IPhoneBookEntryCollectionSettings collectionEntrySettings)
            : base(collectionBookSettings)
        {
            phoneBooks = _database.GetCollection<PhoneBook>(collectionBookSettings.CollectionName);
            phoneBookEntries = _database.GetCollection<PhoneBookEntry>(collectionEntrySettings.CollectionName);
        }

        /// <summary>
        /// Add a new phone book entry
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PhoneBookEntry> AddEntry(PhoneBookEntry model)
        {
            phoneBookEntries.InsertOne(model);
            return await Task.FromResult(model);
        }

        /// <summary>
        /// Delete a phone book entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEntry(string id)
        {
            await phoneBookEntries.DeleteOneAsync( Builders<PhoneBookEntry>.Filter.Eq("_id", ObjectId.Parse(id)));
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Get the phone book
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PhoneBook> GetPhoneBook(PhoneBook model)
        {
            var phoneBook = phoneBooks.Find(x => x.Name == defaultPhoneBookName);

            //Return if it's found
            if(phoneBook.Any())
            {
                var book = phoneBook.First();
                book.Entries = GetEntries(book.Id);

                return book;
            }

            //If not found then we create
            if (String.IsNullOrEmpty(model.Name))
                model.Name = defaultPhoneBookName;

            var newPhoneBook = new PhoneBook() { Name = model.Name };
            phoneBooks.InsertOne(newPhoneBook);

            //Rerun
            return await this.GetPhoneBook(newPhoneBook);
        }

        private IEnumerable<PhoneBookEntry> GetEntries(string phoneBookId)
        {
            return phoneBookEntries.Find(x => x.PhoneBookId == phoneBookId).ToEnumerable();
        }
    }
}
