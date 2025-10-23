using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<int> OnButtonClicked;
    public static event Action<int> OnMachineButtonChanged;
    public static event Action<bool> OnRoundResult;
    
    public static void ButtonClicked(int index) => OnButtonClicked?.Invoke(index);
    public static void MachineButtonChanged(int index) => OnMachineButtonChanged?.Invoke(index);
    public static void RoundResult(bool saved) => OnRoundResult?.Invoke(saved);
}
