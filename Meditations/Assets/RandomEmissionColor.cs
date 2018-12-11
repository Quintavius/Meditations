using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEmissionColor : MonoBehaviour {
	MeshRenderer[] meshRenderers;

	// Use this for initialization
	void Start () {
		meshRenderers = GetComponentsInChildren<MeshRenderer>();
		Color col = Random.ColorHSV(0f,1f,0.7f,1f,0.7f,1f) * Mathf.LinearToGammaSpace(3f);
			
		foreach (MeshRenderer m in meshRenderers){
			m.material.SetColor("_EmissionColor", col);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
