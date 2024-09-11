
using Entities.Models;

namespace bookAPI.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){Id=1,Title="Angels",Price=10},
                new Book(){Id=2,Title="Demons",Price=40}
            };
        }
    }
}
