using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colission : MonoBehaviour
{
    private UImanager instance;
    private bool check;
    private void Start()
    {
        check = false;
        instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<UImanager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "tattoPhase" && check == false)
        {
            check = true;
            Debug.Log("it collides");
           // StartCoroutine(instance.showText());
         //  instance.getRandomText(instance.customerOne);
            // StartCoroutine(instance.customerDelay());
        }
    }
}
