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
	///	Main class, thatwill work with data in XML format.
	/// </summary>
	public class DB_XML
	{
		//Private class variables:
		private string conf_MainXsd = "NT_SkelbimuRrinkimasAnalizavimas.xsd";
		private string conf_ConfigurationXml = "MainAddressesConfiguration.xml";

		/// <summary>
		/// Constructor
		/// </summary>
		public DB_XML()
		{

		}

		/// <summary>
		/// Read configuration and return it.
		/// </summary>
		public DataTable GetConfiguration()
		{
			//Declare and set local variables:
			DataSet ds = new DataSet();
			
			//Read xsd file from  disk:
			ds.ReadXmlSchema(conf_MainXsd);
			
			//Read XML data from disk:
			ds.ReadXml(conf_ConfigurationXml);
			
			//Return configuration table:
			return ds.Tables["MainAddressesConfiguration"];
		}
	}
}