using Grocery.App.ViewModels;
using Grocery.App.Views;

namespace Grocery.App.Views;

public partial class ProductView : ContentPage
{
	private readonly ProductViewModel _viewModel;

	public ProductView(ProductViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

    private async void OnNewProductClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///NewProductView");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadProducts();
    }
}