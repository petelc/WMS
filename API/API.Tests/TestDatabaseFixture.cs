using System;
using Microsoft.EntityFrameworkCore;
using API.Data;



namespace API.Tests;

public class TestDatabaseFixture
{
    private const string ConnectionString = @"Data Source=../API/wmsDB.db";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                // Ensure database is created
                using var context = CreateContext();
                context.Database.EnsureCreated();
                _databaseInitialized = true;
            }
        }
    }

    public WMSContext CreateContext() => new WMSContext( new DbContextOptionsBuilder<WMSContext>()
        .UseSqlite(ConnectionString)
        .Options);
    

}



