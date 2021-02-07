using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col) {      // gets called when an object exits this object(in this case, its a box collider)
        if(col.gameObject.tag == "Ball") {
            Invoke("FallDown", 0.5f);       // the method "FallDown" is invoked after 0.5s
            // FallDown();
        }
    }


    void FallDown() {
        GetComponentInParent<Rigidbody>().useGravity = true;    // Get the parent of the current component(in this case Rigidbody is the parent of boxcollider) and set its useGravity value to true
        GetComponentInParent<Rigidbody>().isKinematic = false;
        // Destroy(transform.parent.gameObject, 2f);               // destroy the parent component after 2s
        PlatformDestroyer.instance.Destroy();
        Debug.Log("Hakai!!!");
        // Destroy(transform.parent.gameObject);
        // DestroyImmediate(transform.parent.gameObject);
    }
}
