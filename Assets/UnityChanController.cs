using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {

	// アニメーションするためのコンポーネントを入れる
	Animator animator;

	// スプライトレンダラーコンポーネントを入れる
	SpriteRenderer sr;

	// Unityちゃんを移動させるコンポーネントを入れる
	Rigidbody2D rigid2D;

	// ジャンプの速度の減衰
	private float dump = 0.8f;

	// ジャンプの速度
	float jumpVelocity = 20;

	// 地面と接触していればTRUE
	bool isGround;

	// 横移動速度
	float speed = 0.1f;

	// スコアテキスト
	GameObject scoreText;

	// 最高の高さ
	int score = 0;

	// リプレイボタン
	private GameObject replayButton;

	// ゲーム終了時に表示するテキスト
	private GameObject stateText;



	void Start () {

		// アニメーターのコンポーネントを取得する
		this.animator = GetComponent<Animator> ();

		// スプライトレンダラーのコンポーネントを取得する
		this.sr = GetComponent<SpriteRenderer> ();

		// Rigidbody2Dのコンポーネントを取得する
		this.rigid2D = GetComponent<Rigidbody2D> ();

		// 走るアニメーションを再生するために、Animatorのパラメータを調節する
		this.animator.SetFloat("Horizontal", 1);

		this.scoreText = GameObject.Find ("Score");

		this.score = 0;

		this.stateText = GameObject.Find ("GameResultText");

		this.replayButton = GameObject.Find ("Replay");

		replayButton.gameObject.SetActive (false);


	}

	void Update () {

		this.scoreText.GetComponent<Text> ().text = this.score.ToString () + "m"; 

		// 高さの最高記録
		if (score < this.transform.position.y + 3f) {

			score = (int)this.transform.position.y + 3;

		}
			
		// アニメーターのisGroundに地面と接触しているかの情報を与える
		this.animator.SetBool ("isGround", isGround);

		this.gameObject.transform.Translate (speed, 0, 0);

		// 着地状態でクリックされた場合
		if (Input.GetMouseButtonDown (0) && isGround) {

			// 上方向の力をかける
			this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);

		}

		// クリックをやめたら上方向への速度を減速する
		if (Input.GetMouseButton (0) == false) {

			if (this.rigid2D.velocity.y > 0) {

				this.rigid2D.velocity *= this.dump;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.tag == "Ground") {
			
			isGround = true;

		}

		if (other.gameObject.tag == "Wall") {

			speed = -speed;

			if (sr.flipX == true) {
			
				sr.flipX = false;
			
			} else if (sr.flipX == false) {
			
				sr.flipX = true;
			
			}
		}
	}

	void OnCollisionExit2D (Collision2D other) {

		if (other.gameObject.tag == "Ground") {
			isGround = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Bane") {

			isGround = true;

		}

		else if (other.gameObject.tag == "Toge" || other.gameObject.tag == "DeadLine") {

			Destroy (this.gameObject);

			this.stateText.GetComponent<Text>().text = "げぃむ おーばー";

			replayButton.gameObject.SetActive (true);

		}
	}
}
