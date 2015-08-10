/*
 * Created by SharpDevelop.
 * User: mrtorres
 * Date: 8/3/2015
 * Time: 2:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RustServerManager
{
	/// <summary>
	/// Description of ServerList.
	/// </summary>
	
	public class ServerList
	{
		public List<RustServer> m_list;
		public string m_dataFolder;
		public string m_dataPath;
		public string m_devPath;
		public string m_mainPath;
		
		// default constructor
		public ServerList()
		{
		
			m_list = new List<RustServer>();
			m_dataFolder = "server_data\\";
			m_dataPath = "server_data\\server_list.dat";
			m_devPath = "servers\\rust_server_dev\\";
			m_mainPath = "server\\rust_server_main\\";
		}
		
		// method for building a new server for the list
		public void add()
		{
			m_list.Add(new RustServer());
		}
		
		// method to erase m_list for this instance of ServerList
		public void clear()
		{
			m_list = new List<RustServer>();
		}
		
		// method for deserializing the list of servers from a file
		public void deSerialize()
		{
			// does file exist? If not, return
			if (!File.Exists(m_dataPath))
			{
				Console.WriteLine("Cannot find data file " + m_dataPath);
				return;
			}
			
			// make file stream
			FileStream inFile = new FileStream(m_dataPath, FileMode.Open);
			
			// make formatter
			BinaryFormatter formatter = new BinaryFormatter();
			
			// deserialize into list
			m_list = (List<RustServer>) formatter.Deserialize(inFile);
			
			// close file stream
			inFile.Close();
		}
		
		// method for serializing the list of server objects to a file.
		public void serialize()
		{
			// Does the server_data folder exist? If not, make it.
			if (!Directory.Exists(m_dataFolder))
			{
				Directory.CreateDirectory(m_dataFolder);
			}
			
			// make file stream
			FileStream outFile = new FileStream(m_dataPath, FileMode.Create);			
			// make binary formatter
			BinaryFormatter formatter = new BinaryFormatter();
			
			// serialize it!
			formatter.Serialize(outFile, m_list);
			
			// close stream
			outFile.Close();
		}
		
		public string summarize()
		{
			string result = "";
			foreach (RustServer server in m_list)
			{
				result += server.summarize();
				result += "\n";
			}				
				
			return result;
		}
	}
}
