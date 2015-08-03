/*
 * Created by SharpDevelop.
 * User: mrtorres
 * Date: 8/3/2015
 * Time: 8:23 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using RustServerManager;

namespace RustServerManager
{
	class Program
	{
		public static void Main(string[] args)
		{
			List<RustServer> servers = new List<RustServer>();
			
			servers.Add(new RustServer());

			
			
			Console.ReadKey(true);
		}
	}
}