using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public Text customerOpinion;
    public Text moneyHolder;
    public Text timerHolder;
    public GameObject panel;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    // a function with a string[] parameter which returns a random string
    public void getText(string customerText)
    {
        // int randX = Random.Range(0, customerID.Length);
        customerOpinion.text = customerText;
        //return randX;
    }

    public void getTimer(float tempTime)
    {
        timerHolder.text = tempTime.ToString("F0");
    }

    public void updateMoney(int tempMoney)
    {
        moneyHolder.text = "$ " + tempMoney.ToString();
    }

    public void setFeedbackText(bool correctChoice)
    {
        customerOpinion.gameObject.SetActive(true);
        if(correctChoice)
        {
            customerOpinion.text = "Thank you!";
        }
        else
        {
            customerOpinion.text = "Kala eisai malakas?";
        }
    }
 
}
