using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseOnclick : MonoBehaviour {
	public Button gameselect,exit,setting;
	static public int selectedButton = -1;
	public void GameSelect()
	{
		
		StartCoroutine(GameSelectBegin()); 
		selectedButton = -1;
	}
		
		void Update () {
			/*foreach (Touch touch in Input.touches) {
			
				if (touch.phase == TouchPhase.Began) {
				if (selectedButton==0) {
			
				StartCoroutine(GameSelectBegin()); 
					selectedButton = -1;

				}
				else if (selectedButton==1) {
					StartCoroutine(SettingBegin()); 
					selectedButton = -1;

				}
				else if (selectedButton==2) {
					StartCoroutine(ExitBegin()); 
					selectedButton = -1;

				}

				}

				if (touch.phase == TouchPhase.Ended) {

				}

			}*/
		}
	public void SelectedWordGroup(int j)		
	{
		selectedButton = j;
	}
		 IEnumerator GameSelectBegin()
		{
		var g = Game.Instance;
		gameselect.GetComponent<Image> ().color = Color.gray;
			yield return WaitForRealSeconds(1);		
		g.ShowCanvasGameSelect ();
		g.HideCanvasMainMenu ();
		g.ShowAd ();
		gameselect.GetComponent<Image> ().color = Color.black;
	
		}

		public static IEnumerator WaitForRealSeconds(float time)
		{
			float start = Time.realtimeSinceStartup;
			while (Time.realtimeSinceStartup < start + time)
			{
				yield return null;
			}
		}
}