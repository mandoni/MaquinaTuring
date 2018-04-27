namespace Proyecto2_MaquinaTuring
{
    partial class MaquinaTuring
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cinta = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCadena = new System.Windows.Forms.TextBox();
            this.evalButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelMovimientos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentPictureMaquina = new System.Windows.Forms.PictureBox();
            this.maquinasBox = new System.Windows.Forms.ComboBox();
            this.outputLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cinta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentPictureMaquina)).BeginInit();
            this.SuspendLayout();
            // 
            // cinta
            // 
            this.cinta.AllowUserToAddRows = false;
            this.cinta.AllowUserToDeleteRows = false;
            this.cinta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cinta.Location = new System.Drawing.Point(24, 115);
            this.cinta.Name = "cinta";
            this.cinta.ReadOnly = true;
            this.cinta.Size = new System.Drawing.Size(548, 51);
            this.cinta.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese cadena a evaluar";
            // 
            // textBoxCadena
            // 
            this.textBoxCadena.Location = new System.Drawing.Point(157, 16);
            this.textBoxCadena.Name = "textBoxCadena";
            this.textBoxCadena.Size = new System.Drawing.Size(417, 20);
            this.textBoxCadena.TabIndex = 2;
            // 
            // evalButton
            // 
            this.evalButton.Location = new System.Drawing.Point(261, 69);
            this.evalButton.Name = "evalButton";
            this.evalButton.Size = new System.Drawing.Size(75, 23);
            this.evalButton.TabIndex = 8;
            this.evalButton.Text = "Evaluar";
            this.evalButton.UseVisualStyleBackColor = true;
            this.evalButton.Click += new System.EventHandler(this.evalButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Estado actual";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(282, 183);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(13, 13);
            this.labelEstado.TabIndex = 10;
            this.labelEstado.Text = "--";
            // 
            // labelMovimientos
            // 
            this.labelMovimientos.AutoSize = true;
            this.labelMovimientos.Location = new System.Drawing.Point(304, 183);
            this.labelMovimientos.Name = "labelMovimientos";
            this.labelMovimientos.Size = new System.Drawing.Size(13, 13);
            this.labelMovimientos.TabIndex = 11;
            this.labelMovimientos.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pasos realizados";
            // 
            // currentPictureMaquina
            // 
            this.currentPictureMaquina.Location = new System.Drawing.Point(28, 214);
            this.currentPictureMaquina.Name = "currentPictureMaquina";
            this.currentPictureMaquina.Size = new System.Drawing.Size(541, 276);
            this.currentPictureMaquina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.currentPictureMaquina.TabIndex = 13;
            this.currentPictureMaquina.TabStop = false;
            // 
            // maquinasBox
            // 
            this.maquinasBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maquinasBox.FormattingEnabled = true;
            this.maquinasBox.Items.AddRange(new object[] {
            "Reconocedor de cadenas palíndromas",
            "Copia de patrones",
            "Multiplicación código unario",
            "Suma código unario",
            "Resta código unario "});
            this.maquinasBox.Location = new System.Drawing.Point(178, 42);
            this.maquinasBox.Name = "maquinasBox";
            this.maquinasBox.Size = new System.Drawing.Size(241, 21);
            this.maquinasBox.TabIndex = 15;
            this.maquinasBox.SelectedIndexChanged += new System.EventHandler(this.maquinasBox_SelectedIndexChanged);
            // 
            // outputLable
            // 
            this.outputLable.AutoSize = true;
            this.outputLable.Location = new System.Drawing.Point(175, 92);
            this.outputLable.Name = "outputLable";
            this.outputLable.Size = new System.Drawing.Size(0, 13);
            this.outputLable.TabIndex = 16;
            // 
            // MaquinaTuring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 492);
            this.Controls.Add(this.outputLable);
            this.Controls.Add(this.maquinasBox);
            this.Controls.Add(this.currentPictureMaquina);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelMovimientos);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.evalButton);
            this.Controls.Add(this.textBoxCadena);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cinta);
            this.Name = "MaquinaTuring";
            this.Text = "Máquina de Turing";
            ((System.ComponentModel.ISupportInitialize)(this.cinta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentPictureMaquina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView cinta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCadena;
        private System.Windows.Forms.Button evalButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label labelMovimientos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox currentPictureMaquina;
        private System.Windows.Forms.ComboBox maquinasBox;
        private System.Windows.Forms.Label outputLable;
    }
}

