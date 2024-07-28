using App_Core.Domains.Other_Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Classes;
using App_Core.Domains.Entities;

namespace App_Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T: BaseEntity
    {
        public static IQueryable <T> GetQuery(IQueryable<T> InputQuery,ISpecification<T> spec)
        {
            var query = InputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            if(spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDesc != null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }

            if (spec.IsPagingEnabled)
            {
                query=query.Take(spec.Take).Skip(spec.Skip);
            }
            query =spec.Includes.Aggregate(query, (current, include)=>current.Include(include));

            return query;

        }

    }
}
