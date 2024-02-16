using NUnit.Framework;
using UnityEngine;

namespace TestUtils
{
    public static class Asserts
    {
        public static void VectorEqual(Vector3 vec1, Vector3 vec2)
        {
            Assert.AreEqual(vec1.x, vec2.x);
            Assert.AreEqual(vec1.y, vec2.y);
            Assert.AreEqual(vec1.z, vec2.z);
        }
    }
}