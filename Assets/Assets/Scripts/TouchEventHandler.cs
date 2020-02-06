using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchEventHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private PlayerWalk playerWalk;
    public bool walkLeft;

	// Use this for initialization
	void Start () {
        playerWalk = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWalk>();
	}
	
    public void OnPointerDown(PointerEventData data) {
        /// this will detect when button is pressed
        playerWalk.AllowMovement(walkLeft);
    }

    public void OnPointerUp(PointerEventData data) {
        /// this will detect when button is released
        playerWalk.DontAllowMovement();
    }




} // class































