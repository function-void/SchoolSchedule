﻿using System.Linq.Expressions;

namespace SchoolSchedule.Infrastructure.Repository.Base;

public interface IQueryBaseRepository<T>
{
    IQueryable<T> Get(Expression<Func<T, bool>> selector);
    Task<T> GetByIdAsync(Guid Id);
    IQueryable<T> GetAll();
}
