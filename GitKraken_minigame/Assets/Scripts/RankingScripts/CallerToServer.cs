﻿using UnityEngine;
using System.Collections;
using System.Net;
using System;
using System.Text;
using System.IO;

public class CallerToServer : MonoBehaviour {


	private string HttpRequestMaker(string jsonText, string serviceName){

		print("Enviando peticion...");
		WebRequest request = WebRequest.Create ("http://51.254.134.174/gitkraken/"+serviceName);
		request.Method = "POST";


		print("Preparando datos la petición...");
		string postData = jsonText;
		byte[] byteArray = Encoding.UTF8.GetBytes (postData);


		print("Definiendo tipo de respuesta...");
		((HttpWebRequest)request).Accept = "application/json";
		request.ContentType = "application/json";
		request.ContentLength = byteArray.Length;


		print("Escribiendo en flujo de salida...");
		Stream dataStream = request.GetRequestStream ();
		dataStream.Write (byteArray, 0, byteArray.Length);
		dataStream.Close ();


		print("Obteniendo respuesta...");
		WebResponse response = request.GetResponse ();
		//print (((HttpWebResponse)response).StatusCode);
		dataStream = response.GetResponseStream ();
		StreamReader reader = new StreamReader (dataStream);
		string responseFromServer = reader.ReadToEnd ();

		//consola.text = responseFromServer;

		print("Cerrando todo...");
		reader.Close ();
		dataStream.Close ();
		response.Close ();

		return responseFromServer;
	}


}
