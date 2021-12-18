﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {

        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetListAll();
        T GetById(int id);
        T GetByFilter(Expression<Func<T, bool>> filter = null);
        List<T> GetListAll(Expression<Func<T, bool>> filter);

    }
}
