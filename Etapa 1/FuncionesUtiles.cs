/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 20/02/2019
 * Time: 10:11 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace Etapa_1
{
	/// <summary>
	/// Description of FuncionesUtiles.
	/// </summary>
	public static class FuncionesUtiles
	{ 
		public static double distanciaEntrePuntos(Point puntoInicial,Point puntoFinal){
			return Math.Sqrt((Math.Pow((puntoFinal.X-puntoInicial.X),2)+Math.Pow((puntoFinal.Y-puntoInicial.Y),2)));
		}	
		public static double calcularPendiente(Point puntoInicial,Point puntoFinal){
			if(puntoInicial.X == puntoFinal.X){
				return double.PositiveInfinity;
			}
			return (puntoFinal.Y-puntoInicial.Y)/(puntoFinal.X-puntoInicial.X);
		}	
		/*public static double iniciarCronometro(){
			
			TimeSpan start = new TimeSpan(DateTime.Now.Ticks);
			
			stop = new TimeSpan(DateTime.Now.Ticks);
			return stop.Subtract(start).TotalMilliseconds;
		}*/
		/*public static double tiempo(){
			
			TimeSpan stop;
			TimeSpan start = new TimeSpan(DateTime.Now.Ticks);
			
			stop = new TimeSpan(DateTime.Now.Ticks);
			return stop.Subtract(start).TotalMilliseconds;
		}*/
	}
}
