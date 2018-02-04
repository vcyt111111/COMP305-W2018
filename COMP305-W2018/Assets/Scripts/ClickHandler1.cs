using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler1 : MonoBehaviour {
    public GameObject myT_shirt;
    private Rigidbody2D rBody;
    private SpriteRenderer sRend;

	// Use this for initialization
	void Start () {
        rBody = myT_shirt.GetComponent<Rigidbody2D>();
        sRend = myT_shirt.GetComponent<SpriteRenderer>();
	}

    void OnMouseDown()
    {
        sRend.color = Color.blue;
    }
    // Update is called once per frame
    private void Update () {
	}
}
