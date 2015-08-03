/*
 * Created by SharpDevelop.
 * User: mrtorres
 * Date: 8/3/2015
 * Time: 8:23 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using RustServerManager;

namespace RustServerManager
{
	class Program
	{
		public static void Main(string[] args)
		{
			RustServer server = new RustServer();
			Console.WriteLine(server.buildArgs());
			
			server.serialize();
			
			Console.ReadKey(true);
		}
	}
}