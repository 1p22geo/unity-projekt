using NUnit.Framework;
using Stage1Level3;
using TestUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExperimentStateManagerStage1Level3Tests
{
    [Test]
    public void UpdateState()
    {
        ExperimentStateManagerStage1Level3 ex = new()
        {
            ball = Mocks.MockGameObjectWithComponent<BallScript>(),
            XButton = ScriptableObject.CreateInstance<InputActionReference>(),
            YButton = ScriptableObject.CreateInstance<InputActionReference>(),

            Xslider = Mocks.MockSlider(1),
            Yslider = Mocks.MockSlider(0),
            Zslider = Mocks.MockSlider(0),
        };

        ex.ball.GetComponent<BallScript>().Xaxis = new GameObject().transform;
        ex.ball.GetComponent<BallScript>().Yaxis = new GameObject().transform;
        ex.ball.GetComponent<BallScript>().Zaxis = new GameObject().transform;
        ex.ball.GetComponent<BallScript>().XYZaxis = new GameObject().transform;

        ex.ExperimentStep(1f);
        Asserts.VectorEqual(ex.ball.transform.position, new(1f, 0, 0));
        ex.ExperimentStep(1f);
        Asserts.VectorEqual(ex.ball.transform.position, new(3f, 0, 0));
        ex.ExperimentStep(.5f);
        Asserts.VectorEqual(ex.ball.transform.position, new(4.25f, 0, 0));
    }
    [Test]
    public void ResetExperiment()
    {
        ExperimentStateManagerStage1Level3 ex = new()
        {
            ball = Mocks.MockGameObjectWithComponent<BallScript>(),
            XButton = ScriptableObject.CreateInstance<InputActionReference>(),
            YButton = ScriptableObject.CreateInstance<InputActionReference>(),
            Xslider = Mocks.MockSlider(1),
            Yslider = Mocks.MockSlider(0),
            Zslider = Mocks.MockSlider(0),
        };

        ex.ball.GetComponent<BallScript>().Xaxis = new GameObject().transform;
        ex.ball.GetComponent<BallScript>().Yaxis = new GameObject().transform;
        ex.ball.GetComponent<BallScript>().Zaxis = new GameObject().transform;
        ex.ball.GetComponent<BallScript>().XYZaxis = new GameObject().transform;

        ex.ExperimentStep(1f);
        Asserts.VectorEqual(ex.ball.transform.position, new(1f, 0, 0));
        ex.ExperimentStep(1f);
        Asserts.VectorEqual(ex.ball.transform.position, new(3f, 0, 0));
        ex.ExperimentStep(.5f);
        Asserts.VectorEqual(ex.ball.transform.position, new(4.25f, 0, 0));
        ex.ResetExperiment();
        Asserts.VectorEqual(ex.ball.transform.position, new(-5f, .6f, -3f));
        ex.ExperimentStep(1f);
        Asserts.VectorEqual(ex.ball.transform.position, new(-4f, .6f, -3f));
        ex.ExperimentStep(.5f);
        Asserts.VectorEqual(ex.ball.transform.position, new(-3.25f, .6f, -3f));
    }
}
