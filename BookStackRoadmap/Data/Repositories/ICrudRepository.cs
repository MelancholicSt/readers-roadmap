using BookStackRoadmap.Entities;

namespace BookStackRoadmap.Data.Repositories;

public interface ICrudRepository<EntityT, IdT> : IRepository where EntityT : IEntity
{
    IEnumerable<EntityT> GetAll();
    EntityT Get(IdT id);
    void Create(EntityT entity);
    void Update(EntityT entity);
    void Remove(EntityT entity);
}