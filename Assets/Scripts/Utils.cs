using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {



	public static int Rand(int i) {
		return UnityEngine.Random.Range(1, i);
	}

	public static int RandZ(int i) {
		return UnityEngine.Random.Range(0, i);
	}
}
