using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBackward : MonoBehaviour
{
    [SerializeField] 
    private GameObject sphere;
    private MeshFilter meshFilter;
    private Vector3[] originalVertices; 
    private Vector2[] originalUVs;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null && meshFilter.mesh != null)
        {
            originalVertices = meshFilter.mesh.vertices.Clone() as Vector3[];
            originalUVs = meshFilter.mesh.uv.Clone() as Vector2[];
        }
        else
        {
            Debug.LogError("MeshFilter or mesh is missing!");
        }
    }

    void Update()
    {
        sphere.transform.position -= new Vector3(0.01f, 0.0f, 0.0f);

        Vector3[] modifiedVertices = new Vector3[originalVertices.Length];

        for (int i = 0; i < originalVertices.Length; i++)
        {
            modifiedVertices[i] = originalVertices[i];
            if ( sphere.transform.position.x < 0.6 && sphere.transform.position.x > 0.4 ) {
                if (originalVertices[i].z > 0 && originalVertices[i].y > 0.01 && originalVertices[i].x > -0.01 && originalVertices[i].x < 0.01)
                    modifiedVertices[i] = new Vector3(originalVertices[i].x/1.1f,originalVertices[i].y/1.1f,originalVertices[i].z/1.1f);
            }
        }
        
        meshFilter.mesh.vertices = modifiedVertices;
        meshFilter.mesh.uv = originalUVs;
        meshFilter.mesh.RecalculateNormals();
        meshFilter.mesh.RecalculateBounds();
        meshFilter.mesh.RecalculateTangents();

        if ( sphere.transform.position.x < 0.4 )
            sphere.transform.position = new Vector3(4f, 0.75f, 7.5f);
    }
}

// if (Input.GetKeyDown(KeyCode.K))
// {    
// }