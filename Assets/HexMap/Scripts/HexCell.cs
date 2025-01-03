using UnityEngine;

namespace HexMap
{
    public class HexCell : MonoBehaviour
    {
        [SerializeField] private HexCoordinates coordinates;

        public HexCoordinates Coordinates
        {
            get => coordinates;
            set => coordinates = value;
        }
    }
}
