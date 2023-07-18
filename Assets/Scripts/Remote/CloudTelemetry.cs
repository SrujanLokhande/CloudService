using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

using UnityEngine;
using UnityEngine.AI;
using Unity.Services.Core;
using UnityEngine.SceneManagement;

namespace VFSCLoud
{
    public class CloudTelemetry : MonoBehaviour
    {
        public TelemetryEvent Telemetry = TelemetryEvent.Service;

        public void RecordEvent(string eventName)
        {
            Telemetry.Data.Level = SceneManager.GetActiveScene().name;
            Telemetry.Data.Position = GameObject.FindGameObjectWithTag("Player").transform.position;
            Telemetry.Data.DeltaTime = Time.timeSinceLevelLoad;

            Telemetry.Record(eventName);
#if UNITY_EDITOR
            Debug.Log($"CloudTelemetry recorded: {eventName}");
#endif
        }

    }
}
