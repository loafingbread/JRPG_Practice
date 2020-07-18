// Recompile at 7/17/2020 9:22:33 PM
#if USE_TIMELINE
#if UNITY_2017_1_OR_NEWER
// Copyright (c) Pixel Crushers. All rights reserved.

using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem
{
    [Serializable]
    public class ContinueConversationClip : PlayableAsset, ITimelineClipAsset
    {
        public ContinueConversationBehaviour template = new ContinueConversationBehaviour();

        public ClipCaps clipCaps
        {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<ContinueConversationBehaviour>.Create(graph, template);
        }
    }
}
#endif
#endif
