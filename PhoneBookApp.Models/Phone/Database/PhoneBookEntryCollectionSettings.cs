using PhoneBookApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Models.Phone.Database
{
    public class PhoneBookEntryCollectionSettings : ICollectionSettings, IPhoneBookEntryCollectionSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
