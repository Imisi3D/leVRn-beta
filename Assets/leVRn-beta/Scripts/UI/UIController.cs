using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject title;
    
    [SerializeField]
    private GameObject screen;
    
    [SerializeField]
    public Text screenText;

    [SerializeField] 
    public GameObject textHolder;

    private static readonly int Vanish = Animator.StringToHash("Vanish");
    // Start is called before the first frame update

    public void ActivateScreen(){
        screen.SetActive(true);
    }

    public void DisplayOnScreen(string message){
        screenText.text = message;
    }

    public void RemoveTitle(){
        title.GetComponent<Animator>().SetTrigger(Vanish);
    }

    public void DisplayWork(){
        textHolder.SetActive(true);
    }
    
    
}
