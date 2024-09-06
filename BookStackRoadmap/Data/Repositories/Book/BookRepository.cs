using BookStackRoadmap.Context;
using BookStackRoadmap.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStackRoadmap.Data.Repositories;

public class BookRepository(RoadmapContext context) : IBookRepository
{
    
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public void Save()
    {
        context.SaveChanges(true);
    }

    public IEnumerable<Book> GetAll()
    {
        return context.Books.AsEnumerable();
    }

    public Book? Get(long id)
    {
        
        return context.Books.Find(id);
    }

    public void Create(Book entity)
    {
        context.Books.Add(entity);
        Save();
    }

    public void Update(Book entity)
    {

        Book book = context.Books.Find(entity.Id);
        context.Entry(book).CurrentValues.SetValues(entity);
        Save();
    }

    public void Remove(Book entity)
    {
        context.Books.Remove(entity);
        Save();
    }

    public Book? FindBookByAuthor(string authorName)
    {
        return context.Books.FirstOrDefault(book => book.Author == authorName);
    }

    public Book FindBookByName(string bookName)
    {
        return context.Books.FirstOrDefault(book => book.Name == bookName);
    }

    public Book FindBookByAuthorAndName(string authorName, string bookName)
    {
        return context.Books.FirstOrDefault(book => book.Author == authorName && book.Name == bookName);
    }
}