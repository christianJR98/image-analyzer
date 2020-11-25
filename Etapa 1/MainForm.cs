/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 30/01/2019
 * Hora: 06:32 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;//pasa sleep
namespace Etapa_1
{
	public partial class MainForm : Form
	{
		int contCirculosTotales;
		bool imagenAnalizada;
		Bitmap bmpImagen;
		Bitmap imagenOriginal;
		Bitmap bitmapAnimacion;
		List<Circulo> listaCirculos;
		Graph grafo;
		//etapa 4
		Vertex verticeInicialArm;
		//5to entregable
		Agente presa;
		List<ElementoDijkstra> caminosMinimos;
		List<Edge> caminoPresa;
		
		int indiceDepredadorGanador;
		Edge aristaMuertePresa;
		
		//7to Entregable
		List<Agente> presas;
		List<Agente> depredadores;
		int[,] caminosMinimosFloyd;
		List<Vertex> verticesDisponibles;
		
		string nombreImagenAnterior;
		
		bool caminoDepredadoresConfirmados;
		bool caminoPresasConfirmados;
		public MainForm()
		{
			InitializeComponent();
			contCirculosTotales = 0;
			imagenAnalizada = false;
			bmpImagen = null;
			imagenOriginal = null;
			depredadores = new List<Agente>();
			presas = new List<Agente>();
			//etapa 4
			verticeInicialArm = null;
			indiceDepredadorGanador = int.MaxValue;
			aristaMuertePresa = null;

			nombreImagenAnterior = "";
			
			caminoDepredadoresConfirmados = false;
			caminoPresasConfirmados = false;
		}
		void ButtonSeleccionarImagenClick(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			imagenAnalizada = false;
			if(openFileDialog1.FileName != "openFileDialog1" ){
					bmpImagen = new Bitmap(openFileDialog1.FileName);
					imagenOriginal = new Bitmap(openFileDialog1.FileName);
					pictureBoxImagen.Image = bmpImagen;
					//nacen en false
					buttonAnalizarImagen.Enabled = true;
					//buttonMostrarImagenAnalizada.Visible = false;
					buttonAnalizarImagen.Visible = true;
					labelImageMostrada.Text = "Imagen Original";
					//etapa 5
					caminoPresa = null;
					caminosMinimos = null;
					presa = null;
					depredadores.Clear();

					nombreImagenAnterior = openFileDialog1.FileName;	
				if(openFileDialog1.FileName == nombreImagenAnterior){
					//se reinicia todo
					listBoxCentros.DataSource = null;
					treeViewGrafo.Nodes.Clear();
					
					groupBoxPresas.Visible = false;
					groupBoxDepredador.Visible = false;
					groupBoxCaminosDepredadores.Visible = false;
					groupBoxCaminosMinimos.Visible = false;
					groupBoxElegirOrigen.Visible = false;
					
					buttonEtapa4.Enabled = false;
					
					buttonAnimar.Enabled = false;
					buttonAnimarPresa.Enabled = false;
					buttonConfirmarOrigenes.Enabled = false;
					buttonConfirmarCamino.Enabled = false;
					while(dataGridViewDepredadores.RowCount != 0){
						dataGridViewDepredadores.Rows.RemoveAt(dataGridViewDepredadores.CurrentRow.Index);
					}
					while(dataGridViewPresas.RowCount != 0){
						dataGridViewPresas.Rows.RemoveAt(dataGridViewPresas.CurrentRow.Index);
					}
					buttonFuerzaVsDivide.Enabled = false;
					buttonBfs.Enabled = false;
					buttonFloydDijkstra.Enabled = false;
				}
				return;
			}
		}
		void ButtonAnalizarImagenClick(object sender, EventArgs e){
			contCirculosTotales = 0;
			Color pixelActual;
			if(imagenAnalizada ){
				return;
			}
			listaCirculos = new List<Circulo>();
			this.Cursor  = Cursors.WaitCursor;
			for(int j=0;j < bmpImagen.Height;j++){//ejeY
				for(int i=0; i < bmpImagen.Width;i++){//ejeX
					pixelActual = bmpImagen.GetPixel(i,j);
					if(AnalizarColor.isBlack(pixelActual))//el pixel es negro
					{
						int centroEjeY = encontrarCentroEjeY(i,j);
						int centroEjeX = encontrarCentroEjeX(i,centroEjeY);
						pintarCirculoApartirCentro(centroEjeX,centroEjeY,Color.Red,imagenOriginal,bmpImagen);
						dibujarCentroCirculo(centroEjeX,centroEjeY,Color.DarkRed,bmpImagen);
						int radio = centroEjeY-j;//centro eje y es desde el incio ejeY hasta el centro
						Circulo circulo = new Circulo(centroEjeX,centroEjeY,radio,contCirculosTotales++);
						listaCirculos.Add(circulo);
					}
				}
			}//altura imagen
			
			pictureBoxImagen.Image = bmpImagen;

		
			if(listaCirculos.Count != 0){
				listBoxCentros.DataSource = listaCirculos;
			}
			else{
				//error
			}
			//buttonAnalizarImagen.Visible = false;
			//buttonAnalizarImagen.Enabled = true;
			labelImageMostrada.Text = "Imagen Analizada";
			this.Cursor  = Cursors.Default;
			imagenAnalizada = true;
			//
			//SE CREA EL GRAFO //ETAPA 2
			grafo = new Graph(listaCirculos,bmpImagen,imagenOriginal);
			pictureBoxImagen.Image = bmpImagen;
			treeViewGrafo.Nodes.Clear();
			actualizarTreeView();
			
			//se prepara el picture box para animacion
			pictureBoxImagen.BackgroundImage = bmpImagen;
			bitmapAnimacion = new Bitmap(bmpImagen.Width,bmpImagen.Height);
			pictureBoxImagen.Image = bitmapAnimacion;
			
			//PUNTOS MAS CERCANOS Y ARISTA MAS CORTA
			if(listaCirculos.Count >=2){
				encontrarPuntosCercanosFuerzaBrutaMejorado(listaCirculos);
				grafo.AristaMasCorta(bmpImagen);
				escribirNombreCirculos(listaCirculos);
				
			}
			//ETAPA 4 Boton
			buttonEtapa4.Enabled = true;
			
			//ETAPA 5 SE inicializa los combobox de la presa
			bitmapAnimacion = new Bitmap(bmpImagen.Width,bmpImagen.Height);
			pictureBoxImagen.BackgroundImage = bmpImagen;
			pictureBoxImagen.Image = bitmapAnimacion;
			
			
			//ETAPA 7 Se inicializan los combobox de Presa
			
			//radioButtonDijkstra.Select();
			//radioButtonAleatorio.Select();
			//radioButtonNoElegirOrigen.Select();
		
			groupBoxPresas.Visible = true;
			groupBoxDepredador.Visible = true;
			groupBoxCaminosDepredadores.Visible = true;
			groupBoxCaminosMinimos.Visible = true;
			groupBoxElegirOrigen.Visible = true;
			//se obtiene la matriz
			caminosMinimosFloyd = grafo.floydWharshall();
			presas = new List<Agente>();
			depredadores = new List<Agente>();
			
			buttonFuerzaVsDivide.Enabled = true;
			buttonBfs.Enabled = true;
			buttonFloydDijkstra.Enabled = true;
		}
		void pintarCirculoApartirCentro(int centroX,int centroY,Color colorCirculo,Bitmap imagenAnalizar,Bitmap ImagenPintar){
			Color pixelActual = imagenAnalizar.GetPixel(centroX,centroY);
			int auxEjeX = centroX;
			int auxEjeY = centroY;
			while(!AnalizarColor.isWhite(pixelActual)){//PINTA parte inferior izquierda
				while(!AnalizarColor.isWhite(pixelActual)){
					ImagenPintar.SetPixel(auxEjeX,auxEjeY,colorCirculo);
					auxEjeX--;//SE va a la izquierda
					pixelActual = imagenAnalizar.GetPixel(auxEjeX,auxEjeY);
				}
				auxEjeX = centroX;
				auxEjeY++;//y se baja
				pixelActual = imagenAnalizar.GetPixel(auxEjeX,auxEjeY);
			}
			
			auxEjeX = centroX;
			auxEjeY = centroY;
			pixelActual = imagenAnalizar.GetPixel(centroX,centroY);
			
			while(!AnalizarColor.isWhite(pixelActual)){//PINTA parte inferior derecha
				while(!AnalizarColor.isWhite(pixelActual)){
					ImagenPintar.SetPixel(auxEjeX,auxEjeY,colorCirculo);
					auxEjeX++;//SE va a la derecha
					pixelActual = imagenAnalizar.GetPixel(auxEjeX,auxEjeY);
				}
				auxEjeX = centroX;
				auxEjeY++;//y se baja
				pixelActual = imagenAnalizar.GetPixel(auxEjeX,auxEjeY);
			}
			
			auxEjeX = centroX;
			auxEjeY = centroY;
			pixelActual = imagenAnalizar.GetPixel(centroX,centroY);
			while(!AnalizarColor.isWhite(pixelActual)){//PINTA parte superior derecha
				while(!AnalizarColor.isWhite(pixelActual)){
					ImagenPintar.SetPixel(auxEjeX,auxEjeY,colorCirculo);
					auxEjeX++;//SE va a la derecha
					pixelActual = imagenAnalizar.GetPixel(auxEjeX,auxEjeY);
				}
				auxEjeX = centroX;
				auxEjeY--;//y se sube
				pixelActual = imagenAnalizar.GetPixel(auxEjeX,auxEjeY);
			}
			
			auxEjeX = centroX;
			auxEjeY = centroY;
			pixelActual = imagenAnalizar.GetPixel(centroX,centroY);
			while(!AnalizarColor.isWhite(pixelActual)){//PINTA parte superior izquierda
				while(!AnalizarColor.isWhite(pixelActual)){
					ImagenPintar.SetPixel(auxEjeX,auxEjeY,colorCirculo);
					auxEjeX--;//SE va a la izquierda
					pixelActual = imagenAnalizar.GetPixel(auxEjeX,auxEjeY);
				}
				auxEjeX = centroX;
				auxEjeY--;//y se sube
				pixelActual = imagenAnalizar.GetPixel(auxEjeX,auxEjeY);
			}
		}
		int encontrarCentroEjeY(int xPixelInicial,int yPixelInicial){
			Color pixelAux = bmpImagen.GetPixel(xPixelInicial,yPixelInicial);
			int xAux = xPixelInicial,yAux = yPixelInicial;
			int cont = 0;
			while((pixelAux.R == 0) & (pixelAux.G == 0) & (pixelAux.B == 0)){//igual negro
				yAux++;//cuenta hacia abajo
				pixelAux = bmpImagen.GetPixel(xPixelInicial,yAux);
				cont++;
			}
			int centro = (cont/2)+yPixelInicial;
			return centro;
		}
		int encontrarCentroEjeX(int ejeXInicial,int centroEjeY){
			Color pixelAux = bmpImagen.GetPixel(ejeXInicial,centroEjeY);
			int xAuxIzquierda = ejeXInicial,xAuxDerecha = ejeXInicial;
			int cont = 0;
			while((pixelAux.R == 0) & (pixelAux.G == 0) & (pixelAux.B == 0)){//sea igual a negro
				xAuxIzquierda--;
				pixelAux = bmpImagen.GetPixel(xAuxIzquierda,centroEjeY);
				cont++;
			}
			pixelAux = bmpImagen.GetPixel(ejeXInicial,centroEjeY);//Se regresa al centro
			while((pixelAux.R == 0) & (pixelAux.G == 0) & (pixelAux.B == 0)){//sea igual a negro
				xAuxDerecha++;
				pixelAux = bmpImagen.GetPixel(xAuxDerecha,centroEjeY);
				cont++;
			}
			
			//radio y primer pixel del lado izq del circulo
			//xAuxIzquierda termina en el punto de la izq del circulo
			int centro = (cont/2) + (xAuxIzquierda);
			return centro;
		}
		void dibujarCentroCirculo(int x_c,int y_c,Color colorCentro,Bitmap imagenDibujar){
			int tamanioCentro = 4;
			for(int i = (tamanioCentro*-1); i < tamanioCentro;i++){
				for(int j = (tamanioCentro*-1); j < tamanioCentro;j++){
					imagenDibujar.SetPixel(x_c-i,y_c-j,colorCentro);
				}
			}
		}
		void ButtonMostrarImagenAnalizadaClick(object sender, EventArgs e)
		{
			labelImageMostrada.Text = "Imagen Analizada";
			pictureBoxImagen.Image = bmpImagen;
		}
		void ButtonSalirClick(object sender, EventArgs e)
		{
			if(bmpImagen != null){
				bmpImagen.Dispose();
			}
			if(imagenOriginal != null){
				imagenOriginal.Dispose();
			}
			if(bitmapAnimacion != null){
				bitmapAnimacion.Dispose();
			}
			this.Close();
		}
		//--------------------------------------------ETAPA 2 ---------------------------------------------------------------------
		void escribirNombreCirculos(List<Circulo> lista){
			for(int i = 0; i < lista.Count;i++){
				Graphics imagenGraphics = Graphics.FromImage(bmpImagen);
				imagenGraphics.DrawString(lista[i].getId().ToString(),new Font("arial",15,FontStyle.Regular)
				                          ,new SolidBrush(Color.Black),new Point(lista[i].getEjeX()+lista[i].getRadio()
				                                                                 ,lista[i].getEjeY()+lista[i].getRadio()));
			}
		}
		void actualizarTreeView(){
			treeViewGrafo.BeginUpdate();
			List<Vertex> listaVertices = grafo.getListaVertices();
			for(int i = 0; i < listaVertices.Count;i++){
				treeViewGrafo.Nodes.Add(listaVertices[i].getId().ToString());
				List<Edge> eL = listaVertices[i].getListaAristas();
				
				for(int j = 0; j < eL.Count;j++){
					treeViewGrafo.Nodes[i].Nodes.Add(eL[j].getVerticeDestino().getId().ToString());
				}
			}
			treeViewGrafo.EndUpdate();
 		}
		void DibujarLineaDDA(Point puntoInicial,Point puntoFinal,Bitmap bmp,Color color){
			double m;
			double b;
			if(puntoInicial.X == puntoFinal.X){
				if(puntoInicial.Y >puntoFinal.Y){
					for(double y_i = puntoFinal.Y; y_i <puntoInicial.Y;y_i++){
						bmp.SetPixel((int)puntoInicial.X,(int)y_i,color);
					}
				}
				else{
					
					for(double y_i = puntoFinal.Y; y_i > puntoInicial.Y;y_i--){
						bmp.SetPixel((int)puntoInicial.X,(int)y_i,color);
					}
				}
			}
			m = ((double)puntoFinal.Y-(double)puntoInicial.Y)/((double)puntoFinal.X-(double)puntoInicial.X);
			b = (double)puntoFinal.Y-m*(double)puntoFinal.X;
			
			if(m >= 0){
				if(m <= 1){
					if(puntoInicial.X < puntoFinal.X){
						for(double y_i, x_i = puntoInicial.X; x_i <puntoFinal.X;x_i++){
							y_i = Math.Round(m*x_i+b);
							bmp.SetPixel((int)x_i,(int)y_i,color);
						}
					}
					else{
						for(double y_i,x_i = puntoInicial.X; x_i > puntoFinal.X;x_i--){
							y_i = Math.Round(m*x_i+b);
							bmp.SetPixel((int)x_i,(int)y_i,color);
						}
					}
					
				}
				if(m > 1){
					if(puntoInicial.X < puntoFinal.X){
						for(double x_i, y_i = puntoInicial.Y; y_i <puntoFinal.Y;y_i++){
							x_i = Math.Round((y_i-b)/m);
							bmp.SetPixel((int)x_i,(int)y_i,color);
						}
					}
					else{
						for(double x_i, y_i = puntoInicial.Y; y_i >puntoFinal.Y;y_i--){
							x_i = Math.Round((y_i-b)/m);
							bmp.SetPixel((int)x_i,(int)y_i,color);
						}
					}
				}
			}
			else{//pendiente negativa
				if((m*-1) <= 1){
					if(puntoInicial.X < puntoFinal.X){
						for(double y_i, x_i = puntoInicial.X; x_i <puntoFinal.X;x_i++){
							y_i = Math.Round(m*x_i+b);
							bmp.SetPixel((int)x_i,(int)y_i,color);
						}
					}
					else{
						for(double y_i,x_i = puntoInicial.X; x_i > puntoFinal.X;x_i--){
							y_i = Math.Round(m*x_i+b);
							bmp.SetPixel((int)x_i,(int)y_i,color);
						}
					}
					
				}
				if((m*-1) > 1){
					if(puntoInicial.X < puntoFinal.X){
						for(double x_i, y_i = puntoInicial.Y; y_i >puntoFinal.Y;y_i--){
							x_i = Math.Round((y_i-b)/m);
							bmp.SetPixel((int)x_i,(int)y_i,color);
						}
					}
					else{
						for(double x_i, y_i = puntoInicial.Y; y_i <puntoFinal.Y;y_i++){
							x_i = Math.Round((y_i-b)/m);
							bmp.SetPixel((int)x_i,(int)y_i,color);
						}
					}
				}
			}
		}
		void encontrarPuntosCercanosFuerzaBrutaMejorado(List<Circulo> lista){
			double menor,distancia;
			menor = FuncionesUtiles.distanciaEntrePuntos(lista[0].getCentro(),lista[1].getCentro());
			Point puntoA = lista[0].getCentro();
			Point puntoB = lista[1].getCentro();

			for(int i = 0; i < listaCirculos.Count; i++){
				for(int j = i+1; j < listaCirculos.Count; j++){
					distancia = FuncionesUtiles.distanciaEntrePuntos(lista[i].getCentro(),lista[j].getCentro());
					if(distancia < menor){
						menor = distancia;
						puntoA = lista[i].getCentro();
						puntoB = lista[j].getCentro();
					}
				}
			}

			
			/*pintarCirculoApartirCentro(puntoA.X,puntoA.Y,Color.Green,imagenOriginal,bmpImagen);
			pintarCirculoApartirCentro(puntoB.X,puntoB.Y,Color.Green,imagenOriginal,bmpImagen);
			 */
			pictureBoxImagen.Image = bmpImagen;
		}
		//--------------------------------------------ETAPA 3 ---------------------------------------------------------------------
		void dibujarAgente(Point punto,Color colorBrocha,Bitmap imagenDibujar){
			int radio = 10;
			Brush brocha = new SolidBrush(colorBrocha);
			Graphics imagen = Graphics.FromImage(imagenDibujar);
			imagen.FillEllipse(brocha,punto.X-radio,punto.Y-radio,radio*2,radio*2);
		}
		void clearBitmap(Bitmap bmp, Color c){
			Graphics g =  Graphics.FromImage(bmp);
			g.Clear(c);
		}
		void mostrarAgentesPosicionInicial(){
			clearBitmap(bitmapAnimacion,Color.Transparent);
			for(int i = 0; i < depredadores.Count;i++){
				dibujarDepredador(depredadores[i].getVerticeActual().getUbicacion(),bitmapAnimacion);
			}
			pictureBoxImagen.Refresh();
		}
		
