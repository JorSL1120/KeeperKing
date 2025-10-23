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

    [Header("Visual Elements")]
    public GameObject gloves;
    public GameObject glovesSave;
    public GameObject ball;
    
    [Header("Panel block")]
    public GameObject blockPanel;

    private int currentMachineIndex = -1;
    private bool machineActive = true;
    private Coroutine machineRoutine;
    
    private float hoverCooldown = 2f;
    private bool[] excludeButton;
    private float[] hoverTime;
    #endregion

    private void Start()
    {
        blockPanel.SetActive(false);
        glovesSave.SetActive(false);
        ball.SetActive(false);
        
        excludeButton = new bool[goalButtons.Length];
        hoverTime = new float[goalButtons.Length];
        
        for (int i = 0; i < goalButtons.Length; i++)
        {
            int index = i;
            goalButtons[i].onClick.AddListener(() => OnButtonClicked(index));
            var trigger = goalButtons[i].gameObject.AddComponent<EventTrigger>();
            var entryEnter = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
            entryEnter.callback.AddListener((_) => StartHover(index));
            trigger.triggers.Add(entryEnter);
            
            var entryExit = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
            entryExit.callback.AddListener((_) => StopHover(index));
            trigger.triggers.Add(entryExit);
        }
        
        machineRoutine = StartCoroutine(MachineMoveRoutine());
    }

    private void Update()
    {
        for (int i = 0; i < goalButtons.Length; i++)
        {
            if (hoverTime[i] >= 0f)
            {
                hoverTime[i] += Time.deltaTime;
                if (hoverTime[i] >= hoverCooldown) excludeButton[i] = true;
            }
        }
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
                List<int> candidates = new List<int>();
                for (int i = 0; i < goalButtons.Length; i++)
                {
                    if (!excludeButton[i]) candidates.Add(i);
                }

                if (candidates.Count > 0)
                {
                    int newIndex;
                    if (candidates.Count == 1)
                        newIndex = candidates[0];
                    else
                    {
                        do
                        {
                           newIndex = candidates[Random.Range(0, candidates.Count)]; 
                        } while (newIndex == currentMachineIndex);
                    }
                    currentMachineIndex = newIndex;
                    UpdateButtonColors();
                    GameEvents.MachineButtonChanged(currentMachineIndex);
                    Debug.Log("Difficult speed " + GameManager.Instance.difficultSpeed);
                }
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

    private void StartHover(int index)
    {
        hoverTime[index] = 0f;
    }

    private void StopHover(int index)
    {
        hoverTime[index] = -1f;
        excludeButton[index] = false;
    }
}
