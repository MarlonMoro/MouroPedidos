using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouroPedidos
{
    public partial class Form2 : Form
    {
        List<pedidoModel> pedidos;
        pedidoDAO pedidoDAO = new pedidoDAO();

       
        private ListViewItem item;
        Form1 instanciaFrm1;

        public Form2(Form1 frm1)
        {
            InitializeComponent();
            instanciaFrm1 = frm1;
            listVPedido.View = View.Details;
            listVPedido.FullRowSelect = true;
            listVPedido.GridLines = true;

           
            listVPedido.Columns.Add("Cliente", 100);
            listVPedido.Columns.Add("Data Entrega", 100);
            listVPedido.Columns.Add("Endereço", 175);
            listVPedido.Columns.Add("Pedido nº");

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            
            limpaLista();

            pedidos = pedidoDAO.ListaPedidoCliente(txtBusca.Text);
            carregaLista();

        }

        private void carregaLista()
        {
            
            int total = pedidos.Count;
            int i = 0;
            while (i < total)
            {
                item = new ListViewItem();

                item.Text = pedidos[i].NomeCliente.ToString();
                item.SubItems.Add(pedidos[i].DataEntrega.ToString());
                item.SubItems.Add(pedidos[i].EnderecoCliente.ToString());
                item.SubItems.Add(pedidos[i].NumPedido.ToString());

               

                listVPedido.Items.Add(item);
               
                i++;
            }
        }

        private void limpaLista()
        {
            listVPedido.Items.Clear();
        }

        
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            pedidoModel pedido = new pedidoModel();

            ListView.SelectedListViewItemCollection itemsLista = this.listVPedido.SelectedItems;
            instanciaFrm1.Retorno = int.Parse(itemsLista[0].SubItems[3].Text);
            instanciaFrm1.carregaPedido();
            this.Dispose();
        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
            {
                limpaLista();

                pedidos = pedidoDAO.ListaPedidoCliente(txtBusca.Text);
                carregaLista();
            }
        }

        
    }
}
