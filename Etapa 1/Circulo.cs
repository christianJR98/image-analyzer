/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 30/01/2019
 * Hora: 07:50 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;

namespace Etapa_1
{
	public class Circulo
	{
		private int ejeX;
		private int ejeY;
		private int radio;
		private int id;
		public Circulo(int ejeX,int ejeY ,int radio, int id)
		{
			this.ejeX = ejeX;
			this.ejeY = ejeY;
			this.radio = radio;
			this.id = id;
		}
		
		public override string ToString()
		{
			return string.Format("[Id={3},X={0}, Y={1}, R={2}]", ejeX, ejeY, radio, id);
		}
		public int getEjeX(){
			return ejeX;
		}
		public int getId(){
			return id;
		}
		public int getEjeY(){
			return ejeY;
		}
		public int getRadio(){
			return radio;
		}
		public double getRadioDistancia(){
			Point punto2 = new Point(ejeX+radio,ejeY);
			return FuncionesUtiles.distanciaEntrePuntos(getCentro(),punto2);
		}
		public Point getCentro(){
			Point punto = new Point(ejeX,ejeY);
			return punto;
		}
	}
}
