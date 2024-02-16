using UnityEngine;
using Lib;
using UnityEngine.InputSystem;
namespace Stage1Level1
{

    public class ExperimentStateManagerStage1Level1 : MonoBehaviour, IExperimentStateManager
    {
        public InputActionReference XButton;
        public InputActionReference YButton;
        private ExperimentTimeState time;
        public bool paused = false;

        public GameObject ball;

        private void OnEnable()
        {
            XButton.action.performed += XButtonPressed;
            XButton.action.Enable();
            YButton.action.performed += YButtonPressed;
            YButton.action.Enable();
            ResetExperiment();
        }
        public void XButtonPressed(InputAction.CallbackContext obj)
        {
            paused = !paused;
        }
        public void YButtonPressed(InputAction.CallbackContext obj)
        {
            ResetExperiment();
        }

        // Update is called once per frame
        void Update()
        {
            if (paused) return;
            time = new ExperimentTimeState(time.time + Time.deltaTime, time.maxTime);
            if (time.over) ResetExperiment();
            ExperimentStep(Time.deltaTime);
        }
        public void ResetExperiment()
        {
            ball.transform.position = new Vector3(5, 1, 0);
            time = new(0, 10);
        }
        public void ExperimentStep(float dt)
        {
            ball.transform.Translate(-dt, 0, 0);
        }
        public ExperimentTimeState getTime()
        {
            return time;
        }
    }
}