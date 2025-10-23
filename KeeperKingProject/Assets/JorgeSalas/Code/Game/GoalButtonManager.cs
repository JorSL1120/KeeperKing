using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GoalButtonManager : MonoBehaviour
{
    #region Fields
    
    [Header("Goal Buttons")]
    public Button[] goalButtons;
    
    private GoalButtonHandler[] goalButtonHandlers;

    [Header("Visual Elements")]
    public GameObject gloves;
    public GameObject glovesSave;
    public GameObject ball;
    
    [Header("Panel block")]
    public GameObject blockPanel;

    private int currentMachineIndex = -1;
    public bool machineActive = true;
    private Coroutine machineRoutine;
    #endregion

    private void Start()
    {
        blockPanel.SetActive(false);
        glovesSave.SetActive(false);
        ball.SetActive(false);
        
        goalButtonHandlers = new GoalButtonHandler[goalButtons.Length];
        
        for (int i = 0; i < goalButtons.Length; i++)
        {
            GoalButtonHandler handler = goalButtons[i].GetComponent<GoalButtonHandler>();
            if (handler == null) handler = goalButtons[i].AddComponent<GoalButtonHandler>();
            goalButtonHandlers[i] = handler;
            int index = i;
            goalButtons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
        machineRoutine = StartCoroutine(MachineMoveRoutine());
    }

    private void OnButtonClicked(int index)
    {
        if (blockPanel.activeSelf) return;
        StartCoroutine(HamdlePlayerClick(index));
    }

    private IEnumerator MachineMoveRoutine()
    {
        while (true)
        {
            if (machineActive)
            {
                List<int> eligibleIndexes = new List<int>();
                for (int i = 0; i < goalButtons.Length; i++)
                {
                    if (goalButtonHandlers[i] != null && !goalButtonHandlers[i].isInelegibleForRandom) eligibleIndexes.Add(i);
                }
                
                
                if (eligibleIndexes.Count > 0)
                {
                    // string.Join() crea una cadena de texto con los índices separados por ", "
                    string indicesStr = string.Join(", ", eligibleIndexes);
                    Debug.Log($"Botones Elegibles para la Máquina: {indicesStr}");
                }
                else
                {
                    Debug.LogWarning("¡ATENCIÓN! Ningún botón elegible. La máquina elegirá cualquiera por fallback.");
                }
                
                
                int newIndex;

                if (eligibleIndexes.Count == 0)
                {
                    do
                    {
                        newIndex = Random.Range(0, goalButtons.Length);
                    } while (newIndex == currentMachineIndex);
                }
                else
                {
                    do
                    {
                        int randomIndexInList = Random.Range(0, eligibleIndexes.Count);
                        newIndex = eligibleIndexes[randomIndexInList];
                    } while (newIndex == currentMachineIndex);
                }
                
                currentMachineIndex = newIndex;
                UpdateButtonColors();
                GameEvents.MachineButtonChanged(currentMachineIndex);
                Debug.Log("Difficult speed " + GameManager.Instance.difficultSpeed);
            }
            
            yield return new WaitForSeconds(GameManager.Instance.difficultSpeed);
        }
    }
    
    private IEnumerator HamdlePlayerClick(int index)
    {
        machineActive = false;
        blockPanel.SetActive(true);
        gloves.SetActive(false);
        glovesSave.SetActive(false);
        ball.SetActive(false);
        
        bool saved = (index == currentMachineIndex);

        if (saved)
        {
            glovesSave.transform.position = goalButtons[index].transform.position;
            glovesSave.SetActive(true);
            
            ball.transform.position = goalButtons[index].transform.position;
            ball.SetActive(true);
        }
        else
        {
            glovesSave.transform.position = goalButtons[index].transform.position;
            glovesSave.SetActive(true);
            
            ball.transform.position = goalButtons[currentMachineIndex].transform.position;
            ball.SetActive(true);
        }
        
        GameEvents.RoundResult(saved);
        
        yield return new WaitForSeconds(2f);
        
        blockPanel.SetActive(false);
        gloves.SetActive(true);
        machineActive = true;
        glovesSave.SetActive(false);
        ball.SetActive(false);
    }

    private void UpdateButtonColors()
    {
        for (int i = 0; i < goalButtons.Length; i++)
        {
            var colors = goalButtons[i].colors;
            colors.normalColor = (i == currentMachineIndex) ? Color.red : Color.white;
            colors.highlightedColor = colors.normalColor;
            colors.selectedColor = colors.normalColor;
            goalButtons[i].colors = colors;
        }
    }
}
