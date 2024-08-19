using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System.Collections.Generic;

namespace MoreMountains.TopDownEngine
{
	/// <summary>
	/// Add this class to a GameObject to have it play a background music when instanciated.
	/// </summary>
	[AddComponentMenu("TopDown Engine/Sound/BackgroundMusic")]
	public class BackgroundMusic : TopDownMonoBehaviour
	{
		/// the background music
		[Tooltip("the audio clip to use as background music")]
		public List<AudioClip> SoundClips;
		public AudioClip Transition;
		// public CameraLevelManager CameraLevelManager;
		/// whether or not the music should loop
		[Tooltip("whether or not the music should loop")]
		public bool Loop = true;
		/// the ID to create this background music with
		[Tooltip("the ID to create this background music with")]
		public int ID = 255;
		int CurrentLevel = 0;


		/// <summary>
		/// Gets the AudioSource associated to that GameObject, and asks the GameManager to play it.
		/// </summary>
		protected virtual void Start()
		{
			int levelIndex = FindObjectOfType<CameraLevelManager>().currentIndex;

			if (levelIndex != CurrentLevel)
			{
                MMSoundManagerPlayOptions transitionOptions = MMSoundManagerPlayOptions.Default;
                transitionOptions.ID = ID;
                transitionOptions.Loop = false;
                transitionOptions.Location = Vector3.zero;
				transitionOptions.MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Sfx;
				MMSoundManagerSoundPlayEvent.Trigger(Transition, transitionOptions);
				CurrentLevel = levelIndex;
				Debug.Log("Play transition");
            }

            MMSoundManagerPlayOptions options = MMSoundManagerPlayOptions.Default;
			options.ID = ID;
			options.Loop = Loop;
			options.Location = Vector3.zero;
			options.MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Music;

			MMSoundManagerSoundPlayEvent.Trigger(SoundClips[levelIndex], options);
		}
	}
}