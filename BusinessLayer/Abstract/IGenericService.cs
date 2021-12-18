using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> filter);
        T TGetByFilter(Expression<Func<T, bool>> filter=null);
        T TGetById(int id);
    }
}
