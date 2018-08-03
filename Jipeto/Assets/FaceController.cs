using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour {

	public static FaceController instance;

	public EyeController leftEye;
	public EyeController rightEye;

	public Animator leftEyebrowAnimator;
	public Animator rightEyebrowAnimator;

	public AnimationClip blink;

	// Use this for initialization
	void Start () {
		if(instance == null) {
			instance = this;
		}
		StartCoroutine(startBlinking());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setSightsTo(Vector3 point) {
		leftEye.setSightsTo(point);
		rightEye.setSightsTo(point);
		normalizeEyes();
	}

	public void normalizeEyes() {
		float leftY = leftEye.getPupilY();
		float rightY = rightEye.getPupilY();
		float average = (leftY + rightY) / 2;
		leftEye.setPupilY(average); 
		rightEye.setPupilY(average); 
	}

	public void setEmotion(string emotionName) {
		switch (emotionName)
		{
			case "sad":
				GetComponent<Animator>().SetTrigger("setSad");
				break;
			case "angry":
				GetComponent<Animator>().SetTrigger("setAngry");
				break;

			case "happy":
				GetComponent<Animator>().SetTrigger("setHappy");
				break;

			case "suprised":
				GetComponent<Animator>().SetTrigger("setSuprised");
				break;

			default:
				return;
		}
	}

	IEnumerator startBlinking() {
		while(true) {
			float nextBlinkInterval = Random.Range(1f, 10f);
			// leftEye.blink();
			// rightEye.blink();
			leftEye.GetComponent<Animator>().Play("Blink", -1, 0f);
			rightEye.GetComponent<Animator>().Play("Blink", -1, 0f);
			// GetComponent<Animator>().Play("Blink", -1, 0f);
			// blink.
			yield return new WaitForSeconds(nextBlinkInterval);
			// GetComponent<Animator>().Play("Blink");	
		}
	}
}
