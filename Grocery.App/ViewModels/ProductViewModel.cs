using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        public ObservableCollection<Product> Products { get; set; }

        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
            Products = [];
            LoadProducts();
        }

        public void LoadProducts()
        {
            Products.Clear();
            foreach (Product p in _productService.GetAll()) Products.Add(p);
        }
    }
}
