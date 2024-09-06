using BookStackRoadmap.Entities;

namespace BookStackRoadmap.Data.Repositories;

public interface IBookRepository : ICrudRepository<Book, long>, IDisposable
{
    Book FindBookByAuthor(string authorName);
    Book FindBookByName(string bookName);
    Book FindBookByAuthorAndName(string authorName, string bookName);
}