/*
 * Created by SharpDevelop.
 * User: mrtorres
 * Date: 8/10/2015
 * Time: 1:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace RustServerManager
{
	/// <summary>
	/// Description of Menu.
	/// </summary>
	public class Menu
	{
		
		private ServerList m_list;
		
		public Menu()
		{
			m_list = new ServerList();
		}
		
		public Menu(ref ServerList list)
		{
			m_list = list;			
		}
	}
}
