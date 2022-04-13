using System.Collections.Generic;

namespace FriendZone.Interfaces
{
  public interface IService<T>
  {
    List<T> GetAll();
    T GetById(int id);
    T Create(string userId, T data);
    T Update(string userId, T data);
    void Delete(string userId, int id);

  }
}