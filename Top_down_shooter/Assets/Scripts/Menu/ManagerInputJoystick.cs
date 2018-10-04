using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ManagerInputJoystick : MonoBehaviour {

    public EventSystem eventSystem;
    public Button[] buttonsStart;

    void changeMenu(string nameOfButton)
    {
        foreach (Button button in buttonsStart)
        {
            if(button.gameObject.name == nameOfButton)
            {
                eventSystem.firstSelectedGameObject = button.gameObject;
                StartCoroutine(HighlightButton(button.gameObject));
            }
        }        
    }

    IEnumerator HighlightButton(GameObject myButton)
    {
        eventSystem.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        eventSystem.SetSelectedGameObject(myButton.gameObject);
    }
}
