// Copyright (C) 2023 Srujan Lokhande, All rights Reserved
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.RemoteConfig;
using UnityEngine.Analytics;
using Unity.Services.Analytics;

namespace VFSCLoud
{
    public class Connection : MonoBehaviour
    {
        private static Connection _instance = null;
        private static Dictionary<string, string> _environmentList;
#if UNITY_EDITOR
        private static string _currentEnv = "development";
#else
        private static string _currentEnv = "production";

#endif

        private IAuthenticationService Auth => AuthenticationService.Instance;

        public static Connection Service
        {
            get
            {
                if (_instance == null )
                {
                    _instance = new Connection();
                }
                return _instance;                
                
            }
        }

        public string RemoteID => _environmentList[_currentEnv];

        private Connection()
        {
            // Add specs for Unity game services remote config environments
            _environmentList = new Dictionary<string, string>
            {
                // environment id for different envrioment from unity game service
                {"demo","1e42e1b4-1b05-41b4-8292-e8f30eb53821" },
                {"development","1788c053-4567-4556-9137-9b3f7345db10" },
                {"production", "63005553-73db-4780-a8ad-83bad330f39d" }
            };
        }

        [Obsolete]
        public async Task Authenticate(string theEnv = "development")
        {
            // Go connect to the enviroment specified
            var options = new InitializationOptions()
                .SetOption("com.unity.services.core.environment-name", theEnv);
            _currentEnv = theEnv;

            // Let the developer know they are connected
            await UnityServices.InitializeAsync(options);
            if(!Auth.IsSignedIn)
            {
                // logs in the user function
                await Auth.SignInAnonymouslyAsync();
            }

            // logs if we are signed in or not
            Debug.Log($"Player ID: {Auth.PlayerId}");

            // start data collection
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
            AnalyticsService.Instance.StartDataCollection();

        }


    }
}

