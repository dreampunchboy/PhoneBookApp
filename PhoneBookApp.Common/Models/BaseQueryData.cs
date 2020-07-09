using PhoneBookApp.Common.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Common.Models
{
    public class BaseQueryData : IBaseQueryData
    {
        public string SortBy { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
        public int Skip { get; set; }
        public string Text { get; set; }
        public string Id { get; set; }
    }
}
