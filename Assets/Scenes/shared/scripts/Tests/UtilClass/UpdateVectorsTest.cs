using NUnit.Framework;
using UnityEngine;
using Lib;
using TestUtils;
namespace SharedTests
{

    public class UpdateVectorsTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SingleAxis()
        {
            Vector3 pos = new(2, 3, 0);
            Vector3 vec = new(1, 0, 0);
            Transform Xaxis = Mocks.MockTransform();
            Transform Yaxis = Mocks.MockTransform();
            Transform Zaxis = Mocks.MockTransform();
            Transform XYZaxis = Mocks.MockTransform();


            Util.UpdateVectors(pos, vec, Xaxis, Yaxis, Zaxis, XYZaxis);

            Assert.AreEqual(Xaxis.position.x, 2f);
            Assert.AreEqual(Xaxis.position.y, 3);
            Assert.AreEqual(Xaxis.position.z, 0);
            Assert.AreEqual(Xaxis.localScale.y, vec.x);
        }
        [Test]
        public void DifferentSize()
        {
            Vector3 pos = new(2, 3, 0);
            Vector3 vec = new(1, 0, 0);
            Transform Xaxis = Mocks.MockTransform();
            Transform Yaxis = Mocks.MockTransform();
            Transform Zaxis = Mocks.MockTransform();
            Transform XYZaxis = Mocks.MockTransform();



            Util.UpdateVectors(pos, vec, Xaxis, Yaxis, Zaxis, XYZaxis);

            Assert.AreEqual(Xaxis.position.x, 2f);
            Assert.AreEqual(Xaxis.position.y, 3);
            Assert.AreEqual(Xaxis.position.z, 0);
            Assert.AreEqual(Xaxis.localScale.y, vec.x);
        }
        [Test]
        public void MultipleAxes()
        {
            Vector3 pos = new(4, 1, 5);
            Vector3 vec = new(1, 0, 2);
            Transform Xaxis = Mocks.MockTransform();
            Transform Yaxis = Mocks.MockTransform();
            Transform Zaxis = Mocks.MockTransform();
            Transform XYZaxis = Mocks.MockTransform();


            Util.UpdateVectors(pos, vec, Xaxis, Yaxis, Zaxis, XYZaxis);

            Assert.AreEqual(Xaxis.position.x, 4f);
            Assert.AreEqual(Xaxis.position.y, 1);
            Assert.AreEqual(Xaxis.position.z, 5);
            Assert.AreEqual(Xaxis.localScale.y, vec.x);
            Assert.AreEqual(Zaxis.position.x, 4f);
            Assert.AreEqual(Zaxis.position.y, 1);
            Assert.AreEqual(Zaxis.position.z, 5f);
            Assert.AreEqual(Zaxis.localScale.y, vec.z);
        }
    }
}