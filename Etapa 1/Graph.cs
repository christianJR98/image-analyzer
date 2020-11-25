/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 14/02/2019
 * Time: 02:14 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Etapa_1;
namespace Etapa_1
{
	public class Graph: ICloneable
	{
		List<Vertex> vl;
		int cantidadSubgrafos;
		public Graph(List<Circulo> cL,Bitmap bmp,Bitmap bmpOriginal)
		{
			//etapa 4
			//pesosSubgrafosKruskal = new List<double>();
			//pesosSubgrafosPrim = new List<double>();
			cantidadSubgrafos = 0;
			vl = new List<Vertex>();
			for(int i = 0; i < cL.Count;i++){
				Vertex V = new Vertex(cL[i],i);
				vl.Add(V);
			}
			double distancia;
			int contadorAristas = 1;
			for(int i = 0; i < vl.Count;i++){
				for(int j = i+1; j < vl.Count;j++){
					if(existeConexion(vl[i].getUbicacion(),vl[j].getUbicacion(),bmpOriginal)){
						distancia = FuncionesUtiles.distanciaEntrePuntos(vl[i].getUbicacion(),vl[j].getUbicacion());
						DibujarLineaDDA(vl[i].getUbicacion(),vl[j].getUbicacion(),bmp,Color.DarkRed);
						//etapa 3 lista de puntos
						List<Point> aristaPuntos = new List<Point>();
						List<Point> aristaPuntosInversa = new List<Point>();
						CrearAristaPuntos(vl[i].getUbicacion(),vl[j].getUbicacion(),bmpOriginal,aristaPuntos);
						CrearAristaPuntos(vl[j].getUbicacion(),vl[i].getUbicacion(),bmpOriginal,aristaPuntosInversa);
						//etapa 3 se agrego la lista de puntos
						vl[i].addEdge(vl[i],vl[j],distancia,aristaPuntos,contadorAristas);
						vl[j].addEdge(vl[j],vl[i],distancia,aristaPuntosInversa,contadorAristas*-1);
						contadorAristas++;
					}
				}
			}
		}
		//etapa 3
		public Graph(Graph grafoCopia)
		{
			//vl = new List<Vertex>();
			//vl = (Vertex)grafoCopia.vl.Clone();
			//Graph grafoCopia = (Graph)grafo.Clone();
			//this.vl = grafoCopia.vl;
			for(int i = 0; i < grafoCopia.vl.Count;i++){
				this.vl[i] = (Vertex)grafoCopia.vl[i].Clone();
			}
		}
		public void AristaMasCorta(Bitmap bitmapCopia){
			List<Edge> listaAristasAux;
			Point puntoA = new Point();
			Point puntoB = new Point();
			bool menorInicializado = false;
			double menor = 0;
			if(hayAristas()){
				for(int i = 0; i < vl.Count;i++){
					listaAristasAux = vl[i].getListaAristas();
					for(int j = 0; j < listaAristasAux.Count;j++){
						if(menorInicializado == false){
							menor = listaAristasAux[j].getDistancia();
							menorInicializado = true;
						}
						if(listaAristasAux[j].getDistancia() < menor){
							menor = listaAristasAux[j].getDistancia();
							puntoA = vl[i].getUbicacion();
							puntoB = listaAristasAux[j].getVerticeDestino().getUbicacion();
						}
					}
				}
				DibujarLineaDDA(puntoA,puntoB,bitmapCopia,Color.Blue);
			}
			
		}
		public override string ToString()
		{
			string vertices = "";
			string aristas = "";
			string grafo = "";
			
			for(int i = 0; i < vl.Count;i++){
				vertices = vl[i].getId().ToString() + "->";
				aristas = vl[i].getAristasToString();
				grafo += vertices + aristas + "\n";
				
			}
			return grafo;
		}
		
