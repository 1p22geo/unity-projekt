using UnityEngine;
using UnityEngine.SceneManagement;
namespace MainMenu
{

    public class Stage1Level1Selectable : MonoBehaviour
    {
        public GameObject tooltip;
        public void HoverEnteredHandler(){
            tooltip.SetActive(true);
        }
        public void HoverExitHandler(){
            tooltip.SetActive(false);
        }
        public void ActivateHandler(){
            SceneManager.LoadScene("Level 1.1");
        }
    }
}