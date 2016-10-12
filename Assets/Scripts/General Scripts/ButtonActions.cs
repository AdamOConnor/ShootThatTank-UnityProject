using UnityEngine;
using System.Collections;

public class ButtonActions : MonoBehaviour {
		
		// Use this for initialization
	public void BUTTON_LOAD_SCREEN_Instructions() { // button action instructions
		Application.LoadLevel("scene0_Instructions");
	}
//--------------------------------------------------------------------
	public void BUTTON_LOAD_SCREEN_Welcome() { // start scene of game
		Application.LoadLevel("scene0_Welcome");
	}
//--------------------------------------------------------------------
	public void BUTTON_LOAD_SCREEN_Control() { // control scene of game
		Application.LoadLevel("scene0_Controls");
	}
//--------------------------------------------------------------------
	public void BUTTON_LOAD_SCREEN_Story() { // story scene of game
		Application.LoadLevel("scene0_Story");
	}
//--------------------------------------------------------------------
	public void BUTTON_LOAD_SCENE_LEVEL_PLAYING() {	// first level of game
		Application.LoadLevel("scene_level01");
	}
//--------------------------------------------------------------------
	public void BUTTON_LOAD_SCENE_NEXT_LEVEL01() {	// next level 2 of game
		Application.LoadLevel("scene_level02");
	}
//--------------------------------------------------------------------
	public void BUTTON_LOAD_SCENE_NEXT_LEVEL02() {	// next level 3 of game
		Application.LoadLevel("scene_level03");
	}
//--------------------------------------------------------------------
	public void BUTTON_LOAD_SCENE_LEVEL01_REPLAYING() {	// replay level 1
		Application.LoadLevel("scene_level01");
	}
//--------------------------------------------------------------------
	public void BUTTON_LOAD_SCENE_LEVEL02_REPLAYING() {	// replay level 2
		Application.LoadLevel("scene_level02");
	}
//--------------------------------------------------------------------
	public void BUTTON_LOAD_SCENE_LEVEL03_REPLAYING() {	// replay level 3
		Application.LoadLevel("scene_level03");
	}
}