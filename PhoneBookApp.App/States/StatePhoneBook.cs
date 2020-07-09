using Microsoft.Extensions.Configuration;
using PhoneBookApp.Models.Phone;
using PhoneBookApp.Models.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PhoneBookApp.App.States
{
    public class StatePhoneBook : StateBase, IState
    {
        private string action = "api/phonebook";
        private PhoneBook phoneBook;
        private StateResult previousStateResult;
        IEnumerable<PhoneBookEntry> entries;

        public StatePhoneBook(IConfiguration configuration) : base(configuration) { }

        public StateResult Execute(StateResult previousStateResult)
        {
            this.previousStateResult = previousStateResult;
            stateResult.AdditionalData.SearchText = previousStateResult.AdditionalData.SearchText;
            stateResult.AdditionalData.SelectedIndex = previousStateResult.AdditionalData.SelectedIndex;

            GetPhoneBook();

            DisplayPhoneBook();
            DisplayActions();

            return stateResult;
        }

        private void GetPhoneBook()
        {
            var request = client.GetAsync(String.Format("{0}", action));

            phoneBook = Deserialize<PhoneBook>(request.Result.Content.ReadAsStringAsync().Result);
            stateResult.AdditionalData.PhoneBookId = phoneBook.Id;
        }

        private void DisplayPhoneBook()
        {
            ClearScreen();
            WriteHeader(phoneBook.Name);

            DisplayPhoneBookEntries();
        }

        private void DisplayActions()
        {
            string actions = "[UP/DOWN ARROW]-Navigate Entries | [N]-Entry | [D]-Delete | [S]-Search";
            if (!String.IsNullOrEmpty(previousStateResult.AdditionalData.SearchText))
                actions += " | [C]-Clear Search";

            WriteLine("");
            WriteLine("================================= ACTIONS =================================");
            WriteLine(actions);
            WriteLine("===========================================================================");

            KeyPress(Console.ReadKey());
        }

        private void KeyPress(ConsoleKeyInfo info)
        {
            ReturnChangeState(AppState.PhoneBook);

            switch (info.Key)
            {
                case ConsoleKey.N:
                    stateResult = ReturnChangeState(AppState.EntryAdd);
                    break;
                case ConsoleKey.D:
                    stateResult = ReturnChangeState(AppState.EntryDelete);
                    stateResult.AdditionalData.phoneBookEntry = entries.ElementAt(stateResult.AdditionalData.SelectedIndex);
                    break;
                case ConsoleKey.S:
                    stateResult = ReturnChangeState(AppState.EntrySearch);
                    break;
                case ConsoleKey.C:
                    stateResult.AdditionalData.SearchText = "";
                    stateResult = ReturnChangeState(AppState.PhoneBook);
                    break;
                case ConsoleKey.UpArrow:
                    if (stateResult.AdditionalData.SelectedIndex - 1 < 0)
                        stateResult.AdditionalData.SelectedIndex = 0;
                    else
                        stateResult.AdditionalData.SelectedIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    if (stateResult.AdditionalData.SelectedIndex < entries.Count() - 1)
                        stateResult.AdditionalData.SelectedIndex++;
                    break;
            }
        }

        private void DisplayPhoneBookEntries()
        {
            //No entries
            if (phoneBook.Entries == null || !phoneBook.Entries.Any())
            {
                WriteLine("No entries...");
            }

            //Filter
            if (!String.IsNullOrEmpty(stateResult.AdditionalData.SearchText))
                entries = phoneBook.Entries.Where(x =>
                (x.Name.ToLower().Contains(stateResult.AdditionalData.SearchText.ToLower()))
                || (x.PhoneNumber.ToLower().Contains(stateResult.AdditionalData.SearchText.ToLower())));
            else
                entries = phoneBook.Entries;

            //Check selected item
            //if (String.IsNullOrEmpty(stateResult.AdditionalData.SelectedIndex))
            //stateResult.AdditionalData.SelectedItem = entries.First().Id;

            //Display
            for (int i = 0; i <  entries.Count(); i++)
            {
                DisplayPhoneBookEntry(entries.ElementAt(i), (stateResult.AdditionalData.SelectedIndex == i));
            }
        }

        private void DisplayPhoneBookEntry(PhoneBookEntry entry, bool selected)
        {
            WriteLine(String.Format("{0} {1} - {2}", (selected? "#" : ""), entry.Name, entry.PhoneNumber));
        }
    }
}
