using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;

    Vector3 lastPos;
    float size;
    public bool gameOver = false;

    void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for(int i = 0; i < 20; i++) {
            SpawnPlatforms();
        }

    }

    public void StartSpawningPlatforms() {
        // InvokeRepeating("SpawnPlatforms", 2f, 0.2f);    // After 2s, calls the method "SpawnPlatforms" at an interval of every 0.2s
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.gameOver == true) {
            CancelInvoke("SpawnPlatforms");     // cancels the invoke named "SpawnPlatforms"
        }
    }

    void SpawnPlatforms() {
        int r = Random.Range(0, 2);     // 0 is inclusive and 2 is exclusive; ie. generates from 0 to 1;
            // Debug.Log(r);
            if(r == 0) {
                SpawnZ();
            }
            else {
                SpawnX();
            }
    }

    void SpawnX() {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);    // spawning the platform along x axis

        int r = Random.Range(0, 4);
        if(r == 0) {
            Instantiate(diamond, new Vector3(pos.x, pos.y+1, pos.z), diamond.transform.rotation);   // spawning the diamond
        }
    }

    void SpawnZ() {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);    // spawning the platform along z axis
        
        int r = Random.Range(0, 4);
        if(r == 0) {
            Instantiate(diamond, new Vector3(pos.x, pos.y+1, pos.z), diamond.transform.rotation);   // spawning the diamond
        }
    }
}
