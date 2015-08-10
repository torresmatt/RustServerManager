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
	
	[Serializable]
	public class RustServer
	{
		private string m_hostName;
		private string m_identity;
		private string m_portNumber;
		private string m_seed;
		private int m_maxPlayers;
		private int m_worldSize;
		private bool m_isDev;		
		
		public RustServer()
		{
			// Initialize member variables to defaults
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
			
			// return the constructed string
			return result;
		}
		
		public string steamCMDArgs()
		{
			string result = "";
			
			result += "+login anonymous";
			
			result += " +force_install_dir ..\\servers\\";
			if (m_isDev)
			{
				result += "dev_server";
			}
			else
			{
				result += "main_server";
			}
			
			result += " +app_update 258550 -beta ";
			if (m_isDev)
			{
				result += "development";
			}
			else
			{
				result += "experimental";
			}
			result += " validate";
			
			result += " +quit";			
			
			return result;
		}
		
		public string summarize()
		{
			// build a string line by line containing info about the server
			string result = "";
			result += "Hostname = \"" + m_hostName + "\"\n";
			result += "Identity = \"" + m_identity + "\"\n";
			result += "Seed = " + m_seed + "\n";
			result += "World size = " + m_worldSize + "m squared\n";
			result += "Port number = " + m_portNumber + "\n";
			result += "Max players = " + m_maxPlayers + "\n";
			
			// add the appropriate branch name depending on whether the server is flagged as dev
			result += "Branch = ";
			if (m_isDev)
			{
				result += "Development\n";
			}
			else
			{
				result += "Main\n";
			}
			
			// return the constructed string
			return result;
		}
		
		// getters setters start here
		
		public string hostName
		{
			get
			{
				return m_hostName;
			}
			
			set
			{
				m_hostName = value;
			}
		}
		
		public string identity
		{
			get
			{
				return m_identity;
			}
			
			set
			{
				// make the passed in value lowercase
				value = value.ToLower();
				// make an empty string to add to and be returned later
				string result = "";
				// go through each character in the string
				foreach (char c in value)
				{
					// if it isn't a symbol, punctuation or whitespace, we want to add it to the string in some form
					if (!Char.IsSymbol(c) && !Char.IsPunctuation(c))
					{
						// if it is a separator, add _
						if (Char.IsSeparator(c))
						{
							result += '_';
						}
						// otherwise, add the character
						else
						{
							result += c;
						}
					}
				}
				m_identity = result;
			}
		}
		
		public bool isDev
		{
			get
			{
				return m_isDev;
			}
			set
			{
				// if it is a different value, change it and update the identity to reflect dev branch or not
				if (value != m_isDev)
				{
					m_isDev = value;
					hostName = m_hostName;
				}
			}
		}
	}
}
