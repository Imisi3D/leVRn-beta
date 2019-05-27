using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropController : MonoBehaviour
{
    [SerializeField] private GameObject table;
    [SerializeField] private GameObject bookExample;

    public void ActivateBookExample(){
        table.SetActive(true);
        bookExample.SetActive(true);
    }
}
