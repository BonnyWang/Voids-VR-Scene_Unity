using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Generator : MonoBehaviour
{
    string Halo_Path = @"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\halos_In_100.dat";
    public GameObject halo_Prefab;
    void Start()
    {
        using(var reader = new StreamReader(Halo_Path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
