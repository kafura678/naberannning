using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Threading;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float countDown = 3;
    [SerializeField] private TextMeshProUGUI CountDownText;
    [SerializeField] private PlayerMove player;
    [SerializeField] private GameObject thermometer;
    [SerializeField] private float thermonumber;

    [SerializeField] private GameObject gameover;
    [SerializeField] private Material lefthand;
    private float maxvalue = 0.8f;

    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCountDown();

        if (active == true)
        {
            GameTime();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("hasei_Scene");
        }
    }

    void GameTime()
    {
        thermonumber -= Time.deltaTime;
        thermometer.GetComponent<Image>().fillAmount = thermonumber / 10;
        float handthermo = 1 - thermonumber / 10;
        float leftvalue = 0 + handthermo;
        if (leftvalue >= 0.8)
        {
            leftvalue = 0.8f;
        }

        lefthand.color = new Color(lefthand.color.r, lefthand.color.g, lefthand.color.b, leftvalue);


        if (thermonumber <= 0)
        {
            gameover.SetActive(true);
            player.enabled = false;
        }
    }
    void StartCountDown()
    {
        countDown -= 0.005f;
        CountDownText.text = countDown.ToString("F0");
        if (-1 < countDown && countDown <= 0)
        {
            CountDownText.enabled = false;
            player.enabled = true;
            countDown = -999;
            active = true;
        }
        else if (countDown > 0)
        {
            player.enabled = false;
        }
    }
}