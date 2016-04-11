using UnityEngine;
using System.Collections;
using SimpleJson;
using models;
using UnityEngine.UI;
using UnityEngine.Experimental.Networking;

public class RankingManager : MonoBehaviour {

	public GameObject prefabItemRanking;
	private int pos;

	void Start(){

		StartCoroutine (LoadRanking());

		StartCoroutine (CheckInRankingReq(200));

		//StartCoroutine (UpdateRanking("Amo Santi",300));
	}
		

	IEnumerator LoadRanking() {

		UnityWebRequest www = UnityWebRequest.Get("http://51.254.134.174/webservices/gitkraken/ranking/LoadRanking.php");
		yield return www.Send();

		if(www.isError) {
			print ("Ojo con la implementación CORS de seguridad de JavaScript");
		}
		else {
			DrawRanking (www.downloadHandler.text);
		}
	}

	private void DrawRanking(string respuesta_json){

		SimpleJSON.JSONNode nodo_principal= SimpleJSON.JSON.Parse (respuesta_json);


		IEnumerator enumerator= nodo_principal.Childs.GetEnumerator ();
		enumerator.MoveNext ();

		Transform contenedorItems = GameObject.Find ("PlayersContainer").transform;

		int pos = 0;

		foreach (SimpleJSON.JSONClass player in ((SimpleJSON.JSONNode)enumerator.Current).AsArray) {

			Player tmp = JsonUtility.FromJson(player.ToString(),typeof(Player)) as Player;

			if(prefabItemRanking!=null){
			GameObject nuevoItem = Instantiate (prefabItemRanking);
			nuevoItem.transform.SetParent (contenedorItems, false);
				nuevoItem.transform.GetChild (0).gameObject.GetComponent<Text> ().text = (pos+1).ToString();
				nuevoItem.transform.GetChild (1).gameObject.GetComponent<Text>().text = tmp.nick.ToUpper();
				nuevoItem.transform.GetChild (2).gameObject.GetComponent<Text> ().text = tmp.score.ToString ();
			}

			pos++;
		}
	}
		

	IEnumerator CheckInRankingReq(int score) {

		WWWForm formulario = new WWWForm ();
		formulario.AddField ("score_player", score);

		UnityWebRequest www = UnityWebRequest.Post("http://51.254.134.174/webservices/gitkraken/ranking/CheckInRanking.php",formulario);

		yield return www.Send();

		if(www.isError) {
			print ("Ojo con la implementación CORS de seguridad de JavaScript");
		}
		else {
			

			DrawDialog (System.Convert.ToInt32(www.downloadHandler.text));
		}
	}


	public void DrawDialog(int posEnRanking){
	
		print ("POSICION con ese escore= "+posEnRanking);

	}


	IEnumerator UpdateRanking(string nick, int score) {

		WWWForm formulario = new WWWForm ();
		formulario.AddField ("nick_player", nick);
		formulario.AddField ("score_player", score);

		UnityWebRequest www = UnityWebRequest.Post("http://51.254.134.174/webservices/gitkraken/ranking/UpdateRanking.php",formulario);

		yield return www.Send();

		if(www.isError) {
			print ("Ojo con la implementación CORS de seguridad de JavaScript");
		}
		else {
			print ("Resultado de la insercion= " + www.downloadHandler.text);
		}
	}

}
