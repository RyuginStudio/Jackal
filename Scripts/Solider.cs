using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : Enemy {

	private float currentTime;
	private float attackUpdate;
	private float swapStatusUpdate;
	private Vector3 attackPos;
	public GameObject prefabBulletSolider;
	public AudioSource[] diedEffect; //死亡音效
	public Sprite diePic; //死亡图片

	// Use this for initialization
	void Start () {
		currentTime = Time.time;
		this.target = GameObject.FindGameObjectWithTag ("Player1");
	}

	// Update is called once per frame
	void Update () {
		currentTime = Time.time;

		changeStatus ();
		move ();
		attack ();
	}

	public enum status {
		attack,
		move
	}
	public status SoliderStatus;

	public enum direction {
		up,
		down,
		left,
		right
	}
	public direction SoliderDirec;

	public override void move () {
		if (SoliderStatus == status.move) {
			var step = GameData.soliderSpeed * Time.deltaTime;

			switch (SoliderDirec) {
				case direction.up:
					{
						transform.position = new Vector2 (transform.position.x, transform.position.y + step);
						break;
					}
				case direction.down:
					{
						transform.position = new Vector2 (transform.position.x, transform.position.y - step);
						break;
					}
				case direction.left:
					{
						transform.position = new Vector2 (transform.position.x - step, transform.position.y);
						break;
					}
				case direction.right:
					{
						transform.position = new Vector2 (transform.position.x + step, transform.position.y);
						break;
					}

			}
		}
	}

	void attack () {
		if (SoliderStatus == status.attack && currentTime - attackUpdate >= GameData.soliderAttackRate && GameObject.FindGameObjectWithTag ("Player1") != null) {

			attackUpdate = Time.time;

			target = GameObject.FindGameObjectWithTag ("Player1");
			attackPos = target.transform.position;
			var bulletPrefab = Instantiate (prefabBulletSolider, transform.position, Quaternion.Euler (Vector3.zero));
			bulletPrefab.GetComponent<Bullet> ().Shotter = transform.gameObject; //通过脚本获取物体			
			bulletPrefab.GetComponent<Bullet> ().attackPos = this.attackPos;
		}
	}

	void changeStatus () //每隔两秒切换Solider状态
	{
		if (currentTime - swapStatusUpdate >= 2) {
			swapStatusUpdate = Time.time;

			switch (Random.Range (0, 2)) //随机状态
			{
				case 0:
					{
						SoliderStatus = status.attack;
						break;
					}
				case 1:
					{
						SoliderStatus = status.move;
						break;
					}

			}

			if (SoliderStatus == status.move) {
				switch (Random.Range (0, 4)) //随机方向
				{
					case 0:
						{
							SoliderDirec = direction.up;
							break;
						}
					case 1:
						{
							SoliderDirec = direction.down;
							break;
						}
					case 2:
						{
							SoliderDirec = direction.left;
							break;
						}
					case 3:
						{
							SoliderDirec = direction.right;
							break;
						}
				}

			}
			animationPlay ();
		}
	}

	void animationPlay () {
		if (SoliderStatus == status.attack) {
			foreach (var item in GetComponents<AnimationPlayer> ()) {
				item.autoPlay = false;

				if (item.Tag == "WaveHand") {
					item.autoPlay = true;
				}
			}

		} else {
			string tag = SoliderDirec.ToString ();

			foreach (var item in GetComponents<AnimationPlayer> ()) {
				item.autoPlay = false;

				if (item.Tag == tag) {
					item.autoPlay = true;
				}
			}

		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		switch (other.tag) {
			case "Player1":
				{
					die ();
					break;
				}
			case "Explode":
				{
					die ();
					break;
				}
			case "BulletMachinGun":
				{
					die ();
					break;
				}
			case "bulletCharacMissile":
				{
					die ();
					break;
				}
			case "Grenade":
				{
					die ();
					break;
				}
		}
	}

	void OnCollisionEnter2D (Collision2D collisionInfo) {
		switch (collisionInfo.gameObject.tag) {
			case "Player1":
				{
					die ();
					break;
				}
		}
	}

	public void die () {
		GetComponent<SpriteRenderer> ().sprite = diePic;
		Destroy (GetComponent<Rigidbody2D> ());
		Destroy (GetComponent<Collider2D> ());
		Destroy (this);

		foreach (var item in GetComponents<AnimationPlayer> ())
			Destroy (item);

		diedEffect[Random.Range (0, 5)].Play ();
		Destroy (gameObject, 1.5f);
	}

}