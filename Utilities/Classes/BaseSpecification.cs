using App_Core.Domains.Other_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Utilities.Classes
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification() { }
        public BaseSpecification(Expression<Func<T,bool>> Criteria) { 
          this.Criteria = Criteria;
        
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDesc { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }


        protected void AddIncludes(Expression<Func<T, object>> Includes)
        {
            this.Includes.Add(Includes); 
        }

        protected void SetOrderBy(Expression<Func<T, object>> OrderBy)
        {
        this.OrderBy = OrderBy; 
        } 
        protected void SetOrderByDesc(Expression<Func<T, object>> OrderByDesc)
        {
        this.OrderByDesc = OrderByDesc; 
        }

        protected void ApplyPaging(int Take, int Skip)
        {
            this.Take = Take;
            this.Skip = Skip;
            this.IsPagingEnabled = true;
        }

        
    }
}
