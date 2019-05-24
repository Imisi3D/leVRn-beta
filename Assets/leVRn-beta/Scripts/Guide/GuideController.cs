using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    public ScriptableObjectsHolder holder;
    [Header("Voice Overs")] 
    public AudioClip introduction;
    public AudioClip energyDefinition;
    
    private Animator anim;
    [NonSerialized]
    public AudioSource audioSource;

    private static readonly int On = Animator.StringToHash("PowerOn");
    private static readonly int Wave = Animator.StringToHash("Wave");
    private static readonly int ToScreen = Animator.StringToHash("GestureToScreen");


    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Introduction(){
        PlayAudio(introduction);
    }

    public void DefineEnergy(){
        PlayAudio(energyDefinition);
    }

    private void PlayAudio(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }

    public void PowerOn(){
        anim.SetTrigger(On);
    }

    public void GestureToScreen(){
        anim.SetTrigger(ToScreen);
    }
    

    public void TriggerWaveBegun(){
        holder.animationTriggers.WaveBegun = true;
    }

    public void TriggerWaveEnded(){
        holder.animationTriggers.WaveEnded = true;
    }

    public void TriggerPowerOnEnded(){
        holder.animationTriggers.PowerOnEnded = true;
    }
    
    
}
