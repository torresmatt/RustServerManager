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

namespace RustServerManager
{
	/// <summary>
	/// Description of ServerDownloader.
	/// </summary>
	public static class ServerDownloader
	{
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
			
			using (var client = new WebClient())
			{
				client.DownloadFile(downloadURL,zipPath());
			}
		}
		
		public static void install()
		{
			if (!isDownloaded())
			{
				download();
			}
			
			if (!isInstalled())
			{
				ZipFile.ExtractToDirectory(zipPath(),steamFolder);
			}			
		}
		
		public static void update()
		{
			if (!isInstalled())
			{
				install();
			}
			Process.Start(fullPath(),"+quit");
			
			Console.WriteLine("Waiting for steamcmd.exe to finish...");
			while (Process.GetProcessesByName("steamcmd").Length != 0);
   
		}
		
		public static string fullPath()
		{
			return steamFolder + steamEXE;
		}
		
		public static string zipPath()
		{
			return steamFolder + steamZip;
		}
		
		public static bool isDownloaded()
		{
			return File.Exists(zipPath());
		}
		
		public static bool isInstalled()
		{
			return File.Exists(fullPath());
		}
	}
}
