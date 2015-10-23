using UnityEngine;
using System.Collections;

public class PatrolAI : MonoBehaviour {

    public int speed;
	float dir = 2.6f;
	void Update () {

        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);

 	}

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Waypoint") {
			
            speed *= -1;

			dir *= -1;

			transform.localScale = new Vector3(dir, 4, 4);

        }

    }

}
