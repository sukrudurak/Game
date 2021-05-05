using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	public string[] allWordss =  { "RENKLERimiz", "KARiŞiK", "SAYiLAR", "FiiLLER ", "ZAMiRLER ", "iSiMLER ", "ZARFLAR ", "SıFATLAR", "KALıPLAR", "PRESENT", "KARiŞiK", "KARiŞiK", "KARiŞiK", "KARiŞiK", "KARiŞiK"};
	public GameObject buttons;
	public GameObject Menu;


	void Start() {

		for (int i = 0; i < allWordss.Length; i++) {
			

			GameObject newButton = Instantiate(buttons, new Vector3(100, 55 * i , 100), Quaternion.identity) as GameObject;
			newButton.transform.SetParent(Menu.transform, true);
			newButton.GetComponentInChildren<Text> ().text = allWordss [i];
			newButton.name=allWordss[i];
		
	
		



		}
	


	}


}