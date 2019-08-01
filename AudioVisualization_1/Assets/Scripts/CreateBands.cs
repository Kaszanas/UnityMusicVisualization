﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBands : MonoBehaviour
{

    // Inserting the geometry that You wish to be created as a music visualizer
    public static GameObject insertGeo;

    // Defining the scale of the geometry created with a default of 5
    public static float geoScale = 5f;

    // Public scenario selecting value to be used within a function
    public int selectScenario;

    // Specifying the material that will be assigned to the created geometry
    public static Material myMaterial;

    // Using bool for switching whether buffer should be used or not
    public bool useBuffer;

    // Creating 2 GameObjects to be used depending on conditions
    GameObject[] geo512 = new GameObject[512];
    GameObject[] geo8 = new GameObject[8];


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void InstantiateCubesAssignMaterial(int selectScenario)
    {


        

        // Created scenarios
        // 0 - Create circle of 512 objects
        // 1 - Create line of 8 objects

        if (selectScenario == 0)
        {

            // Creating GameObject for creating 512 bands
            GameObject[] geo = geo512;

            // Create 512 cubes in a circle
        }

        if (selectScenario == 1)
        {
            // Creating GameObject for creating 8 bands
            GameObject[] geo = geo8;

            // Create 8 cubes in a line

            for (int i = 0; i < 8; i++)
            {

                // Creating Instance of a specified cube
                GameObject instanceSampleCube = (GameObject)Instantiate(insertGeo);
                
                // Setting the name for instanced cubes
                instanceSampleCube.name = "SampleCube8BandCube" + i;

                instanceSampleCube.transform.position = this.transform.position;
                instanceSampleCube.transform.parent = this.transform;
                
                // Creating as much cubes as it is the range of this loop
                geo[i] = instanceSampleCube;
                
                // Transforming every instanced cube
                geo[i].transform.localScale = new Vector3(geoScale, geoScale, geoScale);

                geo[i].transform.position = new Vector3(geoScale + i, 0, 0);

                geo[i].GetComponent<MeshRenderer>().material = myMaterial;


            }

        }


    }

    void UsingBuffer(int selectScenario)
    {

        if (selectScenario == 0)
        {

            int loopVariable = 512;
            GameObject[] geo = geo512;

            for (int i = 0; i < loopVariable; i++)
            {
                if (geo != null)
                {
                    if (useBuffer)
                    {
                        geo[i].transform.localScale = new Vector3(geoScale, geoScale + AudioPeer.audioBandBuffer[i] * maxScale8Bands, geoScale);
                        float emissionStrength = AudioPeer.audioBandBuffer[i];
                        geo[i].GetComponent<MeshRenderer>().material.SetFloat("_MyEmission", emissionStrength);
                    }

                    if (!useBuffer)
                    {
                        geo[i].transform.localScale = new Vector3(geoScale, geoScale + AudioPeer.audioBand[i] * maxScale8Bands, geoScale);
                    }


                }
            }



        }

        if (selectScenario == 1)
        {
            GameObject[] geo = geo8;
        }










    }




}
