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
    public class StateEntryDelete : StateBase, IState
    {
        private string action = "api/phonebook/deleteEntry";
        private StateResult previousStateResult;

        public StateEntryDelete(IConfiguration configuration) : base(configuration) { }

        public StateResult Execute(StateResult previousStateResult)
        {
            this.previousStateResult = previousStateResult;

            ClearScreen();
            WriteHeader("Delete");

            var deleteMessage = String.Format("Are you sure you want to delete {0}?", previousStateResult.AdditionalData.phoneBookEntry.Name);

            WriteLine("");
            WriteLine(deleteMessage);
            WriteLine("");
            WriteLine("============================ ACTIONS ============================");
            WriteLine("[Y]-Yes | [N]-No");
            WriteLine("=================================================================");

            var delete = Console.ReadKey();

            if (delete.Key == ConsoleKey.Y)
            {
                DeleteEntry();
                return ReturnChangeState(AppState.PhoneBook);
            }
            else
            {
                return ReturnChangeState(AppState.PhoneBook);
            }
        }

        private void DeleteEntry()
        {
            var content = new StringContent(previousStateResult.AdditionalData.phoneBookEntry.Id);
            var request = client.GetAsync(String.Format("{0}?id={1}", action, previousStateResult.AdditionalData.phoneBookEntry.Id)).Result;
            //phoneBookEntry = Deserialize<PhoneBookEntry>(request.Result.Content.ReadAsStringAsync().Result);
        }
    }
}
