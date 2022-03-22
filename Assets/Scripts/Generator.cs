using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class Generator : MonoBehaviour
{
    string Halo_Path = @"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\halos_In_100.dat";
    string Void_Path = @"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\voids_In_100.dat";
    public GameObject halo_Prefab;
    public GameObject void_Prefab;
    public GameObject halo_Parent;
    public GameObject void_Parent;
    GameObject tempHalo;
    GameObject tempVoid;
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

        using(var reader = new StreamReader(Void_Path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                tempVoid = Instantiate(void_Prefab, new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2])),Quaternion.identity);
                
                float voidScale = float.Parse(values[3]);
                tempVoid.transform.localScale = new Vector3(voidScale, voidScale, voidScale);

                tempVoid.transform.parent = void_Parent.transform;
                
            }

            PrefabUtility.SaveAsPrefabAsset(halo_Parent, "Assets/Prefabs/Generated_Voids.prefab");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