		//cambiar Nombre bitmap a bitmapUtilizar
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
		void CrearAristaPuntos(Point puntoInicial,Point puntoFinal,Bitmap bmp,List<Point>listaPuntosArista){
			double m;
			double b;
			if(puntoInicial.X == puntoFinal.X){
				if(puntoInicial.Y >puntoFinal.Y){
					for(double y_i = puntoFinal.Y; y_i <puntoInicial.Y;y_i++){
						Point aux = new Point((int)puntoInicial.X,(int)y_i);
						listaPuntosArista.Add(aux);
					}
				}
				else{
					for(double y_i = puntoFinal.Y; y_i > puntoInicial.Y;y_i--){
						Point aux = new Point((int)puntoInicial.X,(int)y_i);
						listaPuntosArista.Add(aux);
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
							Point aux = new Point((int)x_i,(int)y_i);
							listaPuntosArista.Add(aux);
						}
					}
					else{
						for(double y_i,x_i = puntoInicial.X; x_i > puntoFinal.X;x_i--){
							y_i = Math.Round(m*x_i+b);
							Point aux = new Point((int)x_i,(int)y_i);
							listaPuntosArista.Add(aux);
						}
					}
				}
				if(m > 1){
					if(puntoInicial.X < puntoFinal.X){
						for(double x_i, y_i = puntoInicial.Y; y_i <puntoFinal.Y;y_i++){
							x_i = Math.Round((y_i-b)/m);
							Point aux = new Point((int)x_i,(int)y_i);
							listaPuntosArista.Add(aux);
						}
					}
					else{
						for(double x_i, y_i = puntoInicial.Y; y_i >puntoFinal.Y;y_i--){
							x_i = Math.Round((y_i-b)/m);
							Point aux = new Point((int)x_i,(int)y_i);
							listaPuntosArista.Add(aux);
						}
					}
				}
			}
			else{//pendiente negativa
				if((m*-1) <= 1){
					if(puntoInicial.X < puntoFinal.X){
						for(double y_i, x_i = puntoInicial.X; x_i <puntoFinal.X;x_i++){
							y_i = Math.Round(m*x_i+b);
							Point aux = new Point((int)x_i,(int)y_i);
							listaPuntosArista.Add(aux);
						}
					}
					else{
						for(double y_i,x_i = puntoInicial.X; x_i > puntoFinal.X;x_i--){
							y_i = Math.Round(m*x_i+b);
							Point aux = new Point((int)x_i,(int)y_i);
							listaPuntosArista.Add(aux);
						}
					}
					
				}
				if((m*-1) > 1){
					if(puntoInicial.X < puntoFinal.X){
						for(double x_i, y_i = puntoInicial.Y; y_i >puntoFinal.Y;y_i--){
							x_i = Math.Round((y_i-b)/m);
							Point aux = new Point((int)x_i,(int)y_i);
							listaPuntosArista.Add(aux);
						}
					}
					else{
						for(double x_i, y_i = puntoInicial.Y; y_i <puntoFinal.Y;y_i++){
							x_i = Math.Round((y_i-b)/m);
							Point aux = new Point((int)x_i,(int)y_i);
							listaPuntosArista.Add(aux);
						}
					}
				}
			}
		}
		bool hayObstaculoEjeY(int x,int y,Bitmap bmp){
			if(AnalizarColor.isBlue(bmp.GetPixel(x,y))||AnalizarColor.isRed(bmp.GetPixel(x,y))){
				return true;
			}
			if(AnalizarColor.isBlue(bmp.GetPixel(x,y+1))||AnalizarColor.isRed(bmp.GetPixel(x,y))){
				return true;
			}
			/*if(AnalizarColor.isBlue(bmp.GetPixel(x,y-1))||AnalizarColor.isRed(bmp.GetPixel(x,y))){
			  	return true;
			}*/
			return false;
		}
		bool hayObstaculoEjeX(int x,int y,Bitmap bmp){
			if(AnalizarColor.isBlue(bmp.GetPixel(x,y))||AnalizarColor.isRed(bmp.GetPixel(x,y))){
				return true;
			}
			if(AnalizarColor.isBlue(bmp.GetPixel(x+1,y))||AnalizarColor.isRed(bmp.GetPixel(x,y))){
				return true;
			}
			/*if(AnalizarColor.isBlue(bmp.GetPixel(x-1,y))||AnalizarColor.isRed(bmp.GetPixel(x,y))){
			  	return true;
			}*/
			return false;
		}
		//cambiar Nombre bitmap a bitmapAnalizar
				bool existeConexion(Point puntoInicial,Point puntoFinal,Bitmap bmp){
			double m;
			double b;
			Color pixelAnalizar;
			bool colorBlancoEntrado = false;
			bool segundoCirculoEncontrado = false;
			if(puntoInicial.X == puntoFinal.X){
				if(puntoInicial.Y >puntoFinal.Y){//abajo hacia arriba
					for(double y_i = puntoFinal.Y; y_i <puntoInicial.Y;y_i++){
						pixelAnalizar = bmp.GetPixel((int)puntoInicial.X,(int)y_i);
						if(AnalizarColor.isWhite(pixelAnalizar)){
							if(segundoCirculoEncontrado && colorBlancoEntrado){
								return false;
							}
							colorBlancoEntrado = true;
						}
						if(AnalizarColor.isBlack(pixelAnalizar)){
							if(colorBlancoEntrado){
								segundoCirculoEncontrado = true;
							}
							continue;
						}
						if(AnalizarColor.isBlue(pixelAnalizar)||AnalizarColor.isRed(pixelAnalizar)){
							return false;
						}
					}
				}
				else{
					//arriba hacia abajo
					for(double y_i = puntoFinal.Y; y_i > puntoInicial.Y;y_i--){
						pixelAnalizar = bmp.GetPixel((int)puntoInicial.X,(int)y_i);
						if(AnalizarColor.isWhite(pixelAnalizar)){
							if(segundoCirculoEncontrado && colorBlancoEntrado){
								return false;
							}
							colorBlancoEntrado = true;
						}
						if(AnalizarColor.isBlack(pixelAnalizar)){
							if(colorBlancoEntrado){
								segundoCirculoEncontrado = true;
							}
							continue;
						}
						if(AnalizarColor.isBlue(pixelAnalizar)||AnalizarColor.isRed(pixelAnalizar)){
							return false;
						}
					}
				}
			}
			m = ((double)puntoFinal.Y-(double)puntoInicial.Y)/((double)puntoFinal.X-(double)puntoInicial.X);
			b = (double)puntoFinal.Y-m*(double)puntoFinal.X;
			
			if(m >= 0){//pendiente positiva
				if(m <= 1){
					if(puntoInicial.X < puntoFinal.X){
						for(double y_i, x_i = puntoInicial.X; x_i <puntoFinal.X;x_i++){
							y_i = Math.Round(m*x_i+b);
							pixelAnalizar = bmp.GetPixel((int)x_i,(int)y_i);
							if(AnalizarColor.isWhite(bmp.GetPixel((int)x_i,(int)y_i))){
								if(segundoCirculoEncontrado && colorBlancoEntrado){
									return false;
								}
								colorBlancoEntrado = true;
							}
							if(AnalizarColor.isBlack(bmp.GetPixel((int)x_i,(int)y_i))){
								if(colorBlancoEntrado){
									segundoCirculoEncontrado = true;
								}
								continue;
							}
							if(hayObstaculoEjeX((int)x_i,(int)y_i,bmp)||AnalizarColor.isRed(pixelAnalizar)){
								return false;
							}
						}
					}
					else{
						for(double y_i,x_i = puntoInicial.X; x_i > puntoFinal.X;x_i--){
							y_i = Math.Round(m*x_i+b);
							pixelAnalizar = bmp.GetPixel((int)x_i,(int)y_i);
							if(AnalizarColor.isWhite(bmp.GetPixel((int)x_i,(int)y_i))){
								if(segundoCirculoEncontrado && colorBlancoEntrado){
									return false;
								}
								colorBlancoEntrado = true;
							}
							if(AnalizarColor.isBlack(bmp.GetPixel((int)x_i,(int)y_i))){
								if(colorBlancoEntrado){
									segundoCirculoEncontrado = true;
								}
								continue;
							}
							if(hayObstaculoEjeX((int)x_i,(int)y_i,bmp)||AnalizarColor.isRed(pixelAnalizar)){
								return false;
							}
						}
					}
					
				}
				if(m > 1){
					if(puntoInicial.X < puntoFinal.X){
						for(double x_i, y_i = puntoInicial.Y; y_i <puntoFinal.Y;y_i++){
							x_i = Math.Round((y_i-b)/m);
							pixelAnalizar = bmp.GetPixel((int)x_i,(int)y_i);
							if(AnalizarColor.isWhite(bmp.GetPixel((int)x_i,(int)y_i))){
								if(segundoCirculoEncontrado && colorBlancoEntrado){
									return false;
								}
								colorBlancoEntrado = true;
							}
							if(AnalizarColor.isBlack(bmp.GetPixel((int)x_i,(int)y_i))){
								if(colorBlancoEntrado){
									segundoCirculoEncontrado = true;
								}
								continue;
							}
							if(hayObstaculoEjeY((int)x_i,(int)y_i,bmp)||AnalizarColor.isRed(pixelAnalizar)){
								return false;
							}
						}
					}
					else{
						for(double x_i, y_i = puntoInicial.Y; y_i >puntoFinal.Y;y_i--){
							x_i = Math.Round((y_i-b)/m);
							pixelAnalizar = bmp.GetPixel((int)x_i,(int)y_i);
							if(AnalizarColor.isWhite(bmp.GetPixel((int)x_i,(int)y_i))){
								if(segundoCirculoEncontrado && colorBlancoEntrado){
									return false;
								}
								colorBlancoEntrado = true;
							}
							if(AnalizarColor.isBlack(bmp.GetPixel((int)x_i,(int)y_i))){
								if(colorBlancoEntrado){
									segundoCirculoEncontrado = true;
								}
								continue;
							}
							if(hayObstaculoEjeY((int)x_i,(int)y_i,bmp)||AnalizarColor.isRed(pixelAnalizar)){
								return false;
							}
						}
					}
				}
			}
			else{//pendiente negativa
				if((m*-1) <= 1){
					if(puntoInicial.X < puntoFinal.X){
						for(double y_i, x_i = puntoInicial.X; x_i <puntoFinal.X;x_i++){
							y_i = Math.Round(m*x_i+b);
							pixelAnalizar = bmp.GetPixel((int)x_i,(int)y_i);
							if(AnalizarColor.isWhite(bmp.GetPixel((int)x_i,(int)y_i))){
								if(segundoCirculoEncontrado && colorBlancoEntrado){
									return false;
								}
								colorBlancoEntrado = true;
							}
							if(AnalizarColor.isBlack(bmp.GetPixel((int)x_i,(int)y_i))){
								if(colorBlancoEntrado){
									segundoCirculoEncontrado = true;
								}
								continue;
							}
							if(hayObstaculoEjeX((int)x_i,(int)y_i,bmp)||AnalizarColor.isRed(pixelAnalizar)){
								return false;
							}
						}
					}
					else{
						for(double y_i,x_i = puntoInicial.X; x_i > puntoFinal.X;x_i--){
							y_i = Math.Round(m*x_i+b);
							pixelAnalizar = bmp.GetPixel((int)x_i,(int)y_i);
							if(AnalizarColor.isWhite(bmp.GetPixel((int)x_i,(int)y_i))){
								if(segundoCirculoEncontrado && colorBlancoEntrado){
									return false;
								}
								colorBlancoEntrado = true;
							}
							if(AnalizarColor.isBlack(bmp.GetPixel((int)x_i,(int)y_i))){
								if(colorBlancoEntrado){
									segundoCirculoEncontrado = true;
								}
								continue;
							}
							if(hayObstaculoEjeX((int)x_i,(int)y_i,bmp)||AnalizarColor.isRed(pixelAnalizar)){
								return false;
							}
						}
					}
					
				}
				if((m*-1) > 1){//demasiado inclinadas
					if(puntoInicial.X < puntoFinal.X){
						for(double x_i, y_i = puntoInicial.Y; y_i >puntoFinal.Y;y_i--){
							x_i = Math.Round((y_i-b)/m);
							pixelAnalizar = bmp.GetPixel((int)x_i,(int)y_i);
							if(AnalizarColor.isWhite(bmp.GetPixel((int)x_i,(int)y_i))){
								if(segundoCirculoEncontrado && colorBlancoEntrado){
									return false;
								}
								colorBlancoEntrado = true;
							}
							if(AnalizarColor.isBlack(bmp.GetPixel((int)x_i,(int)y_i))){
								if(colorBlancoEntrado){
									segundoCirculoEncontrado = true;
								}
								continue;
							}
							if(hayObstaculoEjeY((int)x_i,(int)y_i,bmp)||AnalizarColor.isRed(pixelAnalizar)){
								return false;
							}
						}
					}
					else{//izquierda-Derecha (Arriba)
						for(double x_i, y_i = puntoInicial.Y; y_i <puntoFinal.Y;y_i++){
							x_i = Math.Round((y_i-b)/m);
							pixelAnalizar = bmp.GetPixel((int)x_i,(int)y_i);
							if(AnalizarColor.isWhite(bmp.GetPixel((int)x_i,(int)y_i))){
								if(segundoCirculoEncontrado && colorBlancoEntrado){
									return false;
								}
								colorBlancoEntrado = true;
							}
							if(AnalizarColor.isBlack(bmp.GetPixel((int)x_i,(int)y_i))){
								if(colorBlancoEntrado){
									segundoCirculoEncontrado = true;
								}
								continue;
							}
							if(hayObstaculoEjeY((int)x_i,(int)y_i,bmp)||AnalizarColor.isRed(pixelAnalizar)){
								return false;
							}
						}
					}
				}
			}
			return true;
		}
		public List<Vertex>  getListaVertices(){
			return vl;
		}
		public bool hayAristas(){
			List<Edge> listaAristasAux;
			for(int i = 0; i < vl.Count;i++){
				listaAristasAux = vl[i].getListaAristas();
				if(listaAristasAux.Count != 0){
					return true;
				}
			}
			return false;
		}
		public void deleteEdge(int origenEliminar,int destinoEliminar){
			List<Edge> aristasAux = vl[origenEliminar].getListaAristas();
			aristasAux.RemoveAt(destinoEliminar);
		}
		public object Clone()
		{
			return this.MemberwiseClone();
		}
		//etapa 4
		List<Double> pesosSubgrafosKruskal;
		List<Double> pesosSubgrafosPrim;
		public Vertex buscarVertice(Point centroCirculo){
			//double menorDiferencia = FuncionesUtiles.distanciaEntrePuntos(vl[0].getUbicacion(),centroCirculo);
			double menorDiferencia = 100000;
			int indiceMenor = 0;
			for(int i = 0; i < vl.Count; i++){
				double distanciaAux = FuncionesUtiles.distanciaEntrePuntos(vl[i].getUbicacion(),centroCirculo);
				//distanciaAux < menorDiferencia &&
				//MessageBox.Show(distanciaAux.ToString() + "<" +vl[i].getCircle().getRadioDistancia());
				if(distanciaAux<menorDiferencia){
					if(distanciaAux < vl[i].getCircle().getRadioDistancia()){
						indiceMenor = i;
					}
				}
			}
			return vl[indiceMenor];
		}
		public List<double> getPesosSubgrafosKruskal(List<Edge>arm,Bitmap imagenDibujar){
			pesosSubgrafosKruskal.Clear();
			int cantGrafos = 0;
			List<Edge> aristas = null;
			List<Vertex> visitados = new List<Vertex>();
			Vertex verticeRecorrido = vl[0];
			while(visitados.Count != vl.Count){
				aristas = recorridoProfundidadAristas(verticeRecorrido,arm);
				for(int i = 0; i < aristas.Count;i++){
					if(!visitados.Contains(aristas[i].getVerticeOrigen())){
						visitados.Add(aristas[i].getVerticeOrigen());
					}
					if(!visitados.Contains(aristas[i].getVerticeDestino())){
						visitados.Add(aristas[i].getVerticeDestino());
					}
				}
				
				double peso = 0;
				for(int k = 0;k< aristas.Count;k++){
					peso +=aristas[k].getDistancia();
				}
				cantGrafos++;
				escribirNombreCirculo(aristas[0].getVerticeOrigen().getCircle(),imagenDibujar,cantGrafos.ToString());
				pesosSubgrafosKruskal.Add(peso);
				//se busca otro vertice que no haya sido visitado
				for(int j = 0; j < vl.Count;j++){
					if(!visitados.Contains(vl[j])){
						verticeRecorrido = vl[j];
						break;
					}
				}
			}
			return pesosSubgrafosKruskal;
		}
		public List<Edge> getArmKruskal(){
			pesosSubgrafosKruskal = new List<double>();
			Lista<Edge> candidatos = new Lista<Edge>();
			List<Edge> aristasCopia;
			List<HashSet<Vertex>> componentesConexos = new List<HashSet<Vertex>>();
			Lista<Edge> prometedor = new Lista<Edge>();
			//inicializarLista
			for(int i = 0; i < vl.Count;i++){
				aristasCopia = new List<Edge>(vl[i].getListaAristas());//arsitas del grafo
				for(int j = 0;j < aristasCopia.Count;j++){
					//se cambia el origen por el destino para ver si existe la parte inversa y no insertarla
					Edge aristaInversa = new Edge(aristasCopia[j].getVerticeDestino(),aristasCopia[j].getVerticeOrigen()
					                              ,aristasCopia[j].getDistancia(),aristasCopia[j].getListaPuntos(),aristasCopia[j].getId()*-1);
					//para no insertar la arista con origen y destino inversa
					if(!candidatos.Contains(aristaInversa) ){
						candidatos.insertOrdered(aristasCopia[j]);
					}
				}
			}//fin fors anidados
			
			//calcular pendiete
			//pero si las x son iguales poner infinito
			
			//Lista<Edge> prometedor = new Lista<Edge>();
			
			//agreagar los vertices a cc
			for(int i = 0; i < vl.Count;i++){
				HashSet<Vertex> componente = new HashSet<Vertex>();
				componente.Add(vl[i]);
				componentesConexos.Add(componente);
			}
			//cantidadSubgrafos = componentesConexos.Count;
			//mientras la solucion no tenga la cantodad de vertices -1 && en candidatos haya aristas
			while((prometedor.Count != (vl.Count-1))&&(candidatos.Count != 0)){
				Edge arista;
				/*if(candidatos.Count == 0){
						return prometedor;
					}*/
				//para que funcionanra como cola
				arista = candidatos[0];
				candidatos.RemoveAt(0);
				//candidatos.RemoveAt(0);
				int indiceComponente1 = 0,indiceComponente2 = 0;
				//buscar el indice del cc del vertice origen
				for(int i = 0; i < componentesConexos.Count;i++){
					if(componentesConexos[i].Contains(arista.getVerticeOrigen())){
						indiceComponente1 = i;
						break;
					}
				}
				//buscar el indice del cc del vertice destino
				for(int i = 0; i < componentesConexos.Count;i++){
					if(componentesConexos[i].Contains(arista.getVerticeDestino())){
						indiceComponente2 = i;
						break;
					}
				}
				if(indiceComponente1 != indiceComponente2){
					prometedor.Add(arista);
					componentesConexos[indiceComponente1].UnionWith(componentesConexos[indiceComponente2]);
					//se debe borrar el indice 2?
					componentesConexos.RemoveAt(indiceComponente2);
				}
				
				//getPesosSubgrafosKruskal();
			}
			cantidadSubgrafos = componentesConexos.Count;
			return prometedor;
		}
		public List<Double> getPesosSubgrafosPrim(){
			return pesosSubgrafosPrim;
		}
		public List<Double> getPesosSubgrafosKruskal(){
			return pesosSubgrafosKruskal;
		}
		void escribirNombreCirculo(Circulo lista,Bitmap bmpImagen,string etiqueta){
			Graphics imagenGraphics = Graphics.FromImage(bmpImagen);
			imagenGraphics.DrawString(etiqueta,new Font("arial",20,FontStyle.Regular)
			                          ,new SolidBrush(Color.Green),new Point(lista.getEjeX()+lista.getRadio()
			                                                                 ,lista.getEjeY()-lista.getRadio()));
		}
		public List<Edge> getArmPrim(Vertex verticeInicial,Bitmap imagenDibujar){
			int aristasContadas = 0;
			int cantGrafos = 0;
			pesosSubgrafosPrim = new List<double>();
			Lista<Edge> candidatos = new Lista<Edge>();
			List<Edge> prometedor = new List<Edge>();
			List<Vertex> visitados = new List<Vertex>();
			visitados.Add(verticeInicial);
			
			List<Edge> aristasAux = new List<Edge>();
			Edge aristaAux;
			
			
			cantidadSubgrafos = 1;
			aristasAux = verticeInicial.getListaAristas();
			for(int i = 0; i < aristasAux.Count;i++){//insertar aritas del inicial
				candidatos.insertOrdered(aristasAux[i]);
			}
			
			while(visitados.Count != vl.Count){
				while((prometedor.Count != (vl.Count-1))&&(candidatos.Count != 0)){
					aristaAux = candidatos[0];
					candidatos.RemoveAt(0);
					//Se revisa que uno de los vertices de la arista no este en visitados
					if((visitados.Contains(aristaAux.getVerticeOrigen())&&!visitados.Contains(aristaAux.getVerticeDestino())) ||
					   (!visitados.Contains(aristaAux.getVerticeOrigen())&&visitados.Contains(aristaAux.getVerticeDestino()))){
						
						prometedor.Add(aristaAux);
						
						//se revisaba si el verticeOrigen o el vDestino era el visitado
						if(visitados.Contains(aristaAux.getVerticeOrigen())){
							visitados.Add(aristaAux.getVerticeDestino());
							aristasAux = aristaAux.getVerticeDestino().getListaAristas();
							//agregar aristas del destino
							for(int i = 0; i < aristasAux.Count;i++){//insertar aristas del inicial
								//candidatos.insertOrdered(aristasAux[i]);
								Edge aristaInversa = new Edge(aristasAux[i].getVerticeDestino(),aristasAux[i].getVerticeOrigen()
								                              ,aristasAux[i].getDistancia(),aristasAux[i].getListaPuntos(),aristasAux[i].getId()*-1);
								if(!candidatos.Contains(aristaInversa) ){
									candidatos.insertOrdered(aristasAux[i]);
								}
							}
						}
						else{
							//agregar los vertices del origen
							visitados.Add(aristaAux.getVerticeOrigen());
							aristasAux = aristaAux.getVerticeOrigen().getListaAristas();
							//agregar aristas del destino
							for(int i = 0; i < aristasAux.Count;i++){//insertar aritas del inicial
								//candidatos.insertOrdered(aristasAux[i]);
								Edge aristaInversa = new Edge(aristasAux[i].getVerticeDestino(),aristasAux[i].getVerticeOrigen()
								                              ,aristasAux[i].getDistancia(),aristasAux[i].getListaPuntos(),aristasAux[i].getId()*-1);
								if(!candidatos.Contains(aristaInversa) ){
									candidatos.insertOrdered(aristasAux[i]);
								}
							}
						}
					}
				}
				//obtiene el peso del primer grafo
				double peso = 0;
				cantGrafos++;
				//escribirNombreCirculo(prometedor[aristasContadas].getVerticeOrigen().getCircle(),imagenDibujar,cantGrafos.ToString());
				for(	; aristasContadas < prometedor.Count;aristasContadas++){
					peso +=prometedor[aristasContadas].getDistancia();
				}
				pesosSubgrafosPrim.Add(peso);
				//con subgrafos
				if(visitados.Count != vl.Count){//cada que entre aqui debe sumarse la cantidad de sub grafos
					cantidadSubgrafos++;
					//buscar un nodo del grafo que no haya sido visitado
					for(int i = 0; i < vl.Count;i++){
						if(!visitados.Contains(vl[i])){
							aristasAux = vl[i].getListaAristas();
							for(int j = 0; j < aristasAux.Count;j++){
								candidatos.insertOrdered(aristasAux[j]);
								Edge aristaInversa = new Edge(aristasAux[j].getVerticeDestino(),aristasAux[j].getVerticeOrigen()
								                              ,aristasAux[j].getDistancia(),aristasAux[j].getListaPuntos(),aristasAux[i].getId()*-1);
								if(!candidatos.Contains(aristaInversa) ){
									candidatos.insertOrdered(aristasAux[j]);
								}
							}
							visitados.Add(vl[i]);
							break;
						}
					}
				}
			}
			

			return prometedor;
		}
		//normales
		public List<Vertex>recorridoProfundidad(Vertex verticeInicial){
			List<Vertex> pilaVertices = new List<Vertex>();
			Vertex verticeActual;
			List<Vertex> visitados = new List<Vertex>();
			pilaVertices.Add(verticeInicial);
			
			List<Edge> aristasAux;
			while(pilaVertices.Count != 0){
				verticeActual = pilaVertices[pilaVertices.Count-1];
				pilaVertices.RemoveAt(pilaVertices.Count-1);
				if(!visitados.Contains(verticeActual)){
					//procesar
					visitados.Add(verticeActual);
					aristasAux = verticeActual.getListaAristas();
					for(int i = 0; i < aristasAux.Count;i++){
						if(!visitados.Contains(aristasAux[i].getVerticeDestino())){
							pilaVertices.Add(aristasAux[i].getVerticeDestino());
						}
					}
				}
			}
			return visitados;
		}
		public List<Edge>recorridoProfundidadAristas(Vertex verticeInicial){
			List<Vertex> pilaVertices = new List<Vertex>();
			Vertex verticeActual;
			List<Vertex> visitados = new List<Vertex>();
			pilaVertices.Add(verticeInicial);
			
			List<Edge> aristas = new List<Edge>();
			List<Edge> aristasFinal = new List<Edge>();
			Edge aristaActual = null;
			List<Edge> aristasAux;
			
			while(pilaVertices.Count != 0){
				verticeActual = pilaVertices[pilaVertices.Count-1];
				pilaVertices.RemoveAt(pilaVertices.Count-1);
				//
				if(aristas.Count!=0){
					aristaActual = aristas[aristas.Count-1];
					aristas.RemoveAt(aristas.Count-1);
				}
				if(!visitados.Contains(verticeActual)){
					//procesar
					visitados.Add(verticeActual);
					if(aristaActual!=null){
						aristasFinal.Add(aristaActual);
					}
					aristasAux = verticeActual.getListaAristas();
					for(int i = 0; i < aristasAux.Count;i++){
						if(!visitados.Contains(aristasAux[i].getVerticeDestino())){
							pilaVertices.Add(aristasAux[i].getVerticeDestino());
							aristas.Add(aristasAux[i]);
						}
					}
				}
			}
			return aristasFinal;
		}
		public List<Vertex> primeroProfundidad(Vertex origen,Vertex destino){
			List<Vertex> pilaVertices = new List<Vertex>();
			List<Edge> parejas = new List<Edge>();
			List<Vertex> visitados = new List<Vertex>();
			
			List<Edge> aristasAux;
			
			Vertex verticeActual;
			pilaVertices.Add(origen);
			while(pilaVertices.Count != 0){
				verticeActual = pilaVertices[pilaVertices.Count-1];
				pilaVertices.RemoveAt(pilaVertices.Count-1);
				if(!visitados.Contains(verticeActual)){
					if(verticeActual == destino){
						//mostrar ruta
						return desplegarRuta(parejas,destino);
					}
					
					visitados.Add(verticeActual);
					
					aristasAux = verticeActual.getListaAristas();
					for(int i = 0; i < aristasAux.Count;i++){
						if(!visitados.Contains(aristasAux[i].getVerticeDestino())){
							pilaVertices.Add(aristasAux[i].getVerticeDestino());
							parejas.Add(aristasAux[i]);
						}
					}
					
				}
			}
			return null;
		}
		public List<Vertex> desplegarRuta(List<Edge> parejas,Vertex verticeDestino){
			Vertex destinoActual = verticeDestino;
			List<Vertex> ruta = new List<Vertex>();
			while(parejas.Count!=0){
				ruta.Add(destinoActual);
				while(parejas.Count != 0 && parejas[parejas.Count-1].getVerticeDestino()!=destinoActual){
					parejas.RemoveAt(parejas.Count-1);
				}
				if(parejas.Count!=0){
					destinoActual = parejas[parejas.Count-1].getVerticeOrigen();
				}
			}
			return ruta;
		}
		//normales
		public List<Edge>recorridoProfundidadAristas(Vertex verticeInicial,List<Edge> arm){
			List<Vertex> pilaVertices = new List<Vertex>();
			Vertex verticeActual;
			List<Vertex> visitados = new List<Vertex>();
			pilaVertices.Add(verticeInicial);
			
			List<Edge> aristasAux;
			Edge aristaInversa;
			List<Edge> aristas = new List<Edge>();
			List<Edge> aristasFinal = new List<Edge>();
			Edge aristaActual = null;
			
			while(pilaVertices.Count != 0){
				verticeActual = pilaVertices[pilaVertices.Count-1];
				pilaVertices.RemoveAt(pilaVertices.Count-1);
				if(aristas.Count!=0){
					aristaActual = aristas[aristas.Count-1];
					aristas.RemoveAt(aristas.Count-1);
				}
				if(!visitados.Contains(verticeActual)){
					//procesar
					visitados.Add(verticeActual);
					if(aristaActual!=null){
						aristasFinal.Add(aristaActual);
					}
					aristasAux = new Lista<Edge>();
					for(int i = 0; i < arm.Count;i++){
						if(arm[i].getVerticeOrigen() == verticeActual){
							aristasAux.Add(arm[i]);
						}
						else if(arm[i].getVerticeDestino() == verticeActual){
							aristaInversa = new Edge(arm[i].getVerticeDestino(),arm[i].getVerticeOrigen()
							                         ,arm[i].getDistancia(),arm[i].getListaPuntosInversa(),aristasAux[i].getId()*-1);
							aristasAux.Add(aristaInversa);
						}
					}
					//diferente
					//cada vertice que actual(actual es aristasAux) tiene como destino y que no ha sido visitado se apila
					for(int i = 0; i < aristasAux.Count;i++){
						if(!visitados.Contains(aristasAux[i].getVerticeDestino())){
							pilaVertices.Add(aristasAux[i].getVerticeDestino());
							aristas.Add(aristasAux[i]);
						}
					}
				}
			}
			return aristasFinal;
		}
		public List<Vertex>recorridoProfundidad(Vertex verticeInicial,List<Edge> arm){
			List<Vertex> pilaVertices = new List<Vertex>();
			Vertex verticeActual;
			List<Vertex> visitados = new List<Vertex>();
			pilaVertices.Add(verticeInicial);
			
			List<Edge> aristasAux;
			Edge aristaInversa;
			while(pilaVertices.Count != 0){
				verticeActual = pilaVertices[pilaVertices.Count-1];
				pilaVertices.RemoveAt(pilaVertices.Count-1);
				if(!visitados.Contains(verticeActual)){
					//procesar
					visitados.Add(verticeActual);
					
					//diferente
					//el arm solo tiene la arista en un sentido
					
					//se obtienen todos los vertices a donde podia ir el vertice actual
					aristasAux = new Lista<Edge>();
					for(int i = 0; i < arm.Count;i++){
						if(arm[i].getVerticeOrigen() == verticeActual){
							aristasAux.Add(arm[i]);
						}
						else if(arm[i].getVerticeDestino() == verticeActual){
							aristaInversa = new Edge(arm[i].getVerticeDestino(),arm[i].getVerticeOrigen()
							                         ,arm[i].getDistancia(),arm[i].getListaPuntosInversa(),arm[i].getId()*-1);
							aristasAux.Add(aristaInversa);
						}
					}
					//diferente
					//cada vertice que actual(actual es aristasAux) tiene como destino y que no ha sido visitado se apila
					for(int i = 0; i < aristasAux.Count;i++){
						if(!visitados.Contains(aristasAux[i].getVerticeDestino())){
							pilaVertices.Add(aristasAux[i].getVerticeDestino());
						}
					}
				}
			}
			return visitados;
		}
		public List<Edge> primeroProfundidad(Vertex origen,Vertex destino,List<Edge> arm){
			//se coloca el verticeOrigen en una pila
			List<Vertex> pilaVertices = new List<Vertex>();
			//inicializar pila de aristas
			List<Edge> parejas = new List<Edge>();
			List<Vertex> visitados = new List<Vertex>();
			
			List<Edge> aristasAux;
			Edge aristaInversa;
			Vertex verticeActual;
			pilaVertices.Add(origen);
			
			//mientras la pila no este vacia
			while(pilaVertices.Count != 0){
				//desapilar un vertice sera el vertice actual
				verticeActual = pilaVertices[pilaVertices.Count-1];
				pilaVertices.RemoveAt(pilaVertices.Count-1);
				//si el vertice actual no hs sido viditado
				if(!visitados.Contains(verticeActual)){
					if(verticeActual == destino){
						return desplegarRutaAristas(parejas,destino);
					}
					
					visitados.Add(verticeActual);
					//diferente
					aristasAux = new List<Edge>();
					for(int i = 0; i < arm.Count;i++){
						if(arm[i].getVerticeOrigen().Equals(verticeActual)){
							//MessageBox.Show("Normal " + arm[i].ToString(),"Informacion",MessageBoxButtons.OK);
							aristasAux.Add(arm[i]);
						}
						else if(arm[i].getVerticeDestino().Equals(verticeActual)){
							//MessageBox.Show("Inversa " + arm[i].ToString(),"Informacion",MessageBoxButtons.OK);
							aristaInversa = new Edge(arm[i].getVerticeDestino(),arm[i].getVerticeOrigen()
							                         ,arm[i].getDistancia(),arm[i].getListaPuntosInversa(),arm[i].getId()*-1);
							aristasAux.Add(aristaInversa);
						}
					}
					//diferente

					//para cada vertice que actual(aristasAux son las posibles del VerticeAct) tiene como destino y que no ha sido visitado
					for(int i = 0; i < aristasAux.Count;i++){
						if(!visitados.Contains(aristasAux[i].getVerticeDestino())){
							pilaVertices.Add(aristasAux[i].getVerticeDestino());
							parejas.Insert(parejas.Count,aristasAux[i]);
						}
					}
				}
			}
			return null;
		}
		public List<Edge> desplegarRutaAristas(List<Edge> parejas,Vertex verticeDestino){
			Vertex destinoActual = verticeDestino;
			List<Vertex> ruta = new List<Vertex>();
			List<Edge> rutaAristas = new List<Edge>();
			while(parejas.Count!=0){
				ruta.Add(destinoActual);
				while(parejas.Count != 0 && parejas[parejas.Count-1].getVerticeDestino()!=destinoActual){
					parejas.RemoveAt(parejas.Count-1);
				}
				if(parejas.Count!=0){
					destinoActual = parejas[parejas.Count-1].getVerticeOrigen();
					rutaAristas.Add(parejas[parejas.Count-1]);
				}
			}
			return rutaAristas;
		}
		public List<Edge> recorrerArm(Vertex verticeInicial,List<Edge> arm){
			List<Vertex> caminoVertices = recorridoProfundidad(verticeInicial,arm);
			List<Edge> caminoAristasFinal = new List<Edge>();
			List<Edge> aristasAux;
			for(int i = 0; i< caminoVertices.Count-1;i++){
				aristasAux = primeroProfundidad(caminoVertices[i],caminoVertices[i+1],arm);
				aristasAux.Reverse();
				caminoAristasFinal.AddRange(aristasAux);
			}
			return verificarRecorrido(caminoAristasFinal);
		}
		public int getCantidadSubgrafos(){
			return cantidadSubgrafos;
		}
		public double calcularPesoArm(List<Edge> armAnalizar){
			double pesoTotal = 0;
			for(int i = 0; i < armAnalizar.Count;i++){
				pesoTotal += armAnalizar[i].getDistancia();
			}
			return pesoTotal;
		}
		public List<Edge> verificarRecorrido(List<Edge> listaAristas){
			for(int i = 0; i < listaAristas.Count;i++){
				if(FuncionesUtiles.distanciaEntrePuntos(listaAristas[i].getVerticeDestino().getUbicacion(),listaAristas[i].getListaPuntos()[0])<
				   FuncionesUtiles.distanciaEntrePuntos(listaAristas[i].getVerticeOrigen().getUbicacion(),listaAristas[i].getListaPuntos()[0])){
					listaAristas[i].getListaPuntos().Reverse();
				}

			}
			return listaAristas;
		}
		//--------------------------------------------Etapa 5
		private bool esSolucionDijkstra(Lista<ElementoDijkstra> distanciasMinimas){
			//se revisa que todas las distancias sean definitivas
			for(int i = 0;i < distanciasMinimas.Count;i++){
				if(!distanciasMinimas[i].esDefinitivo()){
					return false;
				}
			}
			return true;
		}
		private void actualizaVectorDijstra(Lista<ElementoDijkstra>VectorDijkstra,int ind){
			//para cada arista a de G[ind]:
			//si a.pond + vectorDijkstra[ind] < vectorDijkstra[destino de a]
			//vectorDijkstra[destino de a].distancia = a.pond + vectorDijkstra[ind];
			//vectorDijkstra[destino de a].proveniente = G[ind];
		}
		private bool esDestinoDefinitivo(Edge aristaAnalizar,List<ElementoDijkstra> vectorDijkstra){
			for(int i = 0; i < vectorDijkstra.Count;i++){
				if(vectorDijkstra[i].getVertice().getId() == aristaAnalizar.getVerticeDestino().getId()){
					return vectorDijkstra[i].esDefinitivo();
				}
			}
			return false;
		}
		private ElementoDijkstra getElementoDijkstraDestino(Edge aristaAnalizar,List<ElementoDijkstra> vectorDijkstra){
			for(int i = 0; i < vectorDijkstra.Count;i++){
				if(vectorDijkstra[i].getVertice().getId() == aristaAnalizar.getVerticeDestino().getId()){
					return vectorDijkstra[i];
				}
			}
			return null;
		}
		private bool actualizarVectorDijkstra(Edge aristaActualizar,List<ElementoDijkstra> vectorDijkstra){
			for(int i = 0; i < vectorDijkstra.Count;i++){
				if(vectorDijkstra[i].getVertice().getId() == aristaActualizar.getVerticeDestino().getId()){
					if(aristaActualizar.getDistancia()<vectorDijkstra[i].getDistanciaAcumulada()){
						vectorDijkstra[i].setDistanciaAcumulada(aristaActualizar.getDistancia());
					}
					return true;
				}
			}
			return false;
		}
		private double obtenerDistanciaAcumulada(Vertex vertice,List<ElementoDijkstra> vectorDijkstra){
			for(int i = 0; i < vectorDijkstra.Count;i++){
				if(vectorDijkstra[i].getVertice().getId() == vertice.getId()){
					return vectorDijkstra[i].getDistanciaAcumulada();
				}
			}
			return double.PositiveInfinity;
		}
		public Lista<ElementoDijkstra> obtenerPesosMinimos(Vertex verticeInicial){
			Lista<ElementoDijkstra> distanciasMinimas = new Lista<ElementoDijkstra>();
			Lista<Edge> listaAristas = new Lista<Edge>();
			//ElementoDijkstra elementoDikstraAux;
			//se inicializa la lista con las distancias en infinito
			ElementoDijkstra nuevoElemento;
			//se meten todos los vertices del grafo
			Vertex proveniente = null;
			for(int i = 0; i < vl.Count;i++){
				nuevoElemento = new ElementoDijkstra(vl[i]);
				if(nuevoElemento.getVertice().getId() == verticeInicial.getId()){
					nuevoElemento.setDistanciaAcumulada(0);
					nuevoElemento.setDefinitivo(true);
					proveniente = nuevoElemento.getVertice();
				}
				distanciasMinimas.Add(nuevoElemento);
			}

			//se insertan las aristas del verticeInicial
			for(int i = 0; i < proveniente.getListaAristas().Count;i++){
				listaAristas.insertOrdered(proveniente.getListaAristas()[i]);
				//al insertar aristas actualizar los numeros
				//actualizarVectorDijkstra(proveniente.getListaAristas()[i],distanciasMinimas);
			}
			//return distanciasMinimas;
			//inicio del while
			Edge aristasMenor;
			ElementoDijkstra elementoAux;
			while(listaAristas.Count != 0 && !esSolucionDijkstra(distanciasMinimas)){
				aristasMenor = listaAristas[0];
				listaAristas.RemoveAt(0);
				proveniente = aristasMenor.getVerticeOrigen();
				//revisar si el destino de la arista menor es definitivo//si es definitivo se pasa a la siguiente;
				if(!esDestinoDefinitivo(aristasMenor,distanciasMinimas)){//mejorarlo cambiando este por el de abajo
					elementoAux = getElementoDijkstraDestino(aristasMenor,distanciasMinimas);
					elementoAux.setDefinitivo(true);
					elementoAux.setDistanciaAcumulada(obtenerDistanciaAcumulada(proveniente,distanciasMinimas)+aristasMenor.getDistancia());
					elementoAux.setProveniente(proveniente);
					//MessageBox.Show(elementoAux.ToString());
					
					//proveniente = elementoAux;
					//se insertan las aristas del proveniente que es el nuevo actual
					for(int i = 0; i < elementoAux.getVertice().getListaAristas().Count;i++){
						Edge arista = new Edge(elementoAux.getVertice(),elementoAux.getVertice().getListaAristas()[i].getVerticeDestino(),
						                       elementoAux.getVertice().getListaAristas()[i].getDistancia()+aristasMenor.getDistancia()
						                       ,elementoAux.getVertice().getListaAristas()[i].getListaPuntos(),elementoAux.getVertice().getListaAristas()[i].getId()*-1);
						listaAristas.insertOrdered(arista);
						//actualizarVectorDijkstra(arista,distanciasMinimas);
					}
				}
			}
			return distanciasMinimas;
		}
		public List<Vertex> busquedaProfundidad(Vertex verticeInicial){//recorrido en profunidad con backtrackin y recurisvo
			List<Vertex> pila = new List<Vertex>();
			List<Vertex> visitados = new List<Vertex>();
			List<Vertex> caminoCompleto = new List<Vertex>();
			int contador = new int();
			contador = 0;
			pila.Add(verticeInicial);
			visitados.Add(verticeInicial);
			busquedaProfundidad(pila,visitados,ref contador,caminoCompleto);
			contador--;
			//contador--;
			while(contador>0){
				caminoCompleto.RemoveAt(caminoCompleto.Count-1);
				contador--;
			}
			return caminoCompleto;
		}
		private void busquedaProfundidad(List<Vertex> pila,List<Vertex> visitados,ref int contador,List<Vertex>caminoCompleto){
			Vertex verticeActual;
			verticeActual = pila[pila.Count-1];
			pila.RemoveAt(pila.Count-1);
			contador = 0;
			for(int i = 0; i < verticeActual.getListaAristas().Count;i++){
				if(!visitados.Contains(verticeActual.getListaAristas()[i].getVerticeDestino())){
					pila.Add(verticeActual.getListaAristas()[i].getVerticeDestino());
					visitados.Add(verticeActual.getListaAristas()[i].getVerticeDestino());
					caminoCompleto.Add(verticeActual);
					busquedaProfundidad(pila,visitados,ref contador,caminoCompleto);
					//caminoCompleto.Add(verticeActual);
				}
			}
			caminoCompleto.Add(verticeActual);
			contador++;
		}
		public List<Edge> crearCaminoDeListaDeVertices(List<Vertex> vertices){
			List<Edge> caminoAristas = new List<Edge>();
			List<Edge> aristasAux;
			for(int i = 0; i < vertices.Count-1;i++){
				aristasAux = vertices[i].getListaAristas();
				for(int j = 0; j < aristasAux.Count; j++){
					if(aristasAux[j].getVerticeDestino() == vertices[i+1]){
						caminoAristas.Add(aristasAux[j]);
					}
				}
			}
			return caminoAristas;
		}
		//son normales no se regresa el camino de manera buena manera
		public List<Edge> busquedaProfundidadAristas(Vertex verticeInicial){//recorrido en profunidad con backtrackin y recurisvo
			List<Vertex> pila = new List<Vertex>();
			List<Vertex> visitados = new List<Vertex>();
			List<Vertex> caminoCompleto = new List<Vertex>();
			List<Edge> caminoAristas = new List<Edge>();
			int contador = new int();
			contador = 0;
			pila.Add(verticeInicial);
			visitados.Add(verticeInicial);
			busquedaProfundidadAristas(pila,visitados,ref contador,caminoCompleto,caminoAristas);
			contador--;
			while(contador>0){
				caminoCompleto.RemoveAt(caminoCompleto.Count-1);
				contador--;
			}
			return caminoAristas;
		}
		private void busquedaProfundidadAristas(List<Vertex> pila,List<Vertex> visitados,ref int contador,List<Vertex>caminoCompleto,List<Edge>caminoAristas){
			Vertex verticeActual;
			verticeActual = pila[pila.Count-1];
			pila.RemoveAt(pila.Count-1);
			contador = 0;
			for(int i = 0; i < verticeActual.getListaAristas().Count;i++){
				if(!visitados.Contains(verticeActual.getListaAristas()[i].getVerticeDestino())){
					pila.Add(verticeActual.getListaAristas()[i].getVerticeDestino());
					visitados.Add(verticeActual.getListaAristas()[i].getVerticeDestino());
					
					caminoAristas.Add(verticeActual.getListaAristas()[i]);
					
					caminoCompleto.Add(verticeActual);
					busquedaProfundidadAristas(pila,visitados,ref contador,caminoCompleto,caminoAristas);
					//caminoCompleto.Add(verticeActual);
				}
			}
			caminoCompleto.Add(verticeActual);
			contador++;
		}
		public List<Edge> crearCaminoDijkstra(Vertex verticeOrigen,Vertex verticeDestino,List<ElementoDijkstra> vectorDijkstra){//se crea el camino entre dos puntos tomando en cuenta el vector dijstra
			List<Edge> caminoFinal = new List<Edge>();
			List<Vertex> caminoVertices = new List<Vertex>();
			ElementoDijkstra elementoActual = new ElementoDijkstra();
			ElementoDijkstra dijkstraAux2 = new ElementoDijkstra();
			//se buscar el verticeDestino en vector dijkstra
			for(int i = 0; i < vectorDijkstra.Count;i++){
				if(vectorDijkstra[i].getVertice().getId() == verticeDestino.getId()){
					elementoActual = vectorDijkstra[i];
					break;
				}
			}
			if(elementoActual.getProveniente() == null && elementoActual.getVertice().getId() != verticeOrigen.getId()){
				return null;
			}
			//dijkstraAux.getProveniente() != null &&
			while(elementoActual.getVertice().getId() != verticeOrigen.getId()){
				caminoVertices.Add(elementoActual.getVertice());
				dijkstraAux2 = vectorDijkstra[0];
				//dijkstraAux = dijkstraAux.getProveniente();
				for(int i = 0; i < vectorDijkstra.Count;i++){
					if(vectorDijkstra[i].getVertice().getId() == elementoActual.getProveniente().getId() ){
						elementoActual = vectorDijkstra[i];
						break;
					}
				}
				if(elementoActual.getProveniente() == null && elementoActual.getVertice().getId() != verticeOrigen.getId()){
					return null;
				}
			}
			
			caminoVertices.Add(verticeOrigen);
			caminoVertices.Reverse();
			//se crea el camino de aristas a partir del de vertices
			for(int i = 0;i < caminoVertices.Count-1;i++){
				for(int j = 0; j < caminoVertices[i].getListaAristas().Count;j++){
					if(caminoVertices[i+1].getId() == caminoVertices[i].getListaAristas()[j].getVerticeDestino().getId()){
						caminoFinal.Add(caminoVertices[i].getListaAristas()[j]);
					}
				}
			}
			return caminoFinal;
		}
		//--------------------------------------------------------ETAPA 6----------------------------------
		public List<Edge> recorridoAnchuraAristas(Vertex verticeInicial){
			List<Vertex> colaVertices = new List<Vertex>();
			List<Edge> colaAristas = new List<Edge>();
			List<Vertex> visitados = new List<Vertex>();
			//extra
			List<Edge> aristasVisitadas = new List<Edge>();
			Edge aristaActual = null;
			//extra
			colaVertices.Add(verticeInicial);
			Vertex verticeActual;
			while(colaVertices.Count != 0){
				verticeActual = colaVertices[0];
				colaVertices.RemoveAt(0);
				//extra
				if(colaAristas.Count!=0){{
						aristaActual = colaAristas[0];
						colaAristas.RemoveAt(0);
					}
					//extra
					
					if(visitados.Contains(verticeActual)){
						visitados.Add(verticeActual);
						//EXTRA
						if(aristaActual != null){
							aristasVisitadas.Add(aristaActual);
						}
						//extra
						for(int i = 0; i < verticeActual.getListaAristas().Count;i++){
							if(!visitados.Contains(verticeActual.getListaAristas()[i].getVerticeDestino())){
								colaVertices.Add(verticeActual.getListaAristas()[i].getVerticeDestino());
								colaAristas.Add(verticeActual.getListaAristas()[i]);
							}
						}
					}
				}
			}
			return aristasVisitadas;
		}
	
