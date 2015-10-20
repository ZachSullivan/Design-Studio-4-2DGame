using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//defines the speed at which the player will move
	public int speed;

	public float floatHeight;
	public float liftForce;
	public float damping;
	public Rigidbody2D rb2D;

	void Start () {
		speed = 10;
		rb2D = GetComponent<Rigidbody2D>();
	}

	void Update () {
		Move ();

		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.up);
		if (hit.collider != null ) {
			Debug.Log (hit.transform.gameObject.name);
		}
	}

	void Move (){


		//Update main character movement through player key commands
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Translate ((Time.deltaTime * speed), 0.0f, 0.0f);
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate ((Time.deltaTime * -speed), 0.0f, 0.0f);
		}

		if(Input.GetKey(KeyCode.Space)){
			transform.Translate (0.0f, (Time.deltaTime * speed), 0.0f);
		}


	}

}
