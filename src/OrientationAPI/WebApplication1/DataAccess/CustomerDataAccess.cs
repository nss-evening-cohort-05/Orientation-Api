using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DataAccess
{
    public class CustomerDataAccess
    {
        public class IntRepository : IRepository<int>
        {
            public List<int> GetAll()
            {
                throw new NotImplementedException();
            }
        }
    }

    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}