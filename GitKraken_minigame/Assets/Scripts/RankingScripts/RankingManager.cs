using UnityEngine;
using System.Collections;
using SimpleJson;
using models;
using UnityEngine.UI;
using UnityEngine.Experimental.Networking;

public class RankingManager : MonoBehaviour {

	public GameObject prefabItemRanking;

	void Start(){

		StartCoroutine (LoadRanking());
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

		foreach (SimpleJSON.JSONClass player in ((SimpleJSON.JSONNode)enumerator.Current).AsArray) {

			Player currentPlayer=JsonUtility.FromJson(player.ToString(),typeof(Player)) as Player;

			GameObject nuevoItem = Instantiate (prefabItemRanking);

			nuevoItem.transform.SetParent (contenedorItems, false);

			nuevoItem.transform.GetChild (0).gameObject.GetComponent<Text> ().text = currentPlayer.id.ToString ().ToUpper();
			nuevoItem.transform.GetChild (1).gameObject.GetComponent<Text>().text = currentPlayer.nick.ToUpper();
			nuevoItem.transform.GetChild (2).gameObject.GetComponent<Text> ().text = currentPlayer.score.ToString ().ToUpper();
		}
	}
}
