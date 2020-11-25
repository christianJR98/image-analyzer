/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 07/03/2019
 * Time: 08:30 a. m.
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
	/// Description of VentanaMejorAgente.
	/// </summary>
	public partial class VentanaMejorAgente : Form
	{
		List<Agente> agentes;
		public VentanaMejorAgente(List<Agente> agentes)
		{
			InitializeComponent();
			if(agentes.Count != 0){
				this.agentes = agentes;
				textBoxId.Text = agentes[0].getId().ToString();
				textBoxDistancia.Text = Math.Round(agentes[0].obtenerDistanciaRecorrida(),2).ToString();
				textBoxCantidadVertices.Text = agentes[0].cantidadVerticesRecorrida().ToString();
				listBoxCamino.DataSource = agentes[0].getCamino();

				listBoxAgentes.DataSource = agentes;
				buttonMostrarAgente.Enabled = true;
				buttonMostrarMejorAgente.Enabled = true;
				textBoxId.Enabled = true;
			}
			else{
				MessageBox.Show("Para ver informacion primero hacer animacion SOLO de depredadores");
			}
		}
		void ButtonSalirClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void ButtonMostrarMejorAgenteClick(object sender, EventArgs e)
		{
			Agente mejorAgente;
			
			mejorAgente = agentes[0];
			for(int i = 0; i < agentes.Count-1;i++){
				for(int j = i+1; j < agentes.Count;j++){
					if(mejorAgente.cantidadVerticesRecorrida()<agentes[j].cantidadVerticesRecorrida()){
						mejorAgente = agentes[j];
					}
					else if(mejorAgente.cantidadVerticesRecorrida()==agentes[j].cantidadVerticesRecorrida()){
						if(mejorAgente.obtenerDistanciaRecorrida()>agentes[j].obtenerDistanciaRecorrida()){
							mejorAgente = agentes[j];
						}
					}
				}
			}
			
			textBoxId.Text = mejorAgente.getId().ToString();
			textBoxDistancia.Text = Math.Round(mejorAgente.obtenerDistanciaRecorrida(),2).ToString();
			textBoxCantidadVertices.Text = mejorAgente.cantidadVerticesRecorrida().ToString();
			listBoxCamino.DataSource = mejorAgente.getCamino();
			
		}
		void ButtonMostrarAgenteClick(object sender, EventArgs e)
		{
			int indice;
			if(textBoxId.Text != ""){
				try{
					indice = Convert.ToInt32(textBoxId.Text);
					if(indice >= 0 && indice < agentes.Count ){
						textBoxId.Text = agentes[indice].getId().ToString();
						textBoxDistancia.Text = Math.Round(agentes[indice].obtenerDistanciaRecorrida(),2).ToString();
						textBoxCantidadVertices.Text = agentes[indice].cantidadVerticesRecorrida().ToString();
						listBoxCamino.DataSource = agentes[indice].getCamino();
					}
					else{
						MessageBox.Show("El ID es invalido");
						textBoxId.Text = agentes[0].getId().ToString();
						textBoxDistancia.Text = Math.Round(agentes[0].obtenerDistanciaRecorrida(),2).ToString();
						textBoxCantidadVertices.Text = agentes[0].cantidadVerticesRecorrida().ToString();
						listBoxCamino.DataSource = agentes[0].getCamino();
					}
				}
				catch(Exception){
					MessageBox.Show("El ID es invalido");
					textBoxId.Text = agentes[0].getId().ToString();
					textBoxDistancia.Text = Math.Round(agentes[0].obtenerDistanciaRecorrida(),2).ToString();
					textBoxCantidadVertices.Text = agentes[0].cantidadVerticesRecorrida().ToString();
					listBoxCamino.DataSource = agentes[0].getCamino();
				}
			}
			else{
				MessageBox.Show("Ingresa el ID del agente para mostrar informacion");
				textBoxId.Text = agentes[0].getId().ToString();
				textBoxDistancia.Text = Math.Round(agentes[0].obtenerDistanciaRecorrida(),2).ToString();
				textBoxCantidadVertices.Text = agentes[0].cantidadVerticesRecorrida().ToString();
				listBoxCamino.DataSource = agentes[0].getCamino();
			}
		}
	}
}
