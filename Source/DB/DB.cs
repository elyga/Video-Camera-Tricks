using System;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Net;
using System.Data;

namespace ES.Software.NT_Skelbimu_rinkimas_ir_analizavimas
{
	/// <summary>
	/// Main class, that will wrap all DB formats.
	/// DB will be described in configuration file. 
	/// </summary>
	public class DB
	{
		//Private class variables:
		private string conf_DbEngine = "XML"; //Possible values: XML;
		//private string conf_Connection = "";  //XML don't need connection information.
	
		/// <summary>
		/// Constructor
		/// </summary>
		public DB()
		{
			//In future we will read information about DB.
		}
		
		/// <summary>
		/// Read configuration and return it.
		/// </summary>
		public DataTable GetConfiguration()
		{
			//In case engine is XML:
			if (conf_DbEngine=="XML")
			{
				//Declare and set local variables:
				DB_XML objDB_XML = new DB_XML();
			
				//Return value:
				return objDB_XML.GetConfiguration();
			}
			
			//Defaulr return:
			return null;
		}		
	}
}
