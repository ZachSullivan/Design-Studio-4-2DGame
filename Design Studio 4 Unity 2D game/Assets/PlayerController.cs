using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//defines the speed at which the player will move
	public int speed;

	public float floatHeight;
	public float liftForce;
	public float damping;
	
    Renderer renderer;

	//Array list of all enemies in the scene
    public GameObject[] enemys;
    Renderer[] enemyRend;

	//Array list of all coin spawns in the scene
	public GameObject[] scoreSpawns;

	//Array list of all coins in the scene
	public GameObject[] coins;
	Renderer[] coinRend;

	//Reference to the prefab to instanciate
	public GameObject Coin;

	//Array list of all hearts in the scene
	public GameObject[] hearts;
	Renderer[] heartRend;

    public int health = 100;
	public int score;

	public Text ScoreText;

	public Animator animator;
	
	void Awake() {


	}

	void Start() {

        speed = 10;
        renderer = GetComponent<Renderer>();

		//Iterate through all objects with a specific tag and place it into the corresponding array
		scoreSpawns = GameObject.FindGameObjectsWithTag("ScoreSpawn");
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
		coins = GameObject.FindGameObjectsWithTag("Coin");
		hearts = GameObject.FindGameObjectsWithTag ("Heart");

		//Assign Enemy and Coin renderers to new renderer of array size # of enemies & coins 
        enemyRend = new Renderer[enemys.Length];
		coinRend = new Renderer[coins.Length];
		
        for (int i = 0; i < enemys.Length; ++i)
            enemyRend[i] = enemys[i].GetComponent<Renderer>();


		for (int i = 0; i < coins.Length; ++i)
			coinRend[i] = coins[i].GetComponent<Renderer>();

		//Iterate through all spawn locations and place a coin there
		//for (int i = 0; i < scoreSpawns.Length; ++i)
			//Instantiate(Coin, scoreSpawns[i].transform.position, Quaternion.identity);
    }

	void Update () {
		Move ();
		
        for (int i = 0; i < enemys.Length; ++i){

            if (this.renderer.bounds.Intersects(enemyRend[i].bounds)){
                Destroy(this.gameObject);
            }
        }

		for (int i = 0; i < coins.Length; ++i){

			if ((this.renderer.bounds.Intersects(coinRend[i].bounds) && (coinRend[i].enabled != false))) {
				score += 1;
				ScoreText.text = "Score: " + score.ToString();
				coinRend[i].enabled = false;
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
			transform.localScale = new Vector3(1, 1, 1);
			animator.SetInteger("Direction", 1);

		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate ((Time.deltaTime * -speed), 0.0f, 0.0f);
			transform.localScale = new Vector3(-1, 1, 1);

			animator.SetInteger("Direction", 1);
        }

		if(Input.GetKey(KeyCode.Space)){
			transform.Translate (0.0f, (Time.deltaTime * speed), 0.0f);

			animator.SetInteger("Direction", 2);
		}
		if(Input.anyKey == false)
		{
			animator.SetInteger("Direction", 2);
		}


	}

}
