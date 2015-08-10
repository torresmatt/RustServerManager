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
			var server = new RustServer();
			server.hostName = "Test";
			server.identity = "Matt's best server #1";
			Console.WriteLine(server.summarize());
			ServerDownloader.updateServer(ref server);
			Console.WriteLine("Changing server to dev branch...");
			server.isDev = true;
			Console.WriteLine(server.summarize());
			ServerDownloader.updateServer(ref server);
			Console.ReadKey(true);
		}
	}
}