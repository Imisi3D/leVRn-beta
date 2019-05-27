using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyteller : MonoBehaviour
{
    public ScriptableObjectsHolder holder;
    public GuideController guide;
    public UIController ui;
    public PropController prop;

    private float shortBreak = 0.5f;
    private float longBreak = 2f;

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
        RemoveTitle();
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        ui.ActivateScreen();
        ui.DisplayOnScreen("<size=300><color=lime>Energy</color></size> is the ability to do <size=300><color=lime>work</color></size>");
        guide.GestureToScreen();
        await new WaitForSeconds(shortBreak);
        guide.DefineEnergy();
        PotentialEnergy();
    }

    

    async void PotentialEnergy(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        ui.ToggleWork();
        await new WaitForSeconds(longBreak);
        ui.ToggleWork();
        ui.DisplayOnScreen("<size=300><color=lime>Potential energy</color></size> is the energy stored by a body at <size=300><color=lime>rest</color></size>");
        guide.GestureToScreen();
        await new WaitForSeconds(shortBreak);
        guide.PotentialEnergy();
        PotentialEnergyContinue();
    }

    async void PotentialEnergyContinue(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        ui.ToggleRest();
        await new WaitForSeconds(shortBreak);
        guide.PotentialContinue();
        PotentialPosition();
    }

    async void PotentialPosition(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        ui.ToggleRest();
        await new WaitForSeconds(shortBreak);
        guide.PotentialPosition();
        ui.DisplayOnScreen("<size=300><color=lime>Potential energy</color></size> is also the energy a body has because of its <size=300><color=lime>position</color></size>");
        await new WaitForSeconds(shortBreak);
        guide.GestureToScreen();
        PotentialBook();
    }

    async void PotentialBook(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        await new WaitForSeconds(shortBreak);
        guide.PotentialBook();
        await new WaitForSeconds(shortBreak);
        prop.ActivateBookExample();
        GoToStreet();
    }

    async void GoToStreet(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        await new WaitForSeconds(shortBreak);
        holder.sceneLoader.LoadStreetScene();
    }
    
    
    async void RemoveTitle(){
        await new WaitForSeconds(4f);
        ui.RemoveTitle();
    }
}
