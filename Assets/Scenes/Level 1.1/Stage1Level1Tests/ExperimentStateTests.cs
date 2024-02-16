using NUnit.Framework;
using UnityEngine;
using Stage1Level1;
using UnityEngine.InputSystem;
using TestUtils;
namespace Stage1Level1Tests
{
    public class ExperimentStateTests
    {
        [Test]
        public void UpdateState()
        {
            ExperimentStateManagerStage1Level1 ex = new()
            {
                ball = new GameObject(),
                XButton = ScriptableObject.CreateInstance<InputActionReference>(),
                YButton = ScriptableObject.CreateInstance<InputActionReference>()
            };
            ex.ExperimentStep(1f);
            Asserts.VectorEqual(ex.ball.transform.position, new(-1, 0, 0));
            ex.ExperimentStep(0.5f);
            Asserts.VectorEqual(ex.ball.transform.position, new(-1.5f, 0, 0));
            ex.ExperimentStep(2f);
            Asserts.VectorEqual(ex.ball.transform.position, new(-3.5f, 0, 0));
        }
        [Test]
        public void ResetState()
        {
            ExperimentStateManagerStage1Level1 ex = new()
            {
                ball = new GameObject(),
                XButton = ScriptableObject.CreateInstance<InputActionReference>(),
                YButton = ScriptableObject.CreateInstance<InputActionReference>()
            };
            ex.ExperimentStep(1f);
            Asserts.VectorEqual(ex.ball.transform.position, new(-1f, 0, 0));
            ex.ExperimentStep(0.5f);
            Asserts.VectorEqual(ex.ball.transform.position, new(-1.5f, 0, 0));
            ex.ExperimentStep(2f);
            Asserts.VectorEqual(ex.ball.transform.position, new(-3.5f, 0, 0));
            ex.ResetExperiment();
            Asserts.VectorEqual(ex.ball.transform.position, new(5f, 1, 0));
        }
    }
}