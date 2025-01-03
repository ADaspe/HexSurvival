using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace HexMap
{
    public class HexGrid : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private int width = 6;
        [SerializeField] private int height = 6;
        [Header("References")]
        [SerializeField] private HexCell cellPrefab;
        [SerializeField] private TMP_Text cellLabelPrefab;
        [SerializeField] private Canvas gridCanvas;
        [SerializeField] private HexMesh hexMesh;
        [Header("Debug")]
        [SerializeField] private HexCell[] cells;
        private void Awake()
        {
            gridCanvas??=GetComponentInChildren<Canvas>();
            hexMesh??=GetComponentInChildren<HexMesh>();
            cells = new HexCell[width * height];
            for (int z = 0, i = 0; z < height; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    CreateCell(x,z,i++);
                }
            }
        }

        private void Start()
        {
            hexMesh.Triangulate(cells);
        }

        private void CreateCell(int x, int z, int i)
        {
            Vector3 position = new()
            {
                x = (x+z*0.5f - z/2) * HexMetrics.InnerRadius*2f,
                y = 0f,
                z = z * HexMetrics.OuterRadius*1.5f
            };

            HexCell cell = cells[i] = Instantiate(cellPrefab);
            cell.transform.SetParent(transform, false);
            cell.transform.localPosition = position;
            cell.Coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
            
            TMP_Text label = Instantiate(cellLabelPrefab, gridCanvas.transform, false);
            label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
            label.text = cell.Coordinates.ToStringOnSeparateLines();
        }

        
    }
}
