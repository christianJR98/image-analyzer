/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 15/05/2019
 * Time: 08:09 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Etapa_1
{
	partial class ComparacionPuntosMasCercanos
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label labelFuerzaBruta;
		private System.Windows.Forms.Label labelDivideYVenceras;
		private System.Windows.Forms.Button buttonIniciar;
		private System.Windows.Forms.Label labelTiempoFuerza;
		private System.Windows.Forms.Label labelPunto1Fuerza;
		private System.Windows.Forms.Label labelPunto2Fuerza;
		private System.Windows.Forms.Label labelDistanciaFuerza;
		private System.Windows.Forms.Button buttonSalir;
		private System.Windows.Forms.Label labelDistanciaDivide;
		private System.Windows.Forms.Label labelPunto2Divide;
		private System.Windows.Forms.Label labelPunto1Divide;
		private System.Windows.Forms.Label labelTiempoDivide;
		private System.Windows.Forms.TextBox textBoxTiempoFuerza;
		private System.Windows.Forms.TextBox textBoxPunto1Fuerza;
		private System.Windows.Forms.TextBox textBoxPunto2Fuerza;
		private System.Windows.Forms.TextBox textBoxDistanciaFuerza;
		private System.Windows.Forms.TextBox textBoxTiempoDivide;
		private System.Windows.Forms.TextBox textBoxPunto1Divide;
		private System.Windows.Forms.TextBox textBoxPunto2Divide;
		private System.Windows.Forms.TextBox textBoxDistanciaDivide;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.labelFuerzaBruta = new System.Windows.Forms.Label();
			this.labelDivideYVenceras = new System.Windows.Forms.Label();
			this.buttonIniciar = new System.Windows.Forms.Button();
			this.labelTiempoFuerza = new System.Windows.Forms.Label();
			this.labelPunto1Fuerza = new System.Windows.Forms.Label();
			this.labelPunto2Fuerza = new System.Windows.Forms.Label();
			this.labelDistanciaFuerza = new System.Windows.Forms.Label();
			this.buttonSalir = new System.Windows.Forms.Button();
			this.labelDistanciaDivide = new System.Windows.Forms.Label();
			this.labelPunto2Divide = new System.Windows.Forms.Label();
			this.labelPunto1Divide = new System.Windows.Forms.Label();
			this.labelTiempoDivide = new System.Windows.Forms.Label();
			this.textBoxTiempoFuerza = new System.Windows.Forms.TextBox();
			this.textBoxPunto1Fuerza = new System.Windows.Forms.TextBox();
			this.textBoxPunto2Fuerza = new System.Windows.Forms.TextBox();
			this.textBoxDistanciaFuerza = new System.Windows.Forms.TextBox();
			this.textBoxTiempoDivide = new System.Windows.Forms.TextBox();
			this.textBoxPunto1Divide = new System.Windows.Forms.TextBox();
			this.textBoxPunto2Divide = new System.Windows.Forms.TextBox();
			this.textBoxDistanciaDivide = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new System.Drawing.Point(28, 88);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(530, 368);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pictureBox2.Location = new System.Drawing.Point(593, 88);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(538, 368);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// labelFuerzaBruta
			// 
			this.labelFuerzaBruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFuerzaBruta.Location = new System.Drawing.Point(134, 31);
			this.labelFuerzaBruta.Name = "labelFuerzaBruta";
			this.labelFuerzaBruta.Size = new System.Drawing.Size(328, 54);
			this.labelFuerzaBruta.TabIndex = 2;
			this.labelFuerzaBruta.Text = "Fuerza Bruta";
			// 
			// labelDivideYVenceras
			// 
			this.labelDivideYVenceras.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDivideYVenceras.Location = new System.Drawing.Point(662, 31);
			this.labelDivideYVenceras.Name = "labelDivideYVenceras";
			this.labelDivideYVenceras.Size = new System.Drawing.Size(397, 54);
			this.labelDivideYVenceras.TabIndex = 3;
			this.labelDivideYVenceras.Text = "Divide y Venceras";
			// 
			// buttonIniciar
			// 
			this.buttonIniciar.Location = new System.Drawing.Point(508, 470);
			this.buttonIniciar.Name = "buttonIniciar";
			this.buttonIniciar.Size = new System.Drawing.Size(141, 57);
			this.buttonIniciar.TabIndex = 4;
			this.buttonIniciar.Text = "Iniciar";
			this.buttonIniciar.UseVisualStyleBackColor = true;
			this.buttonIniciar.Click += new System.EventHandler(this.ButtonIniciarClick);
			// 
			// labelTiempoFuerza
			// 
			this.labelTiempoFuerza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTiempoFuerza.Location = new System.Drawing.Point(93, 470);
			this.labelTiempoFuerza.Name = "labelTiempoFuerza";
			this.labelTiempoFuerza.Size = new System.Drawing.Size(92, 30);
			this.labelTiempoFuerza.TabIndex = 5;
			this.labelTiempoFuerza.Text = "Tiempo";
			// 
			// labelPunto1Fuerza
			// 
			this.labelPunto1Fuerza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPunto1Fuerza.Location = new System.Drawing.Point(93, 506);
			this.labelPunto1Fuerza.Name = "labelPunto1Fuerza";
			this.labelPunto1Fuerza.Size = new System.Drawing.Size(92, 30);
			this.labelPunto1Fuerza.TabIndex = 6;
			this.labelPunto1Fuerza.Text = "Punto1";
			// 
			// labelPunto2Fuerza
			// 
			this.labelPunto2Fuerza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPunto2Fuerza.Location = new System.Drawing.Point(93, 542);
			this.labelPunto2Fuerza.Name = "labelPunto2Fuerza";
			this.labelPunto2Fuerza.Size = new System.Drawing.Size(92, 30);
			this.labelPunto2Fuerza.TabIndex = 7;
			this.labelPunto2Fuerza.Text = "Punto2";
			// 
			// labelDistanciaFuerza
			// 
			this.labelDistanciaFuerza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDistanciaFuerza.Location = new System.Drawing.Point(91, 576);
			this.labelDistanciaFuerza.Name = "labelDistanciaFuerza";
			this.labelDistanciaFuerza.Size = new System.Drawing.Size(114, 30);
			this.labelDistanciaFuerza.TabIndex = 8;
			this.labelDistanciaFuerza.Text = "Distancia";
			// 
			// buttonSalir
			// 
			this.buttonSalir.Location = new System.Drawing.Point(508, 539);
			this.buttonSalir.Name = "buttonSalir";
			this.buttonSalir.Size = new System.Drawing.Size(141, 57);
			this.buttonSalir.TabIndex = 9;
			this.buttonSalir.Text = "Salir";
			this.buttonSalir.UseVisualStyleBackColor = true;
			this.buttonSalir.Click += new System.EventHandler(this.ButtonSalirClick);
			// 
			// labelDistanciaDivide
			// 
			this.labelDistanciaDivide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDistanciaDivide.Location = new System.Drawing.Point(759, 583);
			this.labelDistanciaDivide.Name = "labelDistanciaDivide";
			this.labelDistanciaDivide.Size = new System.Drawing.Size(106, 30);
			this.labelDistanciaDivide.TabIndex = 13;
			this.labelDistanciaDivide.Text = "Distancia";
			// 
			// labelPunto2Divide
			// 
			this.labelPunto2Divide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPunto2Divide.Location = new System.Drawing.Point(759, 549);
			this.labelPunto2Divide.Name = "labelPunto2Divide";
			this.labelPunto2Divide.Size = new System.Drawing.Size(92, 30);
			this.labelPunto2Divide.TabIndex = 12;
			this.labelPunto2Divide.Text = "Punto2";
			// 
			// labelPunto1Divide
			// 
			this.labelPunto1Divide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPunto1Divide.Location = new System.Drawing.Point(759, 513);
			this.labelPunto1Divide.Name = "labelPunto1Divide";
			this.labelPunto1Divide.Size = new System.Drawing.Size(92, 30);
			this.labelPunto1Divide.TabIndex = 11;
			this.labelPunto1Divide.Text = "Punto1";
			// 
			// labelTiempoDivide
			// 
			this.labelTiempoDivide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTiempoDivide.Location = new System.Drawing.Point(759, 483);
			this.labelTiempoDivide.Name = "labelTiempoDivide";
			this.labelTiempoDivide.Size = new System.Drawing.Size(92, 30);
			this.labelTiempoDivide.TabIndex = 10;
			this.labelTiempoDivide.Text = "Tiempo";
			// 
			// textBoxTiempoFuerza
			// 
			this.textBoxTiempoFuerza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxTiempoFuerza.Location = new System.Drawing.Point(211, 465);
			this.textBoxTiempoFuerza.Name = "textBoxTiempoFuerza";
			this.textBoxTiempoFuerza.ReadOnly = true;
			this.textBoxTiempoFuerza.Size = new System.Drawing.Size(169, 30);
			this.textBoxTiempoFuerza.TabIndex = 14;
			// 
			// textBoxPunto1Fuerza
			// 
			this.textBoxPunto1Fuerza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPunto1Fuerza.Location = new System.Drawing.Point(211, 503);
			this.textBoxPunto1Fuerza.Name = "textBoxPunto1Fuerza";
			this.textBoxPunto1Fuerza.ReadOnly = true;
			this.textBoxPunto1Fuerza.Size = new System.Drawing.Size(169, 30);
			this.textBoxPunto1Fuerza.TabIndex = 15;
			// 
			// textBoxPunto2Fuerza
			// 
			this.textBoxPunto2Fuerza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPunto2Fuerza.Location = new System.Drawing.Point(211, 539);
			this.textBoxPunto2Fuerza.Name = "textBoxPunto2Fuerza";
			this.textBoxPunto2Fuerza.ReadOnly = true;
			this.textBoxPunto2Fuerza.Size = new System.Drawing.Size(169, 30);
			this.textBoxPunto2Fuerza.TabIndex = 16;
			// 
			// textBoxDistanciaFuerza
			// 
			this.textBoxDistanciaFuerza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxDistanciaFuerza.Location = new System.Drawing.Point(211, 576);
			this.textBoxDistanciaFuerza.Name = "textBoxDistanciaFuerza";
			this.textBoxDistanciaFuerza.ReadOnly = true;
			this.textBoxDistanciaFuerza.Size = new System.Drawing.Size(169, 30);
			this.textBoxDistanciaFuerza.TabIndex = 17;
			// 
			// textBoxTiempoDivide
			// 
			this.textBoxTiempoDivide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxTiempoDivide.Location = new System.Drawing.Point(871, 474);
			this.textBoxTiempoDivide.Name = "textBoxTiempoDivide";
			this.textBoxTiempoDivide.ReadOnly = true;
			this.textBoxTiempoDivide.Size = new System.Drawing.Size(169, 30);
			this.textBoxTiempoDivide.TabIndex = 18;
			// 
			// textBoxPunto1Divide
			// 
			this.textBoxPunto1Divide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPunto1Divide.Location = new System.Drawing.Point(871, 510);
			this.textBoxPunto1Divide.Name = "textBoxPunto1Divide";
			this.textBoxPunto1Divide.ReadOnly = true;
			this.textBoxPunto1Divide.Size = new System.Drawing.Size(169, 30);
			this.textBoxPunto1Divide.TabIndex = 19;
			// 
			// textBoxPunto2Divide
			// 
			this.textBoxPunto2Divide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPunto2Divide.Location = new System.Drawing.Point(871, 546);
			this.textBoxPunto2Divide.Name = "textBoxPunto2Divide";
			this.textBoxPunto2Divide.ReadOnly = true;
			this.textBoxPunto2Divide.Size = new System.Drawing.Size(169, 30);
			this.textBoxPunto2Divide.TabIndex = 20;
			// 
			// textBoxDistanciaDivide
			// 
			this.textBoxDistanciaDivide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxDistanciaDivide.Location = new System.Drawing.Point(871, 580);
			this.textBoxDistanciaDivide.Name = "textBoxDistanciaDivide";
			this.textBoxDistanciaDivide.ReadOnly = true;
			this.textBoxDistanciaDivide.Size = new System.Drawing.Size(169, 30);
			this.textBoxDistanciaDivide.TabIndex = 21;
			// 
			// ComparacionPuntosMasCercanos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(1225, 627);
			this.Controls.Add(this.textBoxDistanciaDivide);
			this.Controls.Add(this.textBoxPunto2Divide);
			this.Controls.Add(this.textBoxPunto1Divide);
			this.Controls.Add(this.textBoxTiempoDivide);
			this.Controls.Add(this.textBoxDistanciaFuerza);
			this.Controls.Add(this.textBoxPunto2Fuerza);
			this.Controls.Add(this.textBoxPunto1Fuerza);
			this.Controls.Add(this.textBoxTiempoFuerza);
			this.Controls.Add(this.labelDistanciaDivide);
			this.Controls.Add(this.labelPunto2Divide);
			this.Controls.Add(this.labelPunto1Divide);
			this.Controls.Add(this.labelTiempoDivide);
			this.Controls.Add(this.buttonSalir);
			this.Controls.Add(this.labelDistanciaFuerza);
			this.Controls.Add(this.labelPunto2Fuerza);
			this.Controls.Add(this.labelPunto1Fuerza);
			this.Controls.Add(this.labelTiempoFuerza);
			this.Controls.Add(this.buttonIniciar);
			this.Controls.Add(this.labelDivideYVenceras);
			this.Controls.Add(this.labelFuerzaBruta);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Name = "ComparacionPuntosMasCercanos";
			this.Text = "ComparacionPuntosMasCercanos";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
