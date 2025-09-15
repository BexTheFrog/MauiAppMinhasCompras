using System.Threading.Tasks;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
		try
		{
			Produto item = new Produto
			{

				Descricao = txt_nome.Text,
				Quantidade = Convert.ToDouble(txt_qtd.Text),
				Preco = Convert.ToDouble(txt_vlr.Text)
			};

			await App.Db.Insert(item);
			await DisplayAlert("Sucesso", "Registro Inserido", "Ok");

		}
		catch (Exception erro)
		{
			await DisplayAlert("Erro ao adicionar produto", erro.Message, "Cancelar");
		}
    }
}