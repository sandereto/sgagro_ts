using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace core.seedwork
{
    public interface ISpecificationPaginate<T> : ISpecification<T>
    {
        int Page { get; set; }
        int PageSize { get; set; }
    }
}
