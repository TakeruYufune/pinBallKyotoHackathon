using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    
    //ボールオブジェクト
    public GameObject ball;
    private Rigidbody ballRigidBody;
    float pinPower;

    //ピンボール盤傾き 20°
    float angle = 20f;

    void Start()
    {
        //ball.transform.position = new Vector3(0.268f, 0.025f, -0.87f);	// ピンOBJの初期化
		ballRigidBody = ball.GetComponent<Rigidbody> ();	// ボールのリジッドボディーを格納
		pinPower = 5f;	// 弾きの強さを初期化

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp (KeyCode.Space)) {
			// デバックログの表示
			Debug.Log ("x,y=" + xVector(angle) + "," + yVector(angle));
			// ピンボール台の傾き（20度）に合わせたベクトルを計算
			Vector3 Pos1 = new Vector3 (xVector(angle), yVector(angle) ,0f);
			// ボールに力を加える
			ballRigidBody.AddForce (Pos1*pinPower*105f);
		}

        //reset
        if (Input.GetKeyUp (KeyCode.R)) {
            ball.transform.position = new Vector3(5,10,0);
        }
        
    }

    private float yVector (float angle) {
		// 角度(angle)に対する、y軸のベクトルを計算します。
		float y = (float)Math.Sin(angle * (Math.PI / 180));
		return y;
	}

	private float xVector (float angle) {
		// 角度(angle)に対する、x軸のベクトルを計算します。
		float x = (float)Math.Cos(angle * (Math.PI / 180));
		return x;
	}
}
