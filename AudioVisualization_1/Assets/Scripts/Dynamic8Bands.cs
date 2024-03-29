﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic8Bands : MonoBehaviour
{


    public GameObject sampleCubePrefab;
    GameObject[] cubePrefab = new GameObject[8];
    public float maxScale8Bands;

    public int selectScenario;

    public Material myMaterial;

    public float cubeScale = 5f;
    public bool useBuffer;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateCubesAssignMaterial(selectScenario);
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
                    float emissionStrength = AudioPeer.audioBandBuffer[i];
                    cubePrefab[i].GetComponent<MeshRenderer>().material.SetFloat("_MyEmission", emissionStrength);
                }

                if (!useBuffer)
                {
                    cubePrefab[i].transform.localScale = new Vector3(cubeScale, cubeScale + AudioPeer.audioBand[i] * maxScale8Bands, cubeScale);
                }
                

            }
        }
    }

    public void InstantiateCubesAssignMaterial(int selectScenario)
    {

        // Created scenarios
        // 0 - Create circle of 512 objects
        // 1 - Create line of 8 objects

        if (selectScenario == 0)
        {
            // Create 512 cubes in a circle
        }

        if (selectScenario == 1)
        {

            // Create 8 cubes in a line

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

                cubePrefab[i].GetComponent<MeshRenderer>().material = myMaterial;


            }

        }


    }

}
