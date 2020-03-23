using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tap : MonoBehaviour {
	public Canvas credits;
	public Canvas info;
	public Canvas taps;
	public Canvas main;
	public GameObject a;
	public Canvas gameOverCanvas;


	// Update is called once per frame
	public void tapp () {
		
		main.enabled = false;
		info.enabled = false;

		credits.enabled = false;
		a.SetActive(true);
		taps.enabled = true;
		gameOverCanvas.enabled = false;
	}
}
