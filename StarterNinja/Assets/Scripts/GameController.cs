﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public bool isGameOver;
	public Text scoreTxt;
	public Text gameOverTxt;
	public Canvas gameOverCanvas;
	public Text highscore;
	public Text starno;


	private int _currScore;
	private int _scoreToWin = 30;
	private bool _didIWin;

	/// <summary>
	/// Start a new game.
	/// </summary>
	void start(){
        _currScore=0;
        scoreTxt.text = "" + _currScore;
        highscore.text = "Highscore: " + _currScore;
        ResetGame ();

	}
	void NewGame() {
        
		NinjaStarLauncher gameController = FindObjectOfType<NinjaStarLauncher> ();
		gameController.stars = 5;
        _currScore = 0;
        scoreTxt.text = "" + _currScore;
        highscore.text = "Highscore: " + _currScore;
        ResetGame();
        



    }
	

	/// <summary>
	/// Got an enemy! Increment the score and see if we win.
	/// </summary>
	public void GotOne() {
		_currScore+=1;
		scoreTxt.text =  "" + _currScore;
		highscore.text = "Highscore: " + _currScore;


		if (_currScore >= _scoreToWin) {
			GameOver(true);
		
		}
	}
	
	/// <summary>
	/// Game's over. 
	/// </summary>
	/// <param name="didIWin">Did the playeer win?</param>	
	public void GameOver(bool didIWin) {
		isGameOver = true;
		// We'll be using this more later. I know this looks pointless now.
		_didIWin = didIWin;
		gameOverTxt.text = (_didIWin) ? "Congrats :)" : "They got in!!!";

		gameOverCanvas.enabled = true;
		NinjaStarLauncher gameController = FindObjectOfType<NinjaStarLauncher> ();
		gameController.stars = 5;
 	}
	

	/// <summary>
	/// Resets the interface, removes remaining game objects. Basically gets us to a point
	/// where we're ready to play again.
	/// </summary>
	public void ResetGame() {
		// Reset the interface
		gameOverCanvas.enabled = false;
		isGameOver = false;
		_currScore = 0;
		scoreTxt.text = "--";
        highscore.text = "Highscore: " + _currScore;
        starno.text =  "_";



        // Remove any remaining game objects
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
        	Destroy(enemy);
        }
        
        GameObject[] ninjaStars = GameObject.FindGameObjectsWithTag("NinjaStar");
        foreach (GameObject ninjaStar in ninjaStars) {
        	Destroy (ninjaStar);
        }
	}
	

	
}
