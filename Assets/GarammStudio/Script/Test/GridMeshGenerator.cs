using UnityEngine;

public class GridMeshGenerator : MonoBehaviour
{
    public int gridSizeX = 1;
    public int gridSizeY = 1;
    public float spacing = 1.0f;
    public Terrain terrain; // Reference to your terrain
    private Mesh gridMesh;

    private void Start()
    {
        GenerateGrid();
        PositionGridOnTerrain();
    }

    void GenerateGrid()
    {
        gridMesh = new();
        GetComponent<MeshFilter>().mesh = gridMesh;

        // Calculate the total number of vertices and triangles
        int numVertices = (gridSizeX + 1) * (gridSizeY + 1);
        int numTriangles = gridSizeX * gridSizeY * 2 * 3; // 2 triangles per grid cell, 3 vertices per triangle

        // Initialize arrays to hold vertices and triangles
        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numTriangles];

        // Generate vertices
        for (int y = 0, i = 0; y <= gridSizeY; y++)
        {
            for (int x = 0; x <= gridSizeX; x++)
            {
                vertices[i] = new Vector3(x * spacing, 0, y * spacing);
                i++;
            }
        }

        // Generate triangles
        for (int y = 0, ti = 0, vi = 0; y < gridSizeY; y++, vi++)
        {
            for (int x = 0; x < gridSizeX; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 1] = vi + gridSizeX + 1;
                triangles[ti + 2] = vi + 1;

                triangles[ti + 3] = vi + 1;
                triangles[ti + 4] = vi + gridSizeX + 1;
                triangles[ti + 5] = vi + gridSizeX + 2;
            }
        }

        // Assign vertices and triangles to the mesh
        gridMesh.vertices = vertices;
        gridMesh.triangles = triangles;

        // Optional: Recalculate normals for shading
        gridMesh.RecalculateNormals();
    }

    void PositionGridOnTerrain()
    {
        Vector3[] vertices = gridMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            // Get the X and Z position of the vertex
            float x = vertices[i].x + transform.position.x; // Adjust for grid's local position
            float z = vertices[i].z + transform.position.z; // Adjust for grid's local position

            // Sample the terrain height at this position
            float y = terrain.SampleHeight(new Vector3(x, 0, z));

            // Set the Y-coordinate of the vertex to match the terrain height
            vertices[i] = new Vector3(vertices[i].x, y, vertices[i].z);
        }

        // Update the mesh with the adjusted vertices
        gridMesh.vertices = vertices;
        gridMesh.RecalculateBounds();
    }
}
