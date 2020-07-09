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
    public class StateEntrySearch : StateBase, IState
    {
        private PhoneBookEntry phoneBookEntry;
        private StateResult previousStateResult;


        public StateEntrySearch(IConfiguration configuration) : base(configuration) { }

        public StateResult Execute(StateResult previousStateResult)
        {
            ClearScreen();
            WriteHeader("Search");
            stateResult.AdditionalData.SearchText = ReadStringNoEmpty("Please enter a name or phone number:");

            return ReturnChangeState(AppState.PhoneBook);
        }
    }
}
