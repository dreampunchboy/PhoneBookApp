using PhoneBookApp.Models.Phone;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Models.States
{
    public class StateResult
    {
        public StateResult()
        {
            AdditionalData = new Data();
        }

        public AppState NewState { get; set; }
        public bool ShouldChangeState { get; set; }
        public Data AdditionalData { get; set; }
    }

    public class Data
    {
        public PhoneBookEntry phoneBookEntry;
        public string PhoneBookId;
        public string SearchText;
        public int SelectedIndex;
    }
}
