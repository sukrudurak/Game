using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Audio : MonoBehaviour {
/*	public AudioSource audioTrue;	
	public AudioSource audioFalse;

	AudioSource audio;
	public bool names;
	public	string key;
	public int GenelToplam;

	public Slider[] volumesliders;

	public void SetMasterVolume(float value)
	{
		//AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.MAster);

	}


	public  void OnTriggerEnter(Collider col) {
		var g = Game.Instance;
		if (col.gameObject.tag == "Barrier") {
			audioFalse.Play ();
		} else if (col.gameObject.tag == "TrueAnswer") {
			audioTrue.Play ();
		} else if (col.gameObject.tag == "FalseAnswer")  {
			audioFalse.Play ();

		}*/
	}
		
	//public Rigidbody rb;
/*	void Awake()
	{
		SoundCheck();
	}
	public void SoundCheck()
	{
		audio = GetComponent<AudioSource>();

		PlayerPrefs.GetInt ("GenelToplam");
		GenelToplam=(PlayerPrefs.GetInt("GenelToplam"));
		Debug.Log (GenelToplam);

	}
	void OnTriggerEnter(Collider col) {
		GetComponent<AudioSource>().PlayOneShot(sound);
	}
	void Start() {
		//rb= GetComponent<Rigidbody>();
	}
	void Update () {
		if (GenelToplam == 1) {
			audio.mute = false;

		} else if (GenelToplam == 0) {
			audio.mute = true;
		}

	}
			void  OnMouseUp(){
		
		if (audio.mute) {
			Debug.Log (audio.mute);

			audio.mute = false;
			GenelToplam = 1;
			}
		else {
			
			GenelToplam = 0;
			audio.mute = true;

			Debug.Log ("else"+audio.mute);
			}
	

		PlayerPrefs.SetInt("GenelToplam", GenelToplam);
		Debug.Log ("as"+GenelToplam);
		//rb.velocity = new Vector3 (0, 115, 0);
	
		}

*/






