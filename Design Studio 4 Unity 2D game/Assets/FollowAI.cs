using UnityEngine;
using System.Collections;

public class FollowAI : MonoBehaviour {

    public GameObject Player;

    public int minDist = 5;
    public int speed = 1;

	void Start () {
        Player = GameObject.FindWithTag("Player");
	}

	void Update () {

        if (Vector3.Distance(transform.position, Player.transform.position) > 1) {

            Vector3 dir = Player.transform.position - transform.position;
            dir.Normalize();

            transform.position += dir * speed * Time.deltaTime;

        }

    }
}
