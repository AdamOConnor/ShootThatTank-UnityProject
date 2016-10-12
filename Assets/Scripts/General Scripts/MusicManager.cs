using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	
	private static MusicManager instance = null;
	
	public static MusicManager Instance {
		get { 
			return instance; 
		}
	}
//-------------------------------------------------------
	void Update() {
		OnLevelLoaded (); // when certain level loaded stop music playing on certain scene's
	}
//-------------------------------------------------------
	void Awake() 
	{
		if (instance != null && instance != this) 
		{
			audio.Stop();
			if(instance.audio.clip != audio.clip)
			{
				instance.audio.clip = audio.clip;
				instance.audio.volume = audio.volume;
				instance.audio.Play();
			}
			
			Destroy(this.gameObject);
			return;
		} 
		instance = this;
		audio.Play (); // play audio
		DontDestroyOnLoad(this.gameObject); // keep music playing over scenes
	}
//-------------------------------------------------------
	public void OnLevelLoaded() {
		if (Application.loadedLevel == 4) { // level01
			audio.Play(); // wont play music on this scene
		}
		if (Application.loadedLevel == 5) {// level02
			audio.Play(); // wont play music on this scene
		}
		if (Application.loadedLevel == 6) {// level03
			audio.Play(); // wont play music on this scene
		}
	}
}































