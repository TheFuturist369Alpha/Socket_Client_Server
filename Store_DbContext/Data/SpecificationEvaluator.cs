﻿using App_Core.Domains.Other_Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Classes;

namespace App_Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T: BaseSpecification<T>
    {
        public static IQueryable <T> GetQuery(IQueryable<T> InputQuery,ISpecification<T> spec)
        {
            var query = InputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query=spec.Includes.Aggregate(query, (current, include)=>current.Include(include));

            return query;

        }

    }
}
