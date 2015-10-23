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

    public int lifeCounter;
	public int score;

	public Text ScoreText;

	public Text EndText;

	public Animator animator;

	public GameObject GameOver;
	
	void Start() {

        speed = 10;
        renderer = GetComponent<Renderer>();

		GameOver = GameObject.FindGameObjectWithTag("GameOver");

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

    }

	void Update () {

		Move ();
		
        for (int i = 0; i < enemys.Length; ++i){

            if (this.renderer.bounds.Intersects(enemyRend[i].bounds)){

				lifeCounter -= 1;

				this.transform.position = new Vector3 (-1,-14,0);

				if (lifeCounter > 0) {
					hearts[lifeCounter].SetActive(false);
				} 
            }
        }

		if(lifeCounter == 0) {
			
			//Application.LoadLevel(Application.loadedLevel);
			GameOver.GetComponent<SpriteRenderer>().enabled = true;
			ScoreText.enabled = false;
			StartCoroutine("StartNewGame");
		}

		for (int i = 0; i < coins.Length; ++i){

			if ((this.renderer.bounds.Intersects(coinRend[i].bounds) && (coinRend[i].enabled != false))) {
				score += 1;
				ScoreText.text = "COINS: " + score.ToString() + " / 6";
				coinRend[i].enabled = false;
					
				if(score == 6){
					ScoreText.text = "DONE!";
					StartCoroutine("StartNewGame");
				}

			}
		}
	}

	IEnumerator StartNewGame(){
	
		yield return new WaitForSeconds(1);
		EndText.text = "New Game 3";
		yield return new WaitForSeconds(1);
		EndText.text = "New Game 2";
		yield return new WaitForSeconds(1);
		EndText.text = "New Game 1";
		yield return new WaitForSeconds(1);
		Application.LoadLevel(Application.loadedLevel);
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

			animator.SetInteger("Direction", 3);
		}
		if(Input.anyKey == false)
		{
			animator.SetInteger("Direction", 2);
		}

	}

	//NOTE This is only for checking if the player has fallen out of the map NOT for enemy or coin collision
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Killbox") 
			Application.LoadLevel(Application.loadedLevel);
	}
}
