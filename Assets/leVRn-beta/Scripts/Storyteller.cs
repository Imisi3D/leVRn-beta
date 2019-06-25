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
        else if (holder.phase == 3){
            IntroduceKineticStreet();
        }
        else if (holder.phase == 4){
            IntroduceTest();
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
        holder.propController.PlayDefaultAudio("Bird");
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
                
        PlayBallHit();
        KineticConclusion();
    }

    async void KineticConclusion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new WaitForSeconds(shortBreak);
        guide.KineticConclusion();
        GoToKinetic();
    }

    async void GoToKinetic(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new WaitForSeconds(shortBreak);
        holder.phase = 3;
        holder.sceneLoader.LoadKineticStreetScene();
    }

    async void IntroduceKineticStreet(){
        guide.ForceIdle();
        await new WaitForSeconds(longBreak);
        guide.Previously();
        BusExample();
    }

    async void BusExample(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new WaitForSeconds(shortBreak);
        guide.BusExample();
        holder.propController.HighlightProp("Bus");
        holder.propController.DefaultAnimation("Bus");
        holder.propController.PlayDefaultAudio("Bus");
        PedestrianExample();
    }

    async void PedestrianExample(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new WaitForSeconds(longBreak + 2);
        guide.PedestrianExample();
        holder.propController.UnhighlightProp("Bus");
        holder.propController.HighlightProp("Pedestrian");
        holder.propController.DefaultAnimation("Pedestrian");
        FlagExample();
    }

    async void FlagExample(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new WaitForSeconds(longBreak + 3);
        holder.propController.UnhighlightProp("Pedestrian");
        holder.propController.SetGuideLocation("Flag");
        guide.ChangeLocation();
        await new WaitUntil((() => !guide.changingLocation));
        await new WaitForSeconds(shortBreak);
        guide.FlagExample();      
        holder.propController.HighlightProp("Flag");
        GoToTest();
    }

    async void GoToTest(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new WaitForSeconds(shortBreak);
        holder.phase = 4;
        holder.sceneLoader.LoadStreetTestScene();
    }

    async void IntroduceTest(){
        guide.ForceIdle();
        await new WaitForSeconds(longBreak);
        guide.TestIntro(); 
        FruitQuestion();
    }

    async void FruitQuestion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.SetGuideLocation("Tree");
        guide.ChangeLocation();
        await new WaitUntil((() => !guide.changingLocation));
        await new WaitForSeconds(shortBreak);
        guide.FruitQuestion();
        holder.propController.HighlightProp("Tree");
        DisplayFruitQuestion();
    }

    async void DisplayFruitQuestion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.DisplayQuestion("Tree");
        AnswerFruitQuestion();
    }

    async void AnswerFruitQuestion(){
        await new WaitUntil((() => holder.propController.answer != PropController.Answer.Unanswered));
        PropController.Answer answer = holder.propController.answer;
        if (answer == PropController.Answer.Right){
            guide.FruitRight();
        }
        else{
            guide.FruitWrong();
        }

        holder.propController.answer = PropController.Answer.Unanswered;
        BikeQuestion();
    }

    async void BikeQuestion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.RemoveQuestion("Tree");
        holder.propController.UnhighlightProp("Tree");
        await new WaitForSeconds(shortBreak);
        guide.BikeQuestion();
        holder.propController.HighlightProp("Bike");
        holder.propController.PlayDefaultAudio("Bike");
        holder.propController.DefaultAnimation("Bike");
        DisplayBikeQuestion();
    }

    async void DisplayBikeQuestion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.DisplayQuestion("Bike");
        AnswerBikeQuestion();
    }

    async void AnswerBikeQuestion(){
        await new WaitUntil((() => holder.propController.answer != PropController.Answer.Unanswered));
        if (holder.propController.answer == PropController.Answer.Right){
            guide.BikeRight();
        }
        else{
            guide.BikeWrong();
        }

        holder.propController.answer = PropController.Answer.Unanswered;
        TankQuestion();
    }

    async void TankQuestion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.RemoveQuestion("Bike");
        holder.propController.UnhighlightProp("Bike");
        holder.propController.SetGuideLocation("Box");
        guide.ChangeLocation();
        await new WaitUntil((() => !guide.changingLocation));
        await new WaitForSeconds(shortBreak);
        guide.TankQuestion();
        holder.propController.HighlightProp("Tank");
        DisplayTankQuestion();
    }

    async void DisplayTankQuestion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.DisplayQuestion("Tank");
        AnswerTankQuestion();
    }

    async void AnswerTankQuestion(){
        await new WaitUntil((() => holder.propController.answer != PropController.Answer.Unanswered));
        if (holder.propController.answer == PropController.Answer.Right){
            guide.TankRight();
        }
        else{
            guide.TankWrong();
        }

        holder.propController.answer = PropController.Answer.Unanswered;
        BoxQuestion();
    }

    async void BoxQuestion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.RemoveQuestion("Tank");
        holder.propController.UnhighlightProp("Tank");
        await new WaitForSeconds(shortBreak);
        guide.BoxQuestion();
        holder.propController.HighlightProp("Box");
        DisplayBoxQuestion();
    }

    async void DisplayBoxQuestion(){
        await new WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.DisplayQuestion("Box");
        AnswerBoxQuestion();
    }

    async void AnswerBoxQuestion(){
        await new WaitUntil((() => holder.propController.answer != PropController.Answer.Unanswered));
        if (holder.propController.answer == PropController.Answer.Right){
            guide.BoxRight();
        }
        else{
            guide.BoxWrong();
        }

        holder.propController.answer = PropController.Answer.Unanswered;
        await new WaitForSeconds(shortBreak);
        Debug.Log("Something happen rn");
        Instantiate(holder.quizTracker.experienceStats);
    }
    
    
    async void RemoveTitle(){
        await new WaitForSeconds(4f);
        ui.RemoveTitle();
    }

    async void PlayBallHit(){
        await new WaitForSeconds(2);
        guide.HitBall();
        await new WaitUntil((() => holder.animationTriggers.HitEnded));
        holder.animationTriggers.HitEnded = false;
        holder.propController.PlayDefaultAudio("Ball");
    }

    private void OnApplicationQuit(){
        holder.phase = 0;
    }
}
