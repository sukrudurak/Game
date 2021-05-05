using UnityEngine;
using System.Collections;
using System.Collections;

public class DataSaving : MonoBehaviour {
	public int SonPuan;
	public int GenelToplam;
	// Use this for initialization
	void Start () {
		PlayerPrefs.GetInt ("GenelToplam");
		GenelToplam=(PlayerPrefs.GetInt("GenelToplam"));
	}

	// Update is called once per frame
	void Update () {
		
	}
	void  OnMouseUp(){
		SonPuan=10;

		GenelToplam = GenelToplam + SonPuan;
		PlayerPrefs.SetInt("GenelToplam", GenelToplam);
		Debug.Log("Toplam:"+GenelToplam);
	}

	/*	public int Score;
	void Start () {
		PlayerPrefs.GetInt("scorePref");
		Score=PlayerPrefs.GetInt("scorePref");
	}
	void Update () {
		
		PlayerPrefs.SetInt("scorePref", Score);

		Debug.Log(GenelToplam);
	}*/
}
