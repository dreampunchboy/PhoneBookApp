using Microsoft.Extensions.Configuration;
using PhoneBookApp.Models.Phone;
using PhoneBookApp.Models.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace PhoneBookApp.App.States
{
    public class StateEntryAdd : StateBase, IState
    {
        private string action = "api/phonebook";
        private PhoneBookEntry phoneBookEntry;
        private StateResult previousStateResult;


        public StateEntryAdd(IConfiguration configuration) : base(configuration) { }

        public StateResult Execute(StateResult previousStateResult)
        {
            this.previousStateResult = previousStateResult;
            phoneBookEntry = new PhoneBookEntry();

            ClearScreen();
            WriteHeader("Add new entry");
            phoneBookEntry.Name = ReadStringNoEmpty("Please enter a name:");
            phoneBookEntry.PhoneNumber = ReadStringNoEmpty("Please enter a phone number:");

            var entry = AddPhoneBookEntry();

            WriteLine("");
            WriteLine(String.Format("{0} has been added to your phonebook", entry.Name));
            Thread.Sleep(2000);

            return ReturnChangeState(AppState.PhoneBook);
        }

        private PhoneBookEntry AddPhoneBookEntry()
        {
            phoneBookEntry.PhoneBookId = previousStateResult.AdditionalData.PhoneBookId;
            var content = CreateHttpContent(phoneBookEntry);

            var request = client.PostAsync(action, content);
            phoneBookEntry = Deserialize<PhoneBookEntry>(request.Result.Content.ReadAsStringAsync().Result);

            return phoneBookEntry;
        }
    }
}
