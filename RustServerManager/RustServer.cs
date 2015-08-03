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
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace RustServerManager
{
	/// <summary>
	/// A server that delineates info about a rust dedicated server.
	/// </summary>
	/// 
	
	public class RustServer
	{
		public string m_hostName;
		public string m_identity;
		public string m_portNumber;
		public string m_seed;
		public int m_maxPlayers;
		public int m_worldSize;
		public bool m_isDev;		
		
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
	}
}
