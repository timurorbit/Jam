using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{
    [Header("FadeIn")] public float fadeInDuration;
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
            bubblesGameObjects[i].transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(FadeIn());
            
            i++;
        }
        else{
            LoadLevel1Scene();
        }
    }

    IEnumerator FadeIn(){
        TextMeshProUGUI tmp = bubblesGameObjects[i].GetComponentInChildren<TextMeshProUGUI>();
        Image img = bubblesGameObjects[i].GetComponent<Image>();
        Color imgColor = img.color;
        Color tmpColor = tmp.color;
        for (float t = 0f; t < fadeInDuration; t += Time.deltaTime){
            imgColor.a = Mathf.Lerp(0f, 1f, Mathf.Min(1, t/fadeInDuration));
            tmpColor.a = Mathf.Lerp(0f, 1f, Mathf.Min(1, t/fadeInDuration));
            img.color = imgColor;
            tmp.color = tmpColor;
            yield return null;
        }
    }
}
