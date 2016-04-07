using System.Collections;
using System.Net;
using System;
using System.Text;
using System.IO;
using UnityEngine;

//SINGLETON: Author Santiago Hoyos Zea
public class CallerToServer{

	private static CallerToServer instance;

	private CallerToServer(){
	}

	public static CallerToServer getInstance(){

		if (instance == null) {
			instance = new CallerToServer ();
		}

		return instance;
	}

	public string HttpRequestMaker(string jsonText, string serviceRute){


		WebRequest request = WebRequest.Create ("http://51.254.134.174/webservices/gitkraken/"+serviceRute);
		request.Method = "POST";
	

		string postData = jsonText;
		byte[] byteArray = Encoding.UTF8.GetBytes (postData);


		((HttpWebRequest)request).Accept = "application/json";
		request.ContentType = "application/json";
		request.ContentLength = byteArray.Length;


		Stream dataStream = request.GetRequestStream ();
		dataStream.Write (byteArray, 0, byteArray.Length);
		dataStream.Close ();


		WebResponse response = request.GetResponse ();
		//print (((HttpWebResponse)response).StatusCode);
		dataStream = response.GetResponseStream ();
		StreamReader reader = new StreamReader (dataStream);
		string responseFromServer = reader.ReadToEnd ();


		reader.Close ();
		dataStream.Close ();
		response.Close ();

		return responseFromServer;
	}
		

//	public string GetItemCatelogResponse(string serviceRute2)
//	{
//		string url="http://51.254.134.174/webservices/gitkraken/" + serviceRute2;
//
//		WWW www = new WWW(url);
//
//		StartCoroutine ("WaitForRequest", www);
//
//		while (!www.isDone);
//
//		return www.text; 
//	}
//
//
//	// Run the web call and deliver the result as it is arriving.
//	private IEnumerator WaitForRequest (WWW www)
//	{
//		yield return www;
//	}

}
