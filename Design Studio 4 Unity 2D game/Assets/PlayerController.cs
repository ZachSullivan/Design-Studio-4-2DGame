using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//defines the speed at which the player will move
	public int speed;

	public float floatHeight;
	public float liftForce;
	public float damping;

    public Rigidbody2D rb2D;
    Renderer renderer;

    public GameObject[] enemys;
    Renderer[] enemyRend;

	public GameObject[] scoreSpawns;

	public GameObject Coin;

    public int health = 100;
    public int score = 0;

    void Start() {
        speed = 10;
        rb2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();

		scoreSpawns = GameObject.FindGameObjectsWithTag("ScoreSpawn");
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        enemyRend = new Renderer[enemys.Length];

        for (int i = 0; i < enemys.Length; ++i)
            enemyRend[i] = enemys[i].GetComponent<Renderer>();

		for (int i = 0; i < scoreSpawns.Length; ++i)
			Instantiate(Coin, scoreSpawns[i].transform.position, Quaternion.identity);
        //enemyRend = GameObject.Find("Enemy").GetComponent<Renderer>();
    }

	void Update () {
		Move ();
		
        for (int i = 0; i < enemys.Length; ++i)
        {
            if (this.renderer.bounds.Intersects(enemyRend[i].bounds))
            {
                Destroy(this.gameObject);
            }
        }

        //InvokeRepeating("ReduceHealth",1,1);

	}

    void ReduceHealth() {
        --health;
    }

	void SpawnCoin(Vector3 target){
		
		Instantiate(Coin, target, Quaternion.identity);
		
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