		void mostrarCaminoAgente(Agente agente)
		{
			//int numeroCrecimiento = agente.getCamino().Count/255;
			//int color = 0;

			List<Edge> listaAristaAux = agente.getCamino();
			List<Point> listaPuntosArista;
			Graphics imagenGraphics;
			clearBitmap(bitmapAnimacion,Color.Transparent);
			if(listaAristaAux.Count!=0){
				dibujarAgente(listaAristaAux[0].getVerticeOrigen().getUbicacion(),Color.Aqua,bitmapAnimacion);//Inicial
				for(int i = 0; i < listaAristaAux.Count;i++){
					//DibujarLineaDDA(listaAristaAux[i].getVerticeOrigen().getUbicacion(),listaAristaAux[i].getVerticeDestino().getUbicacion()
					//,bitmapAnimacion,Color.FromArgb(125,numeroCrecimiento,100));
					//color+= numeroCrecimiento;
					imagenGraphics = Graphics.FromImage(bitmapAnimacion);
					listaPuntosArista = listaAristaAux[i].getListaPuntos();
					imagenGraphics.DrawString((i+1).ToString(),new Font("arial",15,FontStyle.Regular)
					                          ,new SolidBrush(Color.Blue),listaPuntosArista[listaPuntosArista.Count/2]);
				}
			}
			else{
				dibujarAgente(agente.getVerticeActual().getUbicacion(),Color.Aqua,bitmapAnimacion);//Inicial
			}
			pictureBoxImagen.Refresh();
		}
		void Button1Click(object sender, EventArgs e)
		{
			VentanaMejorAgente ventanaInfoAgentes;
			ventanaInfoAgentes = new VentanaMejorAgente(depredadores);
			ventanaInfoAgentes.ShowDialog();
			//enviar agentes a la venatana
		}
		//........................................ETAPA 4......................................................
		void dibujarLinea(Bitmap bmp,Color color,int lineaGrueso,Point punto1,Point punto2){
			Graphics imagenGraphics = Graphics.FromImage(bmp);
			Pen pincel = new Pen(color, lineaGrueso);
			
			imagenGraphics.DrawLine(pincel, punto1, punto2);
		}
		void dibujarARM(List<Edge> listaAristas,Color color,int tamanioLinea){
			for(int i = 0; i < listaAristas.Count;i++){
				dibujarLinea(bmpImagen,color,tamanioLinea,listaAristas[i].getVerticeOrigen().getUbicacion()
				             ,listaAristas[i].getVerticeDestino().getUbicacion());
			}
			//pictureBoxImagen.Image = bmpImagen;
		}
		void PictureBoxImagenMouseDoubleClick(object sender, MouseEventArgs e)
		{
			double diferenciaEjeX = (double)imagenOriginal.Width/(double)pictureBoxImagen.Width;
			double diferenciaEjeY = (double)imagenOriginal.Height/(double)pictureBoxImagen.Height;
			clearBitmap(bitmapAnimacion,Color.Transparent);
			Point centroCirculo = new Point((int)((double)e.X * diferenciaEjeX),(int)((double)e.Y * diferenciaEjeY));
			Vertex vertice = grafo.buscarVertice(centroCirculo);
			pintarCirculoApartirCentro(vertice.getUbicacion().X,vertice.getUbicacion().Y,Color.Aquamarine,imagenOriginal,bitmapAnimacion);
			pictureBoxImagen.Refresh();
			pintarCirculoApartirCentro(vertice.getUbicacion().X,vertice.getUbicacion().Y,Color.White,imagenOriginal,bitmapAnimacion);
			
			verticeInicialArm = vertice;
		}
		
