using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour {

	Transform pupil;

	float runner = 0;

	// Use this for initialization
	void Start () {
		pupil = transform.GetChild(0).GetChild(0).gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setSightsTo(Vector3 point) {
		Vector3 origin = transform.position + new Vector3(0,0,2f);
		Vector3 pupilPoint = lerpByDistance(origin, point, 2.5f);
		pupilPoint = new Vector3(pupilPoint.x, pupilPoint.y, origin.z-2.2f);
		// Debug.DrawLine(origin, pupilPoint, Color.green);
		pupil.position = pupilPoint;
	}

	Vector3 lerpByDistance(Vector3 A, Vector3 B, float x) {
		Vector3 P = x * Vector3.Normalize(B - A) + A;
    	return P;
	}

	public float getPupilY() {
		return pupil.position.y; 
	}

	public void setPupilY(float y) {
		pupil.position = new Vector3(pupil.position.x, y, pupil.position.z);
	}

	public void blink() {
		StartCoroutine(blinkAnimation());
		// InvokeRepeating("blinkAnimation", 0f, 4f);
	}

	IEnumerator blinkAnimation() {
		RectTransform rect = GetComponentInChildren<RectTransform>();
		float height = rect.rect.height;
		float width = rect.rect.width;
		float journey = 0f;
		float duration = 0.1f;

		while (journey <= duration) {
			journey = journey + Time.deltaTime;
			float percent = Mathf.Clamp01(journey / duration);			
			float newHeight = Mathf.Lerp(height, 0, percent);
			rect.sizeDelta = new Vector2(width, newHeight);
			yield return null;
		}	
		journey = 0f;
		while (journey <= duration) {
			journey = journey + Time.deltaTime;
			float percent = Mathf.Clamp01(journey / duration);			
			float newHeight = Mathf.Lerp(0, height, percent);
			rect.sizeDelta = new Vector2(width, newHeight);
			yield return null;
		}		

		// rect.sizeDelta = new Vector2(width, 0);
		// yield return new WaitForSeconds(1f);
		// rect.sizeDelta = new Vector2(width, height);
		// yield return new WaitForSeconds(1f);
	}
}
