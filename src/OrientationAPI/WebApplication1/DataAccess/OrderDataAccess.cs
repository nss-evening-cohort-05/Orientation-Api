﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DataAccess
{
    public class OrderDataAccess : IOrdersRepository<OrderDataAccess>
    {

        //placeanorder
        public void Add()
        {
            throw new NotImplementedException();
        }

        //payforanorder
        public void Update()
        {
            throw new NotImplementedException();
        }

        //listordersunpaidorders
        public List<OrderDataAccess> ListUnPaid()
        {
            throw new NotImplementedException();
        }
        
    }

    public interface IOrdersRepository<T>
    {
        void Add();
        void Update();
        List<T> ListUnPaid();
    }
}