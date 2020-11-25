/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 30/04/2019
 * Time: 12:32 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Etapa_1
{
	/// <summary>
	/// Description of InformacionAnimacion.
	/// </summary>
	public partial class InformacionAnimacion : Form
	{
		public InformacionAnimacion(Agente presa,Agente depredador,Edge arista)
		{
			InitializeComponent();
			if(depredador != null){
				textBoxDepredadorId.Text = depredador.getId().ToString();
				listBoxCaminoDepredador.DataSource = depredador.getCamino();
			}
				textBoxPresaId.Text = presa.getId().ToString();
				listBoxCaminoPresa.DataSource = presa.getCamino();
			if(arista != null){
				textBoxArista.Text = arista.ToString();	
			}			
		}
	}
}
