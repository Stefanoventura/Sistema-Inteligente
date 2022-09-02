using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIteligente
{
    public partial class Form1 : Form
    {
        double[,] x_VetoresTreinamento = new double[,] { { 1, 1, 1, 1, 1},
                                                 {-1, -1, -1, -1, 1},
                                                 {1, 1, 1, -1, 1},
                                                 {1, -1, -1, 1, 1},
                                                 {1, -1, 1, 1, 1},
                                                 {-1, -1, -1, 1, 1} };

        double[] Y_SaidaDesejada = new double[] { 1, -1, -1, 1, -1, 1 };
        double[] W_Pesos = new double[] { 0, 0, 0, 0, 0 };

        double Erro;
        double TaxaAprendizagem = 0.2;
        int Ciclos;

        public Form1()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void ButtonTreinar_Click(object sender, EventArgs e)
        {

            buttonTestar.Enabled = true;

            Ciclos = 0;
            bool TemErro = true;

            while (TemErro == true)
            {
                TemErro = false;

                for (int i = 0; i < 6; i++)
                {
                    double somatorio = 0;

                    double RespostaDaRede;
                    for (int j = 0; j < 5; j++)
                        somatorio += x_VetoresTreinamento[i, j] * W_Pesos[j];

                    if (somatorio >= 0)
                        RespostaDaRede = 1;
                    else RespostaDaRede = -1;

                    Erro = Y_SaidaDesejada[i] - RespostaDaRede;
                    if (Erro != 0)
                        TemErro = true;

                    for (int J = 0; J < 5; J++)
                    {
                        Double DeltaW = x_VetoresTreinamento[i, J] * Erro * TaxaAprendizagem;
                        W_Pesos[J] = W_Pesos[J] + DeltaW;
                    }
                }

                Ciclos++;
            }
            labelCiclos.Text = Convert.ToString(Ciclos);
            labelW1.Text = Convert.ToString(W_Pesos[0]);
            labelW2.Text = Convert.ToString(W_Pesos[1]);
            labelW3.Text = Convert.ToString(W_Pesos[2]);
            labelW4.Text = Convert.ToString(W_Pesos[3]);
            labelW5.Text = Convert.ToString(W_Pesos[4]);
        }

        private void GroupBoxTreinamento_Enter(object sender, EventArgs e)
        {

        }

        private void ButtonTestar_Click(object sender, EventArgs e)
        {
            double febre, enjoo, dores, manchas;

            if (checkBoxFebre.Checked)
                febre = 1;
            else febre = -1;

            if (checkBoxDores.Checked)
                dores = 1;
            else dores = -1;

            if (checkBoxEnjoo.Checked)
                enjoo = 1;
            else enjoo = -1;

            if (radioButtonPequenas.Checked)
                manchas = 1;
            else manchas = 1;

            double somatorio;
            somatorio = (W_Pesos[0] * febre) + (W_Pesos[1] * enjoo) + (W_Pesos[2] * manchas) + (W_Pesos[3] * dores) + (1 * W_Pesos[4]);

            if (somatorio >= 0)
                labelDiagnostico.Text = "Doente";
            else labelDiagnostico.Text = "Saudável";
        }
    }
}
