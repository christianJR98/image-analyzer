/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 02/03/2019
 * Time: 09:08 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace Etapa_1
{
	public class Agente
	{
		Vertex v_o;
		double distanciaTotal;
		List<Edge> caminoCompleto;
		int id;
		
		int indAristaActual;
		int posActualEnArista;
		bool caminoCompletado;
		int cantidadVertices;
		
		bool posicionInicial;
		
		Vertex verticeDestino;
		
		List<Point> instante1;
		List<Point> instante2;
		bool esPrimerRecorrido;
		public Agente(Vertex verticeInicial,int id)
		{
			v_o = verticeInicial;
			this.id = id;
			cantidadVertices = 0;
			distanciaTotal = 0;
			caminoCompleto = new List<Edge>();
			caminoCompletado = false;
			posicionInicial = true;

			instante1 = new List<Point>();
			instante2 = new List<Point>();
			esPrimerRecorrido = true;
		}
		public Agente(Vertex verticeInicial,Vertex verticeDestino,int id)
		{
			v_o = verticeInicial;
			this.verticeDestino = verticeDestino;
			this.id = id;
			cantidadVertices = 0;
			distanciaTotal = 0;
			caminoCompleto = new List<Edge>();
			caminoCompletado = false;
			posicionInicial = true;

			instante1 = new List<Point>();
			instante2 = new List<Point>();
			esPrimerRecorrido = true;
		}
		public void setId(int idNuevo){
			this.id = idNuevo;
		}
		public void setCaminoCompleto(List<Edge> caminoCompleto){
			this.caminoCompleto = caminoCompleto;
		}
		public void limpiarCaminoCompleto(){
			while(caminoCompleto.Count!=0){
				caminoCompleto.RemoveAt(0);
			}
		}
		public int getId(){
			return id;
		}
		public Vertex getVerticeActual(){
			return v_o;
		}
		public Vertex getVerticeDestino(){
			return verticeDestino;
		}
		public void setVerticeDestino(Vertex verticeDes){
			verticeDestino = verticeDes;
		}
		public List<Edge> getCamino(){
			return caminoCompleto;
		}
		public Edge getAristaActual(){
			return caminoCompleto[indAristaActual];
		}
		public string getCaminoString(){
			string cadena = "";
			for(int i = 0; i < caminoCompleto.Count;i++){
				cadena += "{"+caminoCompleto[i].getVerticeOrigen().getId().ToString() +","+
					caminoCompleto[i].getVerticeDestino().getId().ToString()+"}";
			}
			return cadena;
		}
		public void setVerticeActual(Vertex verticeInicial){
			v_o = verticeInicial;
		}

		public void agregarAristaCamino(Edge arista){
			caminoCompleto.Add(arista);
		}
		public bool aristaYaVisitada(Edge arista){
			for(int i = 0; i < caminoCompleto.Count;i++){
				if(caminoCompleto[i].getVerticeDestino() == arista.getVerticeDestino()){
					if(caminoCompleto[i].getVerticeOrigen() == arista.getVerticeOrigen()){
						return true;
					}
				}
				if(caminoCompleto[i].getVerticeDestino() == arista.getVerticeOrigen()){
					if(caminoCompleto[i].getVerticeOrigen() == arista.getVerticeDestino()){
						return true;
					}
				}
			}
			return false;
		}
		
		public void setEsPrimerRecorrido(bool esPrimerRecorrido){
			this.esPrimerRecorrido = esPrimerRecorrido;
		}
		public bool getEsPrimerRecorrido(){
			return esPrimerRecorrido;
		}
		
		public void guardarUbicaciones(List<Agente> presas){
			int []radios = new int[3];
			radios[0] = 150;
			radios[1] = 250;
			radios[2] = 350;
			instante1 = instante2;
			while(instante2.Count != 0){
				instante1.RemoveAt(0);
			}
			if(caminoCompleto.Count == 0){
				for(int i = 0; i < presas.Count;i++){
					if(FuncionesUtiles.distanciaEntrePuntos(v_o.getUbicacion(),presas[i].getPosicionActualArista())<radios[2]){
						instante2.Add(presas[i].getPosicionActualArista());
					}
				}
				ordenar(instante2,v_o.getUbicacion());
			}
			else{
				for(int i = 0; i < presas.Count;i++){
					if(FuncionesUtiles.distanciaEntrePuntos(getPosicionActualArista(),presas[i].getPosicionActualArista())<radios[2]){
						instante2.Add(presas[i].getPosicionActualArista());
					}
				}
				ordenar(instante2,getPosicionActualArista());
			}
		}
		public void tomarDesicion(List<Agente> presas){
			/*int radio1 = 150;
			int radio2 = 250;
			int radio3= 350;
			*/
			int []radios = new int[3];
			radios[0] = 100;
			radios[1] = 200;
			radios[2] = 300;
			if(caminoCompleto.Count == 0){
				posActualEnArista = 0;
				indAristaActual = 0;
			}
			//se tienen las presas cercanas
			//Tomar desicion
			if(instante1.Count != 0 && instante2.Count!=0){
				if(caminoCompletado == true){
					MessageBox.Show("Dos instantes");
					//tomar puntos que la distancia entre ellos sea menor a 7 y mayor/igual a 1
					int indice1 = 0;
					int indice2 = 0;
					bool hayParejaValida = false;;
					for(indice1 = 0; indice1 < instante1.Count;indice1++){
						for(indice2 = 0; indice2 < instante2.Count;indice2++){
							/*if(FuncionesUtiles.distanciaEntrePuntos(instante1[indice1],instante2[indice2]) > 0 &&
							   FuncionesUtiles.distanciaEntrePuntos(instante1[indice1],instante2[indice2]) < 8){
								hayParejaValida = true;
								MessageBox.Show("Hay dos puntos de la misma presa :D");
								break;
							}*/
						}
						if(hayParejaValida){
							break;
						}
					}
					indice1 = 0;
					indice2 = 0;
					hayParejaValida = true;
					if(hayParejaValida){
						MessageBox.Show("Hay pareja valida");
						//calcular intersecciones
						List<Point> intersecciones = null;
						int radioInterseccion;
						for(radioInterseccion = 0;radioInterseccion < 3;radioInterseccion++){
							intersecciones = calcularIntersecciones(instante1[indice1],instante2[indice2],
							                                        getPosicionActualArista(),radios[radioInterseccion]);
							if(intersecciones.Count != 0){
								break;
							}
						}
						if(intersecciones.Count != 0){
							//ver direccion
							MessageBox.Show("Hay intersecciones");
							Point puntoFuturo;
							if(FuncionesUtiles.distanciaEntrePuntos(instante1[indice1],intersecciones[0]) <
							   FuncionesUtiles.distanciaEntrePuntos(instante2[indice2],intersecciones[0])){
								puntoFuturo = intersecciones[1];
							}
							else{
								puntoFuturo = intersecciones[0];
							}
							//calcular la pendiete
							//tomar la mejor arista
							//de las aristas disponibles tomar la que te deje mas cerca de la interseccion
							List<Edge> aristasDisponibles;
							aristasDisponibles = getAristaActual().getVerticeDestino().getListaAristas();
							double distanciaMenor = FuncionesUtiles.distanciaEntrePuntos(aristasDisponibles[0].getVerticeDestino().getUbicacion(),puntoFuturo);
							int aristaMenor = 0;
							for(int i = 0; i < aristasDisponibles.Count;i++){
								if(FuncionesUtiles.distanciaEntrePuntos(aristasDisponibles[i].getVerticeDestino().getUbicacion(),puntoFuturo) < distanciaMenor){
									distanciaMenor = FuncionesUtiles.distanciaEntrePuntos(aristasDisponibles[i].getVerticeDestino().getUbicacion(),puntoFuturo);
									aristaMenor = i;
								}
							}
							caminoCompleto.Add(aristasDisponibles[aristaMenor]);
							caminoCompletado = false;
						}
						else{
							//tomar uno random
							MessageBox.Show("Tomar random");
						}
					}
					else{
						Random rand = new Random();
						int indice;
						List<Edge> aristasDisponibles;
						if(caminoCompleto.Count == 0){
							aristasDisponibles = new List<Edge>(getVerticeActual().getListaAristas());
						}
						else{
							aristasDisponibles = new List<Edge>(getAristaActual().getVerticeDestino().getListaAristas());
						}
						indice = rand.Next(0, aristasDisponibles.Count);
						//aristasDisponibles[indice].setListaPuntos(aristasDisponibles[indice].getListaPuntosInversa());
						caminoCompleto.Add(aristasDisponibles[indice]);
						caminoCompletado = false;
					}
					
				}
				AvanzarPixelesArista(1);
				return;
			}
			else if(instante1.Count != 0){
				if(caminoCompletado == true){
					Random rand = new Random();
					int indice;
					List<Edge> aristasDisponibles = new List<Edge>(getAristaActual().getVerticeDestino().getListaAristas());
					indice = rand.Next(0, aristasDisponibles.Count);
					
					caminoCompleto.Add(aristasDisponibles[indice]);
					verificarRecorrido(caminoCompleto);
					//dirigirse hacia la presa
				}
				AvanzarPixelesArista(1);
				return;
			}
			else if(instante2.Count != 0){
				
				if(caminoCompletado == true){
					Random rand = new Random();
					int indice;
					List<Edge> aristasDisponibles = new List<Edge>(getAristaActual().getVerticeDestino().getListaAristas());
					indice = rand.Next(0, aristasDisponibles.Count);
					
					caminoCompleto.Add(aristasDisponibles[indice]);
					verificarRecorrido(caminoCompleto);
					//dirigirse hacia la presa
				}
				AvanzarPixelesArista(1);
				return;
			}
			else{
				//tomar una al azar
				if(caminoCompletado == true){
					Random rand = new Random();
					int indice;
					List<Edge> aristasDisponibles;
					aristasDisponibles = new List<Edge>(getAristaActual().getVerticeDestino().getListaAristas());
					
					indice = rand.Next(0, aristasDisponibles.Count);
					caminoCompleto.Add(aristasDisponibles[indice]);
					verificarRecorrido(caminoCompleto);
					MessageBox.Show("Agregar 1" + aristasDisponibles[indice].ToString());
					caminoCompletado = false;
				}
				else{
					if(caminoCompleto.Count == 0){
						Random rand = new Random();
						int indice;
						List<Edge> aristasDisponibles;
						aristasDisponibles = new List<Edge>(v_o.getListaAristas());
						
						indice = rand.Next(0, aristasDisponibles.Count);
						caminoCompleto.Add(aristasDisponibles[indice]);
						MessageBox.Show("Agregar V_0" + aristasDisponibles[indice].ToString());
						caminoCompletado = false;
						verificarRecorrido(caminoCompleto);
					}
					//sino solo avanza
				}
			}
			AvanzarPixelesArista(1);
		}
		static int compararPuntos(Point punto1,Point punto2,Point puntoCentral){
			if(FuncionesUtiles.distanciaEntrePuntos(punto1,puntoCentral) <
			   FuncionesUtiles.distanciaEntrePuntos(punto2,puntoCentral)){
				return -1;
			}
			else if(FuncionesUtiles.distanciaEntrePuntos(punto1,puntoCentral) >
			        FuncionesUtiles.distanciaEntrePuntos(punto2,puntoCentral)){
				return 1;
			}
			else{
				return 0;
			}
		}
		static void SwapPoints(ref Point x, ref Point y)
		{
			Point tempswap = x;
			x = y;
			y = tempswap;
		}
		static void ordenar(List<Point> puntos,Point puntoCentral){
			for(int i = 0; i< puntos.Count-1;i++){
				for(int j = i+1; j < puntos.Count;j++){
					if(FuncionesUtiles.distanciaEntrePuntos(puntos[j],puntoCentral) <
					   FuncionesUtiles.distanciaEntrePuntos(puntos[i],puntoCentral)){
						Point tempswap = puntos[j];
						puntos[j] = puntos[i];
						puntos[i] = tempswap;
					}
				}
			}
		}
		List<Point> calcularIntersecciones(Point punto1Original,Point punto2Original,Point centroOriginal,double radio){
			List<Point> intersecciones = new List<Point>();
			Point punto1 = new Point(punto1Original.X-centroOriginal.X,punto1Original.Y-centroOriginal.Y);
			Point punto2 = new Point(punto2Original.X-centroOriginal.X,punto2Original.Y-centroOriginal.Y);
			Point centro = new Point(0,0);
			double m = ((double)punto2.Y - (double)punto1.Y)/((double)punto2.X-(double)punto1.X);

			//CIRCUNFERENCIA
			int x_1,y_1;
			int x_2,y_2;
			
			//label3.Text = "(X-"+ centro.X.ToString() + ")^2" + " + Y - " + centro.Y + "= " + Math.Pow(radio,2);
			
			double a,b,c;
			a = (double)1 + (double)Math.Pow(m,2);
			b = (double)2*m*(double)((double)punto1.Y-m*(double)punto1.X);
			c = (double)Math.Pow((double)punto1.Y-m*(double)punto1.X,2) - (double)Math.Pow(radio,2);

			
			try{
				x_1 = (int)Math.Round((((b*(double)-1) + Math.Sqrt(Math.Pow(b,(double)2)-((double)4*a*c)))/((double)2*a)),0);
				y_1 = (int)Math.Round((((double)punto1.Y - (m*(double)punto1.X)) + m*(double)x_1),0);
				Point interseccion1 = new Point(x_1+centroOriginal.X,y_1+centroOriginal.Y);
				intersecciones.Add(interseccion1);
			}catch(Exception){
				
			}
			try{
				x_2 = (int)Math.Round((((b*(double)-1) - Math.Sqrt(Math.Pow(b,(double)2)-((double)4*a*c)))/((double)2*a)),0);
				y_2 = (int)Math.Round((((double)punto1.Y - (m*(double)punto1.X)) + m*(double)x_2),0);
				Point interseccion2 = new Point(x_2+centroOriginal.X,y_2+centroOriginal.Y);
				intersecciones.Add(interseccion2);
			}
			catch(Exception){
				
			}
			return intersecciones;
		}
		void verificarRecorrido(List<Edge> listaAristas){
			for(int i = 0; i < listaAristas.Count;i++){
				if(FuncionesUtiles.distanciaEntrePuntos(listaAristas[i].getVerticeDestino().getUbicacion(),listaAristas[i].getListaPuntos()[0])<
				   FuncionesUtiles.distanciaEntrePuntos(listaAristas[i].getVerticeOrigen().getUbicacion(),listaAristas[i].getListaPuntos()[0])){
					listaAristas[i].getListaPuntos().Reverse();
				}
			}
		}
		public bool CaminoCompletado(){
			/*if(v_o.getUbicacion() ==caminoCompleto[caminoCompleto.Count-1].getVerticeDestino().getUbicacion()){
				return true;
			}
			return false;*/
			return caminoCompletado;
		}
		public Point getSigueintePosPixel(int cantidadPixeles){
			if((posActualEnArista + cantidadPixeles+1) < caminoCompleto[indAristaActual].getListaPuntos().Count){
				return caminoCompleto[indAristaActual].getListaPuntos()[posActualEnArista+cantidadPixeles];
			}
			else{
				if((indAristaActual+1) < caminoCompleto.Count){
					return caminoCompleto[indAristaActual+1].getListaPuntos()[0];
				}
				else{
					return caminoCompleto[indAristaActual].getListaPuntos()[caminoCompleto[indAristaActual].getListaPuntos().Count-1];
				}
			}
		}
		public void AvanzarPixelesArista(int cantidadPixeles){
			posicionInicial = false;
			if((posActualEnArista + cantidadPixeles+1) < caminoCompleto[indAristaActual].getListaPuntos().Count){
				posActualEnArista = posActualEnArista+cantidadPixeles;
			}
			else{
				if((indAristaActual+1) < caminoCompleto.Count){
					indAristaActual++;
					posActualEnArista = 0;
				}
				else{
					posActualEnArista = caminoCompleto[indAristaActual].getListaPuntos().Count-1;
					caminoCompletado = true;
					esPrimerRecorrido = false;
				}
			}
		}
		public bool estaPosicionInicial(){
			return posicionInicial;
		}
		public void retrocederPixelesArista(int cantidadPixeles){
			if((posActualEnArista - cantidadPixeles) >= 0 ){
				posActualEnArista = posActualEnArista-cantidadPixeles;
			}
			else{
				if(indAristaActual >0 ){//se cambia a la arista anterior
					indAristaActual--;
					posActualEnArista = caminoCompleto[indAristaActual].getListaPuntos().Count-1;
				}
				else{
					posicionInicial = true;
				}
			}
		}
		public bool estaEnCentroVertice(){
			if(FuncionesUtiles.distanciaEntrePuntos(caminoCompleto[0].getVerticeOrigen().getUbicacion(), getPosicionActualArista()) <= caminoCompleto[0].getVerticeOrigen().getCircle().getRadio()){
				//MessageBox.Show("Esta en centro");
				return true;
			}
			for(int i = 0; i < caminoCompleto.Count;i++){
				if(FuncionesUtiles.distanciaEntrePuntos(caminoCompleto[i].getVerticeDestino().getUbicacion(), getPosicionActualArista()) <= caminoCompleto[i].getVerticeDestino().getCircle().getRadio()){
					//MessageBox.Show("Esta en centro");
					return true;
				}
			}
			return false;
		}
		
		public Point getPosicionActualArista(){
			List<Point> puntosArista = caminoCompleto[indAristaActual].getListaPuntos();
			return puntosArista[posActualEnArista];
		}
		public void inicializarVariablesAnimacion(){
			if(caminoCompleto.Count!=0){
				v_o = caminoCompleto[0].getVerticeOrigen();
				posActualEnArista = 0;
				indAristaActual = 0;
				caminoCompletado = false;
			}
			else{//solo hay un vertice
				cantidadVertices = 1;
				caminoCompletado = true;
			}
		}
		public int obtenerCantidadVertices(){
			cantidadVerticesRecorrida();
			return cantidadVertices;
		}
		public double obtenerDistanciaRecorrida(){
			if(distanciaTotal == 0){
				for(int i = 0; i < caminoCompleto.Count;i++){
					distanciaTotal += caminoCompleto[i].getDistancia();
				}
			}
			return distanciaTotal;
		}
		public int cantidadVerticesRecorrida(){

			//cantidadVertices = 0;
			List <Vertex> listaVertices = new List<Vertex>();
			if(caminoCompleto.Count != 0){
				//cantidadVertices++;
				listaVertices.Add(caminoCompleto[0].getVerticeOrigen());//inicializar
				for(int i = 0; i < caminoCompleto.Count;i++){
					if(!listaVertices.Contains(caminoCompleto[i].getVerticeDestino())){
						listaVertices.Add(caminoCompleto[i].getVerticeDestino());
					}
					/*
					for(int j = 0; j <listaVertices.Count;j++){
						if(listaVertices[j].getUbicacion() == caminoCompleto[i].getVerticeDestino().getUbicacion()){
							agregar = false;
							break;
						}
					}
					if(agregar == true){
						cantidadVertices++;
						listaVertices.Add(caminoCompleto[i].getVerticeDestino());
					}
					agregar = true;*/
				}
			}
			return listaVertices.Count;
		}
		public string getNombre()
		{
			return string.Format("Agente {0}",id);
		}
		public override string ToString()
		{
			return string.Format("[Id={0},Camino={1},Distancia={2},]",id,getCaminoString(),
			                     Math.Round(obtenerDistanciaRecorrida(),2));
		}
	}
}
