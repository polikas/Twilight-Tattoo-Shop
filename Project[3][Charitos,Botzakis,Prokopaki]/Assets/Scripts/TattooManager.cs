using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TattooManager : MonoBehaviour
{
    public GameObject[] tattoos = new GameObject[3];
    public customerData tattooData;

    // Start is called before the first frame update
    void Start()
    {
        tattooData.initialise();
        turnOffOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool optionChecker(Collider2D other,int cIndex)
    {
        if(cIndex == 0)
        {
            if(other.gameObject.tag == "option1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (cIndex == 1)
        {
            if (other.gameObject.tag == "option3")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (cIndex == 2)
        {
            if (other.gameObject.tag == "option2")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void updateOptions(int customerIndex)
    {
        if(customerIndex == 0)
        {
            // change sprites, set active, change tag???
            for(int i=0; i <=2; i++)
            {
                tattoos[i].GetComponent<SpriteRenderer>().sprite = tattooData.tattoos[i];
            }
           // tattoos[0].GetComponent<SpriteRenderer>().sprite = tattooData.tattoos[0];
        }
        else if (customerIndex == 1)
        {
            for (int i = 0; i <= 2; i++)
            {
                tattoos[i].GetComponent<SpriteRenderer>().sprite = tattooData.tattoos[i + 3];
            }
        }
        else if (customerIndex == 2)
        {
            for (int i = 0; i <= 2; i++)
            {
                tattoos[i].GetComponent<SpriteRenderer>().sprite = tattooData.tattoos[i + 6];
            }

        }
        else
        {
            print("error sto tattoo manager filaraki");
        }
        foreach (GameObject tattoo in tattoos)
        {

            tattoo.SetActive(true);
        }
    }
    public void turnOffOptions()
    {
        foreach (GameObject tattoo in tattoos)
        {

            tattoo.SetActive(false);
        }
    }
}
