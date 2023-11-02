using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    private soundManager musicManager;

    [Header("Sounds")]

    public AudioSource button_click;
    public AudioSource normal_bubble_pop;
    public AudioSource black_bubble_pop;
    public AudioSource hands_animation_inhale;
    public AudioSource hands_animation_exhale;

    [Header("Anything longer than 10 seconds")]

    public AudioSource hands_brown_noise;
    public AudioSource game_soundrack;



    //Start is called before the first frame update
    void Start()
    {
        musicManager = FindObjectOfType<soundManager>();

        DontDestroyOnLoad(musicManager);
    }
   
    //public void DecreaseBackground()
    //{
    //    game_soundrack
    //}

    //public void IncreaseBackground()
    //{

    //}

    public void ButtonClick()
    {
        button_click.Play();
        //attackSound.PlayOneShot(attackSound, 0f);
        
    }

    public void WhiteBubblePop()
    {
        normal_bubble_pop.Play();
    }

    public void BlackBubblePop()
    {
        black_bubble_pop.Play();
    }

    public void HandsAnimationInhale()
    {
        hands_animation_inhale.volume = 1f;
        hands_animation_inhale.Play();
    }

    public void HandsAnimationExhale()
    {
        hands_animation_exhale.volume = 1f;
        hands_animation_exhale.Play();
    }

    public void Brown_Noise()
    {
        hands_brown_noise.Play();
        //Aquí detectamos qué nivel es y ponemos su ost.
    }

    public void GameplaySoundtrack()
    {
        game_soundrack.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
