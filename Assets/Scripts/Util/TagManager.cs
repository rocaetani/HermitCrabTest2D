using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour
{
    //-------------GAME OBJECT TAGS-------------//
    public static readonly string KILLER_TOUCH_TAG = "KillerTouch";
    public static readonly string GAME_MANAGER_TAG = "GameManager";
    public static readonly string PLAYER_TAG = "Player";
    public static readonly string START_POSITION_TAG = "StartPosition";
    public static readonly string END_PHASE_TAG = "EndPhase";



    //----------------SCENE TAGS----------------//
    public static readonly string MENU_SCENE_TAG = "Menu";
    public static readonly string GAME_SCENE_TAG = "GameScene";
    
    public static readonly string GAME_OVER_SCENE_TAG = "GameOverScene";

    //--------------ANIMATION TAGS--------------//
    public static readonly string PLAYER_ANIM_STATE = "PlayerState";
    
        
    public static readonly string JUMP_ANIM_STATE = "JumpState";



}