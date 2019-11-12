using CoffeeMug.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoffeeMug.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        protected const string REPOSITORY_FILE_NAME = "RepositoryData.json";
        private static readonly object locker = new object();
        public IEnumerable<Product> GetAll()
        {
            return LoadData();
        }

        public IEnumerable<Product> GetAll(Func<Product, bool> predicate)
        {
            return LoadData().Where(predicate).ToList();
        }

        public Guid Add(Product product)
        {
            var currentList = LoadData();
            product.Id = Guid.NewGuid();
            currentList.Add(product);
            SaveData(currentList);
            return product.Id;
        }

        public bool Delete(Guid id)
        {
            var currentList = LoadData();
            var productToRemove = currentList.Where(product => product.Id == id).FirstOrDefault();
            if (productToRemove == null)
                return false;
            currentList.Remove(productToRemove);
            SaveData(currentList);
            return true;
        }

        protected IList<Product> LoadData()
        {
            lock (locker)
            {
                string filePath = Directory.GetCurrentDirectory() + REPOSITORY_FILE_NAME;
                IList<Product> result = null;
                if (!File.Exists(filePath))
                {
                    using (FileStream fs = File.Create(filePath))
                    {

                    }
                }
                else
                {
                    var jsonData = File.ReadAllText(filePath);
                    try
                    {
                        result = JsonConvert.DeserializeObject<IList<Product>>(jsonData);
                    }
                    catch (JsonException)
                    {

                    }
                }
                if (result != null)
                {
                    return result;
                }
                return new List<Product>();
            }
        }

        protected void SaveData(IEnumerable<Product> productsList)
        {
            string filePath = Directory.GetCurrentDirectory() + REPOSITORY_FILE_NAME;
            lock (locker)
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(productsList));
            }
        }

        public bool Update(Product product)
        {
            var products = LoadData();
            var currentProduct = products.Where(p => p.Id == product.Id).FirstOrDefault();
            if (currentProduct == null)
                return false;
            var index = products.IndexOf(currentProduct);
            products[index] = product;
            SaveData(products);
            return true;

        }
    }
}
