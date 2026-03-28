// Author: Owen Read
// Online Ordering Program


class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "Ontario", "Canada");

        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Emily Chen", address2);

        Product product1 = new Product("Wireless Mouse", "WM-101", 29.99, 2);
        Product product2 = new Product("USB-C Hub", "UC-202", 49.99, 1);
        Product product3 = new Product("Mechanical Keyboard", "MK-303", 89.99, 1);
        Product product4 = new Product("Monitor Stand", "MS-404", 34.99, 2);
        Product product5 = new Product("Webcam HD", "WC-505", 59.99, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Domestic
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nOrder Total: ${order1.GetTotalCost():F2}");
        Console.WriteLine("(Shipping: $5.00 — domestic)\n");

        Console.WriteLine(new string('-', 40));
        Console.WriteLine();

        // international
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nOrder Total: ${order2.GetTotalCost():F2}");
        Console.WriteLine("(Shipping: $35.00 — international)\n");
    }
}