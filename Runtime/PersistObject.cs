﻿using UnityEngine;
using System.Collections;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Makes a GameObject persist during scene changes.
    /// </summary>
    [AddComponentMenu("Toolbox/Core/Persist Object")]
    public sealed class PersistObject : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
