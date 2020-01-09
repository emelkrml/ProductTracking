using ProductTrackingApp.DataAccess.Abstract;
using ProductTrackingApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTrackingApp.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ProductTrackingContext>, IProductDal
    {
    }
}
