using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {

	public AudioSource machinGunEffect;
	public AudioSource fireInTheHole;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		attack();

	}

	public void attack()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			Debug.Log("machineGun");
			machinGunEffect.Play();
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			Debug.Log("FireInTheHole");
			fireInTheHole.Play();
		}
	}
}
