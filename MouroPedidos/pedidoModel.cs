using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouroPedidos
{
    public class pedidoModel
    {
     
        String nomeCliente;
        String dataEntrega;
        String horaEntrega;
        String telefoneCliente;
        String enderecoCliente;
        String itensPedido;
        String observacoes;
        int tipoPedido;
        int numPedido;
        int formaPagamento;
        DateTime dataPedido;

        
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public string DataEntrega { get => dataEntrega; set => dataEntrega = value; }
        public string HoraEntrega { get => horaEntrega; set => horaEntrega = value; }
        public string TelefoneCliente { get => telefoneCliente; set => telefoneCliente = value; }
        public string EnderecoCliente { get => enderecoCliente; set => enderecoCliente = value; }
        public string ItensPedido { get => itensPedido; set => itensPedido = value; }
        public string Observacoes { get => observacoes; set => observacoes = value; }
        public int TipoPedido { get => tipoPedido; set => tipoPedido = value; }
        public DateTime DataPedido { get => dataPedido; set => dataPedido = value; }
        public int NumPedido { get => numPedido; set => numPedido = value; }
        public int FormaPagamento { get => formaPagamento; set => formaPagamento = value; }




        //Construtor completo -> qnd o pedido precisará de todas as informações.
        public pedidoModel(int nPedido, String nCliente, String dtEntrega, String hrEntrega, int fPagamento, String teleCliente, String endCliente, String itPedido, String observ, int tPedido, DateTime dtPedido)
        {
            NumPedido = nPedido;
            NomeCliente = nCliente;
            DataEntrega = dtEntrega;
            HoraEntrega = hrEntrega;
            TelefoneCliente = teleCliente;
            EnderecoCliente = endCliente;
            ItensPedido = itPedido;
            Observacoes = observ;
            TipoPedido = tPedido;
            DataPedido = dtPedido;
            FormaPagamento = fPagamento;

        }

        public pedidoModel(int nPedido, int fPagamento, String nCliente, String dtEntrega, String itPedido, int tPedido, DateTime dtPedido)
        {
            NumPedido = nPedido;
            NomeCliente = nCliente;
            DataEntrega = dtEntrega;
            ItensPedido = itPedido;
            TipoPedido = tPedido;
            DataPedido = dtPedido;
            FormaPagamento = fPagamento;
        }

        public pedidoModel()
        {
            NumPedido = 0;
            NomeCliente = " ";
            DataEntrega = " ";
            HoraEntrega = " ";
            TelefoneCliente = " ";
            EnderecoCliente = " ";
            ItensPedido = " ";
            Observacoes = " ";
            TipoPedido = 0;
            DataPedido = DateTime.Now;
            FormaPagamento = 0;


        }





    }
}
