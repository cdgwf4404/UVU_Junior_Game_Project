using UnityEngine;
using System.Collections;

public class StandardAttacks : MonoBehaviour {
	
	public GameObject projectileH;
	public GameObject projectileM;
	public GameObject projectileL;
	public GameObject p1SpawnPointH;
	public GameObject p1SpawnPointM;
	public GameObject p1SpawnPointL;
	public GameObject p2SpawnPointH;
	public GameObject p2SpawnPointM;
	public GameObject p2SpawnPointL;

	public float projectileHighUp = 15f;
	public float projectileMedUp = 6f;
	public float projectileLowUp = 3f;

	public float projectileSpeedHigh = 7f;
	public float projectileSpeedMed = 16f;
	public float projectileSpeedLow = 20f;


	private bool canFire = true;
	private int projectileCounter = 0;

	void OnEnable()
	{
		if (this.gameObject.tag == "Player_One") 
		{
			InputManager.P1_A += LowAttack;
			InputManager.P1_X += MedAttack;
			InputManager.P1_Y += HighAttack;
			InputManager.P1_B += Dodge;
			InputManager.P1_RangedA += RangedLowAttack;
			InputManager.P1_RangedX += RangedMedAttack;
			InputManager.P1_RangedY += RangedHighAttack;
		} 

		else if (this.gameObject.tag == "Player_Two") 
		{
			InputManager.P2_A += LowAttack;
			InputManager.P2_X += MedAttack;
			InputManager.P2_Y += HighAttack;
			InputManager.P2_B += Dodge;
			InputManager.P2_RangedA += RangedLowAttack;
			InputManager.P2_RangedX += RangedMedAttack;
			InputManager.P2_RangedY += RangedHighAttack;
		}
	}

	void OnDisable()
	{
		if (this.gameObject.tag == "Player_One") 
		{
			InputManager.P1_A -= LowAttack;
			InputManager.P1_X -= MedAttack;
			InputManager.P1_Y -= HighAttack;
			InputManager.P1_B -= Dodge;
			InputManager.P1_RangedA -= RangedLowAttack;
			InputManager.P1_RangedX -= RangedMedAttack;
			InputManager.P1_RangedY -= RangedHighAttack;
		} 

		else if (this.gameObject.tag == "Player_Two") 
		{
			InputManager.P2_A -= LowAttack;
			InputManager.P2_X -= MedAttack;
			InputManager.P2_Y -= HighAttack;
			InputManager.P2_B -= Dodge;
			InputManager.P2_RangedA -= RangedLowAttack;
			InputManager.P2_RangedX -= RangedMedAttack;
			InputManager.P2_RangedY -= RangedHighAttack;
		}
	}

	void LowAttack()
	{
		if (BoteManager.onBote == true) 
		{
			//this.gameObject
			print ("Low Attack");
		}

	}

	void MedAttack()
	{
		if (BoteManager.onBote == true) 
		{
			//this.gameObject
			print ("Medium Attack");
		}
	}

	void HighAttack()
	{
		if (BoteManager.onBote == true) 
		{
			//this.gameObject
			print ("High Attack");
		}
	}

	void Dodge()
	{
		print ("Dodge");
	}

	//Ranged Attacks
	void RangedLowAttack()
	{
		if (BoteManager.onBote == true)
		{
			if (projectileCounter < 1)
			{
				projectileCounter = 1;
				if (this.gameObject.tag == "Player_One")
				{
					FireProjectile (1, 1);
				}
				else if (this.gameObject.tag == "Player_Two")
				{
					FireProjectile (2, 1);
				}


			}

		}
		else
		{
			projectileCounter = 0;
		}
	}

	void RangedMedAttack()
	{
		if (BoteManager.onBote == true)
		{
			//this.gameObject
			if (projectileCounter < 1)
			{
				projectileCounter = 1;

				if (this.gameObject.tag == "Player_One")
				{
					FireProjectile (1, 2);
				}
				else if (this.gameObject.tag == "Player_Two")
				{
					FireProjectile (2, 2);
				}

			}
		}
		else
		{
			projectileCounter = 0;
		}
	}

	void RangedHighAttack()
	{
		if (BoteManager.onBote == true) 
		{
			if (projectileCounter < 1 ) 
			{
				projectileCounter = 1;
				//FireProjectile


				if (this.gameObject.tag == "Player_One") 
				{
					FireProjectile (1, 3);
					print ("fireProjectile");
				} 

				else if (this.gameObject.tag == "Player_Two") 
				{
					FireProjectile (2, 3);
				}

			}
		}
		else
		{
			projectileCounter = 0;
		}
	}

	void FireProjectile(int playerNum,int projectileType)
	{
		
		GameObject projectileHandler;
		Rigidbody tempRigidBody;

		if (playerNum == 1)
		{
			

			switch (projectileType)
			{
			case 1:
				projectileHandler = Instantiate (projectileL, p1SpawnPointL.transform.position, p1SpawnPointL.transform.rotation) as GameObject;
				projectileHandler.name = "Low";
				Lists.p1aprojectilelist.Add (projectileHandler);


				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedLow, projectileLowUp);

				break;
			case 2:
				projectileHandler = Instantiate (projectileM, p1SpawnPointM.transform.position, p1SpawnPointM.transform.rotation) as GameObject;
				projectileHandler.name = "Mid";
				Lists.p1bprojectilelist.Add (projectileHandler);

				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedMed, projectileMedUp);
				break;
			case 3:
				projectileHandler = Instantiate (projectileH, p1SpawnPointH.transform.position, p1SpawnPointH.transform.rotation) as GameObject;
				projectileHandler.name = "High";
				Lists.p1cprojectilelist.Add (projectileHandler);

				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedHigh, projectileHighUp);
				break;
			default :

				projectileHandler = null;
				break;
			}




			//projectileHandler.name = "High";
		}
		else if (playerNum == 2)
		{
			


			switch (projectileType)
			{
			case 1:
				projectileHandler = Instantiate (projectileL, p2SpawnPointL.transform.position, p2SpawnPointL.transform.rotation) as GameObject;
				projectileHandler.name = "Low";
				Lists.p2aprojectilelist.Add (projectileHandler);


				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (-projectileSpeedLow, projectileLowUp);
				break;
			case 2:
				projectileHandler = Instantiate (projectileM, p2SpawnPointM.transform.position, p2SpawnPointM.transform.rotation) as GameObject;
				projectileHandler.name = "Mid";
				Lists.p2bprojectilelist.Add (projectileHandler);


				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (-projectileSpeedMed, projectileMedUp);
				break;
			case 3:
				projectileHandler = Instantiate (projectileH, p2SpawnPointH.transform.position, p2SpawnPointH.transform.rotation) as GameObject;
				projectileHandler.name = "High";
				Lists.p2cprojectilelist.Add (projectileHandler);


				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (-projectileSpeedHigh, projectileHighUp);
				break;
			default :

				projectileHandler = null;
				break;
			}


			
		}


		
	}


}
