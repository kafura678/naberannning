using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject goalText;
    [SerializeField] private PlayerMove plyaermove;
    [SerializeField] private GameManager gamemanager;
    [SerializeField] private GameObject potts;
    [SerializeField] private Transform spot;
    // Start is called before the first frame update
    void Start()
    {
        goalText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pot"))
        {
            goalText.SetActive(true);
            plyaermove.enabled = false;
            gamemanager.enabled = false;
            potts.transform.parent = null;
            potts.transform.position = spot.transform.position + new Vector3(0, 0.2f, 0);
        }
    }
}
