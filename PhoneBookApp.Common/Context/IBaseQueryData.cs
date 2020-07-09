using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Common.Context
{
    public interface IBaseQueryData
    {
        int Limit { get; set; }
        int Page { get; set; }
        int Skip { get; set; }
        string SortBy { get; set; }
        string Text { get; set; }
        string Id { get; set; }
        string ToString();
    }
}
