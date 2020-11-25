/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 30/01/2019
 * Hora: 06:32 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Etapa_1
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label labelTitulo;
		private System.Windows.Forms.Button buttonSeleccionarImagen;
		private System.Windows.Forms.Button buttonAnalizarImagen;
		private System.Windows.Forms.PictureBox pictureBoxImagen;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonSalir;
		private System.Windows.Forms.Label labelImageMostrada;
		private System.Windows.Forms.Button buttonCrearAgentes;
		private System.Windows.Forms.NumericUpDown numericUpDownAgentes;
		private System.Windows.Forms.Button buttonAnimar;
		private System.Windows.Forms.Button buttonInfoAgente;
		private System.Windows.Forms.Button buttonEtapa4;
		private System.Windows.Forms.Button buttonCrearPresa;
		private System.Windows.Forms.Button buttonAnimarPresa;
		private System.Windows.Forms.Button buttonAnimarTodo;
		private System.Windows.Forms.Button buttonFuerzaVsDivide;
		private System.Windows.Forms.Button buttonBfs;
		private System.Windows.Forms.GroupBox groupBoxDepredador;
		private System.Windows.Forms.GroupBox groupBoxPresas;
		private System.Windows.Forms.NumericUpDown numericUpDownPresas;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButtonFloyd;
		private System.Windows.Forms.RadioButton radioButtonDijkstra;
		private System.Windows.Forms.GroupBox groupBoxCaminosDepredadores;
		private System.Windows.Forms.RadioButton radioButtonBioInspirado;
		private System.Windows.Forms.RadioButton radioButtonDfs;
		private System.Windows.Forms.RadioButton radioButtonAleatorio;
		private System.Windows.Forms.Button buttonConfirmarCamino;
		private System.Windows.Forms.GroupBox groupBoxCaminosMinimos;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaPresa;
		private System.Windows.Forms.DataGridView dataGridViewPresas;
		private System.Windows.Forms.DataGridViewComboBoxColumn ColumnaOrigen;
		private System.Windows.Forms.DataGridViewComboBoxColumn ColumnaDestino;
		private System.Windows.Forms.DataGridView dataGridViewDepredadores;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
		private System.Windows.Forms.GroupBox groupBoxElegirOrigen;
		private System.Windows.Forms.RadioButton radioButtonNoElegirOrigen;
		private System.Windows.Forms.RadioButton radioButtonElegirOrigen;
		private System.Windows.Forms.Button buttonConfirmarOrigenes;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label labelGrafo;
		private System.Windows.Forms.TreeView treeViewGrafo;
		private System.Windows.Forms.Label labelListaCirculos;
		private System.Windows.Forms.ListBox listBoxCentros;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label labelCantidadDepredadores;
		private System.Windows.Forms.Button buttonFloydDijkstra;
		
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
			System.Windows.Forms.Panel panelFondoTitulo;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelTitulo = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.pictureBoxImagen = new System.Windows.Forms.PictureBox();
			this.buttonSeleccionarImagen = new System.Windows.Forms.Button();
			this.buttonAnalizarImagen = new System.Windows.Forms.Button();
			this.buttonSalir = new System.Windows.Forms.Button();
			this.labelImageMostrada = new System.Windows.Forms.Label();
			this.buttonInfoAgente = new System.Windows.Forms.Button();
			this.buttonEtapa4 = new System.Windows.Forms.Button();
			this.buttonFuerzaVsDivide = new System.Windows.Forms.Button();
			this.buttonBfs = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.labelGrafo = new System.Windows.Forms.Label();
			this.treeViewGrafo = new System.Windows.Forms.TreeView();
			this.labelListaCirculos = new System.Windows.Forms.Label();
			this.listBoxCentros = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.buttonAnimarTodo = new System.Windows.Forms.Button();
			this.groupBoxDepredador = new System.Windows.Forms.GroupBox();
			this.labelCantidadDepredadores = new System.Windows.Forms.Label();
			this.buttonConfirmarOrigenes = new System.Windows.Forms.Button();
			this.dataGridViewDepredadores = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.buttonCrearAgentes = new System.Windows.Forms.Button();
			this.buttonAnimar = new System.Windows.Forms.Button();
			this.numericUpDownAgentes = new System.Windows.Forms.NumericUpDown();
			this.groupBoxCaminosMinimos = new System.Windows.Forms.GroupBox();
			this.radioButtonFloyd = new System.Windows.Forms.RadioButton();
			this.radioButtonDijkstra = new System.Windows.Forms.RadioButton();
			this.groupBoxElegirOrigen = new System.Windows.Forms.GroupBox();
			this.radioButtonNoElegirOrigen = new System.Windows.Forms.RadioButton();
			this.radioButtonElegirOrigen = new System.Windows.Forms.RadioButton();
			this.groupBoxPresas = new System.Windows.Forms.GroupBox();
			this.dataGridViewPresas = new System.Windows.Forms.DataGridView();
			this.ColumnaPresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnaOrigen = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.ColumnaDestino = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.buttonConfirmarCamino = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownPresas = new System.Windows.Forms.NumericUpDown();
			this.buttonCrearPresa = new System.Windows.Forms.Button();
			this.buttonAnimarPresa = new System.Windows.Forms.Button();
			this.groupBoxCaminosDepredadores = new System.Windows.Forms.GroupBox();
			this.radioButtonBioInspirado = new System.Windows.Forms.RadioButton();
			this.radioButtonDfs = new System.Windows.Forms.RadioButton();
			this.radioButtonAleatorio = new System.Windows.Forms.RadioButton();
			this.buttonFloydDijkstra = new System.Windows.Forms.Button();
			panelFondoTitulo = new System.Windows.Forms.Panel();
			panelFondoTitulo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBoxDepredador.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepredadores)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgentes)).BeginInit();
			this.groupBoxCaminosMinimos.SuspendLayout();
			this.groupBoxElegirOrigen.SuspendLayout();
			this.groupBoxPresas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPresas)).BeginInit();
			this.groupBoxCaminosDepredadores.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelFondoTitulo
			// 
			panelFondoTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
			panelFondoTitulo.Controls.Add(this.panel1);
			panelFondoTitulo.Controls.Add(this.labelTitulo);
			panelFondoTitulo.Location = new System.Drawing.Point(34, 12);
			panelFondoTitulo.Name = "panelFondoTitulo";
			panelFondoTitulo.Size = new System.Drawing.Size(1736, 102);
			panelFondoTitulo.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(1, 229);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(304, 543);
			this.panel1.TabIndex = 2;
			// 
			// labelTitulo
			// 
			this.labelTitulo.Font = new System.Drawing.Font("Arial Black", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitulo.Location = new System.Drawing.Point(374, 17);
			this.labelTitulo.Name = "labelTitulo";
			this.labelTitulo.Size = new System.Drawing.Size(729, 66);
			this.labelTitulo.TabIndex = 1;
			this.labelTitulo.Text = "Proyecto";
			this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// pictureBoxImagen
			// 
			this.pictureBoxImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxImagen.Location = new System.Drawing.Point(312, 186);
			this.pictureBoxImagen.Name = "pictureBoxImagen";
			this.pictureBoxImagen.Size = new System.Drawing.Size(798, 521);
			this.pictureBoxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxImagen.TabIndex = 4;
			this.pictureBoxImagen.TabStop = false;
			this.pictureBoxImagen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImagenMouseDoubleClick);
			// 
			// buttonSeleccionarImagen
			// 
			this.buttonSeleccionarImagen.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.buttonSeleccionarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSeleccionarImagen.Location = new System.Drawing.Point(24, 177);
			this.buttonSeleccionarImagen.Name = "buttonSeleccionarImagen";
			this.buttonSeleccionarImagen.Size = new System.Drawing.Size(252, 75);
			this.buttonSeleccionarImagen.TabIndex = 1;
			this.buttonSeleccionarImagen.Text = "Seleccionar Imagen";
			this.buttonSeleccionarImagen.UseVisualStyleBackColor = false;
			this.buttonSeleccionarImagen.Click += new System.EventHandler(this.ButtonSeleccionarImagenClick);
			// 
			// buttonAnalizarImagen
			// 
			this.buttonAnalizarImagen.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.buttonAnalizarImagen.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonAnalizarImagen.Enabled = false;
			this.buttonAnalizarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAnalizarImagen.Location = new System.Drawing.Point(24, 258);
			this.buttonAnalizarImagen.Name = "buttonAnalizarImagen";
			this.buttonAnalizarImagen.Size = new System.Drawing.Size(252, 75);
			this.buttonAnalizarImagen.TabIndex = 2;
			this.buttonAnalizarImagen.Text = "Analizar Imagen";
			this.buttonAnalizarImagen.UseVisualStyleBackColor = false;
			this.buttonAnalizarImagen.Click += new System.EventHandler(this.ButtonAnalizarImagenClick);
			// 
			// buttonSalir
			// 
			this.buttonSalir.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.buttonSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSalir.Location = new System.Drawing.Point(24, 641);
			this.buttonSalir.Name = "buttonSalir";
			this.buttonSalir.Size = new System.Drawing.Size(252, 75);
			this.buttonSalir.TabIndex = 11;
			this.buttonSalir.Text = "Salir";
			this.buttonSalir.UseVisualStyleBackColor = false;
			this.buttonSalir.Click += new System.EventHandler(this.ButtonSalirClick);
			// 
			// labelImageMostrada
			// 
			this.labelImageMostrada.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.labelImageMostrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelImageMostrada.Location = new System.Drawing.Point(591, 126);
			this.labelImageMostrada.Name = "labelImageMostrada";
			this.labelImageMostrada.Size = new System.Drawing.Size(362, 48);
			this.labelImageMostrada.TabIndex = 12;
			// 
			// buttonInfoAgente
			// 
			this.buttonInfoAgente.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.buttonInfoAgente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonInfoAgente.Location = new System.Drawing.Point(844, 730);
			this.buttonInfoAgente.Name = "buttonInfoAgente";
			this.buttonInfoAgente.Size = new System.Drawing.Size(252, 75);
			this.buttonInfoAgente.TabIndex = 28;
			this.buttonInfoAgente.Text = "Mostar Informacion Depredadores";
			this.buttonInfoAgente.UseVisualStyleBackColor = false;
			this.buttonInfoAgente.Click += new System.EventHandler(this.Button1Click);
			// 
			// buttonEtapa4
			// 
			this.buttonEtapa4.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.buttonEtapa4.Enabled = false;
			this.buttonEtapa4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonEtapa4.Location = new System.Drawing.Point(24, 354);
			this.buttonEtapa4.Name = "buttonEtapa4";
			this.buttonEtapa4.Size = new System.Drawing.Size(252, 75);
			this.buttonEtapa4.TabIndex = 37;
			this.buttonEtapa4.Text = "Prim Vs Kruskal";
			this.buttonEtapa4.UseVisualStyleBackColor = false;
			this.buttonEtapa4.Click += new System.EventHandler(this.ButtonEtapa4Click);
			// 
			// buttonFuerzaVsDivide
			// 
			this.buttonFuerzaVsDivide.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.buttonFuerzaVsDivide.Enabled = false;
			this.buttonFuerzaVsDivide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonFuerzaVsDivide.Location = new System.Drawing.Point(24, 458);
			this.buttonFuerzaVsDivide.Name = "buttonFuerzaVsDivide";
			this.buttonFuerzaVsDivide.Size = new System.Drawing.Size(252, 75);
			this.buttonFuerzaVsDivide.TabIndex = 47;
			this.buttonFuerzaVsDivide.Text = "Fuerza Bruta VS Divide y venceras";
			this.buttonFuerzaVsDivide.UseVisualStyleBackColor = false;
			this.buttonFuerzaVsDivide.Click += new System.EventHandler(this.buttonFuerzaVsDivideClick);
			// 
			// buttonBfs
			// 
			this.buttonBfs.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.buttonBfs.Enabled = false;
			this.buttonBfs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonBfs.Location = new System.Drawing.Point(24, 551);
			this.buttonBfs.Name = "buttonBfs";
			this.buttonBfs.Size = new System.Drawing.Size(252, 75);
			this.buttonBfs.TabIndex = 48;
			this.buttonBfs.Text = "BFS";
			this.buttonBfs.UseVisualStyleBackColor = false;
			this.buttonBfs.Click += new System.EventHandler(this.ButtonBfsClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(1116, 186);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(567, 642);
			this.tabControl1.TabIndex = 57;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.labelGrafo);
			this.tabPage1.Controls.Add(this.treeViewGrafo);
			this.tabPage1.Controls.Add(this.labelListaCirculos);
			this.tabPage1.Controls.Add(this.listBoxCentros);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(559, 613);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Informacion";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// labelGrafo
			// 
			this.labelGrafo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelGrafo.Location = new System.Drawing.Point(6, 275);
			this.labelGrafo.Name = "labelGrafo";
			this.labelGrafo.Size = new System.Drawing.Size(200, 47);
			this.labelGrafo.TabIndex = 59;
			this.labelGrafo.Text = "Grafo";
			// 
			// treeViewGrafo
			// 
			this.treeViewGrafo.Location = new System.Drawing.Point(11, 325);
			this.treeViewGrafo.Name = "treeViewGrafo";
			this.treeViewGrafo.Size = new System.Drawing.Size(222, 123);
			this.treeViewGrafo.TabIndex = 58;
			// 
			// labelListaCirculos
			// 
			this.labelListaCirculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelListaCirculos.Location = new System.Drawing.Point(11, 20);
			this.labelListaCirculos.Name = "labelListaCirculos";
			this.labelListaCirculos.Size = new System.Drawing.Size(200, 47);
			this.labelListaCirculos.TabIndex = 57;
			this.labelListaCirculos.Text = "Lista de circulos";
			// 
			// listBoxCentros
			// 
			this.listBoxCentros.FormattingEnabled = true;
			this.listBoxCentros.ItemHeight = 16;
			this.listBoxCentros.Location = new System.Drawing.Point(11, 70);
			this.listBoxCentros.Name = "listBoxCentros";
			this.listBoxCentros.Size = new System.Drawing.Size(358, 148);
			this.listBoxCentros.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.buttonAnimarTodo);
			this.tabPage2.Controls.Add(this.groupBoxDepredador);
			this.tabPage2.Controls.Add(this.groupBoxCaminosMinimos);
			this.tabPage2.Controls.Add(this.groupBoxElegirOrigen);
			this.tabPage2.Controls.Add(this.groupBoxPresas);
			this.tabPage2.Controls.Add(this.groupBoxCaminosDepredadores);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(559, 613);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Animacion";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// buttonAnimarTodo
			// 
			this.buttonAnimarTodo.Enabled = false;
			this.buttonAnimarTodo.Location = new System.Drawing.Point(393, 508);
			this.buttonAnimarTodo.Name = "buttonAnimarTodo";
			this.buttonAnimarTodo.Size = new System.Drawing.Size(160, 81);
			this.buttonAnimarTodo.TabIndex = 58;
			this.buttonAnimarTodo.Text = "Animar Presas y Depredadores";
			this.buttonAnimarTodo.UseVisualStyleBackColor = true;
			this.buttonAnimarTodo.Click += new System.EventHandler(this.ButtonAnimarTodoClick);
			// 
			// groupBoxDepredador
			// 
			this.groupBoxDepredador.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.groupBoxDepredador.Controls.Add(this.labelCantidadDepredadores);
			this.groupBoxDepredador.Controls.Add(this.buttonConfirmarOrigenes);
			this.groupBoxDepredador.Controls.Add(this.dataGridViewDepredadores);
			this.groupBoxDepredador.Controls.Add(this.buttonCrearAgentes);
			this.groupBoxDepredador.Controls.Add(this.buttonAnimar);
			this.groupBoxDepredador.Controls.Add(this.numericUpDownAgentes);
			this.groupBoxDepredador.Location = new System.Drawing.Point(6, 6);
			this.groupBoxDepredador.Name = "groupBoxDepredador";
			this.groupBoxDepredador.Size = new System.Drawing.Size(378, 294);
			this.groupBoxDepredador.TabIndex = 51;
			this.groupBoxDepredador.TabStop = false;
			this.groupBoxDepredador.Text = "Depredadores";
			this.groupBoxDepredador.Visible = false;
			// 
			// labelCantidadDepredadores
			// 
			this.labelCantidadDepredadores.Location = new System.Drawing.Point(18, 26);
			this.labelCantidadDepredadores.Name = "labelCantidadDepredadores";
			this.labelCantidadDepredadores.Size = new System.Drawing.Size(100, 23);
			this.labelCantidadDepredadores.TabIndex = 58;
			this.labelCantidadDepredadores.Text = "Cantidad:";
			// 
			// buttonConfirmarOrigenes
			// 
			this.buttonConfirmarOrigenes.Enabled = false;
			this.buttonConfirmarOrigenes.Location = new System.Drawing.Point(21, 234);
			this.buttonConfirmarOrigenes.Name = "buttonConfirmarOrigenes";
			this.buttonConfirmarOrigenes.Size = new System.Drawing.Size(120, 52);
			this.buttonConfirmarOrigenes.TabIndex = 56;
			this.buttonConfirmarOrigenes.Text = "Confirmar Origenes";
			this.buttonConfirmarOrigenes.UseVisualStyleBackColor = true;
			this.buttonConfirmarOrigenes.Click += new System.EventHandler(this.ButtonConfirmarOrigenesClick);
			// 
			// dataGridViewDepredadores
			// 
			this.dataGridViewDepredadores.AllowUserToAddRows = false;
			this.dataGridViewDepredadores.AllowUserToDeleteRows = false;
			this.dataGridViewDepredadores.AllowUserToResizeColumns = false;
			this.dataGridViewDepredadores.AllowUserToResizeRows = false;
			this.dataGridViewDepredadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridViewDepredadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.dataGridViewTextBoxColumn1,
			this.dataGridViewComboBoxColumn1});
			this.dataGridViewDepredadores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dataGridViewDepredadores.Location = new System.Drawing.Point(18, 108);
			this.dataGridViewDepredadores.Name = "dataGridViewDepredadores";
			this.dataGridViewDepredadores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridViewDepredadores.RowTemplate.Height = 24;
			this.dataGridViewDepredadores.Size = new System.Drawing.Size(300, 120);
			this.dataGridViewDepredadores.TabIndex = 57;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Depredador";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn1.Width = 75;
			// 
			// dataGridViewComboBoxColumn1
			// 
			this.dataGridViewComboBoxColumn1.HeaderText = "Origen";
			this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
			this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewComboBoxColumn1.Width = 55;
			// 
			// buttonCrearAgentes
			// 
			this.buttonCrearAgentes.Location = new System.Drawing.Point(18, 62);
			this.buttonCrearAgentes.Name = "buttonCrearAgentes";
			this.buttonCrearAgentes.Size = new System.Drawing.Size(120, 35);
			this.buttonCrearAgentes.TabIndex = 22;
			this.buttonCrearAgentes.Text = "Crear";
			this.buttonCrearAgentes.UseVisualStyleBackColor = true;
			this.buttonCrearAgentes.Click += new System.EventHandler(this.ButtonCrearAgentesClick);
			// 
			// buttonAnimar
			// 
			this.buttonAnimar.Enabled = false;
			this.buttonAnimar.Location = new System.Drawing.Point(201, 236);
			this.buttonAnimar.Name = "buttonAnimar";
			this.buttonAnimar.Size = new System.Drawing.Size(120, 35);
			this.buttonAnimar.TabIndex = 27;
			this.buttonAnimar.Text = "Animar";
			this.buttonAnimar.UseVisualStyleBackColor = true;
			this.buttonAnimar.Click += new System.EventHandler(this.ButtonAnimarClick);
			// 
			// numericUpDownAgentes
			// 
			this.numericUpDownAgentes.Location = new System.Drawing.Point(144, 24);
			this.numericUpDownAgentes.Name = "numericUpDownAgentes";
			this.numericUpDownAgentes.Size = new System.Drawing.Size(120, 22);
			this.numericUpDownAgentes.TabIndex = 21;
			this.numericUpDownAgentes.ValueChanged += new System.EventHandler(this.NumericUpDownAgentesValueChanged);
			// 
			// groupBoxCaminosMinimos
			// 
			this.groupBoxCaminosMinimos.Controls.Add(this.radioButtonFloyd);
			this.groupBoxCaminosMinimos.Controls.Add(this.radioButtonDijkstra);
			this.groupBoxCaminosMinimos.Location = new System.Drawing.Point(390, 315);
			this.groupBoxCaminosMinimos.Name = "groupBoxCaminosMinimos";
			this.groupBoxCaminosMinimos.Size = new System.Drawing.Size(150, 100);
			this.groupBoxCaminosMinimos.TabIndex = 53;
			this.groupBoxCaminosMinimos.TabStop = false;
			this.groupBoxCaminosMinimos.Text = "Caminos Minimos";
			this.groupBoxCaminosMinimos.Visible = false;
			// 
			// radioButtonFloyd
			// 
			this.radioButtonFloyd.Location = new System.Drawing.Point(21, 51);
			this.radioButtonFloyd.Name = "radioButtonFloyd";
			this.radioButtonFloyd.Size = new System.Drawing.Size(129, 24);
			this.radioButtonFloyd.TabIndex = 1;
			this.radioButtonFloyd.TabStop = true;
			this.radioButtonFloyd.Text = "Floyd Warshall";
			this.radioButtonFloyd.UseVisualStyleBackColor = true;
			// 
			// radioButtonDijkstra
			// 
			this.radioButtonDijkstra.Checked = true;
			this.radioButtonDijkstra.Location = new System.Drawing.Point(21, 21);
			this.radioButtonDijkstra.Name = "radioButtonDijkstra";
			this.radioButtonDijkstra.Size = new System.Drawing.Size(104, 24);
			this.radioButtonDijkstra.TabIndex = 0;
			this.radioButtonDijkstra.TabStop = true;
			this.radioButtonDijkstra.Text = "Dijkstra";
			this.radioButtonDijkstra.UseVisualStyleBackColor = true;
			// 
			// groupBoxElegirOrigen
			// 
			this.groupBoxElegirOrigen.Controls.Add(this.radioButtonNoElegirOrigen);
			this.groupBoxElegirOrigen.Controls.Add(this.radioButtonElegirOrigen);
			this.groupBoxElegirOrigen.Location = new System.Drawing.Point(393, 138);
			this.groupBoxElegirOrigen.Name = "groupBoxElegirOrigen";
			this.groupBoxElegirOrigen.Size = new System.Drawing.Size(147, 96);
			this.groupBoxElegirOrigen.TabIndex = 55;
			this.groupBoxElegirOrigen.TabStop = false;
			this.groupBoxElegirOrigen.Text = "Elegir Origen";
			this.groupBoxElegirOrigen.Visible = false;
			// 
			// radioButtonNoElegirOrigen
			// 
			this.radioButtonNoElegirOrigen.Checked = true;
			this.radioButtonNoElegirOrigen.Location = new System.Drawing.Point(18, 60);
			this.radioButtonNoElegirOrigen.Name = "radioButtonNoElegirOrigen";
			this.radioButtonNoElegirOrigen.Size = new System.Drawing.Size(104, 24);
			this.radioButtonNoElegirOrigen.TabIndex = 1;
			this.radioButtonNoElegirOrigen.TabStop = true;
			this.radioButtonNoElegirOrigen.Text = "No";
			this.radioButtonNoElegirOrigen.UseVisualStyleBackColor = true;
			this.radioButtonNoElegirOrigen.Click += new System.EventHandler(this.RadioButtonNoElegirOrigenClick);
			// 
			// radioButtonElegirOrigen
			// 
			this.radioButtonElegirOrigen.Location = new System.Drawing.Point(18, 30);
			this.radioButtonElegirOrigen.Name = "radioButtonElegirOrigen";
			this.radioButtonElegirOrigen.Size = new System.Drawing.Size(104, 24);
			this.radioButtonElegirOrigen.TabIndex = 0;
			this.radioButtonElegirOrigen.TabStop = true;
			this.radioButtonElegirOrigen.Text = "Si";
			this.radioButtonElegirOrigen.UseVisualStyleBackColor = true;
			this.radioButtonElegirOrigen.Click += new System.EventHandler(this.RadioButtonElegirOrigenClick);
			// 
			// groupBoxPresas
			// 
			this.groupBoxPresas.Controls.Add(this.dataGridViewPresas);
			this.groupBoxPresas.Controls.Add(this.buttonConfirmarCamino);
			this.groupBoxPresas.Controls.Add(this.label1);
			this.groupBoxPresas.Controls.Add(this.numericUpDownPresas);
			this.groupBoxPresas.Controls.Add(this.buttonCrearPresa);
			this.groupBoxPresas.Controls.Add(this.buttonAnimarPresa);
			this.groupBoxPresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxPresas.Location = new System.Drawing.Point(6, 306);
			this.groupBoxPresas.Name = "groupBoxPresas";
			this.groupBoxPresas.Size = new System.Drawing.Size(378, 289);
			this.groupBoxPresas.TabIndex = 52;
			this.groupBoxPresas.TabStop = false;
			this.groupBoxPresas.Text = "Presas";
			this.groupBoxPresas.Visible = false;
			// 
			// dataGridViewPresas
			// 
			this.dataGridViewPresas.AllowUserToAddRows = false;
			this.dataGridViewPresas.AllowUserToDeleteRows = false;
			this.dataGridViewPresas.AllowUserToResizeColumns = false;
			this.dataGridViewPresas.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewPresas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewPresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridViewPresas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.ColumnaPresa,
			this.ColumnaOrigen,
			this.ColumnaDestino});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewPresas.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewPresas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dataGridViewPresas.Location = new System.Drawing.Point(21, 98);
			this.dataGridViewPresas.Name = "dataGridViewPresas";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewPresas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewPresas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridViewPresas.RowTemplate.Height = 24;
			this.dataGridViewPresas.Size = new System.Drawing.Size(300, 127);
			this.dataGridViewPresas.TabIndex = 56;
			// 
			// ColumnaPresa
			// 
			this.ColumnaPresa.HeaderText = "Presa";
			this.ColumnaPresa.Name = "ColumnaPresa";
			this.ColumnaPresa.ReadOnly = true;
			this.ColumnaPresa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnaPresa.Width = 55;
			// 
			// ColumnaOrigen
			// 
			this.ColumnaOrigen.HeaderText = "Origen";
			this.ColumnaOrigen.Name = "ColumnaOrigen";
			this.ColumnaOrigen.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnaOrigen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.ColumnaOrigen.Width = 55;
			// 
			// ColumnaDestino
			// 
			this.ColumnaDestino.HeaderText = "Destino";
			this.ColumnaDestino.Name = "ColumnaDestino";
			this.ColumnaDestino.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnaDestino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.ColumnaDestino.Width = 55;
			// 
			// buttonConfirmarCamino
			// 
			this.buttonConfirmarCamino.Enabled = false;
			this.buttonConfirmarCamino.Location = new System.Drawing.Point(18, 231);
			this.buttonConfirmarCamino.Name = "buttonConfirmarCamino";
			this.buttonConfirmarCamino.Size = new System.Drawing.Size(120, 52);
			this.buttonConfirmarCamino.TabIndex = 55;
			this.buttonConfirmarCamino.Text = "Confirmar Caminos";
			this.buttonConfirmarCamino.UseVisualStyleBackColor = true;
			this.buttonConfirmarCamino.Click += new System.EventHandler(this.ButtonConfirmarCaminoClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 54;
			this.label1.Text = "Cantidad:";
			// 
			// numericUpDownPresas
			// 
			this.numericUpDownPresas.Location = new System.Drawing.Point(144, 21);
			this.numericUpDownPresas.Name = "numericUpDownPresas";
			this.numericUpDownPresas.Size = new System.Drawing.Size(120, 22);
			this.numericUpDownPresas.TabIndex = 53;
			// 
			// buttonCrearPresa
			// 
			this.buttonCrearPresa.Location = new System.Drawing.Point(18, 49);
			this.buttonCrearPresa.Name = "buttonCrearPresa";
			this.buttonCrearPresa.Size = new System.Drawing.Size(120, 35);
			this.buttonCrearPresa.TabIndex = 43;
			this.buttonCrearPresa.Text = "Crear";
			this.buttonCrearPresa.UseVisualStyleBackColor = true;
			this.buttonCrearPresa.Click += new System.EventHandler(this.ButtonCrearPresaClick);
			// 
			// buttonAnimarPresa
			// 
			this.buttonAnimarPresa.Enabled = false;
			this.buttonAnimarPresa.Location = new System.Drawing.Point(156, 248);
			this.buttonAnimarPresa.Name = "buttonAnimarPresa";
			this.buttonAnimarPresa.Size = new System.Drawing.Size(120, 35);
			this.buttonAnimarPresa.TabIndex = 44;
			this.buttonAnimarPresa.Text = "Animar";
			this.buttonAnimarPresa.UseVisualStyleBackColor = true;
			this.buttonAnimarPresa.Click += new System.EventHandler(this.ButtonAnimarPresaClick);
			// 
			// groupBoxCaminosDepredadores
			// 
			this.groupBoxCaminosDepredadores.Controls.Add(this.radioButtonBioInspirado);
			this.groupBoxCaminosDepredadores.Controls.Add(this.radioButtonDfs);
			this.groupBoxCaminosDepredadores.Controls.Add(this.radioButtonAleatorio);
			this.groupBoxCaminosDepredadores.Location = new System.Drawing.Point(390, 6);
			this.groupBoxCaminosDepredadores.Name = "groupBoxCaminosDepredadores";
			this.groupBoxCaminosDepredadores.Size = new System.Drawing.Size(150, 126);
			this.groupBoxCaminosDepredadores.TabIndex = 54;
			this.groupBoxCaminosDepredadores.TabStop = false;
			this.groupBoxCaminosDepredadores.Text = "Comportamiento";
			this.groupBoxCaminosDepredadores.Visible = false;
			// 
			// radioButtonBioInspirado
			// 
			this.radioButtonBioInspirado.AutoCheck = false;
			this.radioButtonBioInspirado.Enabled = false;
			this.radioButtonBioInspirado.Location = new System.Drawing.Point(21, 81);
			this.radioButtonBioInspirado.Name = "radioButtonBioInspirado";
			this.radioButtonBioInspirado.Size = new System.Drawing.Size(129, 24);
			this.radioButtonBioInspirado.TabIndex = 55;
			this.radioButtonBioInspirado.TabStop = true;
			this.radioButtonBioInspirado.Text = "BioInspirado";
			this.radioButtonBioInspirado.UseVisualStyleBackColor = true;
			// 
			// radioButtonDfs
			// 
			this.radioButtonDfs.Location = new System.Drawing.Point(21, 51);
			this.radioButtonDfs.Name = "radioButtonDfs";
			this.radioButtonDfs.Size = new System.Drawing.Size(129, 24);
			this.radioButtonDfs.TabIndex = 1;
			this.radioButtonDfs.Text = "DFS";
			this.radioButtonDfs.UseVisualStyleBackColor = true;
			// 
			// radioButtonAleatorio
			// 
			this.radioButtonAleatorio.AutoEllipsis = true;
			this.radioButtonAleatorio.Checked = true;
			this.radioButtonAleatorio.Location = new System.Drawing.Point(21, 21);
			this.radioButtonAleatorio.Name = "radioButtonAleatorio";
			this.radioButtonAleatorio.Size = new System.Drawing.Size(104, 24);
			this.radioButtonAleatorio.TabIndex = 0;
			this.radioButtonAleatorio.TabStop = true;
			this.radioButtonAleatorio.Text = "Aleatorio";
			this.radioButtonAleatorio.UseVisualStyleBackColor = true;
			// 
			// buttonFloydDijkstra
			// 
			this.buttonFloydDijkstra.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.buttonFloydDijkstra.Enabled = false;
			this.buttonFloydDijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonFloydDijkstra.Location = new System.Drawing.Point(12, 809);
			this.buttonFloydDijkstra.Name = "buttonFloydDijkstra";
			this.buttonFloydDijkstra.Size = new System.Drawing.Size(252, 75);
			this.buttonFloydDijkstra.TabIndex = 58;
			this.buttonFloydDijkstra.Text = "Floyd Vs Dijkstra";
			this.buttonFloydDijkstra.UseVisualStyleBackColor = false;
			this.buttonFloydDijkstra.Click += new System.EventHandler(this.ButtonFloydDijkstraClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1682, 1039);
			this.Controls.Add(this.buttonFloydDijkstra);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.buttonBfs);
			this.Controls.Add(this.buttonFuerzaVsDivide);
			this.Controls.Add(this.buttonEtapa4);
			this.Controls.Add(this.buttonInfoAgente);
			this.Controls.Add(this.labelImageMostrada);
			this.Controls.Add(this.buttonSalir);
			this.Controls.Add(this.buttonSeleccionarImagen);
			this.Controls.Add(this.buttonAnalizarImagen);
			this.Controls.Add(this.pictureBoxImagen);
			this.Controls.Add(panelFondoTitulo);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Name = "MainForm";
			this.Text = "Etapa 1";
			panelFondoTitulo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBoxDepredador.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepredadores)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgentes)).EndInit();
			this.groupBoxCaminosMinimos.ResumeLayout(false);
			this.groupBoxElegirOrigen.ResumeLayout(false);
			this.groupBoxPresas.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPresas)).EndInit();
			this.groupBoxCaminosDepredadores.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
