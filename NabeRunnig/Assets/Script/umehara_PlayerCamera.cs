using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umehara_PlayerCamera : MonoBehaviour
{
    public Transform neck;                  // プレイヤーの首のTransformを指定
    public float sensitivity = 2.0f;     // マウス感度（視点の移動の速さを調整）
    public float minVertical = -90.0f;   // 視点の最小角度（縦の回転制限）
    public float maxVertical = 90.0f;    // 視点の最大角度（縦の回転制限）

    // 演算用変数
    private float rotationX = 0f;       // 縦方向の回転角度（首の回転）

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float cameraZ = Input.GetAxis("rightVertical") * sensitivity;

        // Neck（首）の回転（上下）
        rotationX -= cameraZ; // マウスY方向の入力によって縦方向の回転を更新
        rotationX = Mathf.Clamp(rotationX, minVertical, maxVertical);   // 回転角度を指定された範囲に制限
        neck.localRotation = Quaternion.Euler(rotationX, 0, 0);         // 首の回転を設定。縦方向のみ回転させる
    }
}
