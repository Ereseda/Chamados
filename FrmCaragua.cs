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
    public partial class FrmCaragua : Form
    {
        public FrmCaragua()
        {
            InitializeComponent();
        }

        private void FrmCaragua_Load(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=aberturaChamados;Data Source=DESKTOP-66U68E4\\SQLEXPRESS\r\n");
            sql.Open();
            SqlCommand cmd = new SqlCommand("SELECT id, Codigo, Produto,  Data,  Marca, Serie,  Loja, Usuario, MotoristaLevou, MotoristaTrouxe,  Motivo, Retorno, AbrirChamado, fecharChamado FROM aberturaChamados_1 WHERE Loja= 'CARAGUA'  ORDER BY id DESC", sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmCaraguaDem frmCaraguaDem = new FrmCaraguaDem();
            frmCaraguaDem.txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frmCaraguaDem.txtCodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frmCaraguaDem.txtProduto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frmCaraguaDem.txtData.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frmCaraguaDem.txtMarca.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frmCaraguaDem.txtSerie.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frmCaraguaDem.txtLoja.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frmCaraguaDem.txtUsuario.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            frmCaraguaDem.txtMotoristaLevou.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            frmCaraguaDem.txtMotoristaTrouxe.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            frmCaraguaDem.txtMotivo.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            frmCaraguaDem.txtRetorno.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            frmCaraguaDem.txtAbrirChamado.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            frmCaraguaDem.txtFecharChamado.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            frmCaraguaDem.ShowDialog();
        }
    }
}
