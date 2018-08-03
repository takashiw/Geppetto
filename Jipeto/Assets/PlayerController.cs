using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using DaydreamElements.SwipeMenu;

public class PlayerController : MonoBehaviour {

	public string[] Emotions = { "happy", "suprised", "sad", "angry" };

	public float distanceFromCenter = 10f;

	public Vector3 lookAtPoint;	

	public GameObject swipeMenu;

	// Use this for initialization
	void Start () {
		swipeMenu.GetComponent<SwipeMenu>().OnSwipeSelect += OnSwipeSelect;
	}
	
	// Update is called once per frame
	void Update () {
			RaycastHit hit;
			Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
			lookAtPoint = ray.GetPoint(distanceFromCenter);
			// Debug.Log("Hit Point: " + lookAtPoint);
			FaceController.instance.setSightsTo(lookAtPoint);
		// TODO: Do it on multiplayer with some globalness
		
		// if(Network.isServer) {
		// 	return;
		// }
	}

	private void OnSwipeSelect(int ix) {
		// Debug.Log("Swiped For : " + ix);
		FaceController.instance.setEmotion(Emotions[ix]);
    //   type = (ColorUtil.Type)ix;
    //   ColorUtil.Colorize(type, gameObject);
    }
}
