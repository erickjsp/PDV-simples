namespace PDVSimplorio;

using System.IO;
using System.Xml.Linq;

public class Program
{
    public static void Main()
    {
        string filepath = @"C:\repositorioC#\PDVSimplorio/faturamento.txt";
        string faturamento = "0";
        if (File.Exists(filepath))
        {
           faturamento = File.ReadAllText(filepath);

        }
        PDV erick = new PDV();
        while (true)
        {
            Console.WriteLine("==============CAIXA==============");
            Console.WriteLine("1. Adicionar produto ao carrinho");
            Console.WriteLine("2. Remover produto do carrinho");
            Console.WriteLine("3. Ver carrinho");
            Console.WriteLine("4. Finalizar compra");
            Console.WriteLine("5. Ver faturamento");
            Console.WriteLine("6. Resetar Faturamento");
            Console.WriteLine("Escolha sua opção: ");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Digite o ID do produto: ");
                        if (int.TryParse(Console.ReadLine(), out int AddProduct))
                        {
                            if (erick.AddToCart(AddProduct))
                            {
                                Console.WriteLine("Produto adicionado ao carrinho!");
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido!");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Digite o ID do produto: ");
                        if (int.TryParse(Console.ReadLine(), out int RemoveProduct))
                        {
                            if (erick.RemoveToCart(RemoveProduct))
                            {
                                Console.WriteLine("Produto removido do carrinho!");
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido!");
                        }
                        break;
                    case 3:
                        if (erick.ShowCart())
                        {
                            foreach (Product product in erick.cart)
                            {
                                Console.WriteLine($"Nome: {product.NameProduct} | Preço: R${product.PriceProduct:F2} | ID: {product.IdProduct}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Carrinho vazio!");
                        }
                        break;
                    case 4:
                        double paidValue = 0;
                        while (paidValue < erick.CartValue())
                        {
                            Console.Clear();
                            Console.WriteLine("--------AREA DE PAGAMENTO--------");
                            Console.WriteLine($"Valor total do carrinho:R${erick.CartValue():F2} ");
                            Console.WriteLine($"Valor pago:R${paidValue:F2}");
                            Console.WriteLine("Digite a quantidade a  pagar: ");
                            if (double.TryParse(Console.ReadLine(), out double aba))
                            {
                                paidValue += aba;
                            }
                            else
                            {
                                Console.WriteLine("Valor invalido!");
                            }
                        }
                        Console.WriteLine($"O valor do troco é: R${erick.CashBack(paidValue):F2}");
                        double save = (Convert.ToDouble(faturamento) + erick.CartValue());
                        File.WriteAllText(filepath, Convert.ToString(save));
                        return;
                    case 5:
                        
                        Console.WriteLine($"Faturamento:{faturamento:F2} ");

                        break;
                    case 6:
                        File.Delete(filepath);
                        Console.WriteLine("Faturamento apagado!");
                        return;
                    default:
                        {
                            Console.WriteLine("Valor invalido!");
                            break;
                        }
                }


            }
            else
            {
                Console.WriteLine("Valor inválido, tente novamente!");
            }
                
            
        }




    }
}