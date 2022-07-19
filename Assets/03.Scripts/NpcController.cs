using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            print("trigger");
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            print("exit");
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
