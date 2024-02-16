using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using Stage1Level2;
using TestUtils;
namespace Stage1Level2Tests
{
    public class ExperimentStateManagerStage1Level2Test
    {
        [Test]
        public void UpdateState()
        {
            ExperimentStateManagerStage1Level2 ex = new()
            {
                ball = Mocks.MockGameObjectWithComponent<BallScript>(),
                XButton = ScriptableObject.CreateInstance<InputActionReference>(),
                YButton = ScriptableObject.CreateInstance<InputActionReference>(),
                Xslider = Mocks.MockSlider(1),
                Yslider = Mocks.MockSlider(.1f),
                Zslider = Mocks.MockSlider(1),
            };
            ex.ball.GetComponent<BallScript>().Xaxis = new GameObject().transform;
            ex.ball.GetComponent<BallScript>().Yaxis = new GameObject().transform;
            ex.ball.GetComponent<BallScript>().Zaxis = new GameObject().transform;
            ex.ball.GetComponent<BallScript>().XYZaxis = new GameObject().transform;

            ex.ExperimentStep(1f);
            Asserts.VectorEqual(ex.ball.transform.position, new(1f, 0.1f, 1f));
            ex.ExperimentStep(0.5f);
            Asserts.VectorEqual(ex.ball.transform.position, new(1.5f, 0.15f, 1.5f));
        }
        [Test]
        public void ResetExperiment()
        {
            ExperimentStateManagerStage1Level2 ex = new()
            {
                ball = Mocks.MockGameObjectWithComponent<BallScript>(),
                XButton = ScriptableObject.CreateInstance<InputActionReference>(),
                YButton = ScriptableObject.CreateInstance<InputActionReference>(),
                Xslider = Mocks.MockSlider(1),
                Yslider = Mocks.MockSlider(.1f),
                Zslider = Mocks.MockSlider(.5f),
            };
            ex.ball.GetComponent<BallScript>().Xaxis = new GameObject().transform;
            ex.ball.GetComponent<BallScript>().Yaxis = new GameObject().transform;
            ex.ball.GetComponent<BallScript>().Zaxis = new GameObject().transform;
            ex.ball.GetComponent<BallScript>().XYZaxis = new GameObject().transform;
            ex.ExperimentStep(1f);
            Asserts.VectorEqual(ex.ball.transform.position, new(1f, 0.1f, .5f));
            ex.ExperimentStep(0.5f);
            Asserts.VectorEqual(ex.ball.transform.position, new(1.5f, 0.15f, .75f));
            ex.ResetExperiment();
            Asserts.VectorEqual(ex.ball.transform.position, new(-5f, 0.6f, -3f));
        }
    }
}