/*
	Attach this to the same camera as you attached the
	CameraShake script to test and experiment with
	different values.
*/

using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CameraShake))]
public class TestCameraShake : MonoBehaviour {

	public float amplitude = 0.4f;
	public float duration = 0.5f;
	//uncomment the following line and pass it in the Shake call in update if you want
	//to change when the damping starts
	public float dampStart = 0.75f; 
	public bool testShake = false;

	private CameraShake cameraShake;

	// Use this for initialization
	void Start () {
		cameraShake = gameObject.GetComponent<CameraShake>();
	}
	
	// Update is called once per frame
	void Update () {
		if(testShake){
			testShake = false;
			//there's an optional third parameter available for those that want to
			//experiment with when the damping starts
			cameraShake.Shake(amplitude, duration, dampStart);
		}
	}
}
