using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent();
    }

    private async void Salvar_Alteracoes(object sender, EventArgs e)
    {
        try
        {
            Produto itemAlterado = BindingContext as Produto;

            Produto item = new Produto
            {
                Id = itemAlterado.Id,
                Descricao = txt_nome.Text,
                Quantidade = Convert.ToDouble(txt_qtd.Text),
                Preco = Convert.ToDouble(txt_vlr.Text)
            };

            await App.Db.Update(item);
            await DisplayAlert("Sucesso", $"{item.Descricao} atualizado!", "Ok");
            await Navigation.PopAsync();

        }
        catch (Exception erro)
        {
            await DisplayAlert("Erro ao alterar produto", erro.Message, "Cancelar");
        }
    }
}