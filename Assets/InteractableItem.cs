using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour {

    private GameObject playerUi;

    private void Start() {

        // This finds the GameObject that has your icon as a component, and stores it in the script.
        this.playerUi = GameObject.Find("Icon");
        this.playerUi.SetActive(false);
    }

    void OnTriggerEnter(Collider coll) {

        // Return if the colliding object is not a player.
        if (coll.transform.gameObject.tag != "Player")
            return;

        this.playerUi.SetActive(true);
    }

    void OnTriggerStay(Collider coll) {

        // Return if the colliding object is not a player.
        if (coll.transform.gameObject.tag != "Player")
            return;

        if (UnityEngine.Input.GetKeyDown(KeyCode.E)) {

            Debug.Log("Clicked");
        }
    }

    void OnTriggerExit(Collider coll) {

        // Return if the colliding object is not a player.
        if (coll.transform.gameObject.tag != "Player")
            return;

        this.playerUi.SetActive(false);
    }
}