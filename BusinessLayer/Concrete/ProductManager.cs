using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public List<Product> GetList()
        {
            return _productDal.GetListAll();

        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter)
        {
            return _productDal.GetListAll(filter);
        }

        public PagedResponse<List<Product>> GetPaged(int pageNumber, int pageSize, List<Product> products)
        {
            var pagedData = products
             .Skip((pageNumber - 1) * pageSize)
             .Take(pageSize)
             .ToList();

            var response = new PagedResponse<List<Product>>(pagedData, pageNumber, pageSize);
            return response;
        }

        public void TAdd(Product t)
        {
            _productDal.Insert(t);
        }

        public void TDelete(Product t)
        {
            throw new NotImplementedException();
        }

        public Product TGetByFilter(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
