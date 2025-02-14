﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MenuButton : MonoBehaviour {

    public Button[] StageButton;
    public Button storeButton;
    public Button optionButton;
    public Button optionExitButton;
    public Button missionButton;
    public Button missionExitButton;
    int ClearStage;
    string str;
    public static int CurStage;
    public GameObject optionUI;
    public GameObject ExitUI;
    public GameObject missionUI;
    public Button exityes;
    public Button exitno;

    public GameObject storeUI;

    private void Awake()
    {


        //PlayerPrefs.DeleteAll();

        StageButton[0] = GetComponent<Button>();
        for (int i = 1; i < StageButton.Length; i++)
            StageButton[i] = GameObject.Find("Stage" + i).GetComponent<Button>();

       
        StageButton[1].interactable = true;

        //for (int i = 2; i < StageButton.Length; i++)

        //    StageButton[i].interactable = true;



        for (int i = 2; i < StageButton.Length; i++)

        {

            if (PlayerPrefs.GetInt("ClearStage", 0) >= (i - 1))
            {


                StageButton[i].interactable = true;
            }
            else
            {
                StageButton[i].interactable = false;
            }
            }







        }
    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape) && ExitUI.active == false)
            {
                ExitUI.SetActive(true);
            }
        }
    }
    public void storeButtonClick() {
        storeUI.SetActive(true);

    }
    public void storeExitClick()
    {
        storeUI.SetActive(false);
        
    }
    public void optionExitClick() {
        optionUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void optionButtonClick() {
        optionUI.SetActive(true);
    }
    public void missionButtonClick() {
        missionUI.SetActive(true);
    }
    public void missionExitClick() {
        missionUI.SetActive(false);

    }


    public void gameStartButton() {
        if (PlayerPrefs.GetInt("PlayCount", 0) > 0)
        {
            int count = PlayerPrefs.GetInt("PlayCount", 0);
            count++;
            PlayerPrefs.SetInt("PlayCount", count);
            Debug.Log("PlayCount = " + PlayerPrefs.GetInt("PlayCount", 0));
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("PlayCount", 0);
            PlayerPrefs.Save();
            Debug.Log("PlayCount = " + PlayerPrefs.GetInt("PlayCount", 0));
        }

        if (PlayerPrefs.GetInt("PlayCount", 0) == 0)
        {
            AutoFade.LoadLevel("Stage0", 1, 1, Color.black);
            PlayerPrefs.SetInt("CurStage", 0);
            int count = PlayerPrefs.GetInt("PlayCount", 0);
            count++;
            PlayerPrefs.SetInt("PlayCount", count);
            PlayerPrefs.Save();
        }
        else
        {
            str = EventSystem.current.currentSelectedGameObject.name;
            str = str.Replace("Stage", "");
            CurStage = Convert.ToInt32(str);
            PlayerPrefs.SetInt("CurStage", CurStage);
            AutoFade.LoadLevel("Stage" + CurStage.ToString(), 1, 1, Color.black);

            PlayerPrefs.Save();
            RedMove.DieCheck = 0;
        }

        

      

    }

    public void ExitYesClick() {
        Application.Quit();
    }
    public void ExitNoClick() {
        ExitUI.SetActive(false);
    }
    public void deletepref()
    {
        PlayerPrefs.DeleteAll();
    }
    
}
