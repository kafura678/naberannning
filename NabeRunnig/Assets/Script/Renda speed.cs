using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rendaspeed : MonoBehaviour
{
    public float moveSpeed = 5f;           // 移動速度
    public float gravity = -9.8f;        // 重力加速度
    public float pushspeed = 1.5f;       //連打時の速度上昇率
    public float pushmax = 10;
    private float currentSpeed;
    public float pushcount = 0;
    private float lastInputTime;
    private float inputInterval = 0.2f;　　//入力間隔(秒)

    // Start is called before the first frame update
    void Start()
    {
        //currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {//入力間隔をチェック
            pushcount++;
        }

        //連打回数のリセット
        /*if (pushcount > 0 && Time.time - lastInputTime >= inputInterval)
        {
            pushcount = 0;
        }*/

    }
}
