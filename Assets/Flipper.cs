using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    // Inspecterで値を変更する
    public float spring = 40000;
    public float openAngle = 80; // 開く角度
    public float closeAngle = 0; // 閉じる角度

    // Hinge Joint
    private HingeJoint hjL; // axisL
    private HingeJoint hjR; // axisR

    // JointSpring
    private JointSpring jL; // axisL
    private JointSpring jR; // axisR

    void Start()
    {
        // AxisLとAxisRを探す
        GameObject flipperL = GameObject.Find("axisL");
        GameObject flipperR = GameObject.Find("axisR");

        // HingeJointを受け取る
        hjL = flipperL.GetComponent<HingeJoint>();
        hjR = flipperR.GetComponent<HingeJoint>();

        // Springを受け取る
        jL = hjL.spring;
        jR = hjR.spring;
    }

    void Update()
    {
        // ←を押す
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            jL.spring = spring;
            jL.targetPosition = openAngle;
            hjL.spring = jL;

        }
        // →を押す
        if (Input.GetKey(KeyCode.RightArrow))
        {
            jR.spring = spring;
            jR.targetPosition = -openAngle;
            hjR.spring = jR;
        }
        //すぐさま戻す
        if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {

            jL.spring = spring;
            jL.targetPosition = closeAngle;
            hjL.spring = jL;

            jR.spring = spring;
            jR.targetPosition = closeAngle;
            hjR.spring = jR;
        }
    }   
}