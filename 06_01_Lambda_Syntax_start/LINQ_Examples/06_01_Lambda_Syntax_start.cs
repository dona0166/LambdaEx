using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    class Program
    {
        #region Class Definitions
        public class Customer
        {
            public string First { get; set; }
            public string Last { get; set; }
            public string State { get; set; }
            public double Price { get; set; }
            public string[] Purchases { get; set; }
        }

        public class Distributor
        {
            public string Name { get; set; }
            public string State { get; set; }
        }

        public class CustDist
        {
            public string custName { get; set; }
            public string distName { get; set; }
        }

        public class CustDistGroup
        {
            public string custName { get; set; }
            public IEnumerable<string> distName { get; set; }
        }
        #endregion

        #region Create data sources

        static List<Customer> customers = new List<Customer>
        {
            new Customer {First = "Cailin", Last = "Alford", State = "GA", Price = 930.00, Purchases = new string[] {"Panel 625", "Panel 200"}},
            new Customer {First = "Theodore", Last = "Brock", State = "AR", Price = 2100.00, Purchases = new string[] {"12V Li"}},
            new Customer {First = "Jerry", Last = "Gill", State = "MI", Price = 585.80, Purchases = new string[] {"Bulb 23W", "Panel 625"}},
            new Customer {First = "Owens", Last = "Howell", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 200", "Panel 180"}},
            new Customer {First = "Adena", Last = "Jenkins", State = "OR", Price = 2267.80, Purchases = new string[] {"Bulb 23W", "12V Li", "Panel 180"}},
            new Customer {First = "Medge", Last = "Ratliff", State = "GA", Price = 1034.00, Purchases = new string[] {"Panel 625"}},
            new Customer {First = "Sydney", Last = "Bartlett", State = "OR", Price = 2105.00, Purchases = new string[] {"12V Li", "AA NiMH"}},
            new Customer {First = "Malik", Last = "Faulkner", State = "MI", Price = 167.80, Purchases = new string[] {"Bulb 23W", "Panel 180"}},
            new Customer {First = "Serena", Last = "Malone", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 180", "Panel 200"}},
            new Customer {First = "Hadley", Last = "Sosa", State = "OR", Price = 590.20, Purchases = new string[] {"Panel 625", "Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Nash", Last = "Vasquez", State = "OR", Price = 10.20, Purchases = new string[] {"Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Joshua", Last = "Delaney", State = "WA", Price = 350.00, Purchases = new string[] {"Panel 200"}}
        };

        static List<Distributor> distributors = new List<Distributor>
        {
            new Distributor {Name = "Edgepulse", State = "UT"},
            new Distributor {Name = "Jabbersphere", State = "GA"},
            new Distributor {Name = "Quaxo", State = "FL"},
            new Distributor {Name = "Yakijo", State = "OR"},
            new Distributor {Name = "Scaboo", State = "GA"},
            new Distributor {Name = "Innojam", State = "WA"},
            new Distributor {Name = "Edgetag", State = "WA"},
            new Distributor {Name = "Leexo", State = "HI"},
            new Distributor {Name = "Abata", State = "OR"},
            new Distributor {Name = "Vidoo", State = "TX"}
        };

        static double[] exchange = { 0.89, 0.65, 120.29 };

        static double[] ExchangedPrices = {827.70, 604.50, 111869.70,
                                        1869.00, 1,365.00, 252609.00,
                                        521.36, 380.77, 70465.88,
                                        455.68, 332.80, 61588.48,
                                        2018.34, 1474.07, 272793.66,
                                        920.26, 672.10, 124379.86,
                                        1873.45, 1368.25, 253210.45,
                                        149.34, 109.07, 20184.66,
                                        455.68, 332.80, 61588.48,
                                        525.28, 383.63, 70995.16,
                                        9.08, 6.63, 1226.96,
                                        311.50, 227.50, 42101.50};

        static string[] Purchases = {  "Panel 625", "Panel 200",
                                    "12V Li",
                                    "Bulb 23W", "Panel 625",
                                    "Panel 200", "Panel 180",
                                    "Bulb 23W", "12V Li", "Panel 180",
                                    "Panel 625",
                                    "12V Li", "AA NiMH",
                                    "Bulb 23W", "Panel 180",
                                    "Panel 180", "Panel 200",
                                    "Panel 625", "Bulb 23W", "Bulb 9W",
                                    "Bulb 23W", "Bulb 9W",
                                    "Panel 200"
                                 };
        #endregion

        static void Main(string[] args)
        {

            //IEnumerable<Customer> stateQuery =
            //    from c in customers
            //    where c.State == "OR"
            //    select c;

            //foreach (Customer c in stateQuery)
            //{
            //    Console.WriteLine("{0} {1}", c.First, c.Last);
            //}

            //EX1
            //IEnumerable<double> exchangeQuery =
            //    ExchangedPrices.Where(c => c < 1000);

            //foreach(double e in exchangeQuery)
            //{
            //    Console.WriteLine("{0}", e);
            //}

            //IEnumerable<Customer> customerGAQuery =
            //    customers.Where(c => c.State == "GA");

            //foreach (Customer c in customerGAQuery)
            //{
            //    Console.WriteLine("{0}", c.Purchases);
            //}

            //EX2
            //IEnumerable<string> customerFirstNameQuery =
            //    customers.Select(c => c.First);

            //foreach (string names in customerFirstNameQuery)
            //{
            //    Console.WriteLine("{0}", names);
            //}

            //var customerFullNameQuery =
            //    from c in customers
            //    select new { FirstName = c.First, LastName = c.Last };
            //LAMBDA VERSION
            //var customerFullNameQuery =
            //    customers.Select(c => new { FirstName = c.First, LastName = c.Last });

            //foreach (var names in customerFullNameQuery)
            //{
            //    Console.WriteLine("{0} {1}", names.FirstName, names.LastName);
            //}


            //var custAndDisStatesQuery =
            //    from c in customers
            //    from d in distributors
            //    where c.State == d.State
            //    select new { CustomerName = c.Last, DistName = d.Name, State = c.State };
            //LAMBDA
            //var custAndDisStatesQuery =
            //    customers
            //    .Join(
            //    distributors,
            //    c => c.State,
            //    d => d.State,
            //    (c, d) => new { CustomerName = c.Last, DistName = d.Name, State = c.State }
            //    )
            //    .Where((c,d) => c.State == d. 
                
                


            //foreach (var compound in custAndDisStatesQuery)
            //{
            //    Console.WriteLine("{0} {1} {2}", compound.State, compound.CustomerName, compound.DistName);
            //}

            //EX3
            //var firstThreeCustomersQuey =
            //    customers.Take(3);

            //foreach (var element in firstThreeCustomersQuey)
            //{
            //    Console.WriteLine("{0} {1}", element.First, element.Last);
            //}

            //var firstThreeCustomerFromOAQuery =
            //    (from c in customers
            //     where c.State == "OR"
            //     select new { FirstName = c.First, LastName = c.Last })
            //    .Take(3);

            //foreach (var element in firstThreeCustomerFromOAQuery)
            //{
            //    Console.WriteLine("{0} {1}", element.FirstName, element.LastName);
            //}

            //var orderCustAlfByFirstName =
            //    from c in customers
            //    orderby c.First ascending
            //    select c.First;

            //foreach (var element in orderCustAlfByFirstName)
            //{
            //    Console.WriteLine("{0}", element);
            //}

            //var orderCustAlfByLengOFLastName =
            //    from c in customers
            //    orderby c.Last.Length ascending
            //    select c.Last;

            //foreach (var element in orderCustAlfByLengOFLastName)
            //{
            //    Console.WriteLine("{0}", element);
            //}

            //var orderCustAlfByLengOFLastName =
            //    from c in customers
            //    orderby c.Price descending
            //    select c.Price;

            //foreach (var element in orderCustAlfByLengOFLastName)
            //{
            //    Console.WriteLine("{0}", element);
            //}

            //var orderCustAlfByLengOFLastName =
            //    (from c in customers
            //     orderby c.First.Length ascending, c.Last ascending
            //     select c);

            //foreach(var element in orderCustAlfByLengOFLastName)
            //{
            //    Console.WriteLine("{0} {1}", element.First, element.Last);
            //}

            //EX5
            //var groupCustByFirstLetterQuery =
            //    from c in customers
            //    select c.First;

            //var newQuery =
            //    from w in groupCustByFirstLetterQuery
            //    group w by w[0] into g
            //    select g;

            //foreach (var element in newQuery)
            //{
            //    foreach(var letter in element)
            //    {
            //        Console.WriteLine(letter);
            //    }
            //}

            //var groupCustByFirstLetterQuery =
            //    from c in customers
            //    group c.First by c.First.Substring(0,1) into newarray
            //    select newarray;


            //foreach(var newarray in groupCustByFirstLetterQuery)
            //{
            //    foreach(var element in newarray)
            //    {
            //        Console.WriteLine(element);
            //    }
            //}

            //var groupCustByState =
            //    from c in customers
            //    group c by c.State into newarray
            //    select newarray;

            //foreach(var newarray in groupCustByState)
            //{
            //    foreach(var customer in newarray)
            //    {
            //        Console.WriteLine("{0}, {1}, {2}", customer.First, customer.Last, customer.State);
            //    }
            //}

            //EX6
            //var custFirstNameQuery =
            //    from c in customers
            //    select c.First.Substring(0, 1);

            //var custLastNameQuery =
            //    from c in customers
            //    select c.Last.Substring(0, 1);

            //var exceptLastNameFirstLetterQuery =
            //    custFirstNameQuery.Except(custLastNameQuery);

            //foreach(var element in exceptLastNameFirstLetterQuery)
            //{
            //    Console.WriteLine(element);
            //}

            //EX7
            //var custFirstNameContainAnyEdQuery =
            //    from c in customers
            //    group c by c.First into newarray
            //    where newarray.Any(c => c.First.Contains("ed"))
            //    select newarray;

            //foreach (var newarray in custFirstNameContainAnyEdQuery)
            //{
            //    foreach (var element in newarray)
            //    {
            //        Console.WriteLine(element.First);
            //    }
            //}




            Console.ReadKey();
        }
    }
}
