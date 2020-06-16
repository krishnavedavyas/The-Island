﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController_Motor : MonoBehaviour {

	private float speed = 10.0f;
    public float WalkSpeed = 7.0f;
    public float RunSpeed = 12.0f;
	public float sensitivity = 30.0f;
	public float WaterHeight = 15.5f;
	CharacterController character;
	private GameObject cam;

    public GameObject mainCam;
    public GameObject Nightvision;
    bool night=false;

	float moveFB, moveLR;
	float rotX, rotY;
	public bool webGLRightClickRotation = true;
	float gravity = -9.8f;


	void Start(){
		//LockCursor ();
		character = GetComponent<CharacterController> ();
		if (Application.isEditor) {
			webGLRightClickRotation = false;
            speed = WalkSpeed;
            Cursor.visible = false;
			sensitivity = sensitivity * 1.5f;
            Nightvision.gameObject.SetActive(false);
            cam = mainCam;
		}
	}


	void CheckForWaterHeight(){
		if (transform.position.y < WaterHeight) {
			gravity = 0f;			
		} else {
			gravity = -9.8f;
		}
	}



	void Update(){
        if(Input.GetButton("Run"))
        {
            speed = RunSpeed;
        }
        else
        {
            speed = WalkSpeed;
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            if(night==false)
            {
                Nightvision.gameObject.SetActive(true);
                night = true;
            }
          else  if(night==true)
            {
                Nightvision.gameObject.SetActive(false);
                night = false;
            }
        }
		moveFB = Input.GetAxis ("Horizontal") * speed;
		moveLR = Input.GetAxis ("Vertical") * speed;

		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY = Input.GetAxis ("Mouse Y") * sensitivity;

		//rotX = Input.GetKey (KeyCode.Joystick1Button4);
		//rotY = Input.GetKey (KeyCode.Joystick1Button5);

		CheckForWaterHeight ();


		Vector3 movement = new Vector3 (moveFB, gravity, moveLR);



		if (webGLRightClickRotation) {
			if (Input.GetKey (KeyCode.Mouse0)) {
				CameraRotation (cam, rotX, rotY);
			}
		} else if (!webGLRightClickRotation) {
			CameraRotation (cam, rotX, rotY);
		}

		movement = transform.rotation * movement;
		character.Move (movement * Time.deltaTime);
	}


	void CameraRotation(GameObject cam, float rotX, float rotY){		
		transform.Rotate (0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
	}




}
