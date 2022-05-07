using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class Generator : MonoBehaviour
{
    string Halo_Path = @"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\halos_In_200.dat";
    string Void_Path = @"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\voids_In_200.dat";
    string Particle_path = @"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\cells_In_200.dat";
    public GameObject halo_Prefab;
    public GameObject void_Prefab;
    public GameObject cell_Prefab;
    public GameObject halo_Parent;
    public GameObject void_Parent;

    public float cellScaleFacter = 500;
    GameObject tempHalo;
    GameObject tempVoid;
    GameObject tempParticle;
    ParticleSystem.ShapeModule sh;


    void Start()
    {
        // using(var reader = new StreamReader(Halo_Path))
        // {
        //     while (!reader.EndOfStream)
        //     {
        //         var line = reader.ReadLine();
        //         var values = line.Split(',');

        //         tempHalo = Instantiate(halo_Prefab, new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2])),Quaternion.identity);

        //         tempHalo.transform.parent = halo_Parent.transform;
                
        //     }

        //     PrefabUtility.SaveAsPrefabAsset(halo_Parent, "Assets/Prefabs/Generated_Halos.prefab");
        // }

        using(var reader = new StreamReader(Void_Path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                tempVoid = Instantiate(void_Prefab, new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2])),Quaternion.identity);
                
                float voidScale = float.Parse(values[3]);
                tempVoid.transform.localScale = new Vector3(voidScale, voidScale, voidScale);

                // sh = tempVoid.GetComponentInChildren<ParticleSystem>().shape;
                // sh.radius = voidScale/2;

                tempVoid.transform.parent = void_Parent.transform;
                tempVoid.name = values[4];

                // tempVoid.GetComponentInChildren<TMPro.TextMeshPro>().text = "Void ID:" + values[4].ToString() + "\n" + "Density Contrast: " + values[5].ToString();
                
            }

            // PrefabUtility.SaveAsPrefabAsset(void_Parent, "Assets/Prefabs/Generated_Voids.prefab");
        }

        using(var reader = new StreamReader(Particle_path))
        {
            Transform currentVoid = null;
            Color mColor = new Color(1,0,0);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                tempParticle = Instantiate(cell_Prefab, new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2])),Quaternion.identity);
                
                float cellScale = float.Parse(values[3]);
                cellScale = cellScale/cellScaleFacter;
                tempParticle.transform.localScale = new Vector3(cellScale, cellScale, cellScale);

                tempParticle.transform.parent = GameObject.Find(values[4]).transform;
                
                // Change color for different voids
                if(tempParticle.transform.parent != currentVoid){
                    currentVoid = tempParticle.transform.parent;
                    mColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.1f, 0.2f);

                    Material mMaterial = tempParticle.GetComponent<Material>();
                    Debug.Log("Changed color " + tempParticle.transform.parent.name + " " + mColor);
                }
                tempParticle.GetComponent<Renderer>().material.SetColor("_EmissionColor",mColor);
                
            }
            
            
        
        }

        // PrefabUtility.SaveAsPrefabAsset(void_Parent, "Assets/Prefabs/Generated_Voids.prefab");


       

    // void generatePrefab(string filePath){

    // }
    }
}