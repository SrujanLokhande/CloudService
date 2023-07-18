// Copyright (C) 2023 Srujan Lokhande, All rights Reserved

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.RemoteConfig;
using System.Data;
using System.Drawing.Text;
using System.Linq;

namespace VFSCLoud
{
    public class CloudDataManager : MonoBehaviour
    {
        [HideInInspector]
        public CloudDataManager Instance;

        private static  CloudTelemetry Telemetry = new CloudTelemetry();

        private RemoteConfigService Remote => RemoteConfigService.Instance;


        public void Awake()
        {
            // Singleton as it only has one instance
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            // initialize services

            // connect
            
        }
        
        // assume already conencted
        public async Task Start()
        {
            // setup remote config callback

            // choose environment

            // connect and Authenticate/ auth with Unity game servies
            await Connection.Service.Authenticate();


            // fetch RemoteConfig data
            FetchConfigData();

        }

        // call this function to refresh the values whereever we want, like in the pause menu
        public void FetchConfigData()
        {
            // Do some UGS RemoteConfig stuff
            Remote.SetEnvironmentID(Connection.Service.RemoteID);

            // Fetch settings for our main character
            Remote.FetchConfigs(new userAttributes(), new appAttributes());
            
            // check that scene has not been unloaded
            if (this == null)
                return;

            ApplyRemoteConfigs(Remote.appConfig);

        }

        private void ApplyRemoteConfigs(RuntimeConfig theappConfig)
        {
            // turn those settings into a C# class
            // var actualdata = theappConfig.GetFloat("Speed");

            // to load the attributes using JSon File
            var playerData = theappConfig.GetJson("Player");
            PlayerData theData = JsonUtility.FromJson<PlayerData>(playerData);

            // Find all instances that implement my IRemoteData interface
            List<IRemotePlayer> list = FindRemoteObjects<IRemotePlayer>();
            foreach(IRemotePlayer item in list)
            {
                // Tell each one to LoadConfigs( theNewRemoteData )
                item.LoadConfigs(theData);
            }

            var platformData = theappConfig.GetJson("Platforms");
            PlatformData thePlatformData = JsonUtility.FromJson<PlatformData>(platformData);

            // Find all instances that implement my IRemoteData interface
            List<IRemotePlatforms> platformList = FindRemoteObjects<IRemotePlatforms>();
            foreach (IRemotePlatforms item in platformList)
            {
                // Tell each one to LoadConfigs( theNewRemoteData )
                item.LoadConfigs(thePlatformData);
            }
        }

        private List<T> FindRemoteObjects<T>()
        {
            IEnumerable<T> list = FindObjectsOfType<MonoBehaviour>().OfType<T>();

            return new List<T>(list);
        }

        public void RecordEvent ( string eventName)
        {
            Telemetry.RecordEvent(eventName);
        } 



    }

    // used as placeolders for remote config service to fetch data
    public struct userAttributes { }
    public struct appAttributes { }

}

