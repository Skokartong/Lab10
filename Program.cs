using Lab10.Data;
using Lab10.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Menu with options
            Console.WriteLine("Choose option: 1) View all customers, 2) Add new customer or 3) Quit");
            Console.WriteLine("Enter 1, 2 or 3 please.");
            int menuChoice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (menuChoice)
            {
                case 1:
                    {
                        using (NorthContext context = new NorthContext())
                        {
                            Console.WriteLine("Sort 1) Ascending or 2) Descending?");
                            Console.WriteLine("Enter 1 or 2:");
                            int reply = int.Parse(Console.ReadLine());

                            if (reply == 1)
                            {
                                var customers = context.Customers
                                .Include(c => c.Orders)
                                .OrderBy(c => c.CompanyName)
                                .ToList();

                                ViewAllCustomers(customers);
                                ViewCustomer(context);
                            }

                            else if (reply == 2)
                            {
                                var customers = context.Customers
                                .Include(c => c.Orders)
                                .OrderByDescending(c => c.CompanyName)
                                .ToList();

                                ViewAllCustomers(customers);
                                ViewCustomer(context);
                            }

                            else
                            {
                                Console.WriteLine("Invalid number, try again!");
                            }

                        }
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Enter CompanyName:");
                        string companyName = Console.ReadLine();

                        Console.WriteLine("Enter ContactName:");
                        string contactName = Console.ReadLine();

                        Console.WriteLine("Enter Country:");
                        string country = Console.ReadLine();

                        Console.WriteLine("Enter Region:");
                        string region = Console.ReadLine();

                        Console.WriteLine("Enter Phone:");
                        string phone = Console.ReadLine();

                        Console.WriteLine("Enter Postal Code:");
                        string postalcode = Console.ReadLine();

                        Console.WriteLine("Enter city:");
                        string city = Console.ReadLine();

                        Console.WriteLine("Enter contact title:");
                        string contacttitle = Console.ReadLine();

                        Console.WriteLine("Enter fax:");
                        string fax = Console.ReadLine();

                        using (NorthContext context = new NorthContext())
                        {
                            var newCustomer = new Customer
                            {
                                CustomerId = Guid.NewGuid().ToString().Substring(0, 5),
                                CompanyName = companyName,
                                ContactName = contactName,
                                Country = country,
                                Region = region,
                                ContactTitle = contacttitle,
                                Fax = fax,
                                City = city,
                                PostalCode = postalcode
                            };

                            context.Customers.Add(newCustomer);
                            context.SaveChanges();
                            Console.WriteLine("New customer added successfully!");
                        }

                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Bye bye!");
                        break;
                    }
            }

            // Method for displaying all customers and orders
            static void ViewAllCustomers(IEnumerable<Customer> customers)
            {
                Console.WriteLine("Customers");
                foreach (var c in customers)
                {
                    Console.WriteLine($"Company: {c.CompanyName}, Name:{c.ContactName}");
                    Console.WriteLine($"Country: {c.Country}, Region: {c.Region}, Phone: {c.Phone}");
                    Console.WriteLine($"CustomerId: {c.CustomerId}");
                    Console.WriteLine();

                    if (c.Orders != null && c.Orders.Any())
                    {
                        Console.WriteLine($"Orders Count: {c.Orders.Count}");
                        Console.WriteLine($"Order IDs: {string.Join(", ", c.Orders.Select(o => o.OrderId))}");
                    }

                    else
                    {
                        Console.WriteLine("No Orders for this customer.");
                    }

                    Console.WriteLine($"CustomerId: {c.CustomerId}");
                    Console.WriteLine();
                }
            }

            // Method for displaying selected customer
            static void ViewCustomer(NorthContext context)
            {
                Console.WriteLine("Enter CustomerId to view more information");
                string customerId = Console.ReadLine();
                Console.WriteLine();

                var customer = context.Customers
                    .Include(c => c.Orders)
                    .Where(c => c.CustomerId == customerId)
                    .Select(c => new { c.ContactName, c.CompanyName, c.Orders, c.Country })
                    .FirstOrDefault();

                if (customer != null)
                {
                    Console.WriteLine($"Customer Information:");
                    Console.WriteLine($"Company: {customer.CompanyName}, Name: {customer.ContactName}");
                    Console.WriteLine($"Country: {customer.Country}, Orders: {customer.Orders.Count}");
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine($"Customer with ID {customerId} not found.");
                }
            }
        }
    }
}


