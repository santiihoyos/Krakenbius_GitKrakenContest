using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//clase intermediaria
public class DialogRankingController : MonoBehaviour {

	public Text dialogText;
	public Text newNick;
	public GameObject contenedor;
	public RankingManager manager;
	int score;

	void Start(){
		RankingManager manager = new RankingManager ();
		score= 
	}

	public void FinalOfMatch(int score, Text testPos){

		StartCoroutine (manager.CheckInRankingReq(score));
	}

	public void OkButtonClick(Text nick){
		StartCoroutine (manager.UpdateRanking());
	}

	public void CancelButtonClick(){
		contenedor.SetActive (false);
	}
}
