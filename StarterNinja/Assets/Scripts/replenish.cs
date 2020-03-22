using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class replenish : MonoBehaviour {
	public Text rep;

	// Update is called once per frame


	public void Rep(){
		
			NinjaStarLauncher gameController = FindObjectOfType<NinjaStarLauncher> ();

		if (gameController.stars <= 0) {
			NinjaStarLauncher ameController = FindObjectOfType<NinjaStarLauncher> ();

			ameController.stars = 5;
			rep.text=""+gameController.stars;
				
			}	
		}

}

