﻿using Microsoft.EntityFrameworkCore;

namespace Prosolve.MicroService.Watcher.DataAccess
{
  public class WatcherContext :DbContext
  { 
    public DbSet<ProcessDataModel> Processes { get; set; }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql(@"port=5432 dbname=watcher user=watcher password=watcher_password");
    }
  }
}
