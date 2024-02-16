using UnityEngine;
using UnityEngine.InputSystem;
using Lib;
using UnityEngine.UI;
namespace Stage1Level2
{

    public class ExperimentStateManagerStage1Level2 : MonoBehaviour, IExperimentStateManager
    {
        public GameObject ball;
        public InputActionReference XButton;
        public InputActionReference YButton;
        public Slider Xslider;
        public Slider Yslider;
        public Slider Zslider;
        private ExperimentTimeState time;
        public bool paused = false;
        public Vector3 velocity;

        private void OnEnable()
        {
            XButton.action.performed += XButtonPressed;
            XButton.action.Enable();
            YButton.action.performed += YButtonPressed;
            YButton.action.Enable();
            ResetExperiment();
        }

        void Update()
        {
            velocity = new(Xslider.value, Yslider.value, Zslider.value);
            ball.GetComponent<BallScript>().velocity = velocity;
            if (paused) return;
            time = new ExperimentTimeState(time.time + Time.deltaTime, time.maxTime);
            if (time.over) ResetExperiment();
            ExperimentStep(Time.deltaTime);
        }
        public void ResetExperiment()
        {
            ball.transform.position = new Vector3(-5, 0.6f, -3);
            time = new ExperimentTimeState(0, 5);
        }
        public void ExperimentStep(float dt)
        {
            velocity = new(Xslider.value, Yslider.value, Zslider.value);
            ball.GetComponent<BallScript>().velocity = velocity;
            ball.transform.Translate(velocity*dt);
        }
        public ExperimentTimeState getTime()
        {
            return time;
        }
        public void XButtonPressed(InputAction.CallbackContext obj)
        {
            paused = !paused;
        }
        public void YButtonPressed(InputAction.CallbackContext obj)
        {
            ResetExperiment();
        }
    }
}