using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.DAL.Mongo.Types
{
    public interface IFilter<TResult, in TQuery> where TQuery : IQuery
    {
        IEnumerable<TResult> Filter(IEnumerable<TResult> values, TQuery query);
    }

}
