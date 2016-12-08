using UnityEngine;
using System.Collections;

public class CrescendoEffects : MonoBehaviour {

	public GameObject playerStartEffects;
	public GameObject CresendoEffects;
	public GameObject playertwo;
	private string player;


	void Start () {
		player = this.gameObject.tag;



	}
	void OnEnable ()
	{
		//if (player== "Player_One")
		//{
			InputManager.P1_RBump += CrescendoAttack;
		//}
		//else if (player == "Player_Two")
		//{
		//	InputManager.P2_RBump += CrescendoAttack;
		//}
	}

	void OnDisable ()
	{
		//if (this.gameObject.tag == "Player_One")
		//{
			InputManager.P1_RBump -= CrescendoAttack;
		//}
		//else if (this.gameObject.tag == "Player_Two")
		//{
		//	InputManager.P2_RBump -= CrescendoAttack;
		//
		//}
	}
	// Use this for initialization


	void CrescendoAttack()
	{
		print("firing Crescendo");
		//start effect
		Vector3 playerPos = new Vector3 (this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		Instantiate (playerStartEffects, playerPos, Quaternion.identity);

		//spawn Crescendo
		Vector3 player2Pos = new Vector3 (playertwo.gameObject.transform.position.x,playertwo.gameObject.transform.position.y+5.4f,playertwo.gameObject.transform.position.z);

		//Instantiate (Crescendo, player2Pos, Quaternion.identity);

	}

	// Update is called once per frame
	void Update () {
	
	}
}
