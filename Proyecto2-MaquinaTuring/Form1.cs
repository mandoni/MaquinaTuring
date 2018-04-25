using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Proyecto2_MaquinaTuring
{
    public partial class MaquinaTuring : Form
    {
        public MaquinaTuring()
        {
            InitializeComponent();
        }

        int machine;

        private void maquinasBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            switch (maquinasBox.SelectedIndex)
            {
                case 0:
                    currentPictureMaquina.Image = Image.FromFile(path + @"\Máquina 1.png");
                    machine = 1;
                    break;
                case 1:
                    currentPictureMaquina.Image = Image.FromFile(path + @"\Máquina 2.png");
                    machine = 2;
                    break;
                case 2:
                    currentPictureMaquina.Image = Image.FromFile(path + @"\Máquina 3.png");
                    machine = 3;
                    break;
                case 3:
                    currentPictureMaquina.Image = Image.FromFile(path + @"\Máquina 4.png");
                    machine = 4;
                    break;
                case 4:
                    currentPictureMaquina.Image = Image.FromFile(path + @"\Máquina 5.png");
                    machine = 5;
                    break;
            }
        }

        private void evalButton_Click(object sender, EventArgs e)
        {
            outputLable.Text = "";
            labelEstado.Text = "q0";
            labelMovimientos.Text = "0";
            textBoxCadena.Enabled = maquinasBox.Enabled = evalButton.Enabled = false;
            
            if(textBoxCadena.Text.ToCharArray().Length == 0)
            {
                outputLable.Text = "La cadena no es suficientemente larga";
                goto Unblock;
            }

            switch (machine)
            {
                case 1:
                    Maquina1(textBoxCadena.Text.ToCharArray());
                    break;
                case 2:
                    Maquina2(textBoxCadena.Text.ToCharArray());
                    break;
                case 3:
                    Maquina3(textBoxCadena.Text.ToCharArray());
                    break;
                case 4:
                    Maquina4(textBoxCadena.Text.ToCharArray());
                    break;
                case 5:
                    Maquina5(textBoxCadena.Text.ToCharArray());
                    break;
                default:
                    outputLable.Text = "No seleccionó una máquina";
                    break;
            }

            Unblock: 
            textBoxCadena.Enabled = maquinasBox.Enabled = evalButton.Enabled = true;
        }

        //Comenzar con la máquina cuatro.

        private void Maquina1(char[] entrada)
        {
            if (!ABCs(entrada))
            {
                outputLable.Text = "La cadena ingresada no pertenece a lo símbolos de entrada";
                return;
            }

            AddColumns(entrada);
            int posicion = 0;
        }

        private void Maquina2(char[] entrada)
        {
            if (!ABCs(entrada))
            {
                outputLable.Text = "La cadena ingresada no pertenece a lo símbolos de entrada";
                return;
            }

            AddColumns(entrada);
            int posicion = 0;
        }

        private void Maquina3(char[] entrada)
        {
            if (!Unario(entrada, '*'))
            {
                outputLable.Text = "La cadena ingresada no pertenece a lo símbolos de entrada";
                return;
            }

            AddColumns(entrada);
            int posicion = 0;
        }

        private void Maquina4(char[] entrada)
        {
            if (!Unario(entrada, '+'))
            {
                outputLable.Text = "La cadena ingresada no pertenece a lo símbolos de entrada";
                return;
            }

            AddColumns(entrada);
            int posicion = 0;
        }

        private void Maquina5(char[] entrada)
        {
            if (!Unario(entrada, '-'))
            {
                outputLable.Text = "La cadena ingresada no pertenece a lo símbolos de entrada";
                return;
            }

            AddColumns(entrada);
            int posicion = 0;
        }

        private bool ABCs(char[] cadena)
        {
            for (int i = 0; i<cadena.Length; i++)
            {
                if (!(cadena[i] == 'a' || cadena[i] == 'b' || cadena[i] == 'c'))
                    return false;
            }
            return true;
        }

        private bool Unario(char[] cadena, char op)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                if (!(cadena[i] == 'I' || cadena[i] == '=' || cadena[i] == op))
                    return false;
            }
            return true;
        }

        private void AddColumns(char[] entrada)
        {
            cinta.Columns.Add("B", "B");
            for (int i = 0; i < entrada.Length; i++)
            {
                cinta.Columns.Add(entrada[i].ToString(), entrada[i].ToString());
            }

            for(int i = 0; i<500; i++)
            {
                cinta.Columns.Add("B", "B");
            }

            cinta.Rows.Add();
            cinta[1, 0].Style.BackColor = Color.Cyan;

            //Thread.Sleep(250);
        }
    }
}
