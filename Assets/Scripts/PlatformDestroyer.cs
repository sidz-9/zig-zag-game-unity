using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public static PlatformDestroyer instance;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnEnable() {
    //     Invoke("Destroy", 2f);
    // }

    public void Destroy() {
        gameObject.SetActive(false);
        GetComponent<Rigidbody>().useGravity = false;    // Get the parent of the current component(in this case Rigidbody is the parent of boxcollider) and set its useGravity value to true
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void OnDisable() {
        CancelInvoke("Destroy");
    }
}
