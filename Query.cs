using System;
using ADO2.Models;

namespace linq;

class Query {
    public void getProducts(int price) {
    NorthwindContext northwindContext = new NorthwindContext();
    var res = from product in northwindContext.Products
              where product.UnitPrice == price
              select product;

    foreach (var product in res) {
        Console.WriteLine("{0} - {1} - {2} - {3}", 
                          product.ProductId, 
                          product.ProductName, 
                          product.UnitPrice, 
                          product.CategoryId);
        }
    }

    public void getGroups(int price) {
    NorthwindContext dt = new NorthwindContext();
    var res = from product in dt.Products
              where product.UnitPrice <= price
              group product by product.UnitPrice;

    foreach (var group in res) {
        Console.WriteLine(group.Key);
        foreach (var product in group) {
            Console.WriteLine("\t{0}: {1}", product.ProductName, product.UnitPrice);
            }
        }
    }

    public void getGroupsCount(int price){
        NorthwindContext dt = new NorthwindContext();
        var res = from product in dt.Products
            where product.UnitPrice == price
            group product by product.UnitPrice into gr

        select new { 
            price = gr.Key,
            numberOfProducts = gr.Count()
        };

        foreach (var group in res) {
            Console.WriteLine("Number of Products: {0}", group.numberOfProducts);
        }

    }

}