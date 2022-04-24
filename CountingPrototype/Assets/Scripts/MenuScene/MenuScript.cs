using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
   public void MenuStartGameButton()
    {
        SceneManager.LoadScene(1);
    }
}
