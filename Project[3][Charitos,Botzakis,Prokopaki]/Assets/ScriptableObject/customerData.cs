using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Customers/Settings")]
public class customerData : ScriptableObject
{
    public string[] customerTexts = new string[3];
    public Sprite[] tattoos = new Sprite[9];
    public Sprite[] finishedCustomers = new Sprite[3];
  //  public string[] customerTwo = new string[3];
   // public string[] customerThree = new string[3];

   

    public void initialise()
    {
        customerTexts[0] = "I need somethimg manly and be part of nature";
        customerTexts[1] = "I want something to show me the way and never look back";
        customerTexts[2] = "I love hiking and the smell of flowers";

    }



}
