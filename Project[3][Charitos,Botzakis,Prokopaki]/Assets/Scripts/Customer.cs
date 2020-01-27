using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    private UImanager ui_manager;
    public customerData custData;
    public GameObject[] customers = new GameObject[3];
    // public GameObject customer;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public Sprite tattoo;
    public bool isEntering;
    public bool isLeaving;
   
    private bool customerDone;
    private int currentCustomer;
  //  private int tempIndex;
  public int getCurrentCustomerIndex() { return this.currentCustomer; }
    void Start()
    {
        
        customerDone = false;
        currentCustomer = 0;
      //  tempIndex = 0;
        isLeaving = false;
        isEntering = true;
        ui_manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<UImanager>();
        custData.initialise();
    }

    // Update is called once per frame
    void Update()
    {
        checkCurrentCustomer();
    }

    public void checkCurrentCustomer()
    {
        if(!customerDone)
        customerMovement();
        else if (customerDone)
        {
            if (currentCustomer <= 1)
            {
                currentCustomer++;
                isEntering = true;
                customerDone = false;
            }
            else
            {
                GameControl.Instance.setTimeElapsed(true);
                
                customerDone = true;
                GameControl.Instance.gameOver();
                print("ta pame psile");
            }
        }
    }

    public void customerMovement()
    {
        // movement for the customers
        if (customers[currentCustomer].transform.position.x < pointB.position.x && isEntering)
            customers[currentCustomer].transform.position += Vector3.right * 2.0f * Time.deltaTime;
        else if (customers[currentCustomer].transform.position.x >= pointB.position.x && isEntering)
        {
            isEntering = false;
            GameControl.Instance.updateSprites();
            ui_manager.getText(custData.customerTexts[currentCustomer]);
            ui_manager.timerHolder.gameObject.SetActive(true);
            print(isEntering);
        }
        if (customers[currentCustomer].transform.position.x >= pointC.position.x)
        {
            // change sprite and move customer to point D
            customers[currentCustomer].GetComponent<SpriteRenderer>().sprite = custData.finishedCustomers[currentCustomer];
            isLeaving = true;
        }
        if (isLeaving)
        {
            //customers[currentCustomer].GetComponent<SpriteRenderer>().sprite = tattoo;
            customers[currentCustomer].transform.position += Vector3.left * 5.0f * Time.deltaTime;
        }
        if (customers[currentCustomer].transform.position.x <= pointD.position.x && isLeaving)
        {
            customerDone = true;
            isLeaving = false;
            customers[currentCustomer].SetActive(false);
            GameControl.Instance.correctChoice = false;
            GameControl.Instance.wrongChoice = false;
            GameControl.Instance.resetTimer();
            GameControl.Instance.setTimeElapsed(false);
           // GameControl.Instance.optionsUpdateCheck = false;
            
           
            print(customerDone);
            print(currentCustomer);
        }
    }

    public void victoryMovement()
    {
        if(!isLeaving)
            customers[currentCustomer].transform.position += Vector3.right * 5.0f * Time.deltaTime;
        print("VICTORY");
        ui_manager.customerOpinion.text = "Thank you so much.";
    }
    public void lossMovement() // ! ! !
    {
        isLeaving = true;
        print("LOSS");
        ui_manager.customerOpinion.text = "Sorry, wrong.";
    }
    public void optionChecker(int incomingOptionIndex)
    {
     //   if(incomingOptionIndex == tempIndex) //if index of string array is equal to index of sprite array ...
      //  {
            //victoryMovement();
     //   }
    }
  //  public void checkFinish(bool b)
  //  {
     //   if (b)
        //    victoryMovement();
    //}
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "tattoPhase")
        {
            Debug.Log("it collides");
            ui_manager.getRandomText(ui_manager.customerOne);
            // StartCoroutine(instance.customerDelay());
        }
    }
    */
}
