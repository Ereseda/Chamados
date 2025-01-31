using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chamado_Pira
{
    public partial class FrmCampos : Form
    {
        public FrmCampos()
        {
            InitializeComponent();
        }

        private void FrmCampos_Load(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=aberturaChamados;Data Source=DESKTOP-66U68E4\\SQLEXPRESS\r\n");
            sql.Open();
            SqlCommand cmd = new SqlCommand("SELECT id, Codigo, Produto,  Data,  Marca, Serie,  Loja, Usuario, MotoristaLevou, MotoristaTrouxe,  Motivo, Retorno, AbrirChamado, fecharChamado FROM aberturaChamados_1 WHERE Loja= 'CAMPOS' ORDER BY id DESC ", sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        #region Busca de dados  do datagridview para  form individual

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmCamposDem frmCamposDem = new FrmCamposDem();
            frmCamposDem.txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frmCamposDem.txtCodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frmCamposDem.txtProduto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frmCamposDem.txtData.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frmCamposDem.txtMarca.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frmCamposDem.txtSerie.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frmCamposDem.txtLoja.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frmCamposDem.txtUsuario.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            frmCamposDem .txtMotoristaLevou.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            frmCamposDem.txtMotoristaTrouxe.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            frmCamposDem.txtMotivo.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            frmCamposDem.txtRetorno.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            frmCamposDem.txtAbrirChamado.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            frmCamposDem.txtFecharChamado.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            frmCamposDem.ShowDialog();
        }
        #endregion

    }
}
