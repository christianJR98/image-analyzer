/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 21/03/2019
 * Time: 08:55 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Etapa_1
{
	public class Lista<T> : List<T>
	{
		public void insertOrdered(T element){
			int search = 0;
			//IComparer<T> compare = new CompareProduct();
			search = BinarySearch(element);//,(IComparer<T>)compare
			if(search < 0){
				Insert(~search,element);
			}
			else{
				Insert(search,element);
			}
		}
		public void copyToList(List<T> list){
			for(int i = 0; i < Count;i++){
				list.Add(this[i]);
			}
		}
	}
}
