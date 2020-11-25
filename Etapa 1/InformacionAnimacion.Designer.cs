/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 30/04/2019
 * Time: 12:32 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Etapa_1
{
	partial class InformacionAnimacion
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label labelDepredadorId;
		private System.Windows.Forms.Label labelPresaId;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBoxCaminoDepredador;
		private System.Windows.Forms.ListBox listBoxCaminoPresa;
		private System.Windows.Forms.Label labelArista;
		private System.Windows.Forms.TextBox textBoxDepredadorId;
		private System.Windows.Forms.TextBox textBoxPresaId;
		private System.Windows.Forms.TextBox textBoxArista;
		
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
			this.labelDepredadorId = new System.Windows.Forms.Label();
			this.labelPresaId = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listBoxCaminoDepredador = new System.Windows.Forms.ListBox();
			this.listBoxCaminoPresa = new System.Windows.Forms.ListBox();
			this.labelArista = new System.Windows.Forms.Label();
			this.textBoxDepredadorId = new System.Windows.Forms.TextBox();
			this.textBoxPresaId = new System.Windows.Forms.TextBox();
			this.textBoxArista = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// labelDepredadorId
			// 
			this.labelDepredadorId.Location = new System.Drawing.Point(63, 56);
			this.labelDepredadorId.Name = "labelDepredadorId";
			this.labelDepredadorId.Size = new System.Drawing.Size(100, 23);
			this.labelDepredadorId.TabIndex = 0;
			this.labelDepredadorId.Text = "Depredador";
			// 
			// labelPresaId
			// 
			this.labelPresaId.Location = new System.Drawing.Point(63, 157);
			this.labelPresaId.Name = "labelPresaId";
			this.labelPresaId.Size = new System.Drawing.Size(100, 23);
			this.labelPresaId.TabIndex = 1;
			this.labelPresaId.Text = "Presa";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(356, 157);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Camino Presa";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(356, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 45);
			this.label2.TabIndex = 2;
			this.label2.Text = "Camino Depredador";
			// 
			// listBoxCaminoDepredador
			// 
			this.listBoxCaminoDepredador.FormattingEnabled = true;
			this.listBoxCaminoDepredador.ItemHeight = 16;
			this.listBoxCaminoDepredador.Location = new System.Drawing.Point(511, 56);
			this.listBoxCaminoDepredador.Name = "listBoxCaminoDepredador";
			this.listBoxCaminoDepredador.Size = new System.Drawing.Size(120, 84);
			this.listBoxCaminoDepredador.TabIndex = 4;
			// 
			// listBoxCaminoPresa
			// 
			this.listBoxCaminoPresa.FormattingEnabled = true;
			this.listBoxCaminoPresa.ItemHeight = 16;
			this.listBoxCaminoPresa.Location = new System.Drawing.Point(511, 157);
			this.listBoxCaminoPresa.Name = "listBoxCaminoPresa";
			this.listBoxCaminoPresa.Size = new System.Drawing.Size(120, 84);
			this.listBoxCaminoPresa.TabIndex = 5;
			// 
			// labelArista
			// 
			this.labelArista.Location = new System.Drawing.Point(705, 90);
			this.labelArista.Name = "labelArista";
			this.labelArista.Size = new System.Drawing.Size(100, 45);
			this.labelArista.TabIndex = 6;
			this.labelArista.Text = "Arista";
			// 
			// textBoxDepredadorId
			// 
			this.textBoxDepredadorId.Location = new System.Drawing.Point(169, 57);
			this.textBoxDepredadorId.Name = "textBoxDepredadorId";
			this.textBoxDepredadorId.Size = new System.Drawing.Size(100, 22);
			this.textBoxDepredadorId.TabIndex = 7;
			// 
			// textBoxPresaId
			// 
			this.textBoxPresaId.Location = new System.Drawing.Point(169, 158);
			this.textBoxPresaId.Name = "textBoxPresaId";
			this.textBoxPresaId.Size = new System.Drawing.Size(100, 22);
			this.textBoxPresaId.TabIndex = 8;
			// 
			// textBoxArista
			// 
			this.textBoxArista.Location = new System.Drawing.Point(705, 138);
			this.textBoxArista.Name = "textBoxArista";
			this.textBoxArista.Size = new System.Drawing.Size(100, 22);
			this.textBoxArista.TabIndex = 9;
			// 
			// InformacionAnimacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(889, 420);
			this.Controls.Add(this.textBoxArista);
			this.Controls.Add(this.textBoxPresaId);
			this.Controls.Add(this.textBoxDepredadorId);
			this.Controls.Add(this.labelArista);
			this.Controls.Add(this.listBoxCaminoPresa);
			this.Controls.Add(this.listBoxCaminoDepredador);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.labelPresaId);
			this.Controls.Add(this.labelDepredadorId);
			this.Name = "InformacionAnimacion";
			this.Text = "InformacionAnimacion";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
