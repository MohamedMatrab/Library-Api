using System.Linq.Expressions;
using Library.Domain.Models;
using Library.Domain.Shared;

namespace Library.Domain.IRepositories;

public interface ICrudRepository<TObject,Tkey> where TObject:Base<Tkey>
{
    Result Create(TObject obj);
    IEnumerable<TObject> ReadList(Expression<Func<TObject,bool>> filter);
    TObject GetById(Tkey key);
    Result Update(TObject obj,Tkey key);
    Result Delete(Tkey key);
}