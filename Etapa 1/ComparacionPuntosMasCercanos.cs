/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 15/05/2019
 * Time: 08:09 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace Etapa_1
{
	public partial class ComparacionPuntosMasCercanos : Form
	{
		Bitmap bmpOriginalFuerzaBruta;
		Bitmap bmpGrafoCopiaFuerzaBruta;
		Bitmap bmpOriginalDivide;
		Bitmap bmpGrafoCopiaDivide;
		List<Circulo> listaCirculosCopia;
		public ComparacionPuntosMasCercanos(List<Circulo> listaCirculos,Bitmap original,Bitmap bmpGrafo)
		{
			InitializeComponent();
			bmpOriginalFuerzaBruta = new Bitmap(original);
			bmpGrafoCopiaFuerzaBruta = new Bitmap(bmpGrafo);
			bmpOriginalDivide = new Bitmap(original);
			bmpGrafoCopiaDivide =new Bitmap( bmpGrafo);
		 	listaCirculosCopia = listaCirculos;
		 	
		 	pictureBox1.Image =bmpGrafoCopiaFuerzaBruta;
		 	pictureBox2.Image = bmpGrafoCopiaDivide;
		}
		static int compararPuntosEjeY(Circulo punto1,Circulo punto2){
			if(punto1.getEjeY() < punto2.getEjeY() ){
				return -1;
			}
			else if(punto1.getEjeY()  > punto2.getEjeY() ){
				return 1;
			}
			else{
				return 0;
			}
		}
		static int compararPuntosEjeX(Circulo punto1,Circulo punto2){
			if(punto1.getEjeX()  < punto2.getEjeX() ){
				return -1;
			}
			else if(punto1.getEjeX()  > punto2.getEjeX()){
				return 1;
			}
			else{
				return 0;
			}
		}
		static int compararPuntosEjeY(Point punto1,Point punto2){
			if(punto1.Y < punto2.Y){
				return -1;
			}
			else if(punto1.Y > punto2.Y){
				return 1;
			}
			else{
				return 0;
			}
		}
		static int compararPuntosEjeX(Point punto1,Point punto2){
			if(punto1.X < punto2.X){
				return -1;
			}
			else if(punto1.X > punto2.X){
				return 1;
			}
			else{
				return 0;
			}
		}
		double bruteForce(List<Circulo>listaPuntos,int n,ref Point punto1,ref Point punto2)
		{
			double min = double.MaxValue;
			for (int i = 0; i < n; ++i){
				for (int j = i+1; j < n; ++j){
					if (FuncionesUtiles.distanciaEntrePuntos(listaPuntos[i].getCentro(), listaPuntos[j].getCentro()) < min){
						min = FuncionesUtiles.distanciaEntrePuntos(listaPuntos[i].getCentro(), listaPuntos[j].getCentro());
						punto1 = listaPuntos[i].getCentro();
						punto2 = listaPuntos[j].getCentro();
					}
				}
			}
			return min;
		}
		
		double puntosMasCercanosDivideYVenceras(List<Circulo> listaPuntos,ref Point punto1,ref Point punto2){
			List<Circulo> listaCopia = new List<Circulo>(listaPuntos);
			listaCopia.Sort(compararPuntosEjeX);
			return puntosMasCercanosDivideYVenceras(listaCopia,listaCopia.Count,ref punto1,ref punto2);
			
		}
		double puntosMasCercanosDivideYVenceras(List<Circulo> listaPuntos,int n,ref Point punto1,ref Point punto2){
			if (n <= 4){
				return bruteForce(listaPuntos,n,ref punto1,ref punto2);
			}
			int mid = n/2;
			Point midPoint = listaPuntos[mid].getCentro();
			Point punto1Aux = new Point();
			Point punto2Aux = new Point();
			Point punto3Aux = new Point();
			Point punto4Aux = new Point();
			double distanciaIzquierda = puntosMasCercanosDivideYVenceras(listaPuntos.GetRange(0,mid), mid,ref punto1Aux,ref punto2Aux);
			double distanciaDerecha = puntosMasCercanosDivideYVenceras(listaPuntos.GetRange(mid,n-mid),n-mid,ref punto3Aux,ref punto4Aux);
			
			double distancia;
			if(distanciaIzquierda < distanciaDerecha){
				distancia = distanciaIzquierda;
				punto1 = punto1Aux;
				punto2 = punto2Aux;
			}
			else{
				distancia = distanciaDerecha;
				punto1 = punto3Aux;
				punto2 = punto4Aux;
			}
			
			List<Circulo> strip = new List<Circulo>();
			int j = 0;
			for (int i = 0; i < n; i++){
				if (Math.Abs(listaPuntos[i].getEjeX() - midPoint.X) < distancia){
					strip.Add(listaPuntos[i]);
					j++;
				}
			}
			if(distancia < stripClosest(strip, j, distancia,ref punto1,ref punto2)){
				return distancia;
			}
			else{
				return stripClosest(strip, j, distancia,ref punto1,ref punto2);
			}
		}
		double stripClosest(List<Circulo> strip, int size, double d,ref Point punto1,ref Point punto2)
		{
			double min = d;
			
			strip.Sort(compararPuntosEjeY);
			for (int i = 0; i < size; ++i){
				for (int j = i+1; j < size && (strip[j].getEjeY() - strip[i].getEjeY()) < min; ++j){
					if (FuncionesUtiles.distanciaEntrePuntos(strip[i].getCentro(),strip[j].getCentro()) < min){
						min = FuncionesUtiles.distanciaEntrePuntos(strip[i].getCentro(),strip[j].getCentro());
						punto1 = strip[i].getCentro();
						punto2 = strip[j].getCentro();
					}
				}
			}
			return min;
		}
		void encontrarPuntosCercanosFuerzaBrutaMejorado(List<Circulo> lista){
			double menor,distancia;
			menor = FuncionesUtiles.distanciaEntrePuntos(lista[0].getCentro(),lista[1].getCentro());
			Point puntoA = lista[0].getCentro();
			Point puntoB = lista[1].getCentro();
			TimeSpan stop;
            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);

			for(int i = 0; i < listaCirculosCopia.Count; i++){
				for(int j = i+1; j < listaCirculosCopia.Count; j++){
					distancia = FuncionesUtiles.distanciaEntrePuntos(lista[i].getCentro(),lista[j].getCentro());
					if(distancia < menor){
						menor = distancia;
						puntoA = lista[i].getCentro();
						puntoB = lista[j].getCentro();
					}
				}
			}
            Thread.Sleep(100);
            stop = new TimeSpan(DateTime.Now.Ticks);
            
            textBoxTiempoFuerza.Text = stop.Subtract(start).TotalMilliseconds.ToString();
            
			textBoxPunto1Fuerza.Text = puntoA.ToString();
            textBoxPunto2Fuerza.Text = puntoB.ToString();
			pintarCirculoApartirCentro(puntoA.X,puntoA.Y,Color.Green,bmpOriginalFuerzaBruta,bmpGrafoCopiaFuerzaBruta);
			pintarCirculoApartirCentro(puntoB.X,puntoB.Y,Color.Green,bmpOriginalFuerzaBruta,bmpGrafoCopiaFuerzaBruta);
			textBoxDistanciaFuerza.Text = Math.Round(FuncionesUtiles.distanciaEntrePuntos(puntoA,puntoB),2).ToString();
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
		void ButtonIniciarClick(object sender, EventArgs e)
		{
			if(listaCirculosCopia.Count >= 2){
				 encontrarPuntosCercanosFuerzaBrutaMejorado(listaCirculosCopia);
            
            Point punto1 = new Point();
			Point punto2 = new Point();
			
			TimeSpan stop2;
            TimeSpan start2 = new TimeSpan(DateTime.Now.Ticks);
            
			puntosMasCercanosDivideYVenceras(listaCirculosCopia,ref punto1,ref punto2);
			Thread.Sleep(100);
			stop2 = new TimeSpan(DateTime.Now.Ticks);
            textBoxTiempoDivide.Text = stop2.Subtract(start2).TotalMilliseconds.ToString();
            textBoxPunto1Divide.Text = punto1.ToString();
            textBoxPunto2Divide.Text = punto2.ToString();
            pintarCirculoApartirCentro(punto1.X,punto1.Y,Color.Green,bmpOriginalDivide,bmpGrafoCopiaDivide);
            pintarCirculoApartirCentro(punto2.X,punto2.Y,Color.Green,bmpOriginalDivide,bmpGrafoCopiaDivide);
            
            pictureBox1.Image = bmpGrafoCopiaFuerzaBruta;
            pictureBox2.Image = bmpGrafoCopiaDivide;
            
            textBoxDistanciaDivide.Text = Math.Round(FuncionesUtiles.distanciaEntrePuntos(punto1,punto2),2).ToString();
            buttonIniciar.Enabled = false;	
			}
			else{
				MessageBox.Show("La cantidad de vertices es menor a 2");
			}
		}
		void ButtonSalirClick(object sender, EventArgs e)
		{
			bmpOriginalFuerzaBruta.Dispose();
			bmpGrafoCopiaFuerzaBruta.Dispose();
			bmpOriginalDivide.Dispose();
			bmpGrafoCopiaDivide.Dispose();
			this.Close();
		}
	}
}
