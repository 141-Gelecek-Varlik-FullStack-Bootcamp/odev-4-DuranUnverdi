using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetList()
        {
            return _userDal.GetListAll();
        }

        public List<User> GetList(Expression<Func<User, bool>> filter)
        {
            return _userDal.GetListAll(filter);
        }

        public void TAdd(User t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(User t)
        {
            throw new NotImplementedException();
        }

        public User TGetByFilter(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.GetByFilter(filter);
        }

        public User TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void TUpdate(User t)
        {
            _userDal.Update(t);
        }
    }
}
