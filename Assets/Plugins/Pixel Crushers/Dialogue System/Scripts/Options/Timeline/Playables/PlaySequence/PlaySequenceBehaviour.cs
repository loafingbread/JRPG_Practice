// Recompile at 7/17/2020 9:22:33 PM
#if USE_TIMELINE
#if UNITY_2017_1_OR_NEWER
// Copyright (c) Pixel Crushers. All rights reserved.

using UnityEngine;
using UnityEngine.Playables;
using System;

namespace PixelCrushers.DialogueSystem
{

    [Serializable]
    public class PlaySequenceBehaviour : PlayableBehaviour
    {

        [Tooltip("Play this sequence.")]
        [TextArea(5, 5)]
        public string sequence;

        [Tooltip("(Optional) The other subject in the sequence.")]
        public Transform listener;

    }
}
#endif
#endif
