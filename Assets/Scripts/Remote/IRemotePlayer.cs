// Copyright (C) 2023 Srujan Lokhande, All rights Reserved
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VFSCLoud
{
    public interface IRemotePlayer 
    {
        // Go find these attached to other game objects so the game objects know when they can get data
        public void LoadConfigs(PlayerData theData);

    }

    public interface IRemotePlatforms
    {
        public void LoadConfigs(PlatformData theData);
    }


}