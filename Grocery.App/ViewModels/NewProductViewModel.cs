using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels
{
    public partial class NewProductViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        private readonly GlobalViewModel _globalViewModel;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int stock;

        [ObservableProperty]
        private DateOnly shelfLife;

        [ObservableProperty]
        private decimal price;

        public NewProductViewModel(IProductService productService, GlobalViewModel globalViewModel)
        {
            _productService = productService;
            _globalViewModel = globalViewModel;
            ShelfLife = default;
        }

        [RelayCommand]
        private async Task Save()
        {
            if (_globalViewModel.Client == null || _globalViewModel.Client.Role != Role.Admin)
            {
                await Shell.Current.DisplayAlert("Geen toegang", "Alleen admins mogen producten aanmaken.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                await Shell.Current.DisplayAlert("Validatie", "Naam is verplicht.", "OK");
                return;
            }
            if (Price < 0)
            {
                await Shell.Current.DisplayAlert("Validatie", "Prijs moet positief zijn.", "OK");
                return;
            }

            Product created = _productService.Add(new(0, Name.Trim(), Stock, ShelfLife, Price));
            await Shell.Current.DisplayAlert("Gemaakt", $"Product #{created.Id} aangemaakt.", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}


