using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerScript playerScript;
    public GameObject blockArrow;
    public GameObject fingerPoint;
    public GameObject nextButton;
    public bool replayButtonOn;
    public bool isStart;
    public GameObject finishedGoblet;
    public int levelIndex;
    public List<GameObject> levelList;
    public GameObject activeLevel;
    public static bool makeNext;
    public CameraFollow cameraFollow;
    public CollecterScript collecterScript;

    private void Awake()
    {
       
        activeLevel = Instantiate(levelList[levelIndex]);
        //Pause();
    }

    void Pause()
    {
        Time.timeScale = 0f;
        playerScript.enabled = false;
        fingerPoint.SetActive(true);
        blockArrow.SetActive(true);
        //replayButton.SetActive(false);


    }

    public void Play()
    {
        //nextButton.SetActive(false);

        if (playerScript.gameStart)
        {
            playerScript.enabled = true;
            Time.timeScale = 1f;

            fingerPoint.SetActive(false);
            blockArrow.SetActive(false);

        }


    }

    public void Next()
    {
        // SceneManager.LoadScene(levelIndex+1);
        

        Destroy(activeLevel);

        levelIndex += 1;


        if (levelIndex > 2)
        {
            levelIndex = Random.Range(0, 3);

            activeLevel = Instantiate(levelList[levelIndex]);

        }
        else
        {
            activeLevel = Instantiate(levelList[levelIndex]);
        }


        Time.timeScale = 1;
        nextButton.SetActive(false);

        Play();
        finishedGoblet.SetActive(false);
        makeNext = true;



    }


}
