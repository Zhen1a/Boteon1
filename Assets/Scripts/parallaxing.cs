using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxing : MonoBehaviour {
	public 	Transform[] backgrounds;
	public float[] parallaxScales;
	public float smoothing= 1f;

	private Transform cam;
	private Vector3 previousCamPosition;
	// Use this for initialization
	void Awake() {
		cam = Camera.main.transform;
	}
	void Start () {
		previousCamPosition = cam.position;

		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++){
			parallaxScales [i] = backgrounds [i].position.z - 1;
		}
		
	}
	
	// Update is called once per frame
		void Update () {
		for (int i = 0; i < backgrounds.Length; i++) {
				float parallax = (previousCamPosition.x - cam.position.x)*parallaxScales[i];

				float backgroundTargetPositionX = backgrounds [i].position.x + parallax;

				Vector3 backgroundTargetPosition = new Vector3 (backgroundTargetPositionX, backgrounds [i].position.y, backgrounds [i].position.z);
			backgrounds[i].position = Vector3.Lerp (backgrounds [i].position, backgroundTargetPosition,smoothing * Time.deltaTime);

	  }
			previousCamPosition = cam.position;
	}
  }

