/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 26/03/2019
 * Time: 09:19 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Etapa_1
{
	partial class VentanaEtapa4
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBoxDijkstra;
		private System.Windows.Forms.PictureBox pictureBoxPrim;
		private System.Windows.Forms.Label labelDijkstra;
		private System.Windows.Forms.Label labelPrim;
		private System.Windows.Forms.Label labelCantidadSubgrafosDijkstra;
		private System.Windows.Forms.Label labelCantidadSubgrafosPrim;
		private System.Windows.Forms.Label labelNumeroSubgrafosDijkstra;
		private System.Windows.Forms.Label labelNumeroSubgrafosPrim;
		private System.Windows.Forms.ListBox listBoxCaminoAgenteDijkstra;
		private System.Windows.Forms.ListBox listBoxCaminoAgentePrim;
		private System.Windows.Forms.Label labelPesoTotalDijkstra;
		private System.Windows.Forms.Label labelPesoTotalDijkstraNumero;
		private System.Windows.Forms.Label labelPesoTotalPrim;
		private System.Windows.Forms.Label labelPesoTotalPrimNumero;
		private System.Windows.Forms.Button buttonDijkstraArm;
		private System.Windows.Forms.Button buttonPrimArm;
		private System.Windows.Forms.Button buttonAnimarDijkstra;
		private System.Windows.Forms.Button buttonAnimarPrim;
		private System.Windows.Forms.ListBox listBoxArmDijkstra;
		private System.Windows.Forms.ListBox listBoxArmPrim;
		private System.Windows.Forms.Label labelArmDijkstra;
		private System.Windows.Forms.Label labelArmPrim;
		private System.Windows.Forms.Label labelRecorridoDijkstra;
		private System.Windows.Forms.Label labelRecorridoPrim;
		private System.Windows.Forms.ComboBox comboBoxKruskal;
		private System.Windows.Forms.ComboBox comboBoxPrim;
		
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
			this.pictureBoxPrim = new System.Windows.Forms.PictureBox();
			this.labelDijkstra = new System.Windows.Forms.Label();
			this.labelPrim = new System.Windows.Forms.Label();
			this.labelCantidadSubgrafosDijkstra = new System.Windows.Forms.Label();
			this.labelCantidadSubgrafosPrim = new System.Windows.Forms.Label();
			this.labelNumeroSubgrafosDijkstra = new System.Windows.Forms.Label();
			this.labelNumeroSubgrafosPrim = new System.Windows.Forms.Label();
			this.listBoxCaminoAgenteDijkstra = new System.Windows.Forms.ListBox();
			this.listBoxCaminoAgentePrim = new System.Windows.Forms.ListBox();
			this.labelPesoTotalDijkstra = new System.Windows.Forms.Label();
			this.labelPesoTotalDijkstraNumero = new System.Windows.Forms.Label();
			this.labelPesoTotalPrim = new System.Windows.Forms.Label();
			this.labelPesoTotalPrimNumero = new System.Windows.Forms.Label();
			this.buttonDijkstraArm = new System.Windows.Forms.Button();
			this.buttonPrimArm = new System.Windows.Forms.Button();
			this.buttonAnimarDijkstra = new System.Windows.Forms.Button();
			this.buttonAnimarPrim = new System.Windows.Forms.Button();
			this.listBoxArmDijkstra = new System.Windows.Forms.ListBox();
			this.listBoxArmPrim = new System.Windows.Forms.ListBox();
			this.labelArmDijkstra = new System.Windows.Forms.Label();
			this.labelArmPrim = new System.Windows.Forms.Label();
			this.labelRecorridoDijkstra = new System.Windows.Forms.Label();
			this.labelRecorridoPrim = new System.Windows.Forms.Label();
			this.comboBoxKruskal = new System.Windows.Forms.ComboBox();
			this.comboBoxPrim = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDijkstra)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrim)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxDijkstra
			// 
			this.pictureBoxDijkstra.BackColor = System.Drawing.SystemColors.ControlLight;
			this.pictureBoxDijkstra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxDijkstra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxDijkstra.Location = new System.Drawing.Point(48, 116);
			this.pictureBoxDijkstra.Name = "pictureBoxDijkstra";
			this.pictureBoxDijkstra.Size = new System.Drawing.Size(756, 455);
			this.pictureBoxDijkstra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxDijkstra.TabIndex = 0;
			this.pictureBoxDijkstra.TabStop = false;
			// 
			// pictureBoxPrim
			// 
			this.pictureBoxPrim.BackColor = System.Drawing.SystemColors.ControlLight;
			this.pictureBoxPrim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxPrim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPrim.Location = new System.Drawing.Point(855, 116);
			this.pictureBoxPrim.Name = "pictureBoxPrim";
			this.pictureBoxPrim.Size = new System.Drawing.Size(756, 455);
			this.pictureBoxPrim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPrim.TabIndex = 1;
			this.pictureBoxPrim.TabStop = false;
			// 
			// labelDijkstra
			// 
			this.labelDijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDijkstra.Location = new System.Drawing.Point(281, 43);
			this.labelDijkstra.Name = "labelDijkstra";
			this.labelDijkstra.Size = new System.Drawing.Size(186, 70);
			this.labelDijkstra.TabIndex = 2;
			this.labelDijkstra.Text = "Kruskal";
			// 
			// labelPrim
			// 
			this.labelPrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPrim.Location = new System.Drawing.Point(1065, 40);
			this.labelPrim.Name = "labelPrim";
			this.labelPrim.Size = new System.Drawing.Size(158, 61);
			this.labelPrim.TabIndex = 3;
			this.labelPrim.Text = "Prim";
			// 
			// labelCantidadSubgrafosDijkstra
			// 
			this.labelCantidadSubgrafosDijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCantidadSubgrafosDijkstra.Location = new System.Drawing.Point(48, 586);
			this.labelCantidadSubgrafosDijkstra.Name = "labelCantidadSubgrafosDijkstra";
			this.labelCantidadSubgrafosDijkstra.Size = new System.Drawing.Size(130, 69);
			this.labelCantidadSubgrafosDijkstra.TabIndex = 4;
			this.labelCantidadSubgrafosDijkstra.Text = "Cantidad subgrafos";
			// 
			// labelCantidadSubgrafosPrim
			// 
			this.labelCantidadSubgrafosPrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCantidadSubgrafosPrim.Location = new System.Drawing.Point(855, 590);
			this.labelCantidadSubgrafosPrim.Name = "labelCantidadSubgrafosPrim";
			this.labelCantidadSubgrafosPrim.Size = new System.Drawing.Size(142, 63);
			this.labelCantidadSubgrafosPrim.TabIndex = 5;
			this.labelCantidadSubgrafosPrim.Text = "Cantidad subgrafos";
			// 
			// labelNumeroSubgrafosDijkstra
			// 
			this.labelNumeroSubgrafosDijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNumeroSubgrafosDijkstra.Location = new System.Drawing.Point(57, 658);
			this.labelNumeroSubgrafosDijkstra.Name = "labelNumeroSubgrafosDijkstra";
			this.labelNumeroSubgrafosDijkstra.Size = new System.Drawing.Size(108, 44);
			this.labelNumeroSubgrafosDijkstra.TabIndex = 6;
			this.labelNumeroSubgrafosDijkstra.Text = "0";
			this.labelNumeroSubgrafosDijkstra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelNumeroSubgrafosPrim
			// 
			this.labelNumeroSubgrafosPrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNumeroSubgrafosPrim.Location = new System.Drawing.Point(855, 653);
			this.labelNumeroSubgrafosPrim.Name = "labelNumeroSubgrafosPrim";
			this.labelNumeroSubgrafosPrim.Size = new System.Drawing.Size(104, 43);
			this.labelNumeroSubgrafosPrim.TabIndex = 7;
			this.labelNumeroSubgrafosPrim.Text = "0";
			this.labelNumeroSubgrafosPrim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// listBoxCaminoAgenteDijkstra
			// 
			this.listBoxCaminoAgenteDijkstra.FormattingEnabled = true;
			this.listBoxCaminoAgenteDijkstra.ItemHeight = 16;
			this.listBoxCaminoAgenteDijkstra.Location = new System.Drawing.Point(446, 624);
			this.listBoxCaminoAgenteDijkstra.Name = "listBoxCaminoAgenteDijkstra";
			this.listBoxCaminoAgenteDijkstra.Size = new System.Drawing.Size(157, 116);
			this.listBoxCaminoAgenteDijkstra.TabIndex = 8;
			// 
			// listBoxCaminoAgentePrim
			// 
			this.listBoxCaminoAgentePrim.FormattingEnabled = true;
			this.listBoxCaminoAgentePrim.ItemHeight = 16;
			this.listBoxCaminoAgentePrim.Location = new System.Drawing.Point(1273, 624);
			this.listBoxCaminoAgentePrim.Name = "listBoxCaminoAgentePrim";
			this.listBoxCaminoAgentePrim.Size = new System.Drawing.Size(167, 116);
			this.listBoxCaminoAgentePrim.TabIndex = 9;
			// 
			// labelPesoTotalDijkstra
			// 
			this.labelPesoTotalDijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPesoTotalDijkstra.Location = new System.Drawing.Point(48, 707);
			this.labelPesoTotalDijkstra.Name = "labelPesoTotalDijkstra";
			this.labelPesoTotalDijkstra.Size = new System.Drawing.Size(142, 23);
			this.labelPesoTotalDijkstra.TabIndex = 10;
			this.labelPesoTotalDijkstra.Text = "Peso total";
			// 
			// labelPesoTotalDijkstraNumero
			// 
			this.labelPesoTotalDijkstraNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPesoTotalDijkstraNumero.Location = new System.Drawing.Point(48, 749);
			this.labelPesoTotalDijkstraNumero.Name = "labelPesoTotalDijkstraNumero";
			this.labelPesoTotalDijkstraNumero.Size = new System.Drawing.Size(200, 49);
			this.labelPesoTotalDijkstraNumero.TabIndex = 11;
			this.labelPesoTotalDijkstraNumero.Text = "0";
			this.labelPesoTotalDijkstraNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPesoTotalPrim
			// 
			this.labelPesoTotalPrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPesoTotalPrim.Location = new System.Drawing.Point(855, 700);
			this.labelPesoTotalPrim.Name = "labelPesoTotalPrim";
			this.labelPesoTotalPrim.Size = new System.Drawing.Size(142, 36);
			this.labelPesoTotalPrim.TabIndex = 12;
			this.labelPesoTotalPrim.Text = "Peso total";
			// 
			// labelPesoTotalPrimNumero
			// 
			this.labelPesoTotalPrimNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPesoTotalPrimNumero.Location = new System.Drawing.Point(855, 736);
			this.labelPesoTotalPrimNumero.Name = "labelPesoTotalPrimNumero";
			this.labelPesoTotalPrimNumero.Size = new System.Drawing.Size(187, 35);
			this.labelPesoTotalPrimNumero.TabIndex = 13;
			this.labelPesoTotalPrimNumero.Text = "0";
			this.labelPesoTotalPrimNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonDijkstraArm
			// 
			this.buttonDijkstraArm.Location = new System.Drawing.Point(234, 590);
			this.buttonDijkstraArm.Name = "buttonDijkstraArm";
			this.buttonDijkstraArm.Size = new System.Drawing.Size(155, 65);
			this.buttonDijkstraArm.TabIndex = 14;
			this.buttonDijkstraArm.Text = "Kruskal ARM";
			this.buttonDijkstraArm.UseVisualStyleBackColor = true;
			this.buttonDijkstraArm.Click += new System.EventHandler(this.ButtonDijkstraArmClick);
			// 
			// buttonPrimArm
			// 
			this.buttonPrimArm.Location = new System.Drawing.Point(1068, 590);
			this.buttonPrimArm.Name = "buttonPrimArm";
			this.buttonPrimArm.Size = new System.Drawing.Size(155, 65);
			this.buttonPrimArm.TabIndex = 15;
			this.buttonPrimArm.Text = "Prim ARM";
			this.buttonPrimArm.UseVisualStyleBackColor = true;
			this.buttonPrimArm.Click += new System.EventHandler(this.ButtonPrimArmClick);
			// 
			// buttonAnimarDijkstra
			// 
			this.buttonAnimarDijkstra.Location = new System.Drawing.Point(234, 677);
			this.buttonAnimarDijkstra.Name = "buttonAnimarDijkstra";
			this.buttonAnimarDijkstra.Size = new System.Drawing.Size(155, 63);
			this.buttonAnimarDijkstra.TabIndex = 16;
			this.buttonAnimarDijkstra.Text = "Iniciar animación";
			this.buttonAnimarDijkstra.UseVisualStyleBackColor = true;
			this.buttonAnimarDijkstra.Click += new System.EventHandler(this.ButtonAnimarDijkstraClick);
			// 
			// buttonAnimarPrim
			// 
			this.buttonAnimarPrim.Location = new System.Drawing.Point(1068, 678);
			this.buttonAnimarPrim.Name = "buttonAnimarPrim";
			this.buttonAnimarPrim.Size = new System.Drawing.Size(155, 62);
			this.buttonAnimarPrim.TabIndex = 17;
			this.buttonAnimarPrim.Text = "Iniciar animación";
			this.buttonAnimarPrim.UseVisualStyleBackColor = true;
			this.buttonAnimarPrim.Click += new System.EventHandler(this.ButtonAnimarPrimClick);
			// 
			// listBoxArmDijkstra
			// 
			this.listBoxArmDijkstra.FormattingEnabled = true;
			this.listBoxArmDijkstra.ItemHeight = 16;
			this.listBoxArmDijkstra.Location = new System.Drawing.Point(639, 624);
			this.listBoxArmDijkstra.Name = "listBoxArmDijkstra";
			this.listBoxArmDijkstra.Size = new System.Drawing.Size(141, 116);
			this.listBoxArmDijkstra.TabIndex = 18;
			// 
			// listBoxArmPrim
			// 
			this.listBoxArmPrim.FormattingEnabled = true;
			this.listBoxArmPrim.ItemHeight = 16;
			this.listBoxArmPrim.Location = new System.Drawing.Point(1470, 624);
			this.listBoxArmPrim.Name = "listBoxArmPrim";
			this.listBoxArmPrim.Size = new System.Drawing.Size(141, 116);
			this.listBoxArmPrim.TabIndex = 19;
			// 
			// labelArmDijkstra
			// 
			this.labelArmDijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelArmDijkstra.Location = new System.Drawing.Point(671, 598);
			this.labelArmDijkstra.Name = "labelArmDijkstra";
			this.labelArmDijkstra.Size = new System.Drawing.Size(78, 23);
			this.labelArmDijkstra.TabIndex = 20;
			this.labelArmDijkstra.Text = "ARM ";
			// 
			// labelArmPrim
			// 
			this.labelArmPrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelArmPrim.Location = new System.Drawing.Point(1500, 598);
			this.labelArmPrim.Name = "labelArmPrim";
			this.labelArmPrim.Size = new System.Drawing.Size(78, 23);
			this.labelArmPrim.TabIndex = 21;
			this.labelArmPrim.Text = "ARM ";
			// 
			// labelRecorridoDijkstra
			// 
			this.labelRecorridoDijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRecorridoDijkstra.Location = new System.Drawing.Point(458, 598);
			this.labelRecorridoDijkstra.Name = "labelRecorridoDijkstra";
			this.labelRecorridoDijkstra.Size = new System.Drawing.Size(129, 23);
			this.labelRecorridoDijkstra.TabIndex = 22;
			this.labelRecorridoDijkstra.Text = "Recorrido";
			// 
			// labelRecorridoPrim
			// 
			this.labelRecorridoPrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRecorridoPrim.Location = new System.Drawing.Point(1294, 598);
			this.labelRecorridoPrim.Name = "labelRecorridoPrim";
			this.labelRecorridoPrim.Size = new System.Drawing.Size(129, 23);
			this.labelRecorridoPrim.TabIndex = 23;
			this.labelRecorridoPrim.Text = "Recorrido";
			// 
			// comboBoxKruskal
			// 
			this.comboBoxKruskal.FormattingEnabled = true;
			this.comboBoxKruskal.Location = new System.Drawing.Point(234, 817);
			this.comboBoxKruskal.Name = "comboBoxKruskal";
			this.comboBoxKruskal.Size = new System.Drawing.Size(135, 24);
			this.comboBoxKruskal.TabIndex = 26;
			this.comboBoxKruskal.SelectedIndexChanged += new System.EventHandler(this.ComboBoxKruskalSelectedIndexChanged);
			// 
			// comboBoxPrim
			// 
			this.comboBoxPrim.FormattingEnabled = true;
			this.comboBoxPrim.Location = new System.Drawing.Point(1068, 817);
			this.comboBoxPrim.Name = "comboBoxPrim";
			this.comboBoxPrim.Size = new System.Drawing.Size(135, 24);
			this.comboBoxPrim.TabIndex = 27;
			this.comboBoxPrim.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPrimSelectedIndexChanged);
			// 
			// VentanaEtapa4
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1757, 929);
			this.Controls.Add(this.comboBoxPrim);
			this.Controls.Add(this.comboBoxKruskal);
			this.Controls.Add(this.labelRecorridoPrim);
			this.Controls.Add(this.labelRecorridoDijkstra);
			this.Controls.Add(this.labelArmPrim);
			this.Controls.Add(this.labelArmDijkstra);
			this.Controls.Add(this.listBoxArmPrim);
			this.Controls.Add(this.listBoxArmDijkstra);
			this.Controls.Add(this.buttonAnimarPrim);
			this.Controls.Add(this.buttonAnimarDijkstra);
			this.Controls.Add(this.buttonPrimArm);
			this.Controls.Add(this.buttonDijkstraArm);
			this.Controls.Add(this.labelPesoTotalPrimNumero);
			this.Controls.Add(this.labelPesoTotalPrim);
			this.Controls.Add(this.labelPesoTotalDijkstraNumero);
			this.Controls.Add(this.labelPesoTotalDijkstra);
			this.Controls.Add(this.listBoxCaminoAgentePrim);
			this.Controls.Add(this.listBoxCaminoAgenteDijkstra);
			this.Controls.Add(this.labelNumeroSubgrafosPrim);
			this.Controls.Add(this.labelNumeroSubgrafosDijkstra);
			this.Controls.Add(this.labelCantidadSubgrafosPrim);
			this.Controls.Add(this.labelCantidadSubgrafosDijkstra);
			this.Controls.Add(this.labelPrim);
			this.Controls.Add(this.labelDijkstra);
			this.Controls.Add(this.pictureBoxPrim);
			this.Controls.Add(this.pictureBoxDijkstra);
			this.Name = "VentanaEtapa4";
			this.Text = "VentanaEtapa4";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDijkstra)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrim)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
