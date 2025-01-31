using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chamado_Pira
{
    public partial class FrmAberturaChamado : Form
    {
        public FrmAberturaChamado()
        {
            InitializeComponent();
        }

        #region Salvar Cadastro

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=aberturaChamados;Data Source=DESKTOP-66U68E4\\SQLEXPRESS");
            SqlCommand cmd = new SqlCommand("INSERT INTO aberturaChamados_1(Codigo, Produto, Data, Marca, Serie, Loja, Usuario, Motoristalevou, MotoristaTrouxe, Motivo, Retorno, AbrirChamado) Values(@Codigo, @Produto, @Data, @Marca, @Serie, @Loja, @Usuario, @MotoristaLevou, @MotoristaTrouxe, @Motivo, @Retorno, @AbrirChamado)", sql);

            cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = txtCodigo.Text;
            cmd.Parameters.Add("@Produto", SqlDbType.VarChar).Value = txtProduto.Text;
            cmd.Parameters.Add("@Data", SqlDbType.VarChar).Value = txtData.Text;
            cmd.Parameters.Add("@Marca", SqlDbType.VarChar).Value = txtMarca.Text;
            cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = txtSerie.Text;
            cmd.Parameters.Add("@Loja", SqlDbType.VarChar).Value = cmbLoja.Text;
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = txtUsuario.Text;
            cmd.Parameters.Add("@Motoristalevou", SqlDbType.VarChar).Value = txtMotoristaLevou.Text;
            cmd.Parameters.Add("@Motoristatrouxe", SqlDbType.VarChar).Value = txtMotoristaTrouxe.Text;
            cmd.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = txtMotivo.Text;
            cmd.Parameters.Add("@Retorno", SqlDbType.VarChar).Value = txtRetorno.Text;
            cmd.Parameters.Add("@AbrirChamado", SqlDbType.VarChar).Value = txtAbrirChamado.Text;

            if (txtCodigo.Text == "Codigo")
            {
                MessageBox.Show("ATENÇÃO! Este chamado já existe na base de Dados.");
            }
            else
            {
                if (txtCodigo.Text !="" & txtProduto.Text != "" & txtData.Text !="" & txtMarca.Text !="" & txtSerie.Text !="" & cmbLoja.Text !="" & txtUsuario.Text != "" & txtMotoristaLevou.Text != "" & txtMotoristaTrouxe.Text !="" & txtMotivo.Text !="" & txtRetorno.Text !="" & txtAbrirChamado.Text !="")
                {
                    try
                    {
                        sql.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Chamado Cadastrado.");
                        txtId.Text = "";
                        txtCodigo.Text = "";
                        txtProduto.Text = "";
                        txtData.Text = "";
                        txtMarca.Text = "";
                        txtSerie.Text = "";
                        cmbLoja.Text = "";
                        txtUsuario.Text = "";
                        txtMotoristaLevou.Text = "";
                        txtMotoristaTrouxe.Text = "";
                        txtAbrirChamado.Text = "";
                        txtMotivo.Text = "";
                        txtRetorno.Text = "";

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        sql.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Favor digitar todos os campos.");
                }
            }
           
        }

        #endregion


        #region Pesquisar


        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=aberturaChamados;Data Source=DESKTOP-66U68E4\\SQLEXPRESS\r\n");
            SqlCommand cmd = new SqlCommand("SELECT * FROM produtos WHERE Codigo=@Codigo",sql);
            cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = txtCodigo.Text;

            try
            {
                sql.Open();
                SqlDataReader drms = cmd.ExecuteReader();
                if (drms.HasRows == false)
                {
                    throw new Exception("Código não encontrado");
                }
                drms.Read();

                txtId.Text = Convert.ToString(drms["id"]);
                txtCodigo.Text = Convert.ToString(drms["Codigo"]);
                txtProduto.Text = Convert.ToString(drms["Produto"]);
                txtData.Text = Convert.ToString(drms["Data"]);
                txtMarca.Text = Convert.ToString(drms["Marca"]);
                txtSerie.Text = Convert.ToString(drms["Serie"]);
                cmbLoja.Text = Convert.ToString(drms["Loja"]);
                txtUsuario.Text = Convert.ToString(drms["Usuario"]);
                //txtMotoristaLevou.Text = Convert.ToString(drms[""]);
                //txtMotoristaTrouxe.Text = Convert.ToString(drms["MotoristaTrouxe"]);
               // txtMotivo.Text = Convert.ToString(drms["Motivo"]);
               // txtRetorno.Text = Convert.ToString(drms["Retorno"]);


            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql.Close();
            }
        }
        #endregion

    }
}
