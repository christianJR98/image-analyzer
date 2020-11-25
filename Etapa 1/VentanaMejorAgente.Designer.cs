/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 07/03/2019
 * Time: 08:30 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Etapa_1
{
	partial class VentanaMejorAgente
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.TextBox textBoxDistancia;
		private System.Windows.Forms.TextBox textBoxCantidadVertices;
		private System.Windows.Forms.ListBox listBoxCamino;
		private System.Windows.Forms.Button buttonSalir;
		private System.Windows.Forms.Label labelId;
		private System.Windows.Forms.Label labelDistancia;
		private System.Windows.Forms.Label labelCantVertices;
		private System.Windows.Forms.Label labelCamino;
		private System.Windows.Forms.Label labelAgentes;
		private System.Windows.Forms.ListBox listBoxAgentes;
		private System.Windows.Forms.Button buttonMostrarMejorAgente;
		private System.Windows.Forms.Button buttonMostrarAgente;
		
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
			this.labelAgentes = new System.Windows.Forms.Label();
			this.listBoxAgentes = new System.Windows.Forms.ListBox();
			this.buttonMostrarMejorAgente = new System.Windows.Forms.Button();
			this.buttonMostrarAgente = new System.Windows.Forms.Button();
			this.labelCamino = new System.Windows.Forms.Label();
			this.labelCantVertices = new System.Windows.Forms.Label();
			this.labelDistancia = new System.Windows.Forms.Label();
			this.labelId = new System.Windows.Forms.Label();
			this.buttonSalir = new System.Windows.Forms.Button();
			this.listBoxCamino = new System.Windows.Forms.ListBox();
			this.textBoxCantidadVertices = new System.Windows.Forms.TextBox();
			this.textBoxDistancia = new System.Windows.Forms.TextBox();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// labelAgentes
			// 
			this.labelAgentes.Location = new System.Drawing.Point(498, 14);
			this.labelAgentes.Name = "labelAgentes";
			this.labelAgentes.Size = new System.Drawing.Size(131, 23);
			this.labelAgentes.TabIndex = 25;
			this.labelAgentes.Text = "Agentes";
			// 
			// listBoxAgentes
			// 
			this.listBoxAgentes.FormattingEnabled = true;
			this.listBoxAgentes.ItemHeight = 16;
			this.listBoxAgentes.Location = new System.Drawing.Point(498, 40);
			this.listBoxAgentes.Name = "listBoxAgentes";
			this.listBoxAgentes.Size = new System.Drawing.Size(674, 388);
			this.listBoxAgentes.TabIndex = 24;
			// 
			// buttonMostrarMejorAgente
			// 
			this.buttonMostrarMejorAgente.Enabled = false;
			this.buttonMostrarMejorAgente.Location = new System.Drawing.Point(174, 200);
			this.buttonMostrarMejorAgente.Name = "buttonMostrarMejorAgente";
			this.buttonMostrarMejorAgente.Size = new System.Drawing.Size(112, 54);
			this.buttonMostrarMejorAgente.TabIndex = 23;
			this.buttonMostrarMejorAgente.Text = "Mostrar Mejor Agente";
			this.buttonMostrarMejorAgente.UseVisualStyleBackColor = true;
			this.buttonMostrarMejorAgente.Click += new System.EventHandler(this.ButtonMostrarMejorAgenteClick);
			// 
			// buttonMostrarAgente
			// 
			this.buttonMostrarAgente.Enabled = false;
			this.buttonMostrarAgente.Location = new System.Drawing.Point(30, 200);
			this.buttonMostrarAgente.Name = "buttonMostrarAgente";
			this.buttonMostrarAgente.Size = new System.Drawing.Size(138, 54);
			this.buttonMostrarAgente.TabIndex = 22;
			this.buttonMostrarAgente.Text = "Mostrar Agente";
			this.buttonMostrarAgente.UseVisualStyleBackColor = true;
			this.buttonMostrarAgente.Click += new System.EventHandler(this.ButtonMostrarAgenteClick);
			// 
			// labelCamino
			// 
			this.labelCamino.Location = new System.Drawing.Point(251, 14);
			this.labelCamino.Name = "labelCamino";
			this.labelCamino.Size = new System.Drawing.Size(131, 23);
			this.labelCamino.TabIndex = 21;
			this.labelCamino.Text = "Camino Aristas";
			// 
			// labelCantVertices
			// 
			this.labelCantVertices.Location = new System.Drawing.Point(17, 124);
			this.labelCantVertices.Name = "labelCantVertices";
			this.labelCantVertices.Size = new System.Drawing.Size(69, 23);
			this.labelCantVertices.TabIndex = 20;
			this.labelCantVertices.Text = "Vertices";
			// 
			// labelDistancia
			// 
			this.labelDistancia.Location = new System.Drawing.Point(17, 84);
			this.labelDistancia.Name = "labelDistancia";
			this.labelDistancia.Size = new System.Drawing.Size(69, 23);
			this.labelDistancia.TabIndex = 19;
			this.labelDistancia.Text = "Distancia";
			// 
			// labelId
			// 
			this.labelId.Location = new System.Drawing.Point(18, 39);
			this.labelId.Name = "labelId";
			this.labelId.Size = new System.Drawing.Size(69, 23);
			this.labelId.TabIndex = 18;
			this.labelId.Text = "Id";
			// 
			// buttonSalir
			// 
			this.buttonSalir.Location = new System.Drawing.Point(292, 200);
			this.buttonSalir.Name = "buttonSalir";
			this.buttonSalir.Size = new System.Drawing.Size(128, 54);
			this.buttonSalir.TabIndex = 17;
			this.buttonSalir.Text = "Salir";
			this.buttonSalir.UseVisualStyleBackColor = true;
			this.buttonSalir.Click += new System.EventHandler(this.ButtonSalirClick);
			// 
			// listBoxCamino
			// 
			this.listBoxCamino.FormattingEnabled = true;
			this.listBoxCamino.ItemHeight = 16;
			this.listBoxCamino.Location = new System.Drawing.Point(251, 40);
			this.listBoxCamino.Name = "listBoxCamino";
			this.listBoxCamino.Size = new System.Drawing.Size(232, 116);
			this.listBoxCamino.TabIndex = 16;
			// 
			// textBoxCantidadVertices
			// 
			this.textBoxCantidadVertices.Location = new System.Drawing.Point(93, 125);
			this.textBoxCantidadVertices.Name = "textBoxCantidadVertices";
			this.textBoxCantidadVertices.ReadOnly = true;
			this.textBoxCantidadVertices.Size = new System.Drawing.Size(132, 22);
			this.textBoxCantidadVertices.TabIndex = 15;
			// 
			// textBoxDistancia
			// 
			this.textBoxDistancia.Location = new System.Drawing.Point(93, 85);
			this.textBoxDistancia.Name = "textBoxDistancia";
			this.textBoxDistancia.ReadOnly = true;
			this.textBoxDistancia.Size = new System.Drawing.Size(132, 22);
			this.textBoxDistancia.TabIndex = 14;
			// 
			// textBoxId
			// 
			this.textBoxId.Enabled = false;
			this.textBoxId.Location = new System.Drawing.Point(93, 40);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.Size = new System.Drawing.Size(132, 22);
			this.textBoxId.TabIndex = 13;
			// 
			// VentanaMejorAgente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1197, 596);
			this.Controls.Add(this.labelAgentes);
			this.Controls.Add(this.listBoxAgentes);
			this.Controls.Add(this.buttonMostrarMejorAgente);
			this.Controls.Add(this.buttonMostrarAgente);
			this.Controls.Add(this.labelCamino);
			this.Controls.Add(this.labelCantVertices);
			this.Controls.Add(this.labelDistancia);
			this.Controls.Add(this.labelId);
			this.Controls.Add(this.buttonSalir);
			this.Controls.Add(this.listBoxCamino);
			this.Controls.Add(this.textBoxCantidadVertices);
			this.Controls.Add(this.textBoxDistancia);
			this.Controls.Add(this.textBoxId);
			this.Name = "VentanaMejorAgente";
			this.Text = "VentanaMejorAgente";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
