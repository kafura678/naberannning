using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Threading;
using Unity.VisualScripting.Dependencies.Sqlite;

public class GameManager : MonoBehaviour
{
    private float countDown = 3;
    [SerializeField] private TextMeshProUGUI CountDownText;
    [SerializeField] private PlayerMove player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCountDown();
    }

    void StartCountDown()
    {
        countDown -= 0.005f;
        CountDownText.text = countDown.ToString("F0");
        if (countDown <= 0)
        {
            CountDownText.enabled = false;
            player.enabled = true;
        }
        else if (countDown > 0)
        {
            player.enabled = false;
        }
    }
}