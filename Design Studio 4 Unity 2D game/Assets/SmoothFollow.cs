using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	GameObject Player;
	Vector3 newCamPos;

	public float normalize;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		newCamPos = transform.position;
	}

	void Update () {

		Vector3 zPos = transform.position;
		zPos.z = Player.transform.position.z;
		
		Vector3 playerDir = (Player.transform.position - zPos);
		
		float camVel = playerDir.magnitude * normalize;

		//Determine new cam pos. based on player's position
		newCamPos = transform.position + (playerDir.normalized * camVel * Time.deltaTime); 

		//Update the current cam pos. by lerping between current cam pos and new cam pos.
		transform.position = Vector3.Lerp( transform.position, newCamPos, 0.25f);

	}
}
