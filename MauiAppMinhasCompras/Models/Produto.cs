using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        string _descricao;
        double _valor;
        double _quantidade;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception("Preencha a descrição");
                }
                _descricao = value;
            }
        }
        public double Quantidade
        {
            get => _quantidade; set
            {
                if (value == 0.0)
                {
                    throw new Exception("Indique uma quantidade");
                }
                _quantidade = value;
            }
        }
        public double Preco
        {
            get => _valor;

            set
            {
                if (value == 0.0)
                {
                    throw new Exception("Indique uma valor");
                }
                _valor = value;
            }


        }

        public double Total { get => Quantidade * Preco; }
    }
}
