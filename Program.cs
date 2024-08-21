using ADO.NET.CORE.DTOS;
using ADO.NET.CORE.Services;
using ADO.NET.SERVICES;
using System.Text;
StringBuilder headerdesign = new StringBuilder();
headerdesign
            .Append('-', 120)
            .AppendLine()
            .Append(' ', 45)
            .Append("WELCOME TO E-COMMERCE SYSTEM SOFTWARE")
            .Append(' ', 45)
            .AppendLine()
            .Append('-', 120);
Console.WriteLine(headerdesign);
while (true)
{
    IProductService productService = new ProductService();
    Console.Write("\t\tADO.NET\n" +
                   "1:ADD PRODUCTS\n" +
                   "2:REMOVE PRODUCT\n" +
                   "3:UPDATE PRODUCT\n" +
                   "4:VIEW PRODUCT\n" +
                   "5:QUIT\n" +
                   "ENTER OPTION:");
    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            {
                ProductDto productDto = new ProductDto();
                Console.Write("Enter product name:");
                productDto.Name = Console.ReadLine();

                Console.Write("Enter product price:");
                productDto.Price = decimal.Parse(Console.ReadLine());

                Console.Write("Enter product stock:");
                productDto.Stock = int.Parse(Console.ReadLine());
                await productService.AddProductAsync(productDto);
                break;
            }
        case 2:
            {
                Console.Write("Enter Id To Remove:");
                int id = int.Parse(Console.ReadLine());
                await productService.RemoveProductAsync(id);
                break;
            }
        case 3:
            {
                ProductDto productDto = new ProductDto();
                Console.Write("Enter Id To Update:");
                int Id = int.Parse(Console.ReadLine());
                Console.Write("Enter new product name:");
                productDto.Name = Console.ReadLine();

                Console.Write("Enter new product price:");
                productDto.Price = decimal.Parse(Console.ReadLine());

                Console.Write("Enter new product stock:");
                productDto.Stock = int.Parse(Console.ReadLine());
                await productService.UpdateProductAsync(Id, productDto);
            }
            break;
        case 4:
            {
                await productService.ViewProductsAsync();
                break;
            }
        case 5:
            return;
    }
    if (choice == 5)
        break;

}
