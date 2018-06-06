using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yukaGenerator : MonoBehaviour {

	// UnityChanを入れるゲームオブジェクト
	private GameObject unityChan;

	// MainCamera
	private GameObject mainCamera;
	private float mainCameraY;
	private float mainCameraYmax;

	// 床のPrefab
	public GameObject yukaPrefab;

	// トゲのPrefab
	public GameObject togePrefab;

	// バネのPrefab
	public GameObject banePrefab;

	// 床のスタート位置
	float yukaStart = -4f;

	// 床の縦の間隔
	float yukaKankaku = 3f;

	// 床の縦位置のブレ幅
	float yukaBure = 0.6f;

	void Start () {

		// UnityChan
		unityChan = GameObject.Find ("UnityChan2D");

		// mainCamera
		mainCamera = GameObject.Find ("Main Camera");

		mainCameraY = mainCamera.transform.position.y;

		mainCameraYmax = mainCameraY;

		for (int a = 0; a < 4; a++) {

			// 床が2枚から4枚でランダムに設定
			int yukaMaisu = Random.Range (1, 11);

			// 1-6の場合、3枚床
			if (yukaMaisu <= 4) {

				for (int i = 0; i < 3; i++) {

					Vector2 yukaZahyou = yukaZahyou3 (i, yukaStart + yukaKankaku, yukaBure);

					int yukaShurui = Random.Range (1, 11);

					yukaSeisei (yukaShurui, yukaZahyou.x, yukaZahyou.y);
				}

				yukaStart += yukaKankaku;

				// 5-7の場合、4枚床
			} else if (yukaMaisu >= 5 && yukaMaisu <= 7) {

				for (int i = 0; i < 4; i++) {

					Vector2 yukaZahyou = yukaZahyou4 (i, yukaStart + yukaKankaku, yukaBure);

					int yukaShurui = Random.Range (1, 11);

					yukaSeisei (yukaShurui, yukaZahyou.x, yukaZahyou.y);
				}

				yukaStart += yukaKankaku;

				// 8-10の場合、2枚床
			} else if (yukaMaisu >= 8 && yukaMaisu <= 10) {

				for (int i = 0; i < 2; i++) {

					Vector2 yukaZahyou = yukaZahyou2 (i, yukaStart + yukaKankaku, yukaBure);

					int yukaShurui = Random.Range (1, 11);

					yukaSeisei (yukaShurui, yukaZahyou.x, yukaZahyou.y);
				}

				yukaStart += yukaKankaku;

			}
		}
	}

	void Update () {

		mainCameraY = mainCamera.transform.position.y;

		if (mainCameraY > mainCameraYmax) {

			mainCameraYmax = mainCameraY;

		}

		if (mainCameraYmax + 8 > yukaStart) {

			// 床が2枚から4枚でランダムに設定
			int yukaMaisu = Random.Range (1, 11);

			// 1-5の場合、3枚床
			if (yukaMaisu <= 5) {

				for (int i = 0; i < 3; i++) {

					Vector2 yukaZahyou = yukaZahyou3 (i, yukaStart + yukaKankaku, yukaBure);

					int yukaShurui = Random.Range (1, 11);

					yukaSeisei (yukaShurui, yukaZahyou.x, yukaZahyou.y);
				}

				yukaStart += yukaKankaku;

				// 6-7の場合、4枚床
			} else if (yukaMaisu >= 6 && yukaMaisu <= 7) {

				for (int i = 0; i < 4; i++) {

					Vector2 yukaZahyou = yukaZahyou4 (i, yukaStart + yukaKankaku, yukaBure);

					int yukaShurui = Random.Range (1, 11);

					yukaSeisei (yukaShurui, yukaZahyou.x, yukaZahyou.y);
				}

				yukaStart += yukaKankaku;

				// 8-10の場合、2枚床
			} else if (yukaMaisu >= 8 && yukaMaisu <= 10) {

				for (int i = 0; i < 2; i++) {

					Vector2 yukaZahyou = yukaZahyou2 (i, yukaStart + yukaKankaku, yukaBure);

					int yukaShurui = Random.Range (1, 11);

					yukaSeisei (yukaShurui, yukaZahyou.x, yukaZahyou.y);
				}

				yukaStart += yukaKankaku;

			}
		}

	}

	// 床が2枚の場合の座標を生成する関数
	Vector2 yukaZahyou2 (int yukaLeftRight, float yukaTateIchi, float yukaTateBure) {

		float x = 0;
		float y = 0;

		switch (yukaLeftRight) {

		// 左の床
		case 0:
			x = Random.Range (-4f, -2f);
			y = yukaTateIchi + Random.Range (-yukaTateBure, yukaTateBure);
			break;

		// 右の床
		case 1:
			x = Random.Range (2f, 4f);
			y = yukaTateIchi + Random.Range (-yukaTateBure, yukaTateBure);
			break;

		default:
			break;
		}

		return new Vector2 (x, y);

	}

	// 床が3枚の場合の座標を生成する関数
	Vector2 yukaZahyou3 (int yukaLeftMiddleRight, float yukaTateIchi, float yukaTateBure) {

		float x = 0;
		float y = 0;

		switch (yukaLeftMiddleRight) {

		// 左の床
		case 0:
			x = Random.Range (-5.9f, -3.8f);
			y = yukaTateIchi + Random.Range (-yukaTateBure, yukaTateBure);
			break;

		// 中央の床
		case 1:
			x = Random.Range (-1.7f, 1.7f);
			y = yukaTateIchi + Random.Range (-yukaTateBure, yukaTateBure);
			break;

		// 右の床
		case 2:
			x = Random.Range (3.8f, 5.9f);
			y = yukaTateIchi + Random.Range (-yukaTateBure, yukaTateBure);
			break;

		default:
			break;
		}

		return new Vector2 (x, y);

	}

	// 床が4枚の場合の座標を生成する関数
	Vector2 yukaZahyou4 (int yuka4Mai, float yukaTateIchi, float yukaTateBure) {

		float x = 0;
		float y = 0;

		switch (yuka4Mai) {

		// 一番左の床
		case 0:
			x = Random.Range (-5.9f, -4.5f);
			y = yukaTateIchi + Random.Range (-yukaTateBure, yukaTateBure);
			break;

			// 2枚目の床
		case 1:
			x = Random.Range (-2.4f, -1f);
			y = yukaTateIchi + Random.Range (-yukaTateBure, yukaTateBure);
			break;

			// 3枚目の床
		case 2:
			x = Random.Range (1f, 2.4f);
			y = yukaTateIchi + Random.Range (-yukaTateBure, yukaTateBure);
			break;

			// 4枚目の床
		case 3:
			x = Random.Range (4.5f, 5.9f);
			y = yukaTateIchi + Random.Range (-yukaTateBure, yukaTateBure);
			break;

		default:
			break;
		}

		return new Vector2 (x, y);

	}


	// 床を生成する関数
	void yukaSeisei (int yukaShurui, float yukaZahyouX, float yukaZahyouY) {

		// 1〜5の場合、通常の床を生成
		if (yukaShurui >= 1 && yukaShurui <= 6) {
			
			GameObject yuka = Instantiate (yukaPrefab) as GameObject;

			yuka.transform.position = new Vector2 (yukaZahyouX, yukaZahyouY);

		// 6-8の場合、バネの床を作成
		} else if (yukaShurui >= 7 && yukaShurui <= 9) {

			GameObject yuka = Instantiate (banePrefab) as GameObject;

			yuka.transform.position = new Vector2 (yukaZahyouX, yukaZahyouY);

		// 10の場合、トゲの床を作成
		} else if (yukaShurui == 10) {

			GameObject yuka = Instantiate (togePrefab) as GameObject;

			yuka.transform.position = new Vector2 (yukaZahyouX, yukaZahyouY);
		}
	}
}
