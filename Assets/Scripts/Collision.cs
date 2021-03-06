using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Collision : MonoBehaviour {
	
	public TextMesh TextTrueAnswer;
	public AudioSource audioTrue;	
	public AudioSource audioFalse;
	AudioSource audio;
	public Slider[] volumesliders;

	// Çarpışma varsa cevabı kontrol et
	public	void OnTriggerEnter(Collider col) {

		var g = Game.Instance;
		if (col.gameObject.tag == "Barrier") {
			audioFalse.Play ();
			g.AnswerFalse(col);
			col.gameObject.GetComponent<Renderer> ().enabled=false;
			col.gameObject.GetComponent<Collider>().enabled = false;
		} else {
			
		// Tekrardan kaçınalım
		// Eski particle'ları durdur.

		g.DisableParticles();
		// Cevap doğruysa gerekeni yap
			if (col.gameObject.tag == "TrueAnswer") {
			audioTrue.Play ();
				g.AnswerTrue (col);
				// Collider'ları geçici olarak kapat
				g.DisableColliders();
				// Sırayı artır
				g.SetTurn();
				// Sıradaki sözcükler gelsin
				g.SetWords();
				//Debug.Log("Çarpışma oldu: " + col.name); // Debug
			} else if (col.gameObject.tag == "FalseAnswer") {

				audioFalse.Play ();
				g.AnswerFalse (col);
				// Collider'ları geçici olarak kapat
			
				g.GamePause();
				g.DisableColliders();
				// Sırayı artır

				g.SetTurn();
				// Sıradaki sözcükler gelsin
			//	g.SetWords();
				//Debug.Log("Çarpışma oldu: " + col.name); // Debug
			}
		}
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

 