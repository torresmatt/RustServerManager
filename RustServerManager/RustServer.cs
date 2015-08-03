/*
 * Created by SharpDevelop.
 * User: mrtorres
 * Date: 8/3/2015
 * Time: 8:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RustServerManager
{
	/// <summary>
	/// A server that delineates info about a rust dedicated server.
	/// </summary>
	/// 
	
	[Serializable]
	public class RustServer
	{
		string m_dataFolder = ".\\server_data\\";
		string m_fileExt = ".rsv";
		string m_hostName;
		string m_identity;
		string m_portNumber;
		string m_seed;
		int m_maxPlayers;
		int m_worldSize;
		bool m_isDev;
		
		
		public RustServer()
		{
			m_hostName = "Rust Server";
			m_identity = "rust_server";
			m_portNumber = "28015";
			m_seed = "0";
			m_maxPlayers = 50;
			m_isDev = false;
			m_worldSize = 2000;
		}
		
		public string buildArgs()
		{
			//build a string containing RustDedicated.exe arguments for the server using object attributes
			string result = "";
			result += " -batchmode";
			result += " +server.identity " + "\"" + m_identity + "\"";
			result += " +server.hostname " + "\"" + m_hostName + "\"";
			result += " +server.seed " + m_seed;
			result += " +server.worldsize " + m_worldSize;
			result += " +server.port " + m_portNumber;
			result += " +server.maxplayers " + m_maxPlayers;
			
			return result;
		}
		
		public void serialize()
		{
			// Does the server_data folder exist? If not, make it.
			if (!Directory.Exists(m_dataFolder))
			{
				Directory.CreateDirectory(m_dataFolder);
			}

			// create an IFormatter
			IFormatter formatter = new BinaryFormatter();
			// create a stream to the file
			Stream fStream = new FileStream(m_dataFolder + m_identity + m_fileExt, FileMode.Create, FileAccess.Write, FileShare.None);
			// use the formatter to serialize "this" object
			formatter.Serialize(fStream,this);
			// close the stream
			fStream.Close();
		}
	}
}