		/*public List<Vertex> busquedaProfundidad(Vertex verticeInicial){//recorrido en profunidad con backtrackin y recurisvo
			List<Vertex> cola = new List<Vertex>();
			List<Vertex> visitados = new List<Vertex>();
			List<Vertex> caminoCompleto = new List<Vertex>();
			int contador = new int();
			contador = 0;
			pila.Add(verticeInicial);
			visitados.Add(verticeInicial);
			busquedaProfundidad(pila,visitados,ref contador,caminoCompleto);
			contador--;
			//contador--;
			while(contador>0){
				caminoCompleto.RemoveAt(caminoCompleto.Count-1);
				contador--;
			}
			return caminoCompleto;
		}
		private void busquedaProfundidad(List<Vertex> pila,List<Vertex> visitados,ref int contador,List<Vertex>caminoCompleto){
			Vertex verticeActual;
			verticeActual = pila[pila.Count-1];
			pila.RemoveAt(pila.Count-1);
			contador = 0;
			for(int i = 0; i < verticeActual.getListaAristas().Count;i++){
				if(!visitados.Contains(verticeActual.getListaAristas()[i].getVerticeDestino())){
					pila.Add(verticeActual.getListaAristas()[i].getVerticeDestino());
					visitados.Add(verticeActual.getListaAristas()[i].getVerticeDestino());
					caminoCompleto.Add(verticeActual);
					busquedaProfundidad(pila,visitados,ref contador,caminoCompleto);
					//caminoCompleto.Add(verticeActual);
				}
			}
			caminoCompleto.Add(verticeActual);
			contador++;
		}		
		*/
		public List<Edge> recorridoAnchura(Vertex verticeInicial){
			List<Vertex> cola = new List<Vertex>();
			List<Vertex> visitados = new List<Vertex>();
			List<Edge> caminoCompleto = new List<Edge>();
			List<int> listaNivelesHijos = new List<int>();
			List<int> listaNiveles = new List<int>();
			
			listaNiveles.Add(1);
			cola.Add(verticeInicial);
			visitados.Add(verticeInicial);
			if(recorridoAnchura(cola,visitados,caminoCompleto,listaNivelesHijos,listaNiveles)){
				if(caminoCompleto.Count != 0){
					return caminoCompleto;
				}
				else{
					return null;
				}
			}
			else{
				return null;
			}
		}
		public bool recorridoAnchura(List<Vertex> cola,List<Vertex> visitados,List<Edge>caminoCompleto,List<int> listaNivelesHijos
		                            ,List<int> listaNiveles){
			Vertex verticeActual;
			bool esHijo = true;
			int nivelActual;
			if(cola.Count != 0){
				nivelActual = listaNiveles[0];
				listaNiveles.RemoveAt(0);
				verticeActual = cola[0];
				cola.RemoveAt(0);
				for(int i = 0; i < verticeActual.getListaAristas().Count;i++){
					if(!visitados.Contains(verticeActual.getListaAristas()[i].getVerticeDestino())){
						cola.Add(verticeActual.getListaAristas()[i].getVerticeDestino());
						visitados.Add(verticeActual.getListaAristas()[i].getVerticeDestino());
						caminoCompleto.Add(verticeActual.getListaAristas()[i]);
						
						esHijo = false;
						listaNiveles.Add((nivelActual+1));
					}
				}
				if(esHijo){
					listaNivelesHijos.Add(nivelActual);
					if(listaNivelesHijos[0] != nivelActual){
						return false;
					}
				}
				//para mejorar en las ramas
				if(listaNivelesHijos.Count!= 0 && listaNiveles.Count!= 0){
					if(listaNivelesHijos[0] != listaNiveles[listaNiveles.Count-1]){
						return false;
					}
				}
				if(recorridoAnchura(cola,visitados,caminoCompleto,listaNivelesHijos,listaNiveles)){
					return true;
				}
				else{
					return false;
				}
			}
			return true;
		}
		
