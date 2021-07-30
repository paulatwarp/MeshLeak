using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class DebugMemory : MonoBehaviour
{
	public Text output;
	void Update()
	{
		System.GC.Collect();
		long used = Profiler.usedHeapSizeLong;
		output.text = $"Current heap used {used:N0}";
	}
}
