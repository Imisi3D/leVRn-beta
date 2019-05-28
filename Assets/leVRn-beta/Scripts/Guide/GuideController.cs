﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    
    public ScriptableObjectsHolder holder;
    public Transform mainCamera;

    public GameObject speechBubble;
    
    [Header("Voice Overs")] 
    public AudioClip introduction;
    public AudioClip energyDefinition;
    public AudioClip potentialEnergy;
    public AudioClip potentialContinue;
    public AudioClip potentialPosition;
    public AudioClip potentialBook;
    
    private Animator anim;
    [NonSerialized]
    public AudioSource audioSource;

    private static readonly int On = Animator.StringToHash("PowerOn");
    private static readonly int Wave = Animator.StringToHash("Wave");
    private static readonly int ToScreen = Animator.StringToHash("GestureToScreen");
    private static readonly int Talking = Animator.StringToHash("Talking");


    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update(){
        transform.LookAt(mainCamera,Vector3.up);
    }

    // Update is called once per frame
    public void PotentialEnergy(){
        PlayAudio(potentialEnergy);
    }

    public void PotentialContinue(){
        PlayAudio(potentialContinue);
    }

    public void PotentialPosition(){
        PlayAudio(potentialPosition);
    }

    public void PotentialBook(){
        PlayAudio(potentialBook);
    }
    
    public void Introduction(){
        PlayAudio(introduction);
    }

    public void DefineEnergy(){
        PlayAudio(energyDefinition);
    }

    private void PlayAudio(AudioClip clip){
        audioSource.PlayOneShot(clip);
        anim.SetBool(Talking,true);
        speechBubble.SetActive(true);
    }

    public void PowerOn(){
        anim.SetTrigger(On);
    }

    public void GestureToScreen(){
        anim.SetTrigger(ToScreen);
    }

    public void DoneTalking(){
        anim.SetBool(Talking, false);
        speechBubble.SetActive(false);
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
