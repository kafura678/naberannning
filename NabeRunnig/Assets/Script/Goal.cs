using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject goalText;
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
        }
    }
}
