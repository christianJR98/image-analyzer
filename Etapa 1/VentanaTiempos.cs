/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 21/02/2019
 * Time: 09:09 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Etapa_1
{
	/// <summary>
	/// Description of VentanaTiempos.
	/// </summary>
	public partial class VentanaTiempos : Form
	{
		public VentanaTiempos(double tiempoFuerzaBruta)
		{
			InitializeComponent();
			textBox1.Text = tiempoFuerzaBruta.ToString();
		}
	}
}
