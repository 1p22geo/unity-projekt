using UnityEngine;
using UnityEngine.SceneManagement;
namespace MainMenu
{

    public class LevelSelectable : MonoBehaviour
    {
        public GameObject tooltip;
        public string level;
        public void HoverEnteredHandler(){
            tooltip.SetActive(true);
        }
        public void HoverExitHandler(){
            tooltip.SetActive(false);
        }
        public void ActivateHandler(){
            SceneManager.LoadScene(level);
        }
    }
}