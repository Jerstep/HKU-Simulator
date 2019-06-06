using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class InputManager
{
    //public static InputManager instance = null;

    //private PlayerMovement playerMovement;

    static Dictionary<string, KeyCode> keyMapping;

    static string[] keyMaps = new string[8]
    {
        "Drink",
        "Interact",
        "Forward",
        "Backward",
        "Left",
        "Right",
        "Jump",
        "Quit"
    };

    static KeyCode[] defaults = new KeyCode[8]
    {
        KeyCode.Q,
        KeyCode.E,
        KeyCode.W,
        KeyCode.S,
        KeyCode.A,
        KeyCode.D,
        KeyCode.Space,
        KeyCode.Escape
    };

    static InputManager()
    {
        InitializeDictionary();
    }

    private static void InitializeDictionary()
    {
        keyMapping = new Dictionary<string, KeyCode>();
        for(int i = 0; i < keyMaps.Length; ++i)
        {
            keyMapping.Add(keyMaps[i], defaults[i]);
        }
    }

    public static void SetKeyMap(string keyMap, KeyCode key)
    {
        if(!keyMapping.ContainsKey(keyMap))
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        keyMapping[keyMap] = key;
    }

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keyMapping[keyMap]);
    }

    public static bool GetKeyUp(string keyMap)
    {
        return Input.GetKeyUp(keyMapping[keyMap]);
    }

    public static bool GetKey(string keyMap)
    {
        return Input.GetKey(keyMapping[keyMap]);
    }

}
