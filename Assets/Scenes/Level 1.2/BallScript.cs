using Lib;
using UnityEngine;
namespace Stage1Level2
{

    public class BallScript : MonoBehaviour
    {
        public GameObject tooltip;
        public Transform Xaxis;
        public Transform Yaxis;
        public Transform Zaxis;
        public Transform XYZaxis;
        public Vector3 velocity = new(0, 0, 0);
        bool active = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Util.UpdateVectors(transform.position, velocity, Xaxis, Yaxis, Zaxis, XYZaxis);
        }
        public void HoverEnterHandler()
        {
            active = !active;
            tooltip.SetActive(active);
        }
    }
}