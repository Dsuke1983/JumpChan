using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class spiringBlockController : MonoBehaviour {

	// バネを縮めるアニメーションを行う時間
	[SerializeField] float m_actionTime = 0.1f;

	// どのくらいバネを縮めるか
	[SerializeField] float m_compressedScale = 0.5f;

	// 
	[SerializeField] float m_powerChargedScale = 0.6f;

	// 
	[SerializeField] float m_springPower = 5f;

	// バネの初期サイズのY軸の値
	float m_originalScale;

	// バネのY軸の初期位置
	float m_originalPosition;

	// バネと接触しているかどうか
	bool m_isCompressed = false;


	void Start () {

		m_originalScale = transform.localScale.y;
		m_originalPosition = transform.position.y;

	}
	
	void Update () {

		// バネの上部分に触れていて、かつ、、なんだ？
		if (m_isCompressed && transform.localScale.y > m_compressedScale) {

			Compress ();

		// バネの上部分に触れていなくて、かつ、、なんだ？
		} else if (!m_isCompressed && transform.localScale.y < m_originalScale) {

			Release ();
		}
	}

	// バネがUnityChanと接触した際にm_isCompressedをtrueにする。
	private void OnTriggerEnter2D (Collider2D collision) {

		if (collision.gameObject.tag == "UnityChan") {

			m_isCompressed = true;
		
		}
	}


	// バネがUnityChanと接触している間、m_isCompressedをtrueにする。
	private void OnTriggerStay2D (Collider2D collision) {

		if (collision.gameObject.tag == "UnityChan") {

			m_isCompressed = true;

		}
	}

	// バネがUnityChanと離れた際、m_isCompressedをfalseにする。
	private void OnTriggerExit2D (Collider2D collision) {

		if (collision.gameObject.tag == "UnityChan") {

			m_isCompressed = false;

			if (transform.localScale.y < m_powerChargedScale) {

				collision.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * m_springPower, ForceMode2D.Impulse);

			}
		}
	}

	// 縮む処理
	void Compress() {

		// iTween.ScaleToは、大きさをアニメーションさせる
		// iTween.Hashは、どのようなアニメーションをさせるか設定する
		// gameObjectに対して、yの値を、m_compressedScaleまで、m_actionTimeの時間をかけてアニメーションさせる。
		iTween.ScaleTo (gameObject, iTween.Hash ("y", m_compressedScale, "time", m_actionTime));

		// iTween.MoveToは、座標の移動をさせる
		// iTween.Hashは、どのようなアニメーションをさせるか設定する
		// gameObjectに対して、y座標を、縮小に合わせて下げている
		// (中心を起点として縮むため)
		iTween.MoveTo (gameObject, iTween.Hash ("y", m_originalPosition - 0.1f, "time", m_actionTime));

	}

	void Release() {

		iTween.MoveTo (gameObject, iTween.Hash ("y", m_originalPosition, "time", m_actionTime));
		iTween.ScaleTo (gameObject, iTween.Hash ("y", m_originalScale, "time", m_actionTime));

	}

}
