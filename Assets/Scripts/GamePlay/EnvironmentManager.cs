using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject platformContainer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakePlatform();
        }
    }

    private void MakePlatform()
    {
        GameObject temp = Instantiate(platformPrefab, platformContainer.transform.position,
        Quaternion.identity, platformContainer.transform);
    }
}
