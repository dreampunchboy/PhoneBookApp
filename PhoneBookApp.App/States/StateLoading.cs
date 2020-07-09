using Microsoft.Extensions.Configuration;
using PhoneBookApp.Models.States;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PhoneBookApp.App.States
{
    public class StateLoading : StateBase, IState
    {
        public StateLoading(IConfiguration configuration) : base(configuration) { }

        public StateResult Execute(StateResult previousStateResult)
        {
            WriteHeader("Phonebook starting up...");
            return ReturnChangeState(AppState.PhoneBook);
        }
    }
}
