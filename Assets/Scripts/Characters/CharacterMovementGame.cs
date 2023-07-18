// Copyright (C) 2023 Srujan Lokhande, All rights Reserved
using Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CharacterMovement;
using VFSCLoud;

public class CharacterMovementGame : CharacterMovement3D, IRemotePlayer
{
    public void Awake()
    {
        base.Awake();
    }

    public void LoadConfigs(PlayerData theData)
    {
        // take data loaded in param list from unity game services and apply to this behaviour        
        _speed = theData.Speed;
        _jumpHeight = theData.JumpHeight;
        _turnSpeed = theData.TurnSpeed;
        
    }

}