		void ButtonEtapa4Click(object sender, EventArgs e)
		{
			VentanaEtapa4 ventana = new VentanaEtapa4(grafo,bmpImagen,imagenOriginal);
			ventana.ShowDialog();
		}

		//-------------------------------------------------------------Etapa 5----------------------------------------------
		void dibujarPresa(Point p, Bitmap bmp){
			
			int r = 15;
			int radiointerior = 8;
			int distBlanca = 12;
			Graphics g =  Graphics.FromImage(bmp);
			Brush brochaTrans = new SolidBrush(Color.Transparent);
			Brush brochaVerde = new SolidBrush(Color.Green);
			Brush brochaBlanca = new SolidBrush(Color.White);
			g =  Graphics.FromImage(bmp);
			g.FillEllipse(brochaVerde,p.X-r, p.Y-r,2*r,2*r);
			g.FillEllipse(brochaBlanca,p.X-distBlanca, p.Y-distBlanca,2*distBlanca,2*distBlanca);
			g.FillEllipse(brochaTrans,p.X-distBlanca, p.Y-distBlanca,2*distBlanca,2*distBlanca);
			g.FillEllipse(brochaVerde,p.X-radiointerior, p.Y-radiointerior,2*radiointerior,2*radiointerior);
		}
		void dibujarDepredador(Point p, Bitmap bmp){
			int r = 15;
			int radiointerior = 8;
			int distBlanca = 12;
			Graphics g =  Graphics.FromImage(bmp);
			Brush brochaTrans = new SolidBrush(Color.Transparent);
			Brush brochaRoja = new SolidBrush(Color.Red);
			Brush brochaBlanca = new SolidBrush(Color.White);
			g =  Graphics.FromImage(bmp);
			g.FillEllipse(brochaRoja,p.X-r, p.Y-r,2*r,2*r);
			g.FillEllipse(brochaBlanca,p.X-distBlanca, p.Y-distBlanca,2*distBlanca,2*distBlanca);
			g.FillEllipse(brochaTrans,p.X-distBlanca, p.Y-distBlanca,2*distBlanca,2*distBlanca);
			g.FillEllipse(brochaRoja,p.X-radiointerior, p.Y-radiointerior,2*radiointerior,2*radiointerior);
		}
		void dibujarDistanciasMinimas(Lista<ElementoDijkstra> vectorDijkstra){
			for(int i = 0; i < vectorDijkstra.Count;i++){
				if(vectorDijkstra[i].getProveniente()!= null){
					dibujarLinea(bitmapAnimacion,Color.Black,5,vectorDijkstra[i].getProveniente().getUbicacion(),vectorDijkstra[i].getVertice().getUbicacion());
				}
			}
			pictureBoxImagen.Refresh();
		}

