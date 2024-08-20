using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistenBackgroundMusicLevels : PersistentBackgroundMusic
{
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;

    private string previousScene;

    private MMSoundManagerPlayOptions previous;

    private void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
        previousScene = SceneManager.GetActiveScene().name;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (previousScene == arg0.name)
        {
            return;
        }
        if ("Level 1".Equals(arg0.name))
        {
            ChangeSoundtrack(level1);
        }
        else if ("Level 2".Equals(arg0.name))
        {
            ChangeSoundtrack(level2);
        }
        else if ("Level 3".Equals(arg0.name))
        {
            ChangeSoundtrack(level3);
        }

        previousScene = arg0.name;
    }

    private void ChangeSoundtrack(AudioClip audioClip)
    {
        MMSoundManager._instance.StopAllSounds();
        
        MMSoundManagerPlayOptions options = MMSoundManagerPlayOptions.Default;
        options.Loop = Loop;
        options.Location = Vector3.zero;
        options.MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Music;
        options.Persistent = true;

        MMSoundManagerSoundPlayEvent.Trigger(audioClip, options);
        previous = options;
    }
}
