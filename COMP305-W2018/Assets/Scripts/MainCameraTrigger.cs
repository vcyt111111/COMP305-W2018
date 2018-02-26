using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraTrigger : MonoBehaviour {

    public Transform playerPosition;

    private MainCameraFollow cfwb;

    // Use this for initialization
    void Start()
    {
        cfwb = GetComponent<MainCameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition.position.x > transform.position.x - (0.5f * cfwb.cameraSafeOffsetSize))
        {
            cfwb.enabled = true;
            this.enabled = false;
        }
    }
}
