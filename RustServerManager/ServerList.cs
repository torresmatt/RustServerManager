/*
 * Created by SharpDevelop.
 * User: mrtorres
 * Date: 8/3/2015
 * Time: 2:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using RustServerManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RustServerManager
{
	/// <summary>
	/// Description of ServerList.
	/// </summary>
	
	public class ServerList
	{
		public List<RustServer> m_list;
		public string m_dataDir;
		public string m_dataFile;
		public string m_devPath;
		public string m_mainPath;
		
		// default constructor
		public ServerList()
		{
			// stub: add check for file to deserialize from.
			m_list = new List<RustServer>();
			m_dataDir = "server_data\\";
			m_dataFile  = "server_list.xml";
			m_devPath = "servers\\rust_server_dev\\";
			m_mainPath = "server\\rust_server_main\\";
		}
		
		// method for building a new server for the list
		public void add()
		{
			m_list.Add(new RustServer());
		}
		
		// method for serializing the list of server objects to a file.
		public void serialize()
		{
			// Does the server_data folder exist? If not, make it.
			if (!Directory.Exists(m_dataDir))
			{
				Directory.CreateDirectory(m_dataDir);
			}
			
			// make a serializer
			var serializer = new XmlSerializer(typeof(List<RustServer>));
			
			
			using (var stream = File.OpenWrite(m_dataDir + m_dataFile))
			{
				serializer.Serialize(stream,m_list);
			}
		}
	}
}
