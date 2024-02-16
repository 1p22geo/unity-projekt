using UnityEngine;
using UnityEngine.InputSystem;
using Lib;
using UnityEngine.UI;
namespace Stage1Level3
{

    public class ExperimentStateManagerStage1Level3 : MonoBehaviour, IExperimentStateManager
    {
        public GameObject ball;
        public InputActionReference XButton;
        public InputActionReference YButton;
        
        public Slider Xslider;
        public Slider Yslider;
        public Slider Zslider;
        private ExperimentTimeState time;
        public bool paused = false;
        public Vector3 velocity = new(0, 0, 0);
        public Vector3 accel = new(0,0,0);

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
            accel = new(Xslider.value, Yslider.value, Zslider.value);
            if (paused) return;
            time = new ExperimentTimeState(time.time + Time.deltaTime, time.maxTime);
            if (time.over) ResetExperiment();
            ExperimentStep(Time.deltaTime);
        }
        public void ResetExperiment()
        {
            velocity = new(0,0,0);
            ball.GetComponent<BallScript>().velocity = velocity;
            ball.transform.position = new Vector3(-5, 0.6f, -3);
            time = new ExperimentTimeState(0, 5);
        }
        public void ExperimentStep(float dt)
        {
            accel = new(Xslider.value, Yslider.value, Zslider.value);
            velocity += accel*dt;
            ball.GetComponent<BallScript>().velocity = velocity;
            ball.transform.Translate(velocity * dt);
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