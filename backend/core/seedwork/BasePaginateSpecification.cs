using System;
using System.Linq.Expressions;

namespace core.seedwork
{
    public abstract class BasePaginateSpecification<T> : BaseSpecification<T>, ISpecificationPaginate<T>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        protected BasePaginateSpecification()
            :base()
        {

        }

        protected BasePaginateSpecification(Expression<Func<T, bool>> criteria)
            :base(criteria)
        {
            Criterias.Add(criteria);
        }
    }
}
