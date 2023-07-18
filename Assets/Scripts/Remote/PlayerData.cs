// Copyright (C) 2023 Srujan Lokhande, All rights Reserved
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VFSCLoud
{
    [System.Serializable]
    public class PlayerData 
    {
        [SerializeField] public float Speed;
        [SerializeField] public float JumpHeight;
        [SerializeField] public float TurnSpeed;


        public PlayerData() 
        {
            Speed = 5.0f;
            JumpHeight = 5.0f;
            TurnSpeed = 2.0f;
        }
    }
}
