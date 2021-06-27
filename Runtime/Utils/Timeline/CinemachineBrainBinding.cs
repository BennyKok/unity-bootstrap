#if HAS_CINEMACHINE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Cinemachine;

namespace BennyKok.Bootstrap
{
    public class CinemachineBrainBinding : MonoBehaviour
    {
        public string bindNameKey = "Cinemachine Track";

        private void Start()
        {
            Bind();
        }

        public void Bind(){
            var director = GetComponent<PlayableDirector>();
            var mainCamera = Camera.main.GetComponent<CinemachineBrain>();

            var timelineAsset = (TimelineAsset)director.playableAsset;
            for (var i = 0; i < timelineAsset.outputTrackCount; i++)
            {
                var track = (TrackAsset)timelineAsset.GetOutputTrack(i);
                if (track.name.Contains(bindNameKey))
                    director.SetGenericBinding(track, mainCamera);
            }
        }
    }
}

#endif