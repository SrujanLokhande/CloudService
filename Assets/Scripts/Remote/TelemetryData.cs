using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace VFSCLoud
{
    public class TelemetryData
    {
        public string Level;        // level name
        public Vector3 Position;    // Player position at time of the event
        public float DeltaTime;     // time since level load

        // TODO: Add animation state or enum
        // TODO: Heading of player
        public TelemetryData()
        {
            Level = "level-one";
            Position = Vector3.zero;
            DeltaTime = 0.0f;
            return;
        }

        // serialize a dictionary because it is easy as it has key value pauir
        public Dictionary<string, object> AsDict()
        {
            // Convert our class data into a dictionary

            var theDict = new Dictionary<string, object>()
            {
                {"levelName", Level}, {"Position", JsonUtility.ToJson( Position)}, {"DeltaTime",  DeltaTime}
            };

            return theDict;
        }
    }

}