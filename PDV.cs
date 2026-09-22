
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace PDVSimplorio;
public class PDV
{
    public List<Product> products = new List<Product>();
    public List<Product> cart = new List<Product>();
    public PDV()
    {
        products.Add(new Product(1, "cebolinha", 4.55));
        products.Add(new Product(2, "feijao", 12.50));
        products.Add(new Product(3, "farinha", 7.99));
        

    }    
    public  bool AddToCart(int id)
    {
        bool condition = false;
        foreach (Product product in products )
        {
            if (product.IdProduct == id)
            {
                cart.Add(product);
                condition = true;
            }
            
        }
        return condition;

    }
    public bool RemoveToCart(int id)
    {
        bool condition = false;
        foreach (Product product in products)
        {
            if (product.IdProduct == id)
            {
                cart.Remove(product);
                condition = true;
            }

        }
        return condition;

    }
    public bool ShowCart()
    {
        bool condition = true;
        if (cart.Count > 0)
        {
            return condition;
        }
        else
        {
            condition = false;
            return condition;
        }
    }
    public double CartValue()
    {
        double fullPrice = 0;
        foreach (Product product in cart)
        {
            fullPrice += product.PriceProduct;
        }
        return fullPrice;
    }
    public double CashBack(double cash)
    {
        return cash - CartValue();
    }



}
      
    

    
