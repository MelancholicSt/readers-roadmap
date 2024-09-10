namespace BookStackRoadmap.Services;

public interface IBookReaderService
{
    void SeparateBookPages();
    
    void SetCurrentPage(string pagePath);
    string GetCurrentPage();
    
}