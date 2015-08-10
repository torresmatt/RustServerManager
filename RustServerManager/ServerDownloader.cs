/*
 * Created by SharpDevelop.
 * User: Sparrowhawk
 * Date: 8/3/2015
 * Time: 8:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace RustServerManager
{
	/// <summary>
	/// A static class designed to be used by the main program to update servers and keep steamcmd up to date
	/// </summary>
	public static class ServerDownloader
	{
		const string serverFolder = "servers\\";
		const string steamFolder = "steamcmd\\";
		const string steamEXE = "steamcmd.exe";
		const string steamZip = "steamcmd.zip";
		const string downloadURL = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";
		
		public static void download()
		{
			// is the folder there? If not, make it!
			if (!Directory.Exists(steamFolder))
			{
				Directory.CreateDirectory(steamFolder);
			}
			
			// create a web client and download steamcmd.zip to the proper path
			using (var client = new WebClient())
			{
				client.DownloadFile(downloadURL,zipPath());
			}
		}
		
		public static void install()
		{
			// use isDownloaded() method to figure out if it's downloaded.
			// If not, download it
			if (!isDownloaded())
			{
				download();
			}
			
			// use isInstalled() to figure out if it is extracted.
			// If not, extract it.
			if (!isInstalled())
			{
				ZipFile.ExtractToDirectory(zipPath(),steamFolder);
			}			
		}
		
		public static void update()
		{
			// If it isn't installed, install it!
			if (!isInstalled())
			{
				install();
			}
			
			// Run steamcmd.exe and quit when done updating
			Process.Start(fullPath(),"+quit");			
			Console.Write("Updating steamcmd");
			// While it's still running, display a message, wait for it to finish
			while (Process.GetProcessesByName("steamcmd").Length != 0)
			{
				Thread.Sleep(1000);
				Console.Write(".");
			}
			Console.WriteLine();   
		}
		
		public static void updateServer(ref RustServer server)
		{
			// If steamcmd isn't installed, install it.
			if (!isInstalled())
			{
				Console.WriteLine("steamcmd.exe not found, installing...");
				install();
			}
			
			// run steamcmd.exe and quit when done updating server
			Process.Start(fullPath(),server.steamCMDArgs());
			// While it's still running, display a message, wait for it to finish
			Console.Write("Updating server \"" + server.hostName + "\"");
			while (Process.GetProcessesByName("steamcmd").Length != 0)
			{
				Thread.Sleep(1000);
				Console.Write(".");
			}
			Console.WriteLine("\nServer \"" + server.hostName + "\" has been updated.");
		}
		
		public static string fullPath()
		{
			// return the exe name concatenated onto the folder
			return steamFolder + steamEXE;
		}
		
		public static string zipPath()
		{
			// return the zip filename concatenated onto the folder
			return steamFolder + steamZip;
		}
		
		public static bool isDownloaded()
		{
			// return whether the zip file is found
			return File.Exists(zipPath());
		}
		
		public static bool isInstalled()
		{
			// return whether the exe is found
			return File.Exists(fullPath());
		}
	}
}