		//-------------------------------------------------Proyecto FINAL------------------------------------------------------
		public int[,] floydWharshall(){
			double[,] distancias = new double[vl.Count, vl.Count]; 
			int[,] anteriores = new int[vl.Count, vl.Count]; 
        	int i, j, k; 
        	bool existeConexion = false;
        	//inicialiazcion        	
        	for( i = 0; i < vl.Count;i++){
        		for( j = i+1; j <vl.Count;j++){
        			if(i == j){//se inicializa la diagonal en ceros
        				//por ser grafo conexo se inicializan las dos direcciones
        				distancias[i,j] = 0;
        				distancias[j,i] = 0;
        				
        				anteriores[i,j] = -1;
        				anteriores[j,i] = -1;
        			}
        			else{
        				existeConexion = false;
        				//se buscar en la lista de aristas si existe j
        				for(k = 0; k < vl[i].getListaAristas().Count;k++){
        					if(vl[i].getListaAristas()[k].getVerticeDestino().getId() == j){
        						distancias[i,j] = vl[i].getListaAristas()[k].getDistancia();
        						distancias[j,i] = vl[i].getListaAristas()[k].getDistancia();
        						
        						anteriores[i,j] = i;
        						anteriores[j,i] = j;
        						existeConexion = true;
        						break;
        					}
        				}
        				if(!existeConexion){
        					distancias[i,j] = double.PositiveInfinity;	
        					distancias[j,i] = double.PositiveInfinity;
							anteriores[i,j] = -1;
        					anteriores[j,i] = -1;        					
        				}
        			}
				}
			}
        	
        	for(k = 0; k < vl.Count;k++){
        		for(i = 0; i < vl.Count;i++){
        			for(j = 0; j < vl.Count;j++){
        				if (distancias[i, k] + distancias[k, j] < distancias[i, j])  
	                    { 
	                        distancias[i, j] = distancias[i, k] + distancias[k, j];
	                        anteriores[i, j] = anteriores[k,j];
	                    } 
        			}
        		}
        	}
        	
        	//mostrar
        	//string aux = "";
        	/*for( i = 0;i < vl.Count;i++){
        		aux += i.ToString() +" -> ";
				for( j = 0; j < vl.Count;j++){
        			aux += Math.Round(distancias[i,j],2).ToString()+ ", ";
				}
        		aux += "\n";
			}*/
        	/*aux += "        ";
        	for( i = 0;i < vl.Count;i++){
        		aux += i.ToString() +"  ";
			}
        	aux += "\n";
        	for( i = 0;i < vl.Count;i++){
        		aux += i.ToString() +" -> ";
				for( j = 0; j < vl.Count;j++){
        			aux += anteriores[i,j].ToString()+ ", ";
				}
        		aux += "\n";
			}*/
        	//MessageBox.Show(aux);
        	
        	return anteriores;
		}
		public List<int> crearCaminoEnterosFloyd(int[,] caminosMinimos,Vertex inicial,Vertex destino){
			List<int> caminoInt = new List<int>();
			
			if(caminosMinimos[inicial.getId(),destino.getId()] == -1){
				return null;//regresa null si el camino no se puede crear
			}
			int idVerticeActual;
			
			idVerticeActual = destino.getId();
			
			caminoInt.Add(destino.getId());
			while(idVerticeActual != inicial.getId()){
				idVerticeActual = caminosMinimos[inicial.getId(),idVerticeActual];
				caminoInt.Add(idVerticeActual);
			}
			
			caminoInt.Reverse();
			/*for(int i = 0; i < caminoInt.Count; i++){
				MessageBox.Show(caminoInt[i].ToString());
			}*/
			return caminoInt;
		}
		public List<Edge> crearCaminoFloyd(List<int> vertices){
			List<Edge> caminoFinal = new List<Edge>();
			for(int i = 0; i < vertices.Count-1;i++){
				for(int j = 0; j < vl.Count;j++){
					if(vl[j].getId() == vertices[i]){//despues de encontrar el vertice buscar en sus aristas el siguiente
						for(int k = 0; k < vl[j].getListaAristas().Count;k++){
							if(vl[j].getListaAristas()[k].getVerticeDestino().getId() == vertices[i+1]){
								caminoFinal.Add(vl[j].getListaAristas()[k]);
							}
						}
					}
				}
			}
			return caminoFinal;
		}
	}
	public class ElementoDijkstra:IComparable{
		double distanciaAcumulada;
		bool definitivo;
		Vertex proveniente;
		Vertex vertice;
		public ElementoDijkstra(){
			this.vertice = null;
			distanciaAcumulada = double.PositiveInfinity;
			definitivo = false;
			proveniente = null;
		}
		public ElementoDijkstra(Vertex vertice){
			this.vertice = vertice;
			distanciaAcumulada = double.PositiveInfinity;
			definitivo = false;
			proveniente = null;
		}
		public ElementoDijkstra(Vertex vertice,double distancia){
			this.vertice = vertice;
			distanciaAcumulada = distancia;
			definitivo = false;
			proveniente = null;
		}
		public void setDistanciaAcumulada(double nuevaDistancia){
			distanciaAcumulada = nuevaDistancia;
		}
		public void setDefinitivo(bool definitivo){
			this.definitivo = definitivo;
		}
		public void setProveniente(Vertex verticeProveniente){
			proveniente = verticeProveniente;
		}
		public double getDistanciaAcumulada(){
			return distanciaAcumulada;
		}
		public bool esDefinitivo(){
			return definitivo;
		}
		public Vertex getVertice(){
			return vertice;
		}
		public Vertex getProveniente(){
			return proveniente;
		}
		public static bool operator <(ElementoDijkstra elemento1,ElementoDijkstra elemento2){
			return elemento1.getDistanciaAcumulada() < elemento2.getDistanciaAcumulada();
		}
		public static bool operator >(ElementoDijkstra elemento1,ElementoDijkstra elemento2){
			return elemento1.getDistanciaAcumulada() > elemento2.getDistanciaAcumulada();
		}
		public bool Equals(ElementoDijkstra other)
		{
			if (other == null) return false;
			return (this.distanciaAcumulada.Equals(other.distanciaAcumulada))&&(this.distanciaAcumulada.Equals(other.distanciaAcumulada));
		}
		
		int IComparable.CompareTo(object obj)
		{
			ElementoDijkstra c=(ElementoDijkstra)obj;
			if (this > c)
				return 1;
			if (this < c)
				return -1;
			else
				return 0;
		}
		private class sortEdgeAscendingHelper : IComparer{
			int IComparer.Compare(object a, object b)
			{
				ElementoDijkstra c1 = (ElementoDijkstra)a;
				ElementoDijkstra c2 = (ElementoDijkstra)b;
				if (c1.getDistanciaAcumulada() > c2.getDistanciaAcumulada())
					return 1;
				if (c1.getDistanciaAcumulada() < c2.getDistanciaAcumulada())
					return -1;
				else
					return 0;
			}
			public static IComparer sortYearAscending(){
				return (IComparer) new sortEdgeAscendingHelper();
			}
			
		}
		public override string ToString()
		{
			string objetoStr;
			//vertice = idDest.ToString() + " ("+Math.Round(distancia,2) +") ";
			objetoStr = "{"+vertice.getId().ToString()+ "," + definitivo.ToString() + ",";
			if(double.IsPositiveInfinity(distanciaAcumulada)){
				objetoStr += "infinito" + ",";
			}
			else{
				objetoStr += Math.Round(distanciaAcumulada,2) + ",";
			}
			if(proveniente == null){
				objetoStr += "null" +"}" ;
			}
			else{
				objetoStr += proveniente.getId()+ "}";
			}
			return objetoStr;
		}
	}
	public class Vertex: ICloneable{
		List<Edge> listaAristas;
		Circulo circle;
		int id;
		
		public Vertex(Circulo c,int id){
			circle = c;
			this.id = id;
			listaAristas = new List<Edge>();
		}
		//Etapa 3 se agrego la referencia del origen y la lista de puntos
		public void addEdge(Vertex refOrigen,Vertex refDestino,double distancia,List<Point>aristaPuntos,int idArista){
			Edge e = new Edge(refOrigen,refDestino,distancia,aristaPuntos,idArista);
			listaAristas.Add(e);
		}
		public int getId(){
			return id;
		}
		public Point getUbicacion(){
			return circle.getCentro();
		}
		public Circulo getCircle(){
			return circle;
		}
		public List<Edge> getListaAristas(){
			return listaAristas;
		}
		public Edge getPrimeraArista(){
			return listaAristas[0];
		}
		public string getAristasToString(){
			string aristas = "";
			for(int i = 0; i < listaAristas.Count;i++){
				aristas += listaAristas[i].ToString() + ",";
			}
			return aristas;
		}
		public void deleteEdge(Vertex destinoEliminar){
			for(int i = 0; i < listaAristas.Count;i++){
				if(listaAristas[i].getVerticeDestino() == destinoEliminar){
					listaAristas.RemoveAt(i);
					return;
				}
			}
		}
		//etapa 3
		public void setListaAristas(List<Edge>aristas){
			listaAristas = new List<Edge>(aristas);
			//listaAristas = aristas;
		}
		public object Clone()
		{
			return this.MemberwiseClone();
		}
		//etapa 4
		/*public static bool operator ==(Vertex arista1,Vertex arista2){
			return true;
		}*/
		/*public static bool operator !=(Vertex arista1,Vertex arista2){
			return true;
		}*/
		public static bool operator <(Vertex vertice1,Vertex vertice2){
			return vertice1.circle.getId() < vertice2.circle.getId();
		}
		public static bool operator >(Vertex vertice1,Vertex vertice2){
			return vertice1.circle.getId() > vertice2.circle.getId();
		}
		/*
		public static bool operator !=(Vertex vertice1,Vertex vertice2){
			return vertice1.id != vertice2.id;
		}
		public static bool operator ==(Vertex vertice1,Vertex vertice2){
			return vertice1.id == vertice2.id;
		}
		 */
		//etapa 4
		public override string ToString()
		{
			string vertice;
			//vertice = idDest.ToString() + " ("+Math.Round(distancia,2) +") ";
			vertice = id.ToString() + "-";
			return vertice;
		}
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			Vertex objAsVertex = obj as Vertex;
			if (objAsVertex == null) return false;
			else
				return Equals(objAsVertex);
		}
		public override int GetHashCode()
		{
			return id;
		}
		public bool Equals(Vertex other)
		{
			if (other == null) return false;
			return (this.id.Equals(other.id));
		}
	}
	public class Edge: IComparable{
		Vertex refVertex;//DESTINO
		int idDest;
		double distancia;
		//double pendiente;
		List<Point> puntosArista;
		//etapa 3
		Vertex refOrigen;
		//etapa 5
		int id;
		public Edge(Vertex origen,Vertex dest,double d,List<Point>puntosArista,int id){
			refOrigen = origen;
			refVertex = dest;
			idDest = dest.getId();
			distancia = d;
			this.puntosArista = puntosArista;
			this.id = id;
			//this.pendiente =pendiente;
		}
		public override string ToString()
		{
			string vertice;
			//vertice = idDest.ToString() + " ("+Math.Round(distancia,2) +") ";
			vertice = "{"+refOrigen.getId().ToString()+ "," + refVertex.getId().ToString()+ ","+Math.Round(distancia,2)+"}";
			return vertice;
		}
		public Vertex getVerticeDestino(){
			return refVertex;
		}
		public double getDistancia(){
			return distancia;
		}
		//etapa 3
		public Vertex getVerticeOrigen(){
			return refOrigen;
		}
		public List<Point> getListaPuntos(){
			return puntosArista;
		}
		public object Clone()
		{
			return this.MemberwiseClone();
		}
		//etapa 5
		public int getId(){
			return id;
		}
		//public double getPendiente(){
			//return pendiente;
		//}
		//etapa 4
		public List<Point> getListaPuntosInversa(){
			List<Point> listaPuntosInversa = new List<Point>(puntosArista);
			listaPuntosInversa.Reverse();
			return listaPuntosInversa;
		}
		public void setListaPuntos(List<Point> puntos){
			puntosArista = puntos;
		}
		public static bool operator <(Edge arista1,Edge arista2){
			return arista1.getDistancia() < arista2.getDistancia();
		}
		public static bool operator >(Edge arista1,Edge arista2){
			return arista1.getDistancia() > arista2.getDistancia();
		}
		public static bool operator <=(Edge arista1,Edge arista2){
			return arista1.getDistancia() <= arista2.getDistancia();
		}
		public static bool operator >=(Edge arista1,Edge arista2){
			return arista1.getDistancia() <= arista2.getDistancia();
		}
		
		/*public static bool operator !=(Edge arista1,Edge arista2){
			return (arista1.getVerticeDestino() != arista2.getVerticeDestino()) && (arista1.getVerticeOrigen() != arista2.getVerticeOrigen());
		}
		public static bool operator ==(Edge arista1,Edge arista2){
			return (arista1.getVerticeDestino() == arista2.getVerticeDestino()) && (arista1.getVerticeOrigen() == arista2.getVerticeOrigen());
		}	*/

		/*public override bool Equals(object obj)
	{
		if (obj == null) return false;
		Edge objAsEdge = obj as Edge;
		if (objAsEdge == null) return false;
		else
			return Equals(objAsEdge);
	}*/
		/*public override int GetHashCode()
	    {
	        return id;
	    }*/
		public bool Equals(Edge other)
		{
			if (other == null) return false;
			return (this.refOrigen.Equals(other.refOrigen))&&(this.refVertex.Equals(other.refVertex));
		}
		
		int IComparable.CompareTo(object obj)
		{
			Edge c=(Edge)obj;
			if (this > c)
				return 1;
			if (this < c)
				return -1;
			else
				return 0;
		}
		private class sortEdgeAscendingHelper : IComparer{
			int IComparer.Compare(object a, object b)
			{
				Edge c1 = (Edge)a;
				Edge c2 = (Edge)b;
				if (c1.getDistancia() > c2.getDistancia())
					return 1;
				if (c1.getDistancia() < c2.getDistancia())
					return -1;
				else
					return 0;
			}
			public static IComparer sortYearAscending(){
				return (IComparer) new sortEdgeAscendingHelper();
			}
			
		}
		public static IComparer sortEdgeAscending()
		{
			return (IComparer) new sortEdgeAscendingHelper();
		}
	}
}

