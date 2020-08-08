using UnityEngine;

namespace SweetAndSaltyStudios
{
	public struct Node
	{
        #region VARIABLES

        #endregion VARIABLES

        #region PROPERTIES

        public Vector2 WorldPostion { get; }
        public NodeVisual NodeVisual { get; }

        #endregion PROPERTIES

        #region CONSTRUCTORS

        public Node(Vector2 worldPostion, NodeVisual nodeVisual)
        {
            WorldPostion = worldPostion;
            NodeVisual = nodeVisual;
        }

        #endregion CONSTRUCTORS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}