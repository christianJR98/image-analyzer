/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 04/06/2019
 * Time: 11:05 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Etapa_1
{
	/// <summary>
	/// Description of FloydDijkstra.
	/// </summary>
	public partial class FloydDijkstra : Form
	{
		Graph grafoCopia;
		Bitmap fondo;
		Bitmap bitmapDijkstra;
		Bitmap bitmapFloyd;
		int[,] floydCopia;
		public FloydDijkstra(Graph grafo,Bitmap original,int[,] floyd)
		{
			InitializeComponent();
			fondo = new Bitmap(original);
			bitmapDijkstra = new Bitmap(original.Width,original.Height);
			bitmapFloyd = new Bitmap(original.Width,original.Height);
			grafoCopia = grafo;
			for(int i = 0; i <grafoCopia.getListaVertices().Count;i++){
				comboBoxInicio.Items.Add(grafoCopia.getListaVertices()[i].getId());
				//comboBoxDestino.Items.Add(grafoCopia.getListaVertices()[i].getId());
			}
			pictureBoxDijkstra.BackgroundImage = fondo;
			pictureBoxFloyd.BackgroundImage = fondo;
			pictureBoxDijkstra.Image = bitmapDijkstra;
			pictureBoxFloyd.Image = bitmapFloyd;
			floydCopia = floyd;
		}
		void dibujarDistanciasMinimas(Lista<ElementoDijkstra> vectorDijkstra){
			for(int i = 0; i < vectorDijkstra.Count;i++){
				if(vectorDijkstra[i].getProveniente()!= null){
					dibujarLinea(bitmapDijkstra,Color.Black,5,vectorDijkstra[i].getProveniente().getUbicacion(),vectorDijkstra[i].getVertice().getUbicacion());
				}
			}
			pictureBoxDijkstra.Refresh();
		}
		
		void dibujarLinea(Bitmap bmp,Color color,int lineaGrueso,Point punto1,Point punto2){
			Graphics imagenGraphics = Graphics.FromImage(bmp);
			Pen pincel = new Pen(color, lineaGrueso);
            
		    imagenGraphics.DrawLine(pincel, punto1, punto2);
		}
		void Button1Click(object sender, EventArgs e)
		{
			int indice;
			try{
				indice = Convert.ToInt32(comboBoxInicio.Text);
				if(indice>=0 && indice< grafoCopia.getListaVertices().Count){
					bitmapDijkstra = new Bitmap(fondo.Width,fondo.Height);
					
					dibujarDistanciasMinimas(grafoCopia.obtenerPesosMinimos(grafoCopia.getListaVertices()[indice]));
					
					pictureBoxDijkstra.Image = bitmapDijkstra;
					List<int> listaInt;
										
					bitmapFloyd = new Bitmap(fondo.Width,fondo.Height);
					
					for(int i = 0; i < grafoCopia.getListaVertices().Count;i++){
						if(i != indice){
							if(floydCopia[indice,i] != -1){
								listaInt = grafoCopia.crearCaminoEnterosFloyd(floydCopia,grafoCopia.getListaVertices()[indice],grafoCopia.getListaVertices()[i]);
							
								List<Edge> camino = grafoCopia.crearCaminoFloyd(listaInt);
								for(int k = 0; k < camino.Count;k++){
									dibujarLinea(bitmapFloyd,Color.Black,5,camino[k].getVerticeOrigen().getUbicacion(),camino[k].getVerticeDestino().getUbicacion());
								}
							}
						}
					}
					
					pictureBoxFloyd.Image = bitmapFloyd;
					
				}
				else{
					MessageBox.Show("Error en le vertice inicial,Indice fuera de rango");
					return;
				}
			}catch(Exception){
				MessageBox.Show("Error en le vertice inicial,Formato invalido");
				return;
			}	
		}
	}
}
