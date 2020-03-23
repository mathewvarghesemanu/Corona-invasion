using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class NinjaStarLauncher : MonoBehaviour {

	public GameObject ninja;
	public NinjaStarController ninjaStar;
	public AudioSource hooshSound;
	public int stars;
	public Text starnos;
	public Canvas gameOverCanvas;

	private GameController _gameController;
	private Vector3 _shooterOffset;
	private float _nextLaunchTime;
	void Start () {
		
		gameOverCanvas.enabled = false;
		_gameController = this.GetComponent<GameController>();
		_shooterOffset = new Vector3(0.0f, 0.8f, 1.0f);


		
	}
	
	void Update () {

	

		if (Input.GetButtonDown ("Fire1") && !_gameController.isGameOver) {
			// First, turn the ninja so he's looking at the player's mouse / finger.
			Vector3 mouseLoc = Input.mousePosition;
			Vector3 worldMouseLoc = Camera.main.ScreenToWorldPoint (mouseLoc);
			worldMouseLoc.y = ninja.transform.position.y;
			ninja.transform.LookAt (worldMouseLoc);


			if (stars > 0) 
			{
				LaunchNinjaStarFrom (ninja, _shooterOffset);
				stars -= 1;

				starnos.text =  "" +stars;
					}	

		}
	}



	void LaunchNinjaStarFrom(GameObject origin, Vector3 shooterOffset) {
		
		// This will a ninja star slightly in front of our origin object.
		// We also have to rotate our model 90 degrees in the x-coordinate.
		Vector3 ninjaStarRotation = origin.transform.rotation.eulerAngles;
		ninjaStarRotation.x = 90.0f;
		Vector3 transformedOffset = origin.transform.rotation * shooterOffset;
		Instantiate(ninjaStar, origin.transform.position + transformedOffset, Quaternion.Euler(ninjaStarRotation));
		
		// Play a sound effect!
		hooshSound.Play();
		
	}
	
}
