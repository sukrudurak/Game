using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
public class FontVisuality : MonoBehaviour {
	public TextMesh textWord,textScore,Text1, Text2, Text3, Text4, Text5, Text6, Text7, Text8, Text9, Text10, Text11, Text12,textTrueAnswer;
	public List<TextMesh> Texts = new List<TextMesh>();
	void AddTexts() {
		Texts.Add(Text1); Texts.Add(Text2); Texts.Add(Text3);
		Texts.Add(Text4); Texts.Add(Text5); Texts.Add(Text6);
		Texts.Add(Text7); Texts.Add(Text8); Texts.Add(Text9);
		Texts.Add(Text10); Texts.Add(Text11); Texts.Add(Text12);   Texts.Add(textScore); Texts.Add(textWord); Texts.Add(textTrueAnswer);
		/*	if (DebugMode)
			Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name + " OK");*/
	}

	public  IEnumerator TextsColor(byte X, byte Y, byte Z, byte T) {
		foreach (TextMesh text in Texts)
			text.color = new Color32 (X, Y, Z, T); 
		
		yield return null;
	}
	// Use this for initialization
	void Start () {
		AddTexts ();
		StartCoroutine (Begin());
	}
	


	IEnumerator Begin()
	{
		
			
		
		yield return WaitForRealSeconds (5);
	
		StartCoroutine (TextsColor  (255, 205, 210, 255)); 


		yield return WaitForRealSeconds (5);

		StartCoroutine (TextsColor (255, 205, 210, 255)); 

		yield return WaitForRealSeconds (5);

		StartCoroutine (TextsColor (239, 154, 154, 255)); 

		yield return WaitForRealSeconds (5);

		StartCoroutine (TextsColor (229, 115, 115, 255)); 
	
		yield return WaitForRealSeconds (5);

		StartCoroutine (TextsColor (239, 83, 80, 255)); 

	
	

		yield return WaitForRealSeconds (5);

		StartCoroutine (TextsColor (244, 67, 54, 255)); 

		yield return WaitForRealSeconds (5);

		StartCoroutine (TextsColor (229, 57, 53, 255)); 
	
		yield return WaitForRealSeconds (5);

		StartCoroutine (TextsColor (211, 47, 47, 255)); 
	
		yield return WaitForRealSeconds (5);

		StartCoroutine (TextsColor (136, 14, 79, 255)); 
	
		yield return WaitForRealSeconds (5);

		StartCoroutine (TextsColor (173, 20, 87, 255)); 

	
		yield return WaitForRealSeconds (5);

		StartCoroutine (TextsColor (194, 24, 91, 255)); 

	
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (216, 27, 96, 255)); 

	
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (233, 30, 99, 255)); 

	
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (236, 64, 122, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (240, 98, 146, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (244, 143, 177, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (248, 187, 208, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (252, 228, 236, 255));
	
		//Sarı tonları

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (255, 253, 231, 255)); 


		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (255, 249, 196, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (255, 245, 157, 255));
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (255, 241, 118, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (255, 235, 59, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (253, 216, 53, 255));

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (251, 192, 45, 255)); 


		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (249, 168, 37, 255)); 


		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (245, 127, 23, 255));


		//Turuncu tonları
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (191, 54, 12, 255)); 


		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (216, 67, 21, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (230, 74, 25, 255));
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (244, 81, 30, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (255, 87, 34, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (255, 112, 67, 255));

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (255, 138, 101, 255)); 


		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (255, 171, 145, 255)); 


		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (255, 204, 188, 255));

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (251, 233, 231, 255));


		//MAVİ tonları
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (227, 242, 253, 255)); 

	
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (187, 222, 251, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (144, 202, 249, 255));
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (100, 181, 246, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (66, 165, 245, 255)); 

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (33, 150, 243, 255));

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (30, 136, 229, 255)); 

	
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (25, 118, 210, 255)); 


		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (21, 101, 192, 255));

		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (13, 71, 161, 255)); 

		Debug.Log ("BİTTİİİİİİİİİİİİ");
		

		/*yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (248, 187, 208, 255)); 

		Debug.Log ("asdxxxx");
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (252, 228, 236, 255));
		Debug.Log ("asdxxxx");
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (244, 143, 177, 255)); 

		Debug.Log ("asdxxxx");
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (248, 187, 208, 255)); 

		Debug.Log ("asdxxxx");
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (252, 228, 236, 255));
		Debug.Log ("asdxxxx");
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (244, 143, 177, 255)); 

		Debug.Log ("asdxxxx");
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (248, 187, 208, 255)); 

		Debug.Log ("asdxxxx");
		yield return WaitForRealSeconds (5);
		StartCoroutine (TextsColor (252, 228, 236, 255));
*/





	

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
