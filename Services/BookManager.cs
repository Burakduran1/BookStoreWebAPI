using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;

        public BookManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Book CreateOneBook(Book book)
        {
            if (book is null)
                throw new ArgumentNullException(nameof(book));

            _manager.Book.Create(book);
            _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackchanges)
        {
            //check entity
            var entity = _manager.Book.GetOneBookById(id, trackchanges);
            if (entity is null)
                throw new Exception($"Book with id:{id} could not found");

            _manager.Book.Delete(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackchanges)
        {
            return _manager.Book.GetAllBooks(trackchanges);
        }

        public Book GetOneBookById(int id, bool trackchanges)
        {
            return _manager.Book.GetOneBookById(id, trackchanges);
        }

        public void UpdateOneBook(int id, Book book, bool trackchanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackchanges);
            if (entity is null)
                throw new Exception($"Book with id:{id} could not found.");

            if (book is null)
                throw new ArgumentNullException(nameof(book));
            
            entity.Title = book.Title;
            entity.Price = book.Price;

            _manager.Book.Update(entity);
            _manager.Save();

        }
    }
}
