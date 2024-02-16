using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPositionButton : MonoBehaviour
{
    public void ResetPosition(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
