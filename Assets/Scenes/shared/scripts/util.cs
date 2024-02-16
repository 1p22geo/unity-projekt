using UnityEngine;


namespace Lib
{

    public static class Util
    {
        public static void UpdateVectors(Vector3 transform_base, Vector3 vec, Transform Xaxis, Transform Yaxis, Transform Zaxis, Transform XYZaxis)
        {
            float x = vec.x;
            Xaxis.position = transform_base;
            Xaxis.localScale = new Vector3(1f, x, 1f);
            float y = vec.y;
            Yaxis.position = transform_base;
            Yaxis.localScale = new Vector3(1f, y, 1f);
            float z = vec.z;
            Zaxis.position = transform_base;
            Zaxis.localScale = new Vector3(1f, z, 1f);

            XYZaxis.rotation = Quaternion.LookRotation(vec, Vector3.up);
            XYZaxis.localScale = new Vector3(1f, 1f, vec.magnitude);
        }
    }
}