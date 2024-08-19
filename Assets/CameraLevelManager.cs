using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class CameraLevelManager : MonoBehaviour
{
    public int currentIndex;

    [SerializeField] public List<GameObject> Levels;

    [SerializeField] public List<GameObject> cameras;

    [SerializeField] public List<GameObject> Coalas;
    [SerializeField] public List<Transform> theirPositions;


    [SerializeField] public List<GameObject> Enemies;
    public GameObject defaultCamera;
    public List<GameObject> borders;

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
        else
        {
            currentIndex = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        positionCamers(currentlevel);
        while (i < currentlevel)
        {
            Levels[i].SetActive(true);
            cameras[i].SetActive(true);
            if (i == 1)
            {
                cameras[i+1].SetActive(true);
            }
            i++;
        }
        
        if (currentlevel == 1)
        {
            recreateBorders();
        }
    }

    private void recreateBorders()
    {
        borders[0].gameObject.transform.localPosition = new Vector3(-8.8f, -1f, 0);
        borders[1].gameObject.transform.localPosition = new Vector3(5.28f,-1f,0);
        borders[2].gameObject.transform.localPosition = new Vector3(-8.8f,-1f,0);
        borders[3].gameObject.transform.localPosition = new Vector3(5.28f,-1f,0);
    }

    private void positionCamers(int currentlevel)
    {
        Camera camera1 = defaultCamera.GetComponent<Camera>();
        Camera camera2 = cameras[0].GetComponent<Camera>();
        Camera camera3 = cameras[1].GetComponent<Camera>();
        Camera camera4 = cameras[2].GetComponent<Camera>();

        if (currentlevel == 0)
        {
            PostProcessLayer layer = camera1.GetComponent<PostProcessLayer>();
            layer.finalBlitToCameraTarget = false;
            camera1.rect = new Rect(0, 0, 1, 1);
            camera2.rect = new Rect(0, 0, 0, 0);
            camera3.rect = new Rect(0, 0, 0, 0);
            camera4.rect = new Rect(0, 0, 0, 0);
        }

        if (currentlevel == 1)
        {
            camera1.rect = new Rect(0, 0, .5f, 1);
            camera2.rect = new Rect(.5f, 0, .5f, 1);
            camera3.rect = new Rect(0, 0, 0, 0);
            camera4.rect = new Rect(0, 0, 0, 0);
        }

        if (currentlevel == 2)
        {
            camera1.rect = new Rect(0, .5f, .5f, .5f);
            camera2.rect = new Rect(.5f, .5f, .5f, .5f);
            camera3.rect = new Rect(0, 0, .5f, .5f);
            camera4.rect = new Rect(.5f, 0, .5f, .5f);
        }

        if (currentlevel == 3)
        {
            camera1.rect = new Rect(0, .5f, .5f, .5f);
            camera2.rect = new Rect(.5f, .5f, .5f, .5f);
            camera3.rect = new Rect(0, 0, .5f, .5f);
            camera4.rect = new Rect(.5f, 0, .5f, .5f);
        }
    }


    private void resetPositions()
    {
    }
}