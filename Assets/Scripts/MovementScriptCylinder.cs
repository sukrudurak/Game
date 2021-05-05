using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementScriptCylinder : MonoBehaviour {

	private float angle = 11f;
	float timeLeft = 160.0f;



	void Update () {
		timeLeft -= Time.deltaTime;
		if (!Game.Instance.Paused) {
			if (timeLeft < 160 && timeLeft>140) {
				transform.RotateAround (transform.position, -transform.right, Time.deltaTime * angle);

			}
			else if (timeLeft<140 && timeLeft>120) {
				transform.RotateAround (transform.position, -transform.right, Time.deltaTime * (angle+1));
			}

			else if (timeLeft<120 && timeLeft>100) {
				transform.RotateAround (transform.position, -transform.right, Time.deltaTime * (angle+2));
			}
			else if (timeLeft<100 && timeLeft>80) {
				transform.RotateAround (transform.position, -transform.right, Time.deltaTime * (angle+4));

		}
			else if (timeLeft<80 && timeLeft>60) {
				transform.RotateAround (transform.position, -transform.right, Time.deltaTime * (angle+5));

			}
			else if (timeLeft<60 && timeLeft>20) {
				transform.RotateAround (transform.position, -transform.right, Time.deltaTime * (angle+6));

			}
			else if (timeLeft<20 && timeLeft>0) {
				transform.RotateAround (transform.position, -transform.right, Time.deltaTime * (angle+6.5f));

			}
			else if (timeLeft<0 && timeLeft>-60) {
				transform.RotateAround (transform.position, -transform.right, Time.deltaTime * (angle+7));

			} 
			else if (timeLeft<-60) {
				transform.RotateAround (transform.position, -transform.right, Time.deltaTime * (angle+7.5f));
				Debug.Log (timeLeft);
			} 


	}
}
}