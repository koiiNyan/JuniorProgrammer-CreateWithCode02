using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu Instance;
    [SerializeField]
    private InputField _inputField;
    public string nameInput;


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetNameString()
    {
        nameInput = _inputField.text;
    }
}
