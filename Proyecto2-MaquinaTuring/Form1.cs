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

        int machine, mov;

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
            mov = 0;
            outputLable.Text = "";
            labelEstado.Text = "q0";
            labelMovimientos.Text = "0";
            cinta.Rows.Clear();
            cinta.Columns.Clear();
            textBoxCadena.Enabled = maquinasBox.Enabled = evalButton.Enabled = false;
            
            if(textBoxCadena.Text.ToCharArray().Length == 0)
            {
                outputLable.Text = "La cadena no es suficientemente larga";
                goto Unblock;
            }

            AddColumns(textBoxCadena.Text.ToCharArray());

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

        private void Maquina1(char[] entrada)
        {
            int posicion = 1;
            string textoPosicion;

            cinta.Columns.Add("B", "B");
            cinta.Columns[cinta.Columns.Count - 1].Width = 20;
            cinta.Columns.Add("B", "B");
            cinta.Columns[cinta.Columns.Count - 1].Width = 20;

            ESTADOSM1:
            switch (labelEstado.Text)
            {
                case "q0":
                    goto E0M1;
                case "q1":
                    goto E1M1;
                case "q2":
                    goto E2M1;
                case "q3":
                    goto E3M1;
                case "q4":
                    goto E4M1;
                case "q5":
                    goto E5M1;
                case "q6":
                    goto E6M1;
                case "q7":
                    goto E7M1;
                case "q8":
                    goto E8M1;
                case "q9":
                    goto E9M1;
                case "q10":
                    outputLable.Text = "Cadena aceptada";
                    return;
            }

            E0M1:
            if (cinta.Columns[posicion].HeaderText == "a")
            {
                labelEstado.Text = "q1";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (cinta.Columns[posicion].HeaderText == "b")
            {
                labelEstado.Text = "q2";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (cinta.Columns[posicion].HeaderText == "c")
            {
                labelEstado.Text = "q3";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (cinta.Columns[posicion].HeaderText == "B")
            {
                labelEstado.Text = "q10";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E1M1:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c")
            {
                labelEstado.Text = "q1";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q4";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E2M1:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c")
            {
                labelEstado.Text = "q2";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q5";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E3M1:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c")
            {
                labelEstado.Text = "q3";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q6";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E4M1:
            if (cinta.Columns[posicion].HeaderText == "a")
            {
                labelEstado.Text = "q7";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (cinta.Columns[posicion].HeaderText == "B")
            {
                labelEstado.Text = "q7";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E5M1:
            if (cinta.Columns[posicion].HeaderText == "b")
            {
                labelEstado.Text = "q8";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (cinta.Columns[posicion].HeaderText == "B")
            {
                labelEstado.Text = "q8";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E6M1:
            if (cinta.Columns[posicion].HeaderText == "c")
            {
                labelEstado.Text = "q9";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (cinta.Columns[posicion].HeaderText == "B")
            {
                labelEstado.Text = "q9";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E7M1:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c")
            {
                labelEstado.Text = "q7";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q0";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E8M1:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c")
            {
                labelEstado.Text = "q8";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q0";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E9M1:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c")
            {
                labelEstado.Text = "q9";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q0";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;
        }

        private void Maquina2(char[] entrada)
        {
            int posicion = 1;
            string textoPosicion;

            ESTADOSM2:
            switch (labelEstado.Text)
            {
                case "q0":
                    goto E0M2;
                case "q1":
                    goto E1M2;
                case "q2":
                    goto E2M2;
                case "q3":
                    goto E3M2;
                case "q4":
                    goto E4M2;
                case "q5":
                    goto E5M2;
                case "q6":
                    goto E6M2;
                case "q7":
                    goto E7M2;
                case "q8":
                    goto E8M2;
                case "q9":
                    outputLable.Text = "Cadena aceptada";
                    return;
            }

            E0M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion== "a")
            {
                labelEstado.Text = "q1";
                cinta.Columns[posicion].HeaderText = "A";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "b")
            {
                labelEstado.Text = "q2";
                cinta.Columns[posicion].HeaderText = "O";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if(textoPosicion == "c")
            {
                labelEstado.Text = "q3";
                cinta.Columns[posicion].HeaderText = "C";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if(textoPosicion == "X" || textoPosicion == "Y" || textoPosicion == "Z")
            {
                labelEstado.Text = "q7";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E1M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c"
                || textoPosicion == "X" || textoPosicion == "Y" || textoPosicion == "Z")
            {
                labelEstado.Text = "q1";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q4";
                cinta.Columns[posicion].HeaderText = "X";
                cinta.Columns.Add("B", "B");
                cinta.Columns[posicion + 1].Width = 20;
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E2M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c"
                || textoPosicion == "X" || textoPosicion == "Y" || textoPosicion == "Z")
            {
                labelEstado.Text = "q2";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q5";
                cinta.Columns[posicion].HeaderText = "Y";
                cinta.Columns.Add("B", "B");
                cinta.Columns[posicion + 1].Width = 20;
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E3M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c"
                || textoPosicion == "X" || textoPosicion == "Y" || textoPosicion == "Z")
            {
                labelEstado.Text = "q3";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q6";
                cinta.Columns[posicion].HeaderText = "Z";
                cinta.Columns.Add("B", "B");
                cinta.Columns[posicion + 1].Width = 20;
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E4M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c"
                || textoPosicion == "X" || textoPosicion == "Y" || textoPosicion == "Z")
            {
                labelEstado.Text = "q4";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "A")
            {
                labelEstado.Text = "q0";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E5M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c"
                || textoPosicion == "X" || textoPosicion == "Y" || textoPosicion == "Z")
            {
                labelEstado.Text = "q5";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "O")
            {
                labelEstado.Text = "q0";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E6M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "a" || textoPosicion == "b" || textoPosicion == "c"
                || textoPosicion == "X" || textoPosicion == "Y" || textoPosicion == "Z")
            {
                labelEstado.Text = "q6";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "C")
            {
                labelEstado.Text = "q0";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E7M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "A" || textoPosicion == "O" || textoPosicion == "C")
            {
                labelEstado.Text = "q7";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q8";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E8M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "A")
            {
                labelEstado.Text = "q8";
                cinta.Columns[posicion].HeaderText = "a";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "O")
            {
                labelEstado.Text = "q8";
                cinta.Columns[posicion].HeaderText = "b";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "C")
            {
                labelEstado.Text = "q8";
                cinta.Columns[posicion].HeaderText = "c";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "X")
            {
                labelEstado.Text = "q8";
                cinta.Columns[posicion].HeaderText = "a";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "Y")
            {
                labelEstado.Text = "q8";
                cinta.Columns[posicion].HeaderText = "b";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "Z")
            {
                labelEstado.Text = "q8";
                cinta.Columns[posicion].HeaderText = "c";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q9";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;
        }

        private void Maquina3(char[] entrada)
        {
            int posicion = 1;
            string textoPosicion;

            ESTADOSM3:
            switch (labelEstado.Text)
            {
                case "q0":
                    goto E0M3;
                case "q1":
                    goto E1M3;
                case "q2":
                    goto E2M3;
                case "q3":
                    goto E3M3;
                case "q4":
                    goto E4M3;
                case "q5":
                    goto E5M3;
                case "q6":
                    goto E6M3;
                case "q7":
                    goto E7M3;
                case "q8":
                    goto E8M3;
                case "q9":
                    goto E9M3;
                case "q10":
                    goto E10M3;
                case "q11":
                    outputLable.Text = "Cadena aceptada";
                    return;
            }

            E0M3:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "I")
            {
                labelEstado.Text = "q0";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "*")
            {
                labelEstado.Text = "q1";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;

            E1M3:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "C")
            {
                labelEstado.Text = "q1";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if(textoPosicion == "=")
            {
                labelEstado.Text = "q10";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "I")
            {
                labelEstado.Text = "q2";
                cinta.Columns[posicion].HeaderText = "C";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;

            E2M3:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "C" || textoPosicion == "*" || textoPosicion == "I")
            {
                labelEstado.Text = "q2";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B" || textoPosicion == "X")
            {
                labelEstado.Text = "q3";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;

            E3M3:
            if (cinta.Columns[posicion].HeaderText == "I")
            {
                labelEstado.Text = "q4";
                cinta.Columns[posicion].HeaderText = "X";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;

            E4M3:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "C" || textoPosicion == "I" || textoPosicion == "*"
                || textoPosicion == "=")
            {
                labelEstado.Text = "q4";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q5";
                cinta.Columns[posicion].HeaderText = "I";
                cinta.Columns.Add("B", "B");
                cinta.Columns[posicion + 1].Width = 20;
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;

            E5M3:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "C" || textoPosicion == "I" || textoPosicion == "*"
                || textoPosicion == "=")
            {
                labelEstado.Text = "q5";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "X")
            {
                labelEstado.Text = "q6";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;

            E6M3:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "I")
            {
                labelEstado.Text = "q7";
                cinta.Columns[posicion].HeaderText = "X";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "*")
            {
                labelEstado.Text = "q9";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;

            E7M3:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "C" || textoPosicion == "I" || textoPosicion == "*"
                || textoPosicion == "=")
            {
                labelEstado.Text = "q7";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q8";
                cinta.Columns[posicion].HeaderText = "I";
                cinta.Columns.Add("B", "B");
                cinta.Columns[posicion + 1].Width = 20;
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;

            E8M3:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "C" || textoPosicion == "I" || textoPosicion == "*"
                || textoPosicion == "=")
            {
                labelEstado.Text = "q8";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "X")
            {
                labelEstado.Text = "q6";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;

            E9M3:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "X")
            {
                labelEstado.Text = "q9";
                cinta.Columns[posicion].HeaderText = "I";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q0";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;

            E10M3:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "C")
            {
                labelEstado.Text = "q10";
                cinta.Columns[posicion].HeaderText = "I";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "*")
            {
                labelEstado.Text = "q11";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM3;
        }

        private void Maquina4(char[] entrada)
        {
            int posicion = 1;
            string textoPosicion;

            ESTADOSM1:
            if (labelEstado.Text == "q0")
                goto E0M1;
            else if (labelEstado.Text == "q1")
                goto E1M1;
            else if (labelEstado.Text == "q2")
                goto E2M1;
            else if (labelEstado.Text == "q3")
            {
                outputLable.Text = "Cadena aceptada";
                return;
            }
            E0M1:
            if(cinta.Columns[posicion].HeaderText == "I")
            {
                labelEstado.Text = "q1";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (cinta.Columns[posicion].HeaderText == "+")
            {
                labelEstado.Text = "q0";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (cinta.Columns[posicion].HeaderText == "=")
            {
                labelEstado.Text = "q3";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E1M1:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "I" || textoPosicion == "+" || textoPosicion == "=")
            {
                labelEstado.Text = "q1";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q2";
                cinta.Columns[posicion].HeaderText = "I";
                cinta.Columns.Add("B", "B");
                cinta.Columns[posicion + 1].Width = 20;
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

            E2M1:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "I" || textoPosicion == "+" || textoPosicion == "=")
            {
                labelEstado.Text = "q2";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q0";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM1;

        }

        private void Maquina5(char[] entrada)
        {
            int posicion = 1;
            string textoPosicion;

            ESTADOSM2:
            switch (labelEstado.Text)
            {
                case "q0":
                    goto E0M2;
                case "q1":
                    goto E1M2;
                case "q2":
                    goto E2M2;
                case "q4":
                    goto E4M2;
                case "q5":
                    goto E5M2;
                case "q6":
                    goto E6M2;
                case "q7":
                    goto E7M2;
                case "q8":
                    outputLable.Text = "Cadena aceptada";
                return;
            }

            E0M2:
            if (cinta.Columns[posicion].HeaderText == "I")
            {
                labelEstado.Text = "q1";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (cinta.Columns[posicion].HeaderText == "-")
            {
                labelEstado.Text = "q4";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E1M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "I" || textoPosicion == "-" || textoPosicion == "=")
            {
                labelEstado.Text = "q1";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q2";
                cinta.Columns[posicion].HeaderText = "I";
                cinta.Columns.Add("B", "B");
                cinta.Columns[posicion + 1].Width = 20;
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E2M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "I" || textoPosicion == "-" || textoPosicion == "=")
            {
                labelEstado.Text = "q2";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q0";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;


            E4M2:
            if (cinta.Columns[posicion].HeaderText == "I")
            {
                labelEstado.Text = "q5";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (cinta.Columns[posicion].HeaderText == "=")
            {
                labelEstado.Text = "q8";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            goto ESTADOSM2;

            E5M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "I" || textoPosicion == "=")
            {
                labelEstado.Text = "q5";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q6";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E6M2:
            if (cinta.Columns[posicion].HeaderText == "I")
            {
                labelEstado.Text = "q7";
                cinta.Columns[posicion].HeaderText = "B";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;

            E7M2:
            textoPosicion = cinta.Columns[posicion].HeaderText;
            if (textoPosicion == "I" || textoPosicion == "=")
            {
                labelEstado.Text = "q7";
                cinta[posicion--, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else if (textoPosicion == "B")
            {
                labelEstado.Text = "q4";
                cinta[posicion++, 0].Style.BackColor = Color.White;
                cinta[posicion, 0].Style.BackColor = Color.Cyan;
                mov++;
                labelMovimientos.Text = mov.ToString();
                this.Refresh();
                Thread.Sleep(500);
            }
            else
            {
                outputLable.Text = "Cadena no válida";
                return;
            }
            goto ESTADOSM2;


        }

        private bool ABCs(string caracter)
        {
            if (!(caracter == "a" || caracter == "b" || caracter == "c"))
                return false;
            return true;
        }

        private bool Unario(string caracter, string op)
        {
            if (!(caracter == "I" || caracter == "=" || caracter == op))
                   return false;
            return true;
        }

        private void AddColumns(char[] entrada)
        {
            int j = 0;
            cinta.Columns.Add("B", "B");
            cinta.Columns[j++].Width = 20;
            for (int i = 0; i < entrada.Length; i++)
            {
                cinta.Columns.Add(entrada[i].ToString(), entrada[i].ToString());
                cinta.Columns[j++].Width = 20;
            }
            cinta.Columns.Add("B", "B");
            cinta.Columns[j++].Width = 20;

            cinta.Rows.Add();
            cinta[1, 0].Style.BackColor = Color.Cyan;

            Thread.Sleep(250);
        }
    }
}
