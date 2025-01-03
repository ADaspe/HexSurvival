using System;
using UnityEngine;

namespace HexMap
{
    public static class HexMetrics
    {
        public const float OuterRadius = 10f;
        public const float InnerRadius = OuterRadius * 0.866025404f;
        
        public static Vector3[] Corners = {
            new Vector3(0f, 0f, OuterRadius),
            new Vector3(InnerRadius, 0f, 0.5f * OuterRadius),
            new Vector3(InnerRadius, 0f, -0.5f * OuterRadius),
            new Vector3(0f, 0f, -OuterRadius),
            new Vector3(-InnerRadius, 0f, -0.5f * OuterRadius),
            new Vector3(-InnerRadius, 0f, 0.5f * OuterRadius),
            new Vector3(0f, 0f, OuterRadius)
        };
    }

    [Serializable]
    public struct HexCoordinates
    {

        [SerializeField] private int x, z;
        public int X => x;

        public int Y => -X-Z;

        public int Z => z;

        public HexCoordinates(int x, int z)
        {
            this.x = x;
            this.z = z;
        }

        public static HexCoordinates FromOffsetCoordinates(int x, int z)
        {
            return new HexCoordinates(x - z/2, z);
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }

        public string ToStringOnSeparateLines()
        {
            return $"{X}\n{Y}\n{Z}";
        }
    }
}
