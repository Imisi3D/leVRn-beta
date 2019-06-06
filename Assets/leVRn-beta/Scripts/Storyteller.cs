using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Storyteller : MonoBehaviour
{
    public ScriptableObjectsHolder holder;
    public GuideController guide;
    public UIController ui;

    private float shortBreak = 0.5f;
    private float longBreak = 2f;

    /*private void Awake(){
        DontDestroyOnLoad(gameObject);
    }*/

    private void Start(){
        if (holder.phase == 0)
            BeginIntroduction();
        else if (holder.phase == 1)
            IntroduceStreet();
        else if (holder.phase == 2){
            IntroduceKineticEnergy();
        }
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
        guide.DoneTalking();
        ui.ActivateScreen();
        ui.DisplayOnScreen("Energy is the ability to do <size=300><color=black>work</color></size>");
        guide.GestureToScreen();
        await new WaitForSeconds(shortBreak);
        guide.DefineEnergy();
        PotentialEnergy();
    }

    

    async void PotentialEnergy(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        ui.ToggleWork();
        await new WaitForSeconds(longBreak);
        ui.ToggleWork();
        ui.DisplayOnScreen("Potential energy is the energy stored by a body at <size=300><color=black>rest</color></size>");
        guide.GestureToScreen();
        await new WaitForSeconds(shortBreak);
        guide.PotentialEnergy();
        PotentialEnergyContinue();
    }

    async void PotentialEnergyContinue(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        ui.ToggleRest();
        await new WaitForSeconds(shortBreak);
        guide.PotentialContinue();
        PotentialPosition();
    }

    async void PotentialPosition(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        ui.ToggleRest();
        await new WaitForSeconds(shortBreak);
        guide.PotentialPosition();
        ui.DisplayOnScreen("Potential energy is also the energy a body has because of its <size=300><color=black>position</color></size>");
        await new WaitForSeconds(shortBreak);
        guide.GestureToScreen();
        PotentialBook();
    }

    async void PotentialBook(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new WaitForSeconds(shortBreak);
        guide.PotentialBook();
        await new WaitForSeconds(shortBreak);
        holder.propController.ActivateBookExample();
        GoToStreet();
    }

    async void GoToStreet(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new WaitForSeconds(shortBreak);
        holder.phase = 1;
        holder.sceneLoader.LoadStreetScene();
    }

    async void IntroduceStreet(){
        guide.ForceIdle();
        await new WaitForSeconds(longBreak);
        guide.StreetIntroduction();
        SignpostExample();
    }

    async void SignpostExample(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new WaitForSeconds(shortBreak);
        guide.SignpostExample();
        holder.propController.HighlightProp("Signpost");
        BirdExample();
    }

    async void BirdExample(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.UnhighlightProp("Signpost");
        await new WaitForSeconds(shortBreak);
        guide.BirdExample();
        holder.propController.HighlightProp("Bird");
        FruitsExample();
    }
    
    async void FruitsExample(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.UnhighlightProp("Bird");
        await new WaitForSeconds(shortBreak);
        guide.FruitsExample();
        holder.propController.HighlightProp("Fruits");
        PotentialConclusion();
    }

    async void PotentialConclusion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.UnhighlightProp("Fruits");
        await new WaitForSeconds(shortBreak);
        guide.PotentialConclusion();
        GoBackToSimulationRoom();
    }
    
    async void GoBackToSimulationRoom(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new WaitForSeconds(shortBreak);
        holder.phase = 2;
        holder.sceneLoader.LoadSimulationScene();       
    }

    async void IntroduceKineticEnergy(){
        guide.ForceIdle();
        ui.ToggleLearn();
        ui.RemoveTitle();
        await new WaitForSeconds(longBreak);
        guide.KineticIntroduction();
        ui.ActivateScreen();
        ui.DisplayOnScreen("Kinetic Energy is the energy possessed by a <size=300><color=black>moving</color></size> body. ");
        KineticExample();
    }

    async void KineticExample(){       
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        ui.ToggleMoving();
        guide.DoneTalking();
        await new WaitForSeconds(longBreak);
        ui.ToggleMoving();
        guide.KineticExample();
        holder.propController.ActivateBall();
        KineticConclusion();
    }

    async void KineticConclusion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.TurnOnGravity("Ball");
        await new WaitForSeconds(shortBreak);
        guide.KineticConclusion();
        
    }
    
    
    
    
    async void RemoveTitle(){
        await new WaitForSeconds(4f);
        ui.RemoveTitle();
    }

    private void OnApplicationQuit(){
        holder.phase = 0;
    }
}
