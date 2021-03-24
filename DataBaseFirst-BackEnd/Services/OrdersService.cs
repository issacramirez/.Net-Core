using DataBaseFirst_BackEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseFirst_BackEnd.Services {
    class OrdersService : BaseService {

        public IQueryable<Orders> GetOrderByID(int orderID) {
            return GetAllOrders().Where(w => w.OrderId == orderID);
        }

        public IQueryable<Orders> GetAllOrders() {
            return dataContext.Orders;
        }

    }
}
