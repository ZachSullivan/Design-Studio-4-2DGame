using UnityEngine;
using System.Collections;

public class FollowAI : MonoBehaviour {

    public GameObject Player;

    public int minDist = 5;
    public float speed = 1;

	bool flipped = false;

	void Start () {
        Player = GameObject.FindWithTag("Player");
	}

	void Update () {

		if (Player.transform.position.x > transform.position.x && !flipped) {
			transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
			flipped = true;

		}

		if (Player.transform.position.x < transform.position.x && flipped) {
			transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
			flipped = false;

		}
        if (Vector3.Distance(transform.position, Player.transform.position) > 1) {

            Vector3 dir = Player.transform.position - transform.position;
            dir.Normalize();
			

			/*if(rot_z > -90 && !flippedRight){


				flippedRight = true;

			} else if (rot_z < -90 && flippedRight)
				flippedRight = false;

*/

			//transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            transform.position += dir * speed * Time.deltaTime;

        }



    }
}
