using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class PlayerMove : MonoBehaviour
{
    // パラメータ
    public float moveSpeed;           // 移動速度
    private float moveSpeeds;
    public float gravity = -9.8f;        // 重力加速度

    //バッテリーのバー
    public Image batteryBar;

    public GameObject powerSupply;

    //メーター
    public float batteryMeter;
    //マックス
    public float maxBatteryMeter;

    public float cameraX;
    public float sensitivity = 2.0f;
    public float maxSpeed;
    public float changeSpeed;
    public CharacterController controller;  // 移動に使うCharacterController

    // 演算用変数
    private Vector3 velocity;       // 加速度を保持する変数
    private bool isGrounded;        // 地面に着地しているかどうかのフラグ変数
    [SerializeField] private Rendaspeed rendaspeed;

    // ゲーム中実行されるUpdate関数
    void Update()
    {
        SpeedCon();
        Move();
    }

    private void SpeedCon()
    {
        if (moveSpeed <= maxSpeed)
        {
            float upSpeed = rendaspeed.pushcount;
            moveSpeeds = moveSpeed + upSpeed / changeSpeed;
        }

    }

    private void Move()
    {
        // 着地状態のチェック
        isGrounded = controller.isGrounded;

        // 着地している場合は落下速度をリセット
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 地面に着いた場合、速度をリセット
        }

        // 入力の取得
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float cameraX = Input.GetAxis("rightHorizontal") * sensitivity;

        // ローカル座標をワールド座標に変換して移動方向を計算
        Vector3 moveDirection = transform.TransformDirection(new Vector3(h, 0, v)) * moveSpeeds;

        // 重力を加算
        velocity.y += gravity * Time.deltaTime;

        // 移動と重力を一度のcontroller.Moveで処理
        controller.Move((moveDirection + velocity) * Time.deltaTime);

        // Player（体）の回転（左右）
        transform.Rotate(0, cameraX, 0);
    }

    private void BatteryBarControl()
    {
        batteryBar.fillAmount = batteryMeter / maxBatteryMeter;

        if (batteryMeter <= 0)
        {
            powerSupply.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        if (batteryMeter == maxBatteryMeter)
        {
            powerSupply.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        }
    }
}
