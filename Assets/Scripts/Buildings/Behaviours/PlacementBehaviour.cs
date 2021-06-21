using UnityEngine;

namespace Buildings.Behaviours
{
    public class PlacementBehaviour : BuildingBehaviour
    {
        private int ActiveCollisionsCount = 0;
        public Material PreviewMaterial;
        public bool CanBePlaced { get; private set; }
        private float yRot = 0f;

        private void Start()
        {
            yRot = transform.rotation.eulerAngles.y; 
            PreviewMaterial = Resources.Load<Material>("Materials/PreviewMaterial");
            CanBePlaced = true;

            Material[] m = GetComponent<Renderer>().materials;
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = PreviewMaterial;
            }
            GetComponent<Renderer>().materials = m;

            FillColor(Color.green);
            transform.localScale *= .99f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 8) return;

            ActiveCollisionsCount++;
            FillColor(Color.red);
            CanBePlaced = false;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != 8) return;
            ActiveCollisionsCount--;
            if (ActiveCollisionsCount == 0)
            {
                FillColor(Color.green);
                CanBePlaced = true;
            }
        }

        private void FillColor(Color color)
        {
            color.a = -1.0f;
            Material[] materials = GetComponent<Renderer>().materials;

            foreach (Material material in materials)
                material.color = color;
        }

        public void Rotate(float val) 
        {
            yRot += val;
            yRot = Mathf.Repeat(yRot, 360);
            transform.rotation = Quaternion.Euler(0f, yRot, 0f);
        }
    }
}