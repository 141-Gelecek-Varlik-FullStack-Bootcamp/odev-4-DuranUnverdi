using EntityLayer.Concrete;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IProductService:IGenericService<Product>
    {
        public PagedResponse<List<Product>> GetPaged(int pageNumber, int pageSize, List<Product> products);
    }
}
