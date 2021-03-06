﻿using BookCollector.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookCollector.Services
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Book>().Wait();
            _database.CreateTableAsync<Filter>().Wait();
            _database.CreateTableAsync<Location>().Wait();
            _database.CreateTableAsync<Settings>().Wait();
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<Book>> GetBooksAsync()
        {
            return _database.Table<Book>().ToListAsync();
        }

        public Task<Book> GetBookAsync(Guid id)
        {
            return _database.Table<Book>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> AddBookAsync(Book book)
        {
            return _database.InsertAsync(book);
        }

        public Task<int> UpdateBookAsync(Book book)
        {
            return _database.UpdateAsync(book);
        }

        public Task<int> DeleteBookAsync(Book book)
        {
            return _database.DeleteAsync(book);
        }

        public Task<List<Location>> GetLocationsAsync()
        {
            return _database.Table<Location>().ToListAsync();
        }

        public Task<Location> GetLocationAsync(Guid id)
        {
            return _database.Table<Location>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> AddLocationAsync(Location location)
        {
            return _database.InsertAsync(location);
        }

        public Task<int> UpdateLocationAsync(Location location)
        {
            return _database.UpdateAsync(location);
        }

        public Task<int> DeleteLocationAsync(Location location)
        {
            return _database.DeleteAsync(location);
        }
    }
}
