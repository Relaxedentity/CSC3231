using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Profiling;

public class MemoryDisplay : MonoBehaviour
{
    public Text memoryText;
    ProfilerRecorder systemMemory;
    void Start()
    {
        //utilising the profile recorder to obtain the total memory used
        systemMemory = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
    }

    private void Update()
    {
        if (systemMemory.Valid)
        {
            memoryText.text = "Memory Used: "+systemMemory.LastValue.ToString();
        }
    }

    private void OnApplicationQuit()
    {
        systemMemory.Dispose();
    }
}
