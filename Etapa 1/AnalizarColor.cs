/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 15/02/2019
 * Time: 09:36 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace Etapa_1
{
	/// <summary>
	/// Description of AnalizarColor.
	/// </summary>
	public static class AnalizarColor
	{
		public static bool isWhite(Color color){
			if(color.R != 255)
				return false;
			if(color.G != 255)
				return false;
			if(color.B != 255)
				return false;
			return true;
		
		}
		public static bool isBlack(Color c){
			if(c.R != 0)
				return false;
			if(c.G != 0)
				return false;
			if(c.B != 0)
				return false;
			return true;
		}
		public static bool isDarkRed(Color c){
			if(c.R != 139)
				return false;
			if(c.G != 0)
				return false;
			if(c.B != 0)
				return false;
			return true;
		}
		public static bool isBlue(Color c){
			if(c.R != 0)
				return false;
			if(c.G != 0)
				return false;
			if(c.B != 255)
				return false;
			return true;
		}
		public static bool isRed(Color c){
			if(c.R != 255)
				return false;
			if(c.G != 0)
				return false;
			if(c.B != 0)
				return false;
			return true;
		}
	}
}
