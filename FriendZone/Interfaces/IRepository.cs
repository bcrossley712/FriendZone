using System.Collections.Generic;

namespace FriendZone.Interfaces
{
  public interface IRepository<T, Tid>
  {
    List<T> GetAll();
    T GetById(Tid id);
    T Create(T data);
    void Update(T data);
    void Delete(Tid id);
  }
}