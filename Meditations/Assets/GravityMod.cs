using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class GravityMod : MonoBehaviour {
	float startGrav;
	public GameObject killThis;
	FirstPersonController fps;
	public Image blackScreen;
	bool endGame;
	int t;
	// Use this for initialization
	void Start () {
		fps = GetComponent<FirstPersonController>();
		startGrav = fps.m_GravityMultiplier;
	}
	
	void Update(){
		if (endGame){
			fps.m_WalkSpeed = 0;
			if (blackScreen.color.a <= 1){
			var tempc = blackScreen.color;
			tempc.a = blackScreen.color.a + 0.01f;
			blackScreen.color = tempc;

			if (blackScreen.color.a >= 1){
				t++;
			}

			if (t > 5 * Time.deltaTime){
				Application.Quit();
			}
		}
	}
	}

	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "GravityMod"){
			fps.m_GravityMultiplier = 0.0f;
		}
		if (other.tag == "TerrainKill"){
			killThis.GetComponent<TerrainCollider>().enabled = false;
		}
		if (other.tag == "End"){
			endGame = true;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "GravityMod"){
			fps.m_GravityMultiplier = startGrav;
		}
	}
}
