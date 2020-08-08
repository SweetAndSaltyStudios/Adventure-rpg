using System;
using UnityEngine;

namespace SweetAndSaltyStudios
{
	public class MapGenerator : MonoBehaviour
	{
        #region VARIABLES

        [Header("Settings")]
        [Range(0, 100)] public int Grid_Width_World = 10;
        [Range(0, 100)] public int Grid_Height_World = 10;

        private Node[,] grid;
        private int grid_Width;
        private int grid_Height;
        private float nodeDiameter;
        public float NodeRadius = 1;
        public NodeVisual NodeVisualPrefab;

        [Header("Debug")]
        public bool DebugMode;
        public Color32 WorldSizeDraw_Color;
        public Color32 NodeDraw_Color;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Start()
        {
            if(NodeRadius <= 0)
            {
                Debug.LogError("Node radius can not be lower or equal to 0...");
                return;
            }

            nodeDiameter = NodeRadius * 2;
            grid_Width = Mathf.RoundToInt(Grid_Width_World / nodeDiameter);
            grid_Height = Mathf.RoundToInt(Grid_Height_World / nodeDiameter);

            GenerateGrid();
        }

        private void GenerateGrid()
        {
            grid = new Node[grid_Width, grid_Height];

            var worldBottomLeftPoint = 
                transform.position - 
                Vector3.right * Grid_Width_World / 2 - 
                Vector3.up * Grid_Height_World / 2;

            var worldPoint = Vector2.zero;

            if(NodeVisualPrefab == null)
            {
                Debug.LogError("Missing Node Visual Prefab?");
                return;
            }

            for(int x = 0; x < grid.GetLength(0); x++)
                for(int y = 0; y < grid.GetLength(1); y++)
                {
                    worldPoint = worldBottomLeftPoint +
                        Vector3.right * (x * nodeDiameter + NodeRadius) +
                        Vector3.up * (y * nodeDiameter + NodeRadius);

                    var newNodeVisual = Instantiate(NodeVisualPrefab , worldPoint, Quaternion.identity, transform);

                    grid[x, y] = new Node(worldPoint, newNodeVisual);
                }
        }

        private void OnDrawGizmos()
        {
            if(DebugMode == false) return;

            Gizmos.color = WorldSizeDraw_Color;
            Gizmos.DrawWireCube(transform.position, new Vector2(Grid_Width_World, Grid_Height_World));

            if(grid == null) return;

            Gizmos.color = NodeDraw_Color;

            foreach(var node in grid)
            {
                Gizmos.DrawCube(node.WorldPostion, Vector2.one * (nodeDiameter - 0.1f));
            }
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}