using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class deathFeedbackToucher : MonoBehaviour{
    public MMF_Player _MmfPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f")){
            _MmfPlayer.PlayFeedbacks();
            Debug.Log("DONE");
        }
    }
}
