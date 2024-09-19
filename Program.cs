using System;
using System.Data;
using linq;

namespace ADO2.Models;
public class Program{
    public static void Main(){
        Console.WriteLine("Halloe");
        Query query = new Query();
        // query.getProducts(19);
        // query.getGroups(19);
        query.getGroupsCount(19);
        
    }
}

