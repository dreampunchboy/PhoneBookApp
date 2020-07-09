using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Interfaces
{
    public interface IPhoneBookCollectionSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
