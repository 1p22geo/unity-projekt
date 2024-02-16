using Lib;
using UnityEngine;
namespace Stage1Level1
{

    public class BallScript : MonoBehaviour
    {
        public GameObject tooltip;
        public Transform Xaxis;
        public Transform Yaxis;
        public Transform Zaxis;
        public Transform XYZaxis;
        bool active = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Vector3 velocity = new Vector3(-1, 0, 0);
            Util.UpdateVectors(transform.position, velocity, Xaxis, Yaxis, Zaxis, XYZaxis);
        }
        public void HoverEnterHandler()
        {
            active = !active;
            tooltip.SetActive(active);
        }
    }
}