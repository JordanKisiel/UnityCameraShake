using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	private Camera thisCamera;

	void Start(){
		thisCamera = gameObject.GetComponent<Camera>();
	}
	
	public void Shake(float amplitude, float duration, float dampStartPercentage = 0.75f){
		StopAllCoroutines();
		StartCoroutine(ShakeCamera(amplitude, duration, dampStartPercentage));
	}

	private IEnumerator ShakeCamera(float amplitude, float duration, float dampStartPercentage){
		//ensure percentage is in a valid range
		dampStartPercentage = Mathf.Clamp(dampStartPercentage, 0.0f, 1.0f);

		float elapsedTime = 0.0f;
		float damp = 1.0f;

		Vector3 cameraOrigin = thisCamera.transform.position;

		while(elapsedTime < duration){

			elapsedTime += Time.deltaTime;

			float percentComplete = elapsedTime / duration;

			if(percentComplete >= dampStartPercentage && percentComplete <= 1.0f){
				damp = 1.0f - percentComplete;
			}

			Vector2 offsetValues = Random.insideUnitCircle;

			offsetValues *= amplitude * damp;

			thisCamera.transform.position = new Vector3(offsetValues.x, offsetValues.y, cameraOrigin.z);

			yield return null;
		}

		thisCamera.transform.position = cameraOrigin;
	}
}
