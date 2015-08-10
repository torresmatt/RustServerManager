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
		
		// constructors
		
		// default constructor makes a fresh list and tries to deserialize it
		public Menu()
		{
			m_list = new ServerList();
			m_list.deSerialize();
		}
		
		// overloaded constructor takes a list and makes it the list for this menu
		public Menu(ref ServerList list)
		{
			m_list = list;			
		}
		
		// void methods
		
		public void listMenu()
		{
			int choice;
			
			Console.Clear();
			
			Console.WriteLine("Server List");
			Console.WriteLine("-----------\n");
			
			foreach (RustServer server in m_list.list)
			{
				Console.Write(server.hostName + "\t");
				if (server.isDev)
				{
					Console.Write("Dev ");
				}
				else
				{
					Console.Write("Main ");
				}
				Console.WriteLine("branch");
			}
		}
		
		public void mainMenu()
		{			
			int choice;
			
			Console.Clear();

			Console.WriteLine("Rust Server Menu");
			Console.WriteLine("----------------\n");
			Console.WriteLine("1 - List servers");
			Console.WriteLine("2 - Add server");
			Console.WriteLine("3 - Remove server");
			Console.WriteLine("4 - Edit server");
			Console.WriteLine("5 - Quit\n");
			
			// keep asking for input until valid entry is received
			do
			{
				// get us into a loop that will only be exited if there are no exceptions caught
				while (true)
				{
					try
					{
						Console.Write("Enter choice: ");
						choice = Convert.ToInt32(Console.ReadLine());
						break;
					}
					catch (Exception e) {}
				}
			} while (choice < 1 || choice > 5);
			
			
			// take action depending on input.
			switch (choice)
			{
				case 1:
					listMenu();
					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
				case 5:
					quit();
					break;
			}
			                  
		}
		
		public void quit()
		{
			m_list.serialize();
			Console.WriteLine("Thanks for using Rust Server Manager!");
		}
	}
}
