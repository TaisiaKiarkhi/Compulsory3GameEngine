using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Terrain : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] List<float> coordinates_xyz = new List<float>();
   public List<Vector3> vertex_data = new List<Vector3>();
   public int[] triangles;
   public Mesh terrain;

    void Start()
    {
        read_from_file("/Assets/TerrainData.txt");
        terrain = new Mesh();
        GetComponent<MeshFilter>().mesh = terrain;
        CreateShape();
    }



    //reading coordinates from a file
    void read_from_file(string data_path)
    {
        string file_path = Application.dataPath + data_path;
        using (StreamReader reader = new StreamReader(file_path))
        {
            string read_lines;
            while ((read_lines= reader.ReadLine()) != null)
            {
                string[] content = read_lines.Split(new char[] { ' ', ',' }, System.StringSplitOptions.RemoveEmptyEntries);
                foreach(string line in content)
                {
                    if (float.TryParse(line, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out float parse_data))
                    {
                        coordinates_xyz.Add(parse_data);
                    }
                }
            }
        }
    }

    void CreateShape()
    {
        int j = 0;
        for(int i = 0; i<(coordinates_xyz.Count-2); i++)
        {
            vertex_data[j] = new Vector3(coordinates_xyz[i], coordinates_xyz[i+2], coordinates_xyz[i+1]);
            j++;
            i = i ++;
        }

        triangles = new int[vertex_data.Count];

        for(int i = 0; i<vertex_data.Count-2; i++)
        {
            triangles[i] = i;
            triangles[i + 1] = i + 1;
            triangles[i + 2] = i + 2;
        }
    }
   
}
