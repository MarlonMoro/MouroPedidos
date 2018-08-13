using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MouroPedidos
{
    class pedidoDAO
    {
        pedidoModel objPedido = new pedidoModel();
        //string Config = "server=10.1.1.186; userid=mouro; database=mouropedido";

        String config;

        public void configBanco()
        {
            String path = Directory.GetCurrentDirectory();
            StreamReader str = new StreamReader(path + @"\config.txt");
           

            string line = "";

            line = str.ReadLine();

            config = line;
            
        }

        public List<pedidoModel> ListaPedidoCliente(String nomeCliente)
        {
            List<pedidoModel> listaCliente = new List<pedidoModel>();

            configBanco();

            MySqlConnection CONEXAO = new MySqlConnection(config);

            try
            {
                CONEXAO.Open();
                

                string query = "SELECT * FROM pedido WHERE nomeCliente LIKE '%" + nomeCliente + "%'";
                

                //Parte do insert
                MySqlCommand cmd = new MySqlCommand(query, CONEXAO);
                MySqlDataReader leitor = cmd.ExecuteReader();

                if (leitor.HasRows)
                {
                    while(leitor.Read())
                    {
                        pedidoModel pedido = new pedidoModel();
                        
                        //preencher o objeto com os dados retornados
                        pedido.NumPedido = Convert.ToInt32(leitor["idpedido"]);
                        pedido.DataEntrega = leitor["dataEntrega"].ToString();
                        pedido.HoraEntrega = leitor["horaEntrega"].ToString();
                        pedido.TipoPedido = Convert.ToInt32(leitor["tipoPedido"]);
                        pedido.NomeCliente = leitor["nomeCliente"].ToString();
                        pedido.TelefoneCliente = leitor["telefoneCliente"].ToString();
                        pedido.EnderecoCliente = leitor["enderecoCliente"].ToString();
                        pedido.ItensPedido = leitor["itensPedido"].ToString();
                        pedido.FormaPagamento = Convert.ToInt32(leitor["formaPagamento"]);
                        pedido.Observacoes = leitor["observacoes"].ToString();
                        pedido.DataPedido = Convert.ToDateTime(leitor["dataPedido"]);

                       

                        listaCliente.Add(pedido);
                     
                    }
                }
                
                CONEXAO.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return listaCliente;
        }


        public pedidoModel buscaID(int codigoPedido)
        {
            pedidoModel pedido = new pedidoModel();

            configBanco();

            MySqlConnection CONEXAO = new MySqlConnection(config);

            try
            {
                CONEXAO.Open();

                string query = "SELECT * FROM pedido WHERE idpedido = " + codigoPedido;

                
                MySqlCommand cmd = new MySqlCommand(query, CONEXAO);
                MySqlDataReader leitor = cmd.ExecuteReader();

                if (leitor.HasRows)
                {
                    while (leitor.Read())
                    {
                        //preencher o objeto com os dados retornados
                        pedido.NumPedido = Convert.ToInt32(leitor["idpedido"]);
                        pedido.DataEntrega = leitor["dataEntrega"].ToString();
                        pedido.HoraEntrega = leitor["horaEntrega"].ToString();
                        pedido.TipoPedido = Convert.ToInt32(leitor["tipoPedido"]);
                        pedido.NomeCliente = leitor["nomeCliente"].ToString();
                        pedido.TelefoneCliente = leitor["telefoneCliente"].ToString();
                        pedido.EnderecoCliente = leitor["enderecoCliente"].ToString();
                        pedido.ItensPedido = leitor["itensPedido"].ToString();
                        pedido.FormaPagamento = Convert.ToInt32(leitor["formaPagamento"]);
                        pedido.Observacoes = leitor["observacoes"].ToString();
                        pedido.DataPedido = Convert.ToDateTime(leitor["dataPedido"]);

                        
                    }
                }

                CONEXAO.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return pedido;
        }

        public Boolean salvaPedido(pedidoModel pedido)
        {
            configBanco();
            MySqlConnection CONEXAO = new MySqlConnection(config);

            try
            {
                CONEXAO.Open();

                //Parte do insert
                MySqlCommand INSERT = new MySqlCommand("INSERT INTO pedido (dataEntrega, horaEntrega, tipoPedido, nomeCliente, telefoneCliente, enderecoCliente, itensPedido, formaPagamento, observacoes, dataPedido) values (@dataEntrega, @horaEntrega, @tipoPedido, @nomeCliente, @telefoneCliente, @enderecoCliente, @itensPedido, @formaPagamento, @observacoes, @dataPedido)", CONEXAO);
                INSERT.Parameters.AddWithValue("@dataEntrega", pedido.DataEntrega);
                INSERT.Parameters.AddWithValue("@horaEntrega", pedido.HoraEntrega);
                INSERT.Parameters.AddWithValue("@tipoPedido", pedido.TipoPedido);
                INSERT.Parameters.AddWithValue("@nomeCliente", pedido.NomeCliente);
                INSERT.Parameters.AddWithValue("@telefoneCliente", pedido.TelefoneCliente);
                INSERT.Parameters.AddWithValue("@enderecoCliente", pedido.EnderecoCliente);
                INSERT.Parameters.AddWithValue("@itensPedido", pedido.ItensPedido);
                INSERT.Parameters.AddWithValue("@formaPagamento", pedido.FormaPagamento);
                INSERT.Parameters.AddWithValue("@observacoes", pedido.Observacoes);
                INSERT.Parameters.AddWithValue("@dataPedido", pedido.DataPedido);
                INSERT.ExecuteNonQuery();
                CONEXAO.Close();
                MessageBox.Show("Pedido Concluído com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

    }
}
