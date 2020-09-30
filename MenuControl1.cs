using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

[System.Serializable]
public class MenuControl1 : MonoBehaviour {
public Camera main;
// Menu Animation Parameters
public  float pauseCheck = 0;
public  float playCheck = 0;

public GameObject buttonRestart;
public GameObject buttonQuit;
public Animator animRestart;
public Animator animQuit;
public float timerPause = 0f;
public float timerPlay = 0f;
public GameObject pauseButton;
public GameObject playButton;
public int currentIndex = 0;
public TextMeshProUGUI textBox;
public Animator animTutorial;
public float tutTimer ;
public movement mov;

void Start()
{    	
    tutTimer = 0.5f;
	 mov = GameObject.Find("cart").GetComponent<movement>();
       textBox.text = "LEVEL "+ PlayerPrefs.GetInt("LevelNumber").ToString();
	 currentIndex = SceneManager.GetActiveScene().buildIndex;
	Debug.Log("Level " + "Start , " + PlayerPrefs.GetInt("LevelNumber"));
}

public void SaveGame()
{
	 PlayerPrefs.SetInt("ExitLevel",SceneManager.GetActiveScene().buildIndex + 1);
		 PlayerPrefs.Save();
}
	public void PauseMenu()
	{
 pauseButton.SetActive(false);
 playButton.SetActive(true);
 //main.GetComponent<DepthOfFieldDeprecated>().enabled = true;
 pauseCheck = 1;
 playCheck = 0;
 Time.timeScale = 0;
	}
	void OnApplicationQuit()
	{
	 
	}
	public void QuitGame()
	{  
		Application.Quit();
	}

	public void PlayMenu()
	{   	
		playButton.SetActive(false);
	    pauseButton.SetActive(true);
	
		//main.GetComponent<DepthOfFieldDeprecated>().enabled = false;
		Time.timeScale = 1;
		pauseCheck = 0;
		playCheck = 1;
	}

	public void RestartGame()
	{  currentIndex = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log("Level Start - " + (currentIndex + 1));
        TinySauce.OnGameStarted(currentIndex.ToString());
		SceneManager.LoadScene(currentIndex);
	}

	public void NextLevel()
	{  currentIndex = SceneManager.GetActiveScene().buildIndex;
	     if(currentIndex < 6)
		{
		    PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber") + 1);
            TinySauce.OnGameStarted(PlayerPrefs.GetInt("LevelNumber").ToString());

            SceneManager.LoadScene(currentIndex + 1);
		    SaveGame();
		}
		else 
		{
	        PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber") + 1);
            TinySauce.OnGameStarted(PlayerPrefs.GetInt("LevelNumber").ToString());

            SceneManager.LoadScene(1);
            SaveGame();
		}
	}

	void Update()
	{
       if(mov.startFlag == 1)
      tutTimer -= Time.deltaTime;
	  if(tutTimer <= 0f)
	  animTutorial.SetBool("end",true);


		//Pause Menu Animations
		if(pauseCheck == 1)
		{
			timerPause += Time.unscaledDeltaTime;
      if(timerPause >= 0.0f)
		{
          buttonRestart.SetActive(true);
		}
		if(timerPause >= 0.08f)
		{
			buttonQuit.SetActive(true);
      	pauseCheck = 0;
			timerPause = 0f;
		}
	
		}
		//Play Menu Animations
		if(playCheck == 1)
		{  
			timerPlay += Time.unscaledDeltaTime;
			if(timerPlay >= 0.0f)
			{
			 animQuit.SetBool("play",true);
			}
			if(timerPlay >= 0.08f)
			{
			 animRestart.SetBool("play",true);
			}
		
			if(timerPlay >= 0.4f)
			{
				 animQuit.SetBool("play",false);
				
				 animRestart.SetBool("play",false);
				 buttonRestart.SetActive(false);
				
				 buttonQuit.SetActive(false);
				 playCheck = 0f;
			 timerPlay = 0f;
			}
            }
	}
}
