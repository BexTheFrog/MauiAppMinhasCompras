//Iniciando codificação da classe para o armazenamento e definindo metódos;

//Chamando os modelos gravados no aplicativo;
using MauiAppMinhasCompras.Models;
//Chamando a dependencia instalada para utilizar o SQLite;
using SQLite;

//Iniciando conjunto das classes
namespace MauiAppMinhasCompras.Helpers
{
    // Iniciando classe de conexão;
    public class SQLiteDatabaseHelper
    {
        // Chamando readoly para garantir a declaração de classe apenas com seu construtor;
        readonly SQLiteAsyncConnection _conexao;

        // Construtor da conexão e a tabela que representará a classe;
        public SQLiteDatabaseHelper(string path)
        {
            // Estabelece conexão com o SQLite;
            _conexao = new SQLiteAsyncConnection(path);
            // Aguarda a criação da tabela Produto, se existir 
            _conexao.CreateTableAsync<Produto>().Wait();
        }

        //Começando a Iniciar os metódos do CRUD

        // Metodo do Insert - Vai adicionar um produto, parametro do metodo para criação é ter um produto, ou seja um item;
        public Task<int> Insert(Produto item) 
        {
            // Inserindo o produto com o metodo já asincrono para a espera da tarefa;
            return _conexao.InsertAsync(item);
        }

        // Método de atualização do produto - onde o parametro para que atualize é um item (se vou atualizar tem que ter com o que vou atualizar)
        public Task<List<Produto>> Update(Produto item)
        {
            // Definindo a Query. 
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            // Utilizando um metódo com a QueryAsync
            return _conexao.QueryAsync<Produto>(
                sql, item.Descricao, item.Quantidade, item.Preco, item.Id
            );
        }

        // Método para deletar produtos - onde o parametro é o id deste produto, para identificar qual vai ser deletado
        public Task<int> Delete(int id)
        {
            // Realiza o delete, com método próprio;
            return _conexao.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        // Metodo para listar os produtos;
        public Task<List<Produto>> GetAll()
        {
            // Vai retornar uma lista (com metodo próprio) assincrona dos produtos;
            return _conexao.Table<Produto>().ToListAsync();
        }

        // Método para buscar os produtos - Tendo como parametro uma key (chave) para buscar no banco;
        public Task<List<Produto>> Search(string key)
        {
            //Denominando uma variavel para guardar a query a ser usada no query async;
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + key + "%'";

            //Retorna os resultados desta query;
            return _conexao.QueryAsync<Produto>(sql);
        }

        // O task é uma tafera, uma tarefa de lista, que lista produtos;
    }
}