using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chamado_Pira
{
    public partial class FrmAberturaChamadoLoja : Form
    {
        public FrmAberturaChamadoLoja()
        {
            InitializeComponent();
        }

        private void LblUsuario_Click(object sender, EventArgs e)
        {

        }
        #region Salvar Abertura de chamado
                private void BtnSalvar_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=aberturaChamados;Data Source=DESKTOP-66U68E4\\SQLEXPRESS");
            SqlCommand cmd = new SqlCommand("UPDATE aberturaChamados_1 SET Codigo=@Codigo, Produto=@Produto, Data=@Data, Marca=@Marca, Serie=@Serie, Loja=@Loja, Usuario=@Usuario, MotoristaLevou=@MotoristaLevou,  Motivo=@Motivo, Retorno=@Retorno, AbrirChamado=@AbrirChamado, fecharChamado=@fecharChamado  WHERE Codigo=@Codigo", sql);

            cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = txtCodigo.Text;
            cmd.Parameters.Add("@Produto", SqlDbType.VarChar).Value = txtProduto.Text;
            cmd.Parameters.Add("@Data", SqlDbType.VarChar).Value = txtData.Text;
            cmd.Parameters.Add("@Marca", SqlDbType.VarChar).Value = txtMarca.Text;
            cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = txtSerie.Text;
            cmd.Parameters.Add("@Loja", SqlDbType.VarChar).Value = cmbLoja.Text;
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = txtUsuario.Text;
            cmd.Parameters.Add("@MotoristaLevou", SqlDbType.VarChar).Value = txtLevou.Text;
            //cmd.Parameters.Add("@MotoristaTrouxe", SqlDbType.VarChar).Value = txttrouxe.Text;
            cmd.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = txtMotivo.Text;
            cmd.Parameters.Add("@Retorno", SqlDbType.VarChar).Value = txtRetorno.Text;
            cmd.Parameters.Add("@AbrirChamado", SqlDbType.VarChar).Value = txtAbrir.Text;
            cmd.Parameters.Add("@FecharChamado", SqlDbType.VarChar).Value = txtClose.Text;

            if (txtCodigo.Text != "" & txtProduto.Text != "" & txtData.Text != "" & txtMarca.Text != "" & txtSerie.Text != "" & cmbLoja.Text != "" & txtUsuario.Text != "" & txtLevou.Text != "" & txttrouxe.Text != "" & txtMotivo.Text != "" & txtRetorno.Text != "" & txtAbrir.Text !="" & txtClose.Text!="")
            {
                try
                {
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Atualização Realizada com Sucesso!!!");
                    txtCodigo.Text = "";
                    txtProduto.Text = "";
                    txtData.Text = "";
                    txtMarca.Text = "";
                    txtSerie.Text = "";
                    cmbLoja.Text = "";
                    txtUsuario.Text = "";
                    txtLevou.Text = "";
                    txttrouxe.Text = "";
                    txtMotivo.Text = "";
                    txtRetorno.Text = "";
                    txtAbrir.Text = "";
                    txtClose.Text = "";
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
                MessageBox.Show("Por favor digite todas  as informações");
            }




        }



        #endregion

        #region Pesquisar Chamados
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=aberturaChamados;Data Source=DESKTOP-66U68E4\\SQLEXPRESS\r\n");
            SqlCommand cmd = new SqlCommand("SELECT * FROM aberturaChamados_1 WHERE Codigo=@Codigo", sql);
            cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = txtCodigo.Text;

            try
            {
                sql.Open();
                SqlDataReader drms = cmd.ExecuteReader();
                if (drms.HasRows == false)
                {
                    throw new Exception("Chamado não encontrado");
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
               txtLevou.Text = Convert.ToString(drms["MotoristaLevou"]);
               txttrouxe.Text = Convert.ToString(drms["MotoristaTrouxe"]);
               txtMotivo.Text = Convert.ToString(drms["Motivo"]);
                txtRetorno.Text = Convert.ToString(drms["Retorno"]);
                txtClose.Text = Convert.ToString(drms["fecharChamado"]);
               txtAbrir.Text = Convert.ToString(drms["AbrirChamado"]);
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
