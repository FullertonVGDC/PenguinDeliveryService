using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    public float BGsize;

    private Transform cameraTransform;
    private Transform[] layers;
    //private float viewzone = 10;
    private int leftIndex;
    private int rightIndex;

	// Use this for initialization
	private void Start () {
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = layers.Length - 1;
	}

    // Update is called once per frame
    private void Update() {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ScrollLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - BGsize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x - BGsize);
        rightIndex = leftIndex;
        leftIndex--;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
    
}
