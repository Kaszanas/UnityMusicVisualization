using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic8Bands : MonoBehaviour
{


    public GameObject sampleCubePrefab;
    GameObject[] cubePrefab = new GameObject[8];
    public float maxScale8Bands;
    public float cubeScale = 5f;
    public bool useBuffer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {

            // Creating Instance of a specified cube
            GameObject instanceSampleCube = (GameObject)Instantiate(sampleCubePrefab);
            instanceSampleCube.transform.position = this.transform.position;
            instanceSampleCube.transform.parent = this.transform;

            // Setting the name for instanced cubes
            instanceSampleCube.name = "SampleCube8BandCube" + i;

            // Transforming every instanced cube

            // Creating as much cubes as it is the range of this loop
            cubePrefab[i] = instanceSampleCube;
            cubePrefab[i].transform.localScale = new Vector3(cubeScale, cubeScale, cubeScale);
            cubePrefab[i].transform.position = new Vector3(cubeScale + i, 0, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            if (cubePrefab != null)
            {
                if (useBuffer)
                {
                    cubePrefab[i].transform.localScale = new Vector3(cubeScale, cubeScale + AudioPeer.audioBandBuffer[i] * maxScale8Bands, cubeScale);
                }

                if (!useBuffer)
                {
                    cubePrefab[i].transform.localScale = new Vector3(cubeScale, cubeScale + AudioPeer.audioBand[i] * maxScale8Bands, cubeScale);
                }
                

            }
        }
    }
}
