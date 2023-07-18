// Copyright (C) 2023 Srujan Lokhande, All rights Reserved
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VFSCLoud
{
    [System.Serializable]
    public class PlatformInfo 
    {
        [SerializeField] public float Speed;
        [SerializeField] public float EasingDistance;
        [SerializeField] public List<Vector3> Points;


        public PlatformInfo() 
        {
            Speed = 2.0f;
            EasingDistance = 0.5f;
            Points = new List<Vector3>();
        }
    }
    [System.Serializable]
    public class PlatformData
    {
        public List<PlatformInfo> PlatformList;
        public PlatformData()
        {
            PlatformList = new List<PlatformInfo>();
        }
   
    }
}
