using DataBaseFirst_BackEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFirst_BackEnd.Services {
    class ProductServices : BaseService {

        public void AddNewProduct(string productName,decimal unitPrice) {
            var newProduct = new Products();
            newProduct.ProductName = productName;
            newProduct.UnitPrice = unitPrice;

            dataContext.Products.Add(newProduct);
            dataContext.SaveChanges();

        }

    }
}