		void verificarRecorrido(List<Edge> listaAristas){
			for(int i = 0; i < listaAristas.Count;i++){
				if(FuncionesUtiles.distanciaEntrePuntos(listaAristas[i].getVerticeDestino().getUbicacion(),listaAristas[i].getListaPuntos()[0])<
				   FuncionesUtiles.distanciaEntrePuntos(listaAristas[i].getVerticeOrigen().getUbicacion(),listaAristas[i].getListaPuntos()[0])){
					listaAristas[i].getListaPuntos().Reverse();
				}
			}
		}
		bool vieneDepredadorDeVerticeDestino(){
			for(int i = 0; i < depredadores.Count;i++){
				if(depredadores[i].getAristaActual().getId() == (presa.getAristaActual().getId()*-1)){
					return true;
				}
			}
			return false;
		}
		bool hayDepredadorCerca(){
			int distanciaCerca;
			//la distancia que se consideraba cerca era el punto mas cercano del que estaba la presa
			if(FuncionesUtiles.distanciaEntrePuntos(presa.getPosicionActualArista(),presa.getAristaActual().getVerticeDestino().getUbicacion())
			   < FuncionesUtiles.distanciaEntrePuntos(presa.getPosicionActualArista(),presa.getAristaActual().getVerticeOrigen().getUbicacion())){
				distanciaCerca = presa.getAristaActual().getVerticeDestino().getCircle().getRadio();
			}
			else{
				distanciaCerca = presa.getAristaActual().getVerticeOrigen().getCircle().getRadio();
			}
			for(int i = 0; i < depredadores.Count;i++){
				if(FuncionesUtiles.distanciaEntrePuntos(presa.getPosicionActualArista(),depredadores[i].getPosicionActualArista()) <= distanciaCerca*2){
					return true;
				}
			}
			return false;
		}
		bool estaEnCentroDeVertice(Point punto){
			for(int i = 0; i < listaCirculos.Count;i++){
				if(FuncionesUtiles.distanciaEntrePuntos(punto,listaCirculos[i].getCentro()) < listaCirculos[i].getRadio()){
					return true;
				}
			}
			return false;
		}
		int calcularSiPresaLlegaAntes(){
			int distanciaMenorDpredador = int.MaxValue;
			Vertex verticeDestinoPresa;
			verticeDestinoPresa = presa.getAristaActual().getVerticeDestino();
			for(int i = 0; i < depredadores.Count;i++){
				//revisa que no venga depredadores de las aristas adyascentes del vertice destino del agente
				for(int j = 0; j < verticeDestinoPresa.getListaAristas().Count;j++){
					//si se quita esta parte de codigo se ahorra una validacion importante de cuando un depredador regresa
					/*if(presa.getAristaActual().getId() == (verticeDestinoPresa.getListaAristas()[j].getId()*-1) ){
						continue;
					}*/
					if(depredadores[i].getAristaActual().getId() == (verticeDestinoPresa.getListaAristas()[j].getId()*-1)){
						if(FuncionesUtiles.distanciaEntrePuntos(depredadores[i].getPosicionActualArista(),
						                                        depredadores[i].getAristaActual().getVerticeDestino().getUbicacion()) < distanciaMenorDpredador){
							distanciaMenorDpredador = (int)FuncionesUtiles.distanciaEntrePuntos(depredadores[i].getPosicionActualArista(),
							                                                                    depredadores[i].getAristaActual().getVerticeDestino().getUbicacion())+1;
						}
					}
				}
			}
			//se obtiene la distancia que tardara el depredadro que este mas cerca(arriba)
			
			//se revisa si el depredador llega antes
			//Point puntoCominezoZonaSegura = presa.getAristaActual().getVerticeDestino().getUbicacion() -
			if((int)FuncionesUtiles.distanciaEntrePuntos(presa.getPosicionActualArista(),presa.getAristaActual().getVerticeDestino().getUbicacion())-presa.getAristaActual().getVerticeDestino().getCircle().getRadio() <distanciaMenorDpredador){
				//llega antes
				return (int)FuncionesUtiles.distanciaEntrePuntos(presa.getPosicionActualArista(),presa.getAristaActual().getVerticeDestino().getUbicacion());
			}
			else{
				//lega despues
				return distanciaMenorDpredador *-1;
			}
		}
		
		void ButtonMostrarInformacionClick(object sender, EventArgs e)
		{
			InformacionAnimacion infoAnimacion;
			if(indiceDepredadorGanador!= int.MaxValue && aristaMuertePresa != null){
				infoAnimacion = new InformacionAnimacion(presa,depredadores[indiceDepredadorGanador],aristaMuertePresa);
			}
			else{
				infoAnimacion = new InformacionAnimacion(presa,null,null);
			}
			infoAnimacion.Show();
		}
		//------------------------------------------------------Etapa 6 ------------------------------------------------------
		void buttonFuerzaVsDivideClick(object sender, EventArgs e)
		{
			ComparacionPuntosMasCercanos comparacion = new ComparacionPuntosMasCercanos(listaCirculos,imagenOriginal,bmpImagen);
			comparacion.ShowDialog();
		}
		void ButtonBfsClick(object sender, EventArgs e)
		{
			int  i = 0;
			List<Edge> aristas = null;
			while(i < grafo.getListaVertices().Count){
				aristas = grafo.recorridoAnchura(grafo.getListaVertices()[i]);
				if(aristas != null){
					break;
				}
				i++;
			}
			if(aristas != null){
				pintarCirculoApartirCentro(grafo.getListaVertices()[i].getUbicacion().X,grafo.getListaVertices()[i].getUbicacion().Y,
				                           Color.Blue,imagenOriginal,bmpImagen);
				dibujarARM(aristas,Color.Black,6);
			}
			else{
				MessageBox.Show("No se puede crear ");
			}
			pictureBoxImagen.BackgroundImage = bmpImagen;
			pictureBoxImagen.Refresh();
		}
		//------------------------------------------------------ETAPA 7-----------------------------------------------------
		
