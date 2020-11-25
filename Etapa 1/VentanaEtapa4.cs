/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 26/03/2019
 * Time: 09:19 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Etapa_1
{
	public partial class VentanaEtapa4 : Form
	{
		Bitmap bitmapAnimacionDijkstra;
		Bitmap bitmapAnimacionPrim;
		Bitmap fondoDijkstra;
		Bitmap fondoPrim;
		Bitmap fondoPrimOriginal;
		
		Vertex verticeInicialArmDijkstra;
		Vertex verticeInicialArmPrim;
		
		List<Edge> caminoFinalDijkstra;
		List<Edge> caminoFinalPrim;
		List<Edge> armDijkstra;
		List<Edge> armPrim;
		
		Graph grafo;
		Bitmap imagenOriginal;
		public VentanaEtapa4(Graph grafoOriginal,Bitmap imagenFondo,Bitmap imagenOriginal)
		{
			InitializeComponent();
			grafo = grafoOriginal;
			this.imagenOriginal = imagenOriginal;
			
			fondoDijkstra = new Bitmap(imagenFondo);
		 	fondoPrim = new Bitmap(imagenFondo);
		 	fondoPrimOriginal = new Bitmap(imagenFondo);
		 		
			pictureBoxDijkstra.BackgroundImage = fondoDijkstra;
			pictureBoxPrim.BackgroundImage = fondoPrim;
			bitmapAnimacionDijkstra = new Bitmap(imagenFondo.Width,imagenFondo.Height);
			bitmapAnimacionPrim = new Bitmap(imagenFondo.Width,imagenFondo.Height);
			
			pictureBoxDijkstra.Image = bitmapAnimacionDijkstra;
			pictureBoxPrim.Image = bitmapAnimacionPrim;
			
			armDijkstra = null;
			armPrim = null;
			//inicialzizar combobox
			comboBoxKruskal.Items.Clear();
			comboBoxPrim.Items.Clear();
			for(int i = 0; i < grafoOriginal.getListaVertices().Count;i++){
				comboBoxKruskal.Items.Add(grafoOriginal.getListaVertices()[i].getId());
				comboBoxPrim.Items.Add(grafoOriginal.getListaVertices()[i].getId());
			}
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
		void clearBitmap(Bitmap bmp, Color c){
			Graphics g =  Graphics.FromImage(bmp);
			g.Clear(c);
		}
		void dibujarAgente(Point punto,Color colorBrocha,Bitmap imagenDibujar){
			int radio = 10;
			Brush brocha = new SolidBrush(colorBrocha);
			Graphics imagen = Graphics.FromImage(imagenDibujar);
			imagen.FillEllipse(brocha,punto.X-radio,punto.Y-radio,radio*2,radio*2);
		}
		void dibujarLinea(Bitmap bmp,Color color,int lineaGrueso,Point punto1,Point punto2){
			Graphics imagenGraphics = Graphics.FromImage(bmp);
			Pen pincel = new Pen(color, lineaGrueso);
            
		    imagenGraphics.DrawLine(pincel, punto1, punto2);
		}
		
		void dibujarARM(List<Edge> listaAristas,Color color,Bitmap imagen){
			for(int i = 0; i < listaAristas.Count;i++){
				dibujarLinea(imagen,color,5,listaAristas[i].getVerticeOrigen().getUbicacion()
				             ,listaAristas[i].getVerticeDestino().getUbicacion());
			}
		}
		
		void dibujarCentroCirculo(int x_c,int y_c,Color colorCentro,Bitmap imagenDibujar){
			int tamanioCentro = 4;
			for(int i = (tamanioCentro*-1); i < tamanioCentro;i++){
				for(int j = (tamanioCentro*-1); j < tamanioCentro;j++){
					imagenDibujar.SetPixel(x_c-i,y_c-j,colorCentro);
				}	
			}
		}

		void ButtonDijkstraArmClick(object sender, EventArgs e)
		{
			if(grafo.hayAristas()){
				armDijkstra = grafo.getArmKruskal();
				clearBitmap(bitmapAnimacionDijkstra,Color.Transparent);
				dibujarARM(armDijkstra,Color.Black,fondoDijkstra);
				pictureBoxDijkstra.Refresh();	
				clearBitmap(bitmapAnimacionDijkstra,Color.Transparent);
				listBoxArmDijkstra.DataSource = armDijkstra;
				labelPesoTotalDijkstraNumero.Text = Math.Round(grafo.calcularPesoArm(armDijkstra),2).ToString();				
			}
			else{
				MessageBox.Show("Kruskal - No hay aristas");
			}
			armDijkstra = grafo.getArmKruskal();
			labelNumeroSubgrafosDijkstra.Text = grafo.getCantidadSubgrafos().ToString();
		}
		void ButtonPrimArmClick(object sender, EventArgs e)
		{
			int indice;
			try{
				indice = Convert.ToInt32(comboBoxPrim.Text);
				if(indice>=0 && indice< grafo.getListaVertices().Count){
					verticeInicialArmPrim = grafo.getListaVertices()[indice];
				}
				else{
					MessageBox.Show("Error en le vertice inicial,Indice fuera de rango");
					return;
				}
			}catch(Exception){
				MessageBox.Show("Error en le vertice inicial,Formato invalido");
				return;
			}
			if(verticeInicialArmPrim != null){
				armPrim = grafo.getArmPrim(verticeInicialArmPrim,bitmapAnimacionPrim);
				if(grafo.hayAristas()){
					fondoPrim = new Bitmap(fondoPrimOriginal);
					pictureBoxPrim.BackgroundImage = fondoPrim;
					clearBitmap(bitmapAnimacionPrim,Color.Transparent);
					dibujarARM(armPrim,Color.Black,fondoPrim);
					pictureBoxPrim.Refresh();	
					clearBitmap(bitmapAnimacionPrim,Color.Transparent);
					
					listBoxArmPrim.DataSource = armPrim;
					labelPesoTotalPrimNumero.Text = Math.Round(grafo.calcularPesoArm(armPrim),2).ToString();					
				}
				else{
					MessageBox.Show("Prim - No hay aristas");
				}
				labelNumeroSubgrafosPrim.Text = grafo.getCantidadSubgrafos().ToString();
			}
			else{
				MessageBox.Show("Elige vertice inicial","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
	
		void ButtonAnimarPrimClick(object sender, EventArgs e)
		{
			Agente agente;

			int indice;
			try{
				indice = Convert.ToInt32(comboBoxPrim.Text);
				if(indice>=0 && indice< grafo.getListaVertices().Count){
					verticeInicialArmPrim = grafo.getListaVertices()[indice];
				}
				else{
					MessageBox.Show("Error en le vertice inicial,Indice fuera de rango");
					return;
				}
			}catch(Exception){
				MessageBox.Show("Error en le vertice inicial,Formato invalido");
				return;
			}
			if(verticeInicialArmPrim!=null){
				if(armPrim == null){
					MessageBox.Show("Para animar primero CREAR ARM");
					return;
				}
				this.Enabled = false;
				agente = new Agente(verticeInicialArmPrim,0);
			
				caminoFinalPrim = grafo.recorrerArm(verticeInicialArmPrim,armPrim);
				agente.setCaminoCompleto(caminoFinalPrim);
				agente.inicializarVariablesAnimacion();
				
				while(!agente.CaminoCompletado()){
					agente.AvanzarPixelesArista(15);
	
					dibujarAgente(agente.getPosicionActualArista(),Color.White,bitmapAnimacionPrim);
					dibujarAgente(agente.getPosicionActualArista(),Color.Blue,bitmapAnimacionPrim);
					
					pictureBoxPrim.Refresh();
					clearBitmap(bitmapAnimacionPrim,Color.Transparent);
				}
				listBoxCaminoAgentePrim.DataSource = caminoFinalPrim;
				this.Enabled = true;
			}
			else{
				MessageBox.Show("Elige vertice inicial","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
		void ButtonAnimarDijkstraClick(object sender, EventArgs e)
		{
			Agente agente;
			int indice;
			try{
				indice = Convert.ToInt32(comboBoxKruskal.Text);
				if(indice>=0 && indice< grafo.getListaVertices().Count){
					verticeInicialArmDijkstra = grafo.getListaVertices()[indice];
				}
				else{
					MessageBox.Show("Error en le vertice inicial,Indice fuera de rango");
					return;
				}
			}catch(Exception){
				MessageBox.Show("Error en le vertice inicial,Formato invalido");
				return;
			}
			if(verticeInicialArmDijkstra!=null){
				if(armDijkstra == null){
					MessageBox.Show("Para animar primero CREAR ARM");
					return;
				}
				this.Enabled = false;
				agente = new Agente(verticeInicialArmDijkstra,0);
			
				caminoFinalDijkstra = grafo.recorrerArm(verticeInicialArmDijkstra,armDijkstra);
				grafo.verificarRecorrido(caminoFinalDijkstra);
				
				agente.setCaminoCompleto(caminoFinalDijkstra);
				agente.inicializarVariablesAnimacion();
					
				while(!agente.CaminoCompletado()){
					agente.AvanzarPixelesArista(10);
	
					dibujarAgente(agente.getPosicionActualArista(),Color.White,bitmapAnimacionDijkstra);
					dibujarAgente(agente.getPosicionActualArista(),Color.Blue,bitmapAnimacionDijkstra);
					
					pictureBoxDijkstra.Refresh();
					clearBitmap(bitmapAnimacionDijkstra,Color.Transparent);
				}
				
				listBoxCaminoAgenteDijkstra.DataSource = caminoFinalDijkstra;
				this.Enabled = true;
			}
			else{
				MessageBox.Show("Elige vertice inicial","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
		void ComboBoxKruskalSelectedIndexChanged(object sender, EventArgs e)
		{
			int indice = comboBoxKruskal.SelectedIndex;
			clearBitmap(bitmapAnimacionDijkstra,Color.Transparent);
			pintarCirculoApartirCentro(grafo.getListaVertices()[indice].getUbicacion().X,grafo.getListaVertices()[indice].getUbicacion().Y,Color.Aquamarine,imagenOriginal,bitmapAnimacionDijkstra);
			pictureBoxDijkstra.Refresh();
			pintarCirculoApartirCentro(grafo.getListaVertices()[indice].getUbicacion().X,grafo.getListaVertices()[indice].getUbicacion().Y,Color.White,imagenOriginal,bitmapAnimacionDijkstra);
			verticeInicialArmDijkstra = grafo.getListaVertices()[indice];	
		}
		void ComboBoxPrimSelectedIndexChanged(object sender, EventArgs e)
		{
			int indice = comboBoxPrim.SelectedIndex;
			clearBitmap(bitmapAnimacionPrim,Color.Transparent);
			pintarCirculoApartirCentro(grafo.getListaVertices()[indice].getUbicacion().X,grafo.getListaVertices()[indice].getUbicacion().Y,Color.Aquamarine,imagenOriginal,bitmapAnimacionPrim);
			pictureBoxPrim.Refresh();
			pintarCirculoApartirCentro(grafo.getListaVertices()[indice].getUbicacion().X,grafo.getListaVertices()[indice].getUbicacion().Y,Color.White,imagenOriginal,bitmapAnimacionPrim);
			verticeInicialArmPrim = grafo.getListaVertices()[indice];	
		}	
	}
}
