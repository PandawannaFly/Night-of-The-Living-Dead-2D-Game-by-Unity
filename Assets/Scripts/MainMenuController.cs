using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Playgame()
    {
        int selectedCharacter =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameManager.instance.charIndex = selectedCharacter;
        SceneManager.LoadScene("Gameplay");

    }

    // Update is called once per frame
    
}//class








