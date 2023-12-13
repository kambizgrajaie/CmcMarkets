﻿using CmcMarkets.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CmcMarkets.Backend.Persistence
{
    public interface IDataContext
    {
        public DbSet<UserTask> UserTasks { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
