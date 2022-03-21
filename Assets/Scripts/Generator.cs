using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class Generator : MonoBehaviour
{
    string Halo_Path = @"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\halos_In_100.dat";
    public GameObject halo_Prefab;
    public GameObject halo_Parent;
    GameObject tempHalo;
    void Start()
    {
        using(var reader = new StreamReader(Halo_Path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                 tempHalo = Instantiate(halo_Prefab, new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2])),Quaternion.identity);

                 tempHalo.transform.parent = halo_Parent.transform;
                
            }

            PrefabUtility.SaveAsPrefabAsset(halo_Parent, "Assets/Prefabs/Generated_Halos.prefab");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
