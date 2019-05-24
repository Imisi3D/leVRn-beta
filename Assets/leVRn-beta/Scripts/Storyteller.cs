using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyteller : MonoBehaviour
{
    public ScriptableObjectsHolder holder;
    public GuideController guide;
    public UIController ui;

    private void Start(){
        BeginIntroduction();
    }

    public void SetActive(GameObject element){
        element.SetActive(!element.activeSelf);
    }

    async void BeginIntroduction(){
        await new WaitUntil((() => holder.animationTriggers.WaveBegun));
        holder.animationTriggers.WaveBegun = false;
        guide.Introduction();
        DefineEnergy();
    }

    async void DefineEnergy(){
        await new WaitForSeconds(4f);
        ui.RemoveTitle();
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        ui.ActivateScreen();
        ui.DisplayOnScreen($"Energy is the ability to do <size=300><color=lime>work</color></size>");
        guide.GestureToScreen();
        await new WaitForSeconds(0.5f);
        guide.DefineEnergy();
        PotentialEnergy();
    }

    async void PotentialEnergy(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        ui.DisplayWork();
    }
    
    
    
}
