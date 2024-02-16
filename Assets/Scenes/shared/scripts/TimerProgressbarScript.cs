using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
namespace Lib
{

    public class TimerProgressbarScript : MonoBehaviour
    {
        private GameObject experimentObject;
        private IExperimentStateManager experiment;
        public InputActionReference AButton;
        public InputActionReference BButton;
        public bool open = false;
        void OnEnable()
        {
            AButton.action.performed += AButtonPressed;
            BButton.action.performed += BButtonPressed;
        }
        void AButtonPressed(InputAction.CallbackContext cx)
        {
            SceneManager.LoadScene("MainMenu");
        }
        void BButtonPressed(InputAction.CallbackContext cx)
        {
            GameObject panel = GameObject.FindGameObjectWithTag("MenuPanel").transform.GetChild(0).gameObject;
            open = !open;
            panel.SetActive(open);
        }
        // Start is called before the first frame update
        void Start()
        {
            experimentObject = GameObject.FindGameObjectsWithTag("ExperimentStateManager")[0];
            experiment = experimentObject.GetComponent<IExperimentStateManager>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.localScale = new Vector3(experiment.getTime().percentage, 1, 1);
            transform.localPosition = new Vector3((1 - experiment.getTime().percentage) / 2, 0, 0);
        }
    }
}