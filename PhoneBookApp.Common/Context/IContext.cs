using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Common.Context
{
    public interface IContext<T, in TQuery> where TQuery : IBaseQueryData where T : class
    {
        Task<ContextResult<T>> Create(T data);
        Task<ContextResult<T>> Update(string id, T data);
        //Task<ContextResult<T>> Update(ContextInfo info, string id, JsonPatchDocument<T> data);
        //Task<ContextResult<T>> Update(ContextInfo info, TQuery queryData, TQuery updateData);
        Task<ContextResult<T>> Get(string id);
        //Task<ContextResult<T>> Get(ContextInfo info, TQuery queryData);
        Task<long> GetCount(TQuery queryData);
        Task<ContextResult<T>> Delete(ContextInfo info, string id);
    }

}
