using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(bool trackchanges);
        Book GetOneBookById(int id, bool trackchanges);
        Book CreateOneBook(Book book);
        void UpdateOneBook(int id, Book book, bool trackchanges);
        void DeleteOneBook(int id, bool trackchanges);
    }
}
