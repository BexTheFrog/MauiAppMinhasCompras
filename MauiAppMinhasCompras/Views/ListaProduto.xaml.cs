namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	public ListaProduto()
	{
		InitializeComponent();
	}

    private void Adicionar_Produto(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());

        }
        catch (Exception erro)
        {
            DisplayAlert("Ops, erro ao abrir a página ", erro.Message, "Fechar");
        }
    }
}