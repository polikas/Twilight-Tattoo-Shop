using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private const float MAX_TIME = 7.0f;
    private bool isPaused;
    private bool timeElapsed;  
    public bool correctChoice;
    public bool wrongChoice;
    public bool optionsUpdateCheck;
    private float timeRemaining;
    private int currMoney;
    private Customer customerInstance;
    private TattooManager tattoomanager_Instance;
    private static GameControl instance;
    private UImanager ui_instance;
    private ScenesManager scenes_manager;

    private void Awake()
    {
        customerInstance = GetComponent<Customer>();
        tattoomanager_Instance = GetComponent<TattooManager>();
        ui_instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<UImanager>();
        scenes_manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScenesManager>();
    }
    void Start()
    {
        currMoney = 0;
        correctChoice = false;
        wrongChoice = false;
        timeRemaining = MAX_TIME;
        ui_instance.updateMoney(currMoney);
        Time.timeScale = 1;
        isPaused = false;
        timeElapsed = false;
        optionsUpdateCheck = false;
    }
    public static GameControl Instance
    {
        get
        {
            if ( instance== null)
            {
                instance = GameObject.FindObjectOfType<GameControl>();
            }
            return instance;
        }
    }
    // Update is called once per frame
    void Update()
    {
        playerClickPhase();
        TimerRunning();
        checkPause();
      //  if (!optionsUpdateCheck)
      //  {
        //    tattoomanager_Instance.updateOptions(customerInstance.getCurrentCustomerIndex());
         //   optionsUpdateCheck = true;
       // }
        if (wrongChoice)
            customerInstance.lossMovement();
      //  else
           // timeElapsed = false;
        if (correctChoice)
        {
            customerInstance.victoryMovement();
            ui_instance.updateMoney(currMoney);
        }
       
       // else
          //  timeElapsed = false;
    }
    public void updateSprites()
    {
        tattoomanager_Instance.updateOptions(customerInstance.getCurrentCustomerIndex());
    }
    public void gameOver()
    {
        if(currMoney >=300)
        {
            scenes_manager.loadWinScene();
        }
        else
        {
            scenes_manager.loadGameOver();
        }
    }
    #region PAUSE CONTROL
    public void pauseGame()
    {
        isPaused = true;
        print("paused");
        Time.timeScale = 0; //set timescale to 0
        ui_instance.panel.SetActive(true);
    }
    public void resumeGame()
    {
        isPaused = false;
        print("resumed");
        Time.timeScale = 1; //set timescale to 1
        ui_instance.panel.SetActive(false);
    }

    public void checkPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseGame();
        }   
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            resumeGame();
        }

    }
    #endregion
    #region TIMER
    private void TimerRunning()
    {
        if (!timeElapsed && !customerInstance.isEntering)
        {
            
            timeRemaining -= Time.deltaTime;
            ui_instance.getTimer(timeRemaining);
            //update UI here ! ! !
            //TextManager.Instance.updateTimerText(timeRemaining);
            if (timeRemaining < 0) //when timer finishes
            {
                timeElapsed = true;
                //correctChoice = false; //! ! ! placeholder
                customerInstance.lossMovement();
                //  tattoomanager_Instance.turnOffOptions();
                correctChoice = false;
                wrongChoice = false;//! ! ! placeholder
                tattoomanager_Instance.turnOffOptions();
               // resetTimer();
                print(timeRemaining);
            }
        }
        else
        {
      
            //finishGame();
        }
    }
    public void resetTimer()
    {
        //instance.isEntering = false;
        ui_instance.customerOpinion.text = "";
        timeElapsed = true;
        timeRemaining = MAX_TIME;
    }
    public void setTimeElapsed(bool b )
    {
        timeElapsed = b;
    }
    #endregion
    #region PLAYER_ACTION
    private void playerClickPhase()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("gatzos");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            //PLAYER DECK CLICK
            RaycastHit2D hitinfo = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("PlayerChoiceDeck"));
            if (hitinfo.collider != null) //&& hitinfo.collider.tag != "EmptyPuzzlePiece") //for later use
            {
                print(hitinfo.collider.gameObject.name);
                //optionsUpdateCheck = false;
                correctChoice = tattoomanager_Instance.optionChecker(hitinfo.collider, customerInstance.getCurrentCustomerIndex());
                wrongChoice = !tattoomanager_Instance.optionChecker(hitinfo.collider, customerInstance.getCurrentCustomerIndex());
                if (correctChoice)
                {
                    currMoney += 100;
                   
                }
                ui_instance.timerHolder.gameObject.SetActive(false);

                tattoomanager_Instance.turnOffOptions();
                timeElapsed = true;
                // tempPieceTag = PlayerManager.selectPiece(hitinfo.collider);
                //  tempSelection = hitinfo.collider;
            }
        }
    }
    #endregion
}
