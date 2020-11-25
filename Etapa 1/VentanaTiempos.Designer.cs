/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 21/02/2019
 * Time: 09:09 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Etapa_1
{
	partial class VentanaTiempos
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label labelComparacionTiempo;
		private System.Windows.Forms.Label labelFuerzaBruta;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label labelDivideVenceras;
		private System.Windows.Forms.TextBox textBoxDivideVenceras;
		
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
			this.labelComparacionTiempo = new System.Windows.Forms.Label();
			this.labelFuerzaBruta = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.labelDivideVenceras = new System.Windows.Forms.Label();
			this.textBoxDivideVenceras = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// labelComparacionTiempo
			// 
			this.labelComparacionTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelComparacionTiempo.Location = new System.Drawing.Point(12, 9);
			this.labelComparacionTiempo.Name = "labelComparacionTiempo";
			this.labelComparacionTiempo.Size = new System.Drawing.Size(543, 45);
			this.labelComparacionTiempo.TabIndex = 0;
			this.labelComparacionTiempo.Text = "Comparacion tiempo(Milisegundos)";
			// 
			// labelFuerzaBruta
			// 
			this.labelFuerzaBruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFuerzaBruta.Location = new System.Drawing.Point(12, 67);
			this.labelFuerzaBruta.Name = "labelFuerzaBruta";
			this.labelFuerzaBruta.Size = new System.Drawing.Size(174, 35);
			this.labelFuerzaBruta.TabIndex = 1;
			this.labelFuerzaBruta.Text = "Fuerza Bruta";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(12, 105);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(150, 30);
			this.textBox1.TabIndex = 2;
			// 
			// labelDivideVenceras
			// 
			this.labelDivideVenceras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDivideVenceras.Location = new System.Drawing.Point(267, 67);
			this.labelDivideVenceras.Name = "labelDivideVenceras";
			this.labelDivideVenceras.Size = new System.Drawing.Size(174, 35);
			this.labelDivideVenceras.TabIndex = 3;
			this.labelDivideVenceras.Text = "Divide y venceras";
			// 
			// textBoxDivideVenceras
			// 
			this.textBoxDivideVenceras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxDivideVenceras.Location = new System.Drawing.Point(267, 105);
			this.textBoxDivideVenceras.Name = "textBoxDivideVenceras";
			this.textBoxDivideVenceras.ReadOnly = true;
			this.textBoxDivideVenceras.Size = new System.Drawing.Size(179, 30);
			this.textBoxDivideVenceras.TabIndex = 4;
			// 
			// VentanaTiempos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 254);
			this.Controls.Add(this.textBoxDivideVenceras);
			this.Controls.Add(this.labelDivideVenceras);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.labelFuerzaBruta);
			this.Controls.Add(this.labelComparacionTiempo);
			this.Name = "VentanaTiempos";
			this.Text = "VentanaTiempos";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
