using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MouroPedidos
{
    public partial class Form1 : Form
    {
        String buscar = " ";
        String strPagamento = " ";
        String strPedido = "Inicio";

        int retorno;
        string Config = "server=10.1.1.186; userid=mouro; database=mouropedido";

        public int Retorno { get => retorno; set => retorno = value; }
        public string Config1 { get => Config; set => Config = value; }

        public Form1()
        {
            InitializeComponent();
            lblPagamento.Visible = false;
            txtPagamento.Visible = false;
            groupBox1.Text = DateTime.Today.ToString("dd/MM/yy");
            txtDataEntrega.Text = DateTime.Today.ToString();
            

        }

        private void SalvarPedido()
        {
            int tipoPedido = 0;
            DateTime dataPedido;
            dataPedido = DateTime.Now;
            pedidoModel novoPedido = new pedidoModel();

            int formaPagamento = 0;
            // 0 - Forma de pagamento Dinheiro
            // 1 - Forma de pagamento a Prazo (convenio)
            // 2 - Forma de pagamento Cartão

           
            if (checkBuscar.Checked)
            {
                tipoPedido = 1;
            }

            if (rbDinheiro.Checked)
            {
                formaPagamento = 0;
            }

            if (rbPrazo.Checked)
            {
                formaPagamento = 1;
            }

            if (rbCartao.Checked)
            {
                formaPagamento = 2;
            }
            
            pedidoDAO pedidoDAO = new pedidoDAO();

            novoPedido.NomeCliente = txtNome.Text;
            novoPedido.DataEntrega = txtDataEntrega.Text;
            novoPedido.HoraEntrega = txtHorario.Text;
            novoPedido.TelefoneCliente = txtTelefone.Text;
            novoPedido.EnderecoCliente = txtEndereco.Text;
            novoPedido.ItensPedido = txtItens.Text;
            novoPedido.Observacoes = txtObservacao.Text;
            novoPedido.FormaPagamento = formaPagamento;
            novoPedido.TipoPedido = tipoPedido;
            novoPedido.DataPedido = dataPedido;

            if (pedidoDAO.salvaPedido(novoPedido))
            {
                limpaCampos();
            }
            else
            {
                MessageBox.Show("O pedido não foi salvo no banco de dados!");
            }     
           
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDataEntrega.Focus();
           

        }

        private void rbDinheiro_CheckedChanged(object sender, EventArgs e)
        {
            lblPagamento.Text = "Troco para:";
            lblPagamento.Visible = true;
            txtPagamento.Visible = true;
        }

        private void rbPrazo_CheckedChanged(object sender, EventArgs e)
        {
            lblPagamento.Text = "Nome Cliente:";
            lblPagamento.Visible = true;
            txtPagamento.Visible = true;
        }

        private void rbCartao_CheckedChanged(object sender, EventArgs e)
        {
            lblPagamento.Text = "Qual bandeira:";
            lblPagamento.Visible = true;
            txtPagamento.Visible = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int copias = int.Parse(txtCopias.Text);

            for (int i = 1; i <= copias; i++)
            {
                using (var printDocument = new System.Drawing.Printing.PrintDocument())
                {
                    var printer = new System.Drawing.Printing.PrinterSettings();

                    printDocument.PrintPage += printDocument_PrintPage;
                    printDocument.PrinterSettings.PrinterName = printer.PrinterName;
                    printDocument.Print();
                }

            }

            SalvarPedido();

           
        }

        private String formaPedido()
        {
            
            if (checkBuscar.Checked)
            {
                buscar = "Vem retirar aqui.";
            }

            if (rbDinheiro.Checked)
            {
                strPagamento = "Dinheiro, troco para: " + txtPagamento.Text;
            }

            if (rbPrazo.Checked)
            {
                strPagamento = "Nota a prazo, para: " + txtPagamento.Text;
            }

            if (rbCartao.Checked)
            {
                strPagamento = "Cartao: " + txtPagamento.Text;
            }

            strPedido = "Data do pedido: " + DateTime.Today.ToString("dd/MM/yy") + Environment.NewLine +
                "Data para entrega: " + txtDataEntrega.Text + buscar + Environment.NewLine +
                " Horario: " + txtHorario.Text + Environment.NewLine +
                "Cliente: " + txtNome.Text + " Telefone: " + txtTelefone.Text + Environment.NewLine +
                "Endereco: " + txtEndereco.Text + Environment.NewLine +
                "Itens: " + Environment.NewLine +  txtItens.Text + Environment.NewLine +
                "Forma de pagamento: " + strPagamento + Environment.NewLine +
                "Observacoes: " + txtObservacao.Text;

              return strPedido;
        
        }

        private void limpaCampos()
        {
            txtDataEntrega.Text = DateTime.Today.ToString();
            checkBuscar.Checked = false;
            txtNome.Text = " ";
            txtHorario.Text = " ";
            txtTelefone.Text = " ";
            txtEndereco.Text = " ";
            txtItens.Text = " ";
            txtPagamento.Text = " ";
            txtObservacao.Text = " ";
            txtCopias.Text = "1";


        }


           

        void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var printDocument = sender as System.Drawing.Printing.PrintDocument;
            
            if(printDocument != null)
            {
                using (var font = new Font("Times New Roman", 12))
                using (var brush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(formaPedido(), font, brush, new RectangleF(0, 0, printDocument.DefaultPageSettings.PrintableArea.Width, printDocument.DefaultPageSettings.PrintableArea.Height));
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            
            limpaCampos();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 telaBusca = new Form2(this);
            telaBusca.Show();
        }

        public void carregaPedido()
        {
            pedidoModel pedidoSalvo = new pedidoModel();
            pedidoDAO pedidoDAO = new pedidoDAO();

            pedidoSalvo = pedidoDAO.buscaID(retorno);


            //preenche cmapos no formulario
            txtDataEntrega.Text = pedidoSalvo.DataEntrega.ToString();
            txtNome.Text = pedidoSalvo.NomeCliente.ToString();
            if (pedidoSalvo.TipoPedido == 1)
            {
                checkBuscar.Checked = true;
            }
            txtHorario.Text = pedidoSalvo.HoraEntrega.ToString();
            txtTelefone.Text = pedidoSalvo.TelefoneCliente.ToString();
            txtEndereco.Text = pedidoSalvo.EnderecoCliente.ToString();
            txtItens.Text = pedidoSalvo.ItensPedido.ToString();
            if(pedidoSalvo.FormaPagamento == 0)
            {
                rbDinheiro.Checked = true;
            }
            if(pedidoSalvo.FormaPagamento == 1)
            {
                rbPrazo.Checked = true;
            }
            if(pedidoSalvo.FormaPagamento == 2)
            {
                rbCartao.Checked = true;
            }
            txtObservacao.Text = pedidoSalvo.Observacoes.ToString();

        }
    }
}
