using PhoneBookApp.Models.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.App.States
{
    public interface IState
    {
        StateResult Execute(StateResult previousStateResult);
    }
}
