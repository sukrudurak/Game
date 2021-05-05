using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public enum Swipe { None, Up, Down, Left, Right };
public class MovementScript : MonoBehaviour 
{
	public Transform player; // Drag your player here
	private Vector2 fp; // first finger position
	private Vector2 lp; // last finger position
	public int i = 0;
	private float moveSpeed = 10f;
	private float gridSize = 5.5f;
	private float gridLimit = 4;
	int JumpAmount = 1;
	private enum Orientation {
		Horizontal,
		Vertical
	};
	private Orientation gridOrientation = Orientation.Horizontal;
	private bool allowDiagonals = false;
	private bool correctDiagonalSpeed = true;
	private Vector2 input;
	private bool isMoving = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float t;
	private float factor;
	public Rigidbody jumping;
	// Only for debug purpose
	public Text TextDebug;
	public int count=0;
	public TextMesh Score;
	int y = 0, z = 0, n = 0;
	void Start () {
		Input.multiTouchEnabled = true; //enabled Multitouch
		jumping= GetComponent<Rigidbody>();
	}
	void Update () {
		if (Game.buttonEnable) {
			// Dokunmatik ekran için
			CheckInputTouch();
			// Klavye için
			CheckInputKeyboard();
		

		foreach(Touch touch in Input.touches)
		{
				//Score.text = "X degeri:"+GameObject.Find("Cat").transform.position.x +  Game.buttonEnable;
			if (touch.phase == TouchPhase.Began)
			{
				fp = touch.position;
				lp = touch.position;
			}
			if (touch.phase == TouchPhase.Moved )
			{
				lp = touch.position;
			}
			if(touch.phase == TouchPhase.Ended)
			{
				input = Vector2.zero;
				if (!Game.Instance.Paused) {
						

						if (((fp.x - lp.x) > 80 &&   ( GameObject.Find("Cat").transform.position.x==5.5f ||  GameObject.Find("Cat").transform.position.x==0)) && ((fp.y - lp.y) < -80 &&  Game.buttonEnable==true ))  { // left swipe and up
						
							Game.buttonEnable = false;
						
							Vector3 catposition = GameObject.Find ("Cat").transform.position;
							if (catposition.x==gridSize) {
								y = 1;
								z = 0;
							} else if (catposition.x==0) {
								z = 1;
								y=0;
							
							}

							jumping.isKinematic=false;
							jumping.velocity = new Vector3 (-5.5f, 23, 0);

							//	StartCoroutine (Move (transform));

							StartCoroutine(Begin());


						} 


						else 	if ((fp.x - lp.x) < -80 && ( GameObject.Find("Cat").transform.position.x==-5.5f ||  GameObject.Find("Cat").transform.position.x==0) && ((fp.y - lp.y) < -80 &&  Game.buttonEnable==true ))  { // right swipe and up
							Game.buttonEnable = false;

							Vector3 catposition = GameObject.Find ("Cat").transform.position;
							if (catposition.x==-gridSize) {
								y = 1;
								n = 0;

							} else if (catposition.x==0) {
								n = 1;
								y=0;

							}
							jumping.isKinematic=false;
							jumping.velocity = new Vector3 (5.5f, 23, 0);

							//	StartCoroutine (Move (transform));

							StartCoroutine(Begin());


						} 

						else	if ((fp.x - lp.x) > 80  &&   ( GameObject.Find("Cat").transform.position.x==5.5f ||  GameObject.Find("Cat").transform.position.x==0) &&  Game.buttonEnable==true  ) { // left swipe
						input.x = -1;
						StartCoroutine (Move (transform));
						} else if ((fp.x - lp.x) < -80 && ( GameObject.Find("Cat").transform.position.x==-5.5f ||  GameObject.Find("Cat").transform.position.x==0) &&  Game.buttonEnable==true ) { // right swipe
						input.x = 1;
						StartCoroutine (Move (transform));
					} 
					else if ((fp.y - lp.y) < -80 &&  Game.buttonEnable==true ) { // up swipe

						Game.buttonEnable = false;

						jumping.isKinematic=false;
						jumping.velocity = new Vector3 (0, 23, 0);
						
						StartCoroutine(Begin());

					}
					if (jumping.velocity.y<=0) {
						jumping.velocity = new Vector3 (0, 43, -13.5f);
					}
				
				}
			}
		}
		}
	}

	// Dokunmatik ekran için
	void CheckInputTouch() {
		if (Input.touchCount > 0 && !isMoving) {

			var touch = Input.GetTouch(0);
			input = Vector2.zero;		

			// Grid sınırlarını aşmamalı
		/*	if (touch.position.x <= Screen.width / 2 && touch.position.y < Screen.height / 2  && endPosition.x >= -gridLimit + 0.1) {
				input.x = -1;
				StartCoroutine (Move(transform));
			}
			else if (touch.position.x > Screen.width / 2 && touch.position.y < Screen.height / 2  && endPosition.x <= gridLimit - 0.1) {
				input.x = 1;
				StartCoroutine (Move(transform));
			}
			else if (touch.position.y > Screen.height / 2 && jumping.velocity.y==0) {
				jumping.isKinematic=false;
				jumping.velocity = new Vector3 (0, 11, 0);
				StartCoroutine(Begin());
			}
*/
		}
	}

	// Klavye için
	void CheckInputKeyboard() {
		if (!isMoving) {
			input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			// Grid sınırlarını aşmamalı
			if ((input.x < 0 && endPosition.x >= -gridLimit + 0.1) || (input.x > 0 && endPosition.x <= gridLimit - 0.1)) {
				if (!allowDiagonals) {
					if (Mathf.Abs (input.x) > Mathf.Abs (input.y)) {
						input.y = 0;
					} else {
						input.x = 0;
					}
				}

				if (input != Vector2.zero) {
					StartCoroutine(Move(transform));
				}

			}
		}
	}

	public IEnumerator Move(Transform transform) {
		isMoving = true;
		startPosition = transform.position;
		t = 0;

		if (gridOrientation == Orientation.Horizontal) {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
				startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
		} else {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
				startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
		}

		if (allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
			factor = 0.7071f;
		} else {
			factor = 1f;
		}

		while (t < 1f) {
			t += Time.deltaTime * (moveSpeed/gridSize) * factor*1.4f;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return null;
		}
		 
		isMoving = false;
		yield return 0;
	}
/*	public IEnumerator MoveJump(Transform transform) {
		isMoving = true;
		startPosition = transform.position;
		t = 0;

		if (gridOrientation == Orientation.Horizontal) {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
				startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
		} else {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
				startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
		}

		if (allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
			factor = 0.7071f;
		} else {
			factor = 1f;
		}

		while (t < 1f) {
			t += Time.deltaTime * (moveSpeed/gridSize) * factor;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return null;
		}

		isMoving = false;
		yield return 0;
	}*/
	IEnumerator Begin()
	{
		yield return WaitForRealSeconds (0.9f);
		jumping.isKinematic=true;
	
		if (GameObject.Find("Cat").transform.position.y>=43f ||GameObject.Find("Cat").transform.position.y<=43f ) {
			Vector3 newpos = GameObject.Find ("Cat").transform.position;
			newpos.y = 43f;
			 // why does this work while 'transform.position.x += 5.0f;' doesn't?
			if (y==1) {
				newpos.x = 0;
			}
			else if (z==1) {
				newpos.x = -5.5f;
			}
			else if (n==1) {
				newpos.x = 5.5f;
			}
			y = 0;
			z = 0;
			t = 0;
			n = 0;

			GameObject.Find ("Cat").transform.position = newpos;
			Game.buttonEnable = true;

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