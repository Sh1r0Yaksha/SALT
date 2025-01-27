﻿using UnityEngine;

namespace SALT
{
    /// <summary>
    /// Class with events
    /// </summary>
    public static class Callbacks
    {
        /// <summary>
        /// Event for when the main menu is loaded.
        /// </summary>
        public static event Callbacks.OnLevelLoadedDelegate OnMainMenuLoaded;
        /// <summary>
        /// Event for when any level, that isn't the main menu, is loaded.
        /// </summary>
        public static event Callbacks.OnLevelLoadedDelegate OnLevelLoaded;
        /// <summary>
        /// Event that's called when <see cref="MainScript.Start"/> ends.
        /// </summary>
        internal static event Callbacks.OnGameContextReadyDelegate OnGameContextReady;
        /// <summary>
        /// Triggers when the game's resolution is changed
        /// </summary>
        public static event OnResolutionChangedDelegate OnApplyResolution;

        internal static void OnLoad()
        {
            Callbacks.OnGameContextReadyDelegate gameContextReady = Callbacks.OnGameContextReady;
            if (gameContextReady == null)
                return;
            gameContextReady();
        }

        internal static void OnSceneLoaded()
        {
            if (Levels.isMainMenu())
            {
                Callbacks.OnLevelLoadedDelegate onMainMenuLoaded = Callbacks.OnMainMenuLoaded;
                if (onMainMenuLoaded == null)
                    return;
                onMainMenuLoaded();
                return;
            }
            Callbacks.OnLevelLoadedDelegate onLevelLoaded = Callbacks.OnLevelLoaded;
            if (onLevelLoaded == null)
                return;
            onLevelLoaded();
        }

        internal static void OnApplyResolution_Trigger()
        {
            Callbacks.OnResolutionChangedDelegate onApplyResolution = Callbacks.OnApplyResolution;
            if (onApplyResolution == null)
                return;
            onApplyResolution();
        }

        /// <summary>
        /// Delegate for when a level is loaded.
        /// </summary>
        public delegate void OnLevelLoadedDelegate();

        internal delegate void OnGameContextReadyDelegate();

        public delegate void OnResolutionChangedDelegate();
    }
}
