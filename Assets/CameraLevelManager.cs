using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraLevelManager : MonoBehaviour
{
    public int currentIndex;
    
    [SerializeField]
    public List<GameObject> Levels;

    [SerializeField] public List<GameObject> cameras;

    [SerializeField] public List<GameObject> Coalas;
    [SerializeField] public List<Transform> theirPositions;


    [SerializeField] public List<GameObject> Enemies;

    private void OnEnable()
    {
        DontDestroyOnLoad(this);
        copyHolder();
    }

    public void copyHolder()
    {
        CameraLevelManagerHolder holder = FindObjectOfType<CameraLevelManagerHolder>();
        cameras = holder.cameras;
        Levels = holder.Levels;
        Coalas = holder.Coalas;
        theirPositions = holder.theirPositions;
        Enemies = holder.Enemies; 
    }

    public void launchNextLevel()
    {
     //   copyHolder();
        if (currentIndex < Levels.Count)
        {
            currentIndex++;
            StartCoroutine(loadLevel());
        }

        if (currentIndex > Levels.Count)
        {
            Debug.Log("you win");
        }
    }

    public void died()
    {
        StartCoroutine(loadLevel());
      
    }

    private IEnumerator loadLevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        
        while (!operation.isDone)
        {
            yield return null; // Continue waiting in the next frame
        }
    }

    public void recreateLevel()
    {
        //  copyHolder();
        recreate(currentIndex);
    }

    private void recreate(int currentlevel)
    {
        int i = 0;
        while (i < currentlevel)
        {
            Levels[i].SetActive(true);
            cameras[i].SetActive(true);
            i++;
        }
    }


    private void resetPositions()
    {
        
    }
}
