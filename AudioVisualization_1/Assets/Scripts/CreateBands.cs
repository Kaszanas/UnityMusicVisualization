using System.Collections;
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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static void InstantiateCubesAssignMaterial(int selectScenario)
    {


        

        // Created scenarios
        // 0 - Create circle of 512 objects
        // 1 - Create line of 8 objects

        if (selectScenario == 0)
        {

            // Creating GameObject for creating 512 bands
            GameObject[] geo = new GameObject[512];

            // Create 512 cubes in a circle
        }

        if (selectScenario == 1)
        {
            // Creating GameObject for creating 8 bands
            GameObject[] geo = new GameObject[8];

            // Create 8 cubes in a line

            for (int i = 0; i < 8; i++)
            {

                // Creating Instance of a specified cube
                GameObject instanceSampleCube = (GameObject)Instantiate(insertGeo);


                // Setting the name for instanced cubes
                instanceSampleCube.name = "SampleCube8BandCube" + i;

                instanceSampleCube.transform.position = this.transform.position;
                instanceSampleCube.transform.parent = this.transform;



                // Transforming every instanced cube

                // Creating as much cubes as it is the range of this loop
                geo[i] = instanceSampleCube;
                geo[i].transform.localScale = new Vector3(geoScale, geoScale, geoScale);
                geo[i].transform.position = new Vector3(geoScale + i, 0, 0);

                geo[i].GetComponent<MeshRenderer>().material = myMaterial;


            }

        }


    }


}
