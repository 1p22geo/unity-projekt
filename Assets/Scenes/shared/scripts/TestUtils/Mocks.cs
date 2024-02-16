using UnityEngine;
using UnityEngine.UI;

namespace TestUtils
{
    public static class Mocks
    {
        public static Transform MockTransform()
        {
            GameObject obj = new();
            Transform transf = obj.transform;
            return transf;
        }
        public static Slider MockSlider(float value = 0f)
        {
            GameObject obj = new();
            obj.AddComponent<Slider>();
            obj.GetComponent<Slider>().value = value;
            return obj.GetComponent<Slider>();
        }
        public static GameObject MockGameObjectWithComponent<T>() where T : Component
        {
            GameObject obj = new();
            obj.AddComponent<T>();
            return obj;
        }
    }
}