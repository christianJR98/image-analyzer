/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 04/06/2019
 * Time: 11:05 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Etapa_1
{
	partial class FloydDijkstra
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBoxDijkstra;
		private System.Windows.Forms.PictureBox pictureBoxFloyd;
		private System.Windows.Forms.ComboBox comboBoxInicio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		
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
			this.pictureBoxDijkstra = new System.Windows.Forms.PictureBox();
			this.pictureBoxFloyd = new System.Windows.Forms.PictureBox();
			this.comboBoxInicio = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDijkstra)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFloyd)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxDijkstra
			// 
			this.pictureBoxDijkstra.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pictureBoxDijkstra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxDijkstra.Location = new System.Drawing.Point(64, 109);
			this.pictureBoxDijkstra.Name = "pictureBoxDijkstra";
			this.pictureBoxDijkstra.Size = new System.Drawing.Size(526, 331);
			this.pictureBoxDijkstra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxDijkstra.TabIndex = 0;
			this.pictureBoxDijkstra.TabStop = false;
			// 
			// pictureBoxFloyd
			// 
			this.pictureBoxFloyd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pictureBoxFloyd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxFloyd.Location = new System.Drawing.Point(596, 109);
			this.pictureBoxFloyd.Name = "pictureBoxFloyd";
			this.pictureBoxFloyd.Size = new System.Drawing.Size(526, 331);
			this.pictureBoxFloyd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxFloyd.TabIndex = 1;
			this.pictureBoxFloyd.TabStop = false;
			// 
			// comboBoxInicio
			// 
			this.comboBoxInicio.FormattingEnabled = true;
			this.comboBoxInicio.Location = new System.Drawing.Point(524, 509);
			this.comboBoxInicio.Name = "comboBoxInicio";
			this.comboBoxInicio.Size = new System.Drawing.Size(138, 24);
			this.comboBoxInicio.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(545, 474);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Origen";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(197, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Dijkstra";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(788, 66);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Floyd";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(488, 565);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(208, 53);
			this.button1.TabIndex = 8;
			this.button1.Text = "Comparar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// FloydDijkstra
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1228, 656);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxInicio);
			this.Controls.Add(this.pictureBoxFloyd);
			this.Controls.Add(this.pictureBoxDijkstra);
			this.Name = "FloydDijkstra";
			this.Text = "FloydDijkstra";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDijkstra)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFloyd)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
