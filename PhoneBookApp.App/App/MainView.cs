using Microsoft.Extensions.Configuration;
using PhoneBookApp.App.States;
using PhoneBookApp.Models.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.App.App
{
    public class MainView
    {
        IConfiguration configuration;
        private AppState currentAppState;
        private Dictionary<AppState, IState> states;

        public MainView(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Start()
        {
            SetupStates();
            ChangeState(AppState.Loading);

            ExecuteState(new StateResult());
            Start();
        }

        private void SetupStates()
        {
            //Setup states
            states = new Dictionary<AppState, IState>();
            states.Add(AppState.Loading, new StateLoading(configuration));
            states.Add(AppState.PhoneBook, new StatePhoneBook(configuration));
            states.Add(AppState.EntryAdd, new StateEntryAdd(configuration));
            states.Add(AppState.EntrySearch, new StateEntrySearch(configuration));
            states.Add(AppState.EntryDelete, new StateEntryDelete(configuration));
        }

        /// <summary>
        /// This is the main loop of the application
        /// </summary>
        private void ExecuteState(StateResult previousStateResult)
        {
            try
            {
                //Execute the state
                var result = states[currentAppState].Execute(previousStateResult);

                //Check for changes
                if (result.ShouldChangeState)
                    ChangeState(result.NewState);

                ExecuteState(result);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("There was an error, let's restart.");
                return;
            }
        }

        public void ChangeState(AppState newState)
        {
            currentAppState = newState;
        }

    }
}
