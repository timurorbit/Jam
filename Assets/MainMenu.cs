using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    private int i;
    public List<GameObject> bubblesGameObjects;

    public void LoadStoryScene(){
        SceneManager.LoadScene(1);
    }

    public void LoadLevel1Scene(){
        SceneManager.LoadScene(2);
    }

    public void ShowNextBubble(){
        if (i < bubblesGameObjects.Count){
            bubblesGameObjects[i].SetActive(true);
            i++;
        }
        else{
            LoadLevel1Scene();
        }
    }
}
