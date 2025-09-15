using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
    public ListaProduto()
    {
        InitializeComponent();

        lst_produtos.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        if (lista.Count > 0) { 
        try
        {
            List<Produto> tmp = await App.Db.GetAll();
            lista.Clear();
            tmp.ForEach(i => lista.Add(i));
        } catch (Exception erro){
            await DisplayAlert("Ops, erro ao carregar ", erro.Message, "Fechar");
        }
        } else
        {

        }
        
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

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
        string q = e.NewTextValue;

                lista.Clear();

                List<Produto> tmp = await App.Db.Search(q);

                tmp.ForEach(i => lista.Add(i));
        } catch (Exception erro)
        {
            await DisplayAlert("Ops, erro ao Buscar ", erro.Message, "Fechar");
        }
        
    }

    private void Somar_Clicked(object sender, EventArgs e)
    {
        if (lista.Count == 0)
        {
            DisplayAlert("Nada por aqui", "Nenhum produto á ser somado", "Ok");
        } else { 

        double soma = lista.Sum(i => i.Total);

        string msg = $"O total é {soma:C}";

        DisplayAlert("Total dos produtos", msg,"Ok");
        }
    }

    private async void Remover_Produto(object sender, EventArgs e)
   
        {
            try
            {
                MenuItem? selecinado = sender as MenuItem;

                Produto? p = selecinado?.BindingContext as Produto;

                bool confirm = await DisplayAlert(
                    "Tem Certeza?", $"Remover {p.Descricao}?", "Sim", "Não");

                if (confirm)
                {
                    await App.Db.Delete(p.Id);
                    lista.Remove(p);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro ao remover", ex.Message, "Fechar");
            }
        }

    private void Editar_Produto(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto item = e.SelectedItem as Produto;

            if (item != null)
            {
                Navigation.PushAsync(new Views.EditarProduto { BindingContext = item });
            } else
            {
                DisplayAlert("Ops", "Nada foi selecionado", "Fechar");
            }

        } catch (Exception ex)
        {
            DisplayAlert("Erro ao remover", ex.Message, "Fechar");
        }
    }
}