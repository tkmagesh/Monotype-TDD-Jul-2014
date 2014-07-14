using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new ProductsCollection();
            products.Add(new Product { Id = 101, Name = "pen", Cost = 30, Units = 40 });
            products.Add(new Product { Id = 103, Name = "hen", Cost = 70, Units = 70 });
            products.Add(new Product { Id = 107, Name = "ten", Cost = 20, Units = 20 });
            products.Add(new Product { Id = 102, Name = "den", Cost = 90, Units = 60 });
            products.Add(new Product { Id = 109, Name = "len", Cost = 40, Units = 10 });
            products.Add(new Product { Id = 104, Name = "zen", Cost = 80, Units = 50 });
            products.Save();
            Console.WriteLine("Products saved");
            Console.WriteLine("Initial Product");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i]);
            }
            Console.WriteLine();
            Console.WriteLine("After sorting by units");
            products.Sort(new CompareProductById());
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i]);
            }

            Console.WriteLine();
            Console.WriteLine("After sorting by cost");
            products.Sort(new CompareProductByCost());
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i]);
            }
            Console.ReadLine();
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Units { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", Id, Name, Units, Cost);
        }
    }

    public class ProductsCollection
    {
        private ArrayList _list = new ArrayList();

        public void Add(Product product)
        {
            _list.Add(product);
        }
        public Product this[int index]
        {
            get
            {
                return _list[index] as Product;
            }
            set
            {
                _list[index] = value;
            }
        }
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public void Save()
        {
            var sw = new StreamWriter("products.csv");
            for(var i=0;i<_list.Count;i++)
                sw.WriteLine(_list[i].ToString());
            sw.Close();
        }

        public void Sort(ICompareProduct productComparer)
        {
            
            for(var i=0;i<_list.Count-1;i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var leftItem = (Product)_list[i];
                    var rightItem = (Product)_list[j];
                    if (productComparer.Compare(leftItem, rightItem) > 0)
                    {
                        var temp = _list[i];
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
        }
    }

    public interface ICompareProduct
    {
        int Compare(Product p1, Product p2);
    }

    public class CompareProductById : ICompareProduct
    {
        public int Compare(Product p1, Product p2) {
            if (p1.Id > p2.Id) return 1;
            if (p1.Id < p2.Id) return -1;
            return 0;
        }
    }

    public class CompareProductByCost : ICompareProduct
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Cost > p2.Cost) return 1;
            if (p1.Cost < p2.Cost) return -1;
            return 0;
        }
    }

}