		void ButtonCrearAgentesClick(object sender, EventArgs e)
		{
			if((int)numericUpDownAgentes.Value == 0 ){
				MessageBox.Show("No se pueden crear cero agentes","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
			else if((int)numericUpDownAgentes.Value <= listaCirculos.Count){
				elegirVerticesInicialesDepredadores();
			}
			else{
				MessageBox.Show("No se pueden crear mas agentes que vertices","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
		void elegirVerticesInicialesDepredadores(){
			depredadores.Clear();
				verticesDisponibles = new List<Vertex>();
				int indice;
				Agente agente;
				if(radioButtonElegirOrigen.Checked){
					buttonAnimar.Enabled = false;
				}
				if(radioButtonNoElegirOrigen.Checked){
					buttonConfirmarOrigenes.Enabled = true;
				}
				Random rand = new Random();
				bool estaLibre = false;
				//etapa 5
				if(presas.Count != 0){
					//si ya hay una presa y se quieren crear la misma cantidad de depredadores que de vertices
					if((presas.Count + (int)numericUpDownAgentes.Value) > listaCirculos.Count){
						MessageBox.Show("La presas y depredadores exceden la cantidad de vertices");
						return;
					}
					//se obtienen los ocupados ver todas las presas
					for(int i = 0;i < grafo.getListaVertices().Count;i++){
						estaLibre = true;
						for(int j = 0; j < presas.Count;j++){
							if(presas[j].getVerticeActual() == null){
								estaLibre = true;
							}
							else if(grafo.getListaVertices()[i].getId() == presas[j].getVerticeActual().getId()){
								estaLibre = false;
							}	
						}
						if(estaLibre){
							verticesDisponibles.Add(grafo.getListaVertices()[i]);
						}
					}
				}
				else{
					for(int i = 0;i < grafo.getListaVertices().Count;i++){
						verticesDisponibles.Add(grafo.getListaVertices()[i]);
					}
				}
				
				//se eligen los vertices iniciales
				if(radioButtonNoElegirOrigen.Checked){
					for(int i = 0; i < (int)numericUpDownAgentes.Value;i++){
						indice = rand.Next(0, verticesDisponibles.Count);
						agente = new Agente(verticesDisponibles[indice],i);
						depredadores.Add(agente);
						verticesDisponibles.Remove(verticesDisponibles[indice]);
					}
					
					dibujarPresasYDepredadores();
					actualizarDataGridViewDepredadores();
					for(int i = 0; i < depredadores.Count;i++){
						dataGridViewDepredadores.Rows[i].Cells[1].Value = depredadores[i].getVerticeActual().getId().ToString();
						dataGridViewDepredadores.Rows[i].Cells[1].ReadOnly = true;	
					}
					buttonAnimar.Enabled = true;
					buttonConfirmarOrigenes.Enabled = false;
					pictureBoxImagen.Refresh();	
					caminoDepredadoresConfirmados = true;
			
				}
				if(radioButtonElegirOrigen.Checked){
					for(int i = 0; i < (int)numericUpDownAgentes.Value;i++){
						agente = new Agente(null,null,i);
						depredadores.Add(agente);
					}
					actualizarDataGridViewDepredadores();
					buttonConfirmarOrigenes.Enabled = true;
					buttonAnimar.Enabled = false;
				}
		}
		
		void crearCaminosParaAgentes(){//depredadores
			List<Vertex> verticesDisponibles = new List<Vertex>();
			Random rand = new Random();
			int indice;
			
			//se limpian los caminos De los depredadores
			for(int i = 0; i < depredadores.Count;i++){
				depredadores[i].limpiarCaminoCompleto();
			}
			
			if(radioButtonAleatorio.Checked){
				for(int i = 0; i < depredadores.Count;i++){
					List<Edge> aristasCopia = new List<Edge>(depredadores[i].getVerticeActual().getListaAristas());
					List<Edge> aristasPosibles = new List<Edge>(aristasCopia);
					while(aristasPosibles.Count != 0 && (depredadores[i].obtenerCantidadVertices() < grafo.getListaVertices().Count)){
						indice = rand.Next(0, aristasPosibles.Count);
						depredadores[i].agregarAristaCamino(aristasPosibles[indice]);
						depredadores[i].setVerticeActual(aristasPosibles[indice].getVerticeDestino());
						aristasCopia = depredadores[i].getVerticeActual().getListaAristas();
						aristasPosibles.Clear();
						for(int j = 0; j < aristasCopia.Count;j++){
							if(!depredadores[i].aristaYaVisitada(aristasCopia[j])){
								aristasPosibles.Add(aristasCopia[j]);
							}
						}
					}
					verificarRecorrido(depredadores[i].getCamino());
				}
				caminoDepredadoresConfirmados = true;
				if(caminoDepredadoresConfirmados && caminoPresasConfirmados){
					buttonAnimarTodo.Enabled = true;
				}
				else{
					buttonAnimarTodo.Enabled = false;
				}
			}
			if(radioButtonDfs.Checked){
				for(int i = 0; i < depredadores.Count;i++){
					List<Edge>caminoCompleto;
					caminoCompleto = grafo.crearCaminoDeListaDeVertices(grafo.busquedaProfundidad(depredadores[i].getVerticeActual()));
					verificarRecorrido(caminoCompleto);
					depredadores[i].setCaminoCompleto(caminoCompleto);
				}
				caminoDepredadoresConfirmados = false;
			}
			if(radioButtonBioInspirado.Checked){
				
			}
		}
		void ButtonConfirmarOrigenesClick(object sender, EventArgs e)
		{
			int origen = 0;
			int indiceDepredador = 0;
			//el boton se activa cuando 
			for(int i = 0; i < depredadores.Count;i++){
				if(dataGridViewDepredadores.Rows[i].Cells[0].Value== null){
					//seleccionar uno aleatorio que no haya ningun depredado
					MessageBox.Show("Error en el depredador " + i.ToString());
					return;
				}
				if(dataGridViewDepredadores.Rows[i].Cells[1].Value == null){
					MessageBox.Show("Elegir el vertice ORIGEN del depredador:" + i.ToString());
					return;
				}
				//revisar que el origen no este ocupado por otro depredador
				string origenesRepetidos = "";
				for(int j = 0; j < depredadores.Count-1;j++){
					for(int k = j+1; k < depredadores.Count;k++){
						if( System.Convert.ToInt32(dataGridViewDepredadores.Rows[j].Cells[1].Value)
						   == System.Convert.ToInt32(dataGridViewDepredadores.Rows[k].Cells[1].Value)){
							origenesRepetidos += j.ToString() + " - " + k.ToString()+"\n";
						}
					}
				}
				if(origenesRepetidos != ""){
					MessageBox.Show("Depredadores origenes repetidos\n" + origenesRepetidos);
					return;
				}
				
				//revisar que el origen no este ocupado por una presa
				if(presas.Count != 0){
					for(int j = 0; j < depredadores.Count;j++){
						for(int k = 0; k < presas.Count;k++){
							if(System.Convert.ToInt32(dataGridViewDepredadores.Rows[j].Cells[1].Value)
							   == System.Convert.ToInt32(dataGridViewPresas.Rows[k].Cells[1].Value)){
								origenesRepetidos += j + " - " + k +"\n";
							}
						}
					}
					if(origenesRepetidos != ""){
						MessageBox.Show("Depredadores y Presas con origenes repetidos\n" + origenesRepetidos);
						return;
					}
				}
				
				origen = System.Convert.ToInt32(dataGridViewDepredadores.Rows[i].Cells[1].Value);
				indiceDepredador =  System.Convert.ToInt32(dataGridViewDepredadores.Rows[i].Cells[0].Value);
				depredadores[i].setVerticeActual(grafo.getListaVertices()[origen]);
			}
			//dibujar Presas y depredadores
			clearBitmap(bitmapAnimacion,Color.Transparent);
			if(depredadores.Count != 0){
				for(int i = 0; i < depredadores.Count;i++){
					if(depredadores[i].getVerticeActual() != null){
						dibujarDepredador(depredadores[i].getVerticeActual().getUbicacion(),bitmapAnimacion);	
					}
				}
			}
			if(presas.Count != 0){
				for(int i = 0; i < presas.Count;i++){
					if(presas[i].getVerticeActual() != null){
						dibujarPresa(presas[i].getVerticeActual().getUbicacion(),bitmapAnimacion);	
					}
				}
			}
			pictureBoxImagen.Refresh();
			buttonAnimar.Enabled = true;
			caminoDepredadoresConfirmados = true;
			if(caminoDepredadoresConfirmados && caminoPresasConfirmados){
				buttonAnimarTodo.Enabled = true;
			}
			else{
				buttonAnimarTodo.Enabled = false;
			}
		}
		void ButtonAnimarClick(object sender, EventArgs e)
		{
			if(grafo.hayAristas()){
				crearCaminosParaAgentes();
				this.Enabled = false;
				animarCaminosAgentes();
				this.Enabled = true;
				
				buttonInfoAgente.Enabled = true;
			}
			else{
				MessageBox.Show("No hay aristas","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
		void animarCaminosAgentes(){
			int cantidadPixelesAvanzar = 6;
			int contadorAgentesTerminaros = 0;
			indiceDepredadorGanador = int.MaxValue;
			aristaMuertePresa = null;
			if(radioButtonBioInspirado.Checked){
				for(int i = 0; i < depredadores.Count;i++){
					depredadores[i].inicializarVariablesAnimacion();
				}
				while(true){
					for(int i = 0; i < depredadores.Count;i++){
						depredadores[i].tomarDesicion(presas);
						dibujarDepredador(depredadores[i].getPosicionActualArista(),bitmapAnimacion);
					}
					pictureBoxImagen.Refresh();
					clearBitmap(bitmapAnimacion,Color.Transparent);
				}
			}
			else{
				for(int i = 0; i < depredadores.Count;i++){
					depredadores[i].inicializarVariablesAnimacion();
					verificarRecorrido(depredadores[i].getCamino());
				}
				while(contadorAgentesTerminaros != depredadores.Count){
					contadorAgentesTerminaros = 0;
					for(int i = 0; i < depredadores.Count;i++){
						if(depredadores[i].CaminoCompletado()){
							contadorAgentesTerminaros++;
						}
						else{
							//dibujarDepredador(depredadores[i].getPosicionActualArista(),bitmapAnimacion);
							depredadores[i].AvanzarPixelesArista(cantidadPixelesAvanzar);//se modifica el camino completo
						}
						dibujarDepredador(depredadores[i].getPosicionActualArista(),bitmapAnimacion);
					}
					pictureBoxImagen.Refresh();
					clearBitmap(bitmapAnimacion,Color.Transparent);
				}	
			}
			dibujarPresasYDepredadores();
		}
		void actualizarDataGridViewDepredadores(){
			//limpiar
			
			while(dataGridViewDepredadores.RowCount != 0){
				dataGridViewDepredadores.Rows.RemoveAt(dataGridViewDepredadores.CurrentRow.Index);
			}
			int fila;
			dataGridViewDepredadores.AllowUserToAddRows = true;
			for(int i = 0; i < depredadores.Count;i++){
				fila = dataGridViewDepredadores.Rows.Add();
				
				DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();
				for(int j = 0; j < listaCirculos.Count;j++){
					cmb.Items.Add(listaCirculos[j].getId().ToString());
				}
				dataGridViewDepredadores.Rows[fila].Cells[0].Value = depredadores[i].getId();
				dataGridViewDepredadores.Rows[fila].Cells[1] = cmb;
				dataGridViewDepredadores.Rows[fila].Cells[1].Value = "0";
			}
			dataGridViewDepredadores.AllowUserToAddRows = false;
		}
		
		void ButtonCrearPresaClick(object sender, EventArgs e)
		{
			Agente presa;
			DialogResult eleccion;
			if((int)numericUpDownPresas.Value == 0){
				presas.Clear();
				while(dataGridViewPresas.RowCount != 0){
					dataGridViewPresas.Rows.RemoveAt(dataGridViewPresas.CurrentRow.Index);
				}
			}
			else if((int)numericUpDownPresas.Value > 0 && (int)numericUpDownPresas.Value <= listaCirculos.Count){
				if((depredadores.Count + (int)numericUpDownPresas.Value) > listaCirculos.Count){
					MessageBox.Show("La presas y depredadores exceden la cantidad de vertices");
					return;
				}
				
				if(dataGridViewPresas.Rows.Count != 0){
					eleccion = MessageBox.Show("Si se crean Nuevas Presas las anteriores se eliminaran\n\n¿Seguro que desea crear nuevas Presas?"
				                ,"Informacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if(eleccion == DialogResult.Yes){
						presas.Clear();
						for(int i = 0; i < (int)numericUpDownPresas.Value;i++){
							presa = new Agente(null,null,i);
							presas.Add(presa);
						}
			
						buttonConfirmarCamino.Enabled = true;
						buttonAnimarPresa.Enabled = false;
						actualizarDataGridViewPresas();	
					}
					else{
						buttonAnimarPresa.Enabled = false;
						buttonAnimarTodo.Enabled = false;
					}
				}
				else{
					for(int i = 0; i < (int)numericUpDownPresas.Value;i++){
							presa = new Agente(null,null,i);
							presas.Add(presa);
						}
			
						buttonConfirmarCamino.Enabled = true;
						buttonAnimarPresa.Enabled = false;
						actualizarDataGridViewPresas();	
				}
			}
			else{
				MessageBox.Show("No se pueden crear mas presas que vertices","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
		void ButtonAnimarPresaClick(object sender, EventArgs e)
		{
			animarPresas();
		}
		
		void NumericUpDownPresasValueChanged(object sender, EventArgs e)
		{
			buttonConfirmarCamino.Enabled = false;
			buttonAnimarPresa.Enabled = false;
			
			while(dataGridViewPresas.RowCount != 0){
				dataGridViewPresas.Rows.RemoveAt(dataGridViewPresas.CurrentRow.Index);
			}
			
			if((int)numericUpDownPresas.Value == 0){
				
			}
			else if((int)numericUpDownPresas.Value <= listaCirculos.Count){
				if((depredadores.Count + (int)numericUpDownPresas.Value) > listaCirculos.Count){
					MessageBox.Show("La presas y depredadores exceden la cantidad de vertices");
					return;
				}
			}
			else{
				numericUpDownPresas.Value = listaCirculos.Count;
				MessageBox.Show("No se pueden crear mas Presas que vertices","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
		void ButtonConfirmarCaminoClick(object sender, EventArgs e)
		{
			int origen = 0;
			int destino = 0;
			int indicePresa = 0;
			List<int> listaInt;
			if(radioButtonDijkstra.Checked){
				for(int i = 0; i < presas.Count;i++){
					if(dataGridViewPresas.Rows[i].Cells[0].Value== null){
						//seleccionar uno aleatorio que no haya ningun depredado
						MessageBox.Show(i.ToString());
						return;
					}
					if(dataGridViewPresas.Rows[i].Cells[1].Value == null){//seleccionar uno aleatorio que no haya ningun depredado
						MessageBox.Show("Elegir el vertice ORIGEN de la presa:" +i.ToString());
						return;
					}
					if(dataGridViewPresas.Rows[i].Cells[2].Value == null){
						MessageBox.Show("Elegir el vertice DESTINO de la presa:" +i.ToString());
						return;
					}
					
					//Validaciones

					//revisar que el origen no este ocupado por otro depredador
					string origenesRepetidos = "";
					for(int j = 0; j < presas.Count-1;j++){
						for(int k = j+1; k < presas.Count;k++){
							if( System.Convert.ToInt32(dataGridViewPresas.Rows[j].Cells[1].Value)
							   == System.Convert.ToInt32(dataGridViewPresas.Rows[k].Cells[1].Value)){
								if(presas[j].getEsPrimerRecorrido() && presas[k].getEsPrimerRecorrido()){
									origenesRepetidos += j.ToString() + " - " + k.ToString()+"\n";	
								}
							}
						}
					}
					if(origenesRepetidos != ""){
						MessageBox.Show("Presas con origenes repetidos\n" + origenesRepetidos);
						return;
					}
					
					//revisar que el origen no este ocupado por un depredador
					if(depredadores.Count != 0){
						for(int j = 0; j < presas.Count;j++){
							for(int k = 0; k < depredadores.Count;k++){
								if(System.Convert.ToInt32(dataGridViewPresas.Rows[j].Cells[1].Value)
								   == System.Convert.ToInt32(dataGridViewDepredadores.Rows[k].Cells[1].Value)){
									origenesRepetidos += j + " - " + k +"\n";
								}
							}
						}
						if(origenesRepetidos != ""){
							MessageBox.Show("Presas y Depredadores con origenes repetidos\n" + origenesRepetidos);
							return;
						}
					}
					
					//Validaciones
					origen = System.Convert.ToInt32(dataGridViewPresas.Rows[i].Cells[1].Value);
					destino = System.Convert.ToInt32(dataGridViewPresas.Rows[i].Cells[2].Value);
					indicePresa =  System.Convert.ToInt32(dataGridViewPresas.Rows[i].Cells[0].Value);
					//falta dijkstra
					if(origen != destino){
						caminosMinimos = grafo.obtenerPesosMinimos(grafo.getListaVertices()[origen]);
						caminoPresa = grafo.crearCaminoDijkstra(grafo.getListaVertices()[origen],grafo.getListaVertices()[destino],caminosMinimos);
						if(caminoPresa == null){
							MessageBox.Show("La presa "+ i.ToString() + " no puede llegar al destino");
							return;
						}
						verificarRecorrido(caminoPresa);
						presas[indicePresa].setVerticeActual(grafo.getListaVertices()[origen]);
						presas[indicePresa].setVerticeDestino(grafo.getListaVertices()[destino]);
						presas[indicePresa].setCaminoCompleto(caminoPresa);	
					}
					else{//origen y destino es igual
						presas[indicePresa].setVerticeActual(grafo.getListaVertices()[origen]);
						presas[indicePresa].setVerticeDestino(grafo.getListaVertices()[destino]);
					}
					buttonAnimarPresa.Enabled = true;
				}
				caminoPresasConfirmados = true;
			}
			if(radioButtonFloyd.Checked){
				for(int i = 0; i < presas.Count;i++){
					if(dataGridViewPresas.Rows[i].Cells[0].Value== null){
						//seleccionar uno aleatorio que no haya ningun depredado
						MessageBox.Show(i.ToString());
						return;
					}
					if(dataGridViewPresas.Rows[i].Cells[1].Value == null){//seleccionar uno aleatorio que no haya ningun depredado
						MessageBox.Show("Elegir el vertice ORIGEN de la presa:" +i.ToString());
						return;
					}
					if(dataGridViewPresas.Rows[i].Cells[2].Value == null){
						MessageBox.Show("Elegir el vertice DESTINO de la presa:" +i.ToString());
						return;
					}
					
					//Validaciones

					//revisar que el origen no este ocupado por otro depredador
					string origenesRepetidos = "";
					for(int j = 0; j < presas.Count-1;j++){
						for(int k = j+1; k < presas.Count;k++){
							if( System.Convert.ToInt32(dataGridViewPresas.Rows[j].Cells[1].Value)
							   == System.Convert.ToInt32(dataGridViewPresas.Rows[k].Cells[1].Value)){
								if(presas[j].getEsPrimerRecorrido() && presas[k].getEsPrimerRecorrido()){
									origenesRepetidos += j.ToString() + " - " + k.ToString()+"\n";	
								}
							}
						}
					}
					if(origenesRepetidos != ""){
						MessageBox.Show("Presas con origenes repetidos\n" + origenesRepetidos);
						return;
					}
					
					//revisar que el origen no este ocupado por un depredador
					if(depredadores.Count != 0){
						for(int j = 0; j < presas.Count;j++){
							for(int k = 0; k < depredadores.Count;k++){
								if(System.Convert.ToInt32(dataGridViewPresas.Rows[j].Cells[1].Value)
								   == System.Convert.ToInt32(dataGridViewDepredadores.Rows[k].Cells[1].Value)){
									origenesRepetidos += j + " - " + k +"\n";
								}
							}
						}
						if(origenesRepetidos != ""){
							MessageBox.Show("Presas y Depredadores con origenes repetidos\n" + origenesRepetidos);
							return;
						}
					}
					//Validaciones
					origen = System.Convert.ToInt32(dataGridViewPresas.Rows[i].Cells[1].Value);
					destino = System.Convert.ToInt32(dataGridViewPresas.Rows[i].Cells[2].Value);
					indicePresa =  System.Convert.ToInt32(dataGridViewPresas.Rows[i].Cells[0].Value);
					if(origen != destino){
						if(caminosMinimosFloyd[origen,destino] == -1){
							MessageBox.Show("La presa " + i.ToString() +" No puede llegar al destino");
							return;
						}
						listaInt = grafo.crearCaminoEnterosFloyd(caminosMinimosFloyd,grafo.getListaVertices()[origen],grafo.getListaVertices()[destino]);
					
						List<Edge> camino = grafo.crearCaminoFloyd(listaInt);
						presas[indicePresa].setVerticeActual(grafo.getListaVertices()[origen]);
						presas[indicePresa].setVerticeDestino(grafo.getListaVertices()[destino]);
						presas[indicePresa].setCaminoCompleto(camino);	
					}
					else{//origen y destino es igual
						presas[indicePresa].setVerticeActual(grafo.getListaVertices()[origen]);
						presas[indicePresa].setVerticeDestino(grafo.getListaVertices()[destino]);
					}
					buttonAnimarPresa.Enabled = true;
				}
				caminoPresasConfirmados = true;
			}
			if(caminoDepredadoresConfirmados && caminoPresasConfirmados){
				buttonAnimarTodo.Enabled = true;
			}
			else{
				buttonAnimarTodo.Enabled = false;
			}
			BloquearDestinosDataGridViewPresas();
			BloquearOrigenesDataGridViewPresas();
			dibujarPresasYDepredadores();
		}
		void animarPresas(){
			int presasConCaminoCompleto;
			int cantidadPixelesAvanzar = 6;
			if(presas.Count == 0){
				MessageBox.Show("No hay Presas :O");
			}
			for(int i = 0; i < presas.Count;i++){
				presas[i].inicializarVariablesAnimacion();
			}
			presasConCaminoCompleto = 0;
			while(presasConCaminoCompleto != presas.Count){
				presasConCaminoCompleto = 0;
				for(int i = 0; i < presas.Count;i++){
					if(presas[i].CaminoCompletado()){
						presasConCaminoCompleto++;
					}
				}
				if(presasConCaminoCompleto == presas.Count){
					break;
				}
				for(int i = 0; i < presas.Count;i++){
					if(!presas[i].CaminoCompletado()){
						presas[i].AvanzarPixelesArista(cantidadPixelesAvanzar);
					}
					if(presas[i].getCamino().Count != 0){
						dibujarPresa(presas[i].getPosicionActualArista(),bitmapAnimacion);	
					}
					else{
						dibujarPresa(presas[i].getVerticeActual().getUbicacion(),bitmapAnimacion);
					}
				}
				
				//dibujarPresa(presa.getPosicionActualArista(),bitmapAnimacion);
				
				pictureBoxImagen.Refresh();
				clearBitmap(bitmapAnimacion,Color.Transparent);
			}
			
			for(int i = 0; i < presas.Count;i++){
				presas[i].setEsPrimerRecorrido(false);
				presas[i].setVerticeActual(presas[i].getVerticeDestino());
				presas[i].limpiarCaminoCompleto();
			}
			actualizarDataGridViewPresas();
			buttonAnimar.Enabled = false;
			buttonAnimarPresa.Enabled = false;
			
			caminoPresasConfirmados = false;
			if(caminoDepredadoresConfirmados && caminoPresasConfirmados){
				buttonAnimarTodo.Enabled = true;
			}
			else{
				buttonAnimarTodo.Enabled = false;
			}
			DesbloquearDestinosDataGridViewPresas();
		}

		void dibujarPresasYDepredadores(){
			clearBitmap(bitmapAnimacion,Color.Transparent);
			if(depredadores.Count != 0){
				for(int i = 0; i < depredadores.Count;i++){
					if(depredadores[i].getVerticeActual() != null){
						dibujarDepredador(depredadores[i].getVerticeActual().getUbicacion(),bitmapAnimacion);	
					}
				}
			}
			if(presas.Count != 0){
				for(int i = 0; i < presas.Count;i++){
					if(presas[i].getVerticeActual() != null){
						dibujarPresa(presas[i].getVerticeActual().getUbicacion(),bitmapAnimacion);	
					}
				}
			}
			pictureBoxImagen.Refresh();
			
		}
		void actualizarDataGridViewPresas(){
			//limpiar
			
			while(dataGridViewPresas.RowCount != 0){
				dataGridViewPresas.Rows.RemoveAt(dataGridViewPresas.CurrentRow.Index);
			}
			int fila;
			dataGridViewPresas.AllowUserToAddRows = true;
			for(int i = 0; i < presas.Count;i++){
				
				fila = dataGridViewPresas.Rows.Add();
				
				DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();
				DataGridViewComboBoxCell cmb2 = new DataGridViewComboBoxCell();
				for(int j = 0; j < listaCirculos.Count;j++){
					cmb.Items.Add(listaCirculos[j].getId().ToString());
					cmb2.Items.Add(listaCirculos[j].getId().ToString());
				}
				dataGridViewPresas.Rows[fila].Cells[0].Value = presas[i].getId();
				dataGridViewPresas.Rows[fila].Cells[1] = cmb;
				dataGridViewPresas.Rows[fila].Cells[2] = cmb2;
				
				if(!presas[i].getEsPrimerRecorrido()){
					dataGridViewPresas.Rows[fila].Cells[1].Value = presas[i].getVerticeActual().getId().ToString();
					dataGridViewPresas.Rows[fila].Cells[1].ReadOnly = true;
					dataGridViewPresas.Rows[fila].Cells[2].Value = "0";	
				}
				else{
					dataGridViewPresas.Rows[fila].Cells[1].Value = "0";
					dataGridViewPresas.Rows[fila].Cells[2].Value = "0";	
				}
			}
			dataGridViewPresas.AllowUserToAddRows = false;
		}
		void BloquearDestinosDataGridViewPresas(){
			if(dataGridViewPresas.RowCount != 0){
				dataGridViewPresas.AllowUserToAddRows = true;
				for(int i = 0; i < presas.Count;i++){
						dataGridViewPresas.Rows[i].Cells[2].ReadOnly = true;	
				}
				dataGridViewPresas.AllowUserToAddRows = false;
			}
		}
		void DesbloquearDestinosDataGridViewPresas(){
			if(dataGridViewPresas.RowCount != 0){
				dataGridViewPresas.AllowUserToAddRows = true;
				for(int i = 0; i < presas.Count;i++){
						dataGridViewPresas.Rows[i].Cells[2].ReadOnly = false;	
				}
				dataGridViewPresas.AllowUserToAddRows = false;
			}
		}
		void BloquearOrigenesDataGridViewPresas(){
			if(dataGridViewPresas.RowCount != 0){
				dataGridViewPresas.AllowUserToAddRows = true;
				for(int i = 0; i < presas.Count;i++){
					dataGridViewPresas.Rows[i].Cells[1].ReadOnly = true;	
				}
				dataGridViewPresas.AllowUserToAddRows = false;
			}
		}
		void DesbloquearOrigenesDataGridViewPresas(){
			if(dataGridViewPresas.RowCount != 0){
				dataGridViewPresas.AllowUserToAddRows = true;
				for(int i = 0; i < presas.Count;i++){
						dataGridViewPresas.Rows[i].Cells[1].ReadOnly = false;	
				}
				dataGridViewPresas.AllowUserToAddRows = false;
			}
		}
		
		void dibujarDepredadorIndicadores(Point p, Bitmap bmp){
			int r = 12;
			int radiointerior = 6;
			int distBlanca = 9;
			Pen lapiz1= new Pen(Color.Brown,5);
			Pen lapiz2 = new Pen(Color.Ivory,5);
			
			int R = 255;
			int G = 0;
			int B = 0;
			
			Brush brochaCercana = new SolidBrush(Color.FromArgb(150, (byte)R, (byte)G, (byte)B));
			Brush brochaMediana = new SolidBrush(Color.FromArgb(100, (byte)(R), (byte)(G+100), (byte)B));
			Brush brochaLejana = new SolidBrush(Color.FromArgb(50, (byte)(R), (byte)(G+200), (byte)B));
			
			Graphics g;
			Brush whiteBrush = new SolidBrush(Color.White);
			Brush brochaTrans = new SolidBrush(Color.Transparent);
			Brush brochaVerde = new SolidBrush(Color.Green);
			Brush brocha1 = new SolidBrush(Color.Red);
			g =  Graphics.FromImage(bmp);
			
			int distCerca = 100;
			int distMedia= 200;
			int distLejana = 300;
			g.FillEllipse(brochaCercana,p.X-r-distLejana, p.Y-r-distLejana,2*r+(distLejana*2),2*r+(distLejana*2));
			g.FillEllipse(brochaMediana,p.X-r-distMedia, p.Y-r-distMedia,2*r+(distMedia*2),2*r+(distMedia*2));
			g.FillEllipse(brochaLejana,p.X-r-distCerca, p.Y-r-distCerca,2*r+(distCerca*2),2*r+(distCerca*2));
			
			
			g.FillEllipse(brochaVerde,p.X-r, p.Y-r,2*r,2*r);
			g.FillEllipse(brochaVerde,p.X-r, p.Y-r,2*r,2*r);
			g.FillEllipse(whiteBrush,p.X-distBlanca, p.Y-distBlanca,2*distBlanca,2*distBlanca);
			g.FillEllipse(brochaTrans,p.X-distBlanca, p.Y-distBlanca,2*distBlanca,2*distBlanca);
			g.FillEllipse(brochaVerde,p.X-radiointerior, p.Y-radiointerior,2*radiointerior,2*radiointerior);
			
			//indicadores
			g.DrawLine(lapiz1,p.X,p.Y,p.X+5,p.Y+5);
			g.DrawLine(lapiz2,p.X,p.Y,p.X-5,p.Y-5);
		}		
		bool presaCapturada(Agente presaRevisar){
			for(int i = 0; i < depredadores.Count;i++){
				if(presaRevisar.getCamino().Count != 0){
					if(depredadores[i].getPosicionActualArista() == presaRevisar.getPosicionActualArista() && !presaRevisar.estaEnCentroVertice()){
						//indiceDepredadorGanador = i;
						//aristaMuertePresa = depredadores[i].getAristaActual();
						return true;
					}	
				}
			}
			return false;
		}
		void animarPresasYDepredadores(){
			//presa
			int contPixelesAvanzados = 0;
			int constantePixelesAvanzados = 6;//se muestran los agentes cada x piceles avanzados

			if(presas.Count == 0){
				MessageBox.Show("No hay Presas");
				return;
			}
			for(int i = 0; i < presas.Count;i++){
				presas[i].inicializarVariablesAnimacion();
			}
			
			if(depredadores.Count == 0){
				MessageBox.Show("No hay Depredadores");
				return;
			}
			if(radioButtonBioInspirado.Checked){
				bool primerCiclo = true;
				bool presaMuerta = false;
				//Animacion
				int presasTerminaron = 0;
				while(presasTerminaron != presas.Count){
					presasTerminaron = 0;
					for(int i = 0;i < presas.Count;i++){
						presaMuerta = false;
						presas[i].AvanzarPixelesArista(1);
						if(presas[i].CaminoCompletado() == true){
							presasTerminaron++;
						}
						if(!primerCiclo){
							if(presaCapturada(presas[i])){
								presas.RemoveAt(i);	
								presaMuerta = true;
							}	
						}
						if(!presaMuerta){
							dibujarPresa(presas[i].getPosicionActualArista(),bitmapAnimacion);	
						}
					}
					primerCiclo= false;
					for(int j = 0;j < depredadores.Count;j++){
						if(contPixelesAvanzados %5 == 0){
							depredadores[j].guardarUbicaciones(presas);
						}
						depredadores[j].tomarDesicion(presas);
						dibujarDepredadorIndicadores(depredadores[j].getPosicionActualArista(),bitmapAnimacion);
					}
					for(int i = 0;i < presas.Count;i++){
						if(presaCapturada(presas[i])){
							presas.RemoveAt(i);	
						}
					}
		
					if(contPixelesAvanzados %constantePixelesAvanzados == 0){
						pictureBoxImagen.Refresh();
					}
					clearBitmap(bitmapAnimacion,Color.Transparent);
					contPixelesAvanzados++;
				}		
			}
			else{
				//depredadores
				crearCaminosParaAgentes();//depredadores
	
				for(int i = 0; i < depredadores.Count;i++){
					depredadores[i].inicializarVariablesAnimacion();
					verificarRecorrido(depredadores[i].getCamino());
				}
				//depredadores
				
				//Animacion
				int presasTerminaron = 0;
				while(presasTerminaron != presas.Count){
					presasTerminaron = 0;
					for(int i = 0;i < presas.Count;i++){
						if(presas[i].CaminoCompletado() == true){
							presasTerminaron++;
						}
						else{
							presas[i].AvanzarPixelesArista(1);
						}
						if(presas[i].getCamino().Count == 0){
							dibujarPresa(presas[i].getVerticeActual().getUbicacion(),bitmapAnimacion);
						}
						else{
							dibujarPresa(presas[i].getPosicionActualArista(),bitmapAnimacion);
						}
					}
					for(int i = 0; i < presas.Count;i++){
						if(presaCapturada(presas[i])){
							presas.RemoveAt(i);	
						}
					}
					for(int j = 0;j < depredadores.Count;j++){
						depredadores[j].AvanzarPixelesArista(1);
						dibujarDepredador(depredadores[j].getPosicionActualArista(),bitmapAnimacion);
					}
					for(int i = 0;i < presas.Count;i++){
						if(presaCapturada(presas[i])){
							presas.RemoveAt(i);	
						}
					}
		
					if(contPixelesAvanzados %constantePixelesAvanzados == 0){
						pictureBoxImagen.Refresh();
					}
					clearBitmap(bitmapAnimacion,Color.Transparent);
					contPixelesAvanzados++;
				}
				for(int i = 0; i < presas.Count;i++){
					presas[i].setEsPrimerRecorrido(false);
					presas[i].setVerticeActual(presas[i].getVerticeDestino());
					presas[i].limpiarCaminoCompleto();
				}
				buttonConfirmarCamino.Enabled = true;
				buttonAnimarPresa.Enabled = false;
				
				buttonAnimarTodo.Enabled = false;
				caminoPresasConfirmados = false;
				radioButtonNoElegirOrigen.Select();
				RadioButtonNoElegirOrigenClick(null, null);//para aleatorizar los origenes de los depredadores
				//se actualizan los id de las presas por que al crear camino se genera error
				for(int i = 0; i < presas.Count;i++){
					presas[i].setId(i);
				}
				actualizarDataGridViewPresas();
				dibujarPresasYDepredadores();
				DesbloquearDestinosDataGridViewPresas();
				if(presas.Count == 0){
					buttonConfirmarCamino.Enabled = false;
				}
			}
		}
		void ButtonAnimarTodoClick(object sender, EventArgs e)
		{
			animarPresasYDepredadores();
		}
		void RadioButtonElegirOrigenClick(object sender, EventArgs e)
		{
			if(dataGridViewDepredadores.Rows.Count != 0){
				for(int i = 0; i < depredadores.Count;i++){
					dataGridViewDepredadores.Rows[i].Cells[1].Value = depredadores[i].getVerticeActual().getId().ToString();
					dataGridViewDepredadores.Rows[i].Cells[1].ReadOnly = false;	
				}
				buttonConfirmarOrigenes.Enabled = true;
				buttonAnimar.Enabled = false;
				caminoDepredadoresConfirmados = false;				
			}
			if(caminoDepredadoresConfirmados && caminoPresasConfirmados){
				buttonAnimarTodo.Enabled = true;
			}
			else{
				buttonAnimarTodo.Enabled = false;
			}
		}
		void RadioButtonNoElegirOrigenClick(object sender, EventArgs e)
		{
			//se actualizan
			if(depredadores.Count != 0 ){
				if(dataGridViewDepredadores.Rows.Count != 0){
					elegirVerticesInicialesDepredadores();
					//se actualizan los origenes en el 
					for(int i = 0; i < depredadores.Count;i++){
						dataGridViewDepredadores.Rows[i].Cells[1].ReadOnly = false;	
						dataGridViewDepredadores.Rows[i].Cells[1].Value = depredadores[i].getVerticeActual().getId().ToString();
						dataGridViewDepredadores.Rows[i].Cells[1].ReadOnly = true;	
					}
					buttonConfirmarOrigenes.Enabled = false;
					buttonAnimar.Enabled = true;
					caminoDepredadoresConfirmados = true;						
				}			
			}
			if(caminoDepredadoresConfirmados && caminoPresasConfirmados){
				buttonAnimarTodo.Enabled = true;
			}
			else{
				buttonAnimarTodo.Enabled = false;
			}
		}
		void NumericUpDownAgentesValueChanged(object sender, EventArgs e)
		{
			buttonConfirmarOrigenes.Enabled = false;
			buttonAnimar.Enabled = false;
			depredadores.Clear();
			//limpiar data;
			while(dataGridViewDepredadores.RowCount != 0){
				dataGridViewDepredadores.Rows.RemoveAt(dataGridViewDepredadores.CurrentRow.Index);
			}
		}
		void ButtonFloydDijkstraClick(object sender, EventArgs e)
		{
			//crear la pantalla
			FloydDijkstra pantalla = new FloydDijkstra(grafo,bmpImagen,caminosMinimosFloyd);
			pantalla.ShowDialog();
		}
		}
	}
