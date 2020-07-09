using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PhoneBookApp.Interfaces;
using PhoneBookApp.Models.Phone.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Common.Services
{
    public class BaseService
    {
        protected MongoClient _client;
        protected IMongoDatabase _database;

        public BaseService(object collectionSettings)
        {
            var settings = (ICollectionSettings)collectionSettings;
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
        }
    }
}
