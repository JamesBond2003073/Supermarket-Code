using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
   void Awake()
   {
        if (!PlayerPrefs.HasKey("LevelNumber"))
        {
            PlayerPrefs.SetInt("LevelNumber", 1);
            TinySauce.OnGameStarted("1");
        }
      
       
       if(PlayerPrefs.GetInt("ExitLevel") >= 1 && PlayerPrefs.GetInt("ExitLevel") <= 6)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("ExitLevel"));
            TinySauce.OnGameStarted(PlayerPrefs.GetInt("ExitLevel").ToString());
        }
       else
        {
            SceneManager.LoadScene(1);
            TinySauce.OnGameStarted("1");
        }
   }

    
}
