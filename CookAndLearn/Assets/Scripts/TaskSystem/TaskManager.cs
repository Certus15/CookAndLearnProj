using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<Task> tasks;
    public int currentTaskIndex;
    public TaskUI taskUI;


    public void CompleteTask(string recipe)
    {
        if (tasks[currentTaskIndex].recipeToCook == recipe)
        {
            tasks[currentTaskIndex].isCompleted = true;
            Debug.Log(tasks[currentTaskIndex].taskName + " выполнено!");
            if (currentTaskIndex < tasks.Count - 1)
            {
                DisplayNextTask();
            }else
            {
                taskUI.taskText.text = "Все задачи выполнены!";
                taskUI.descText.text = "Перетащи готовое блюдо на тарелку!";
                taskUI.engVoiceBut.gameObject.SetActive(false);
                taskUI.rusVoiceBut.gameObject.SetActive(false);
            }
        }
    }

    public void Start()
    {
        taskUI.taskText.text = tasks[0].taskName;
        taskUI.descText.text = tasks[0].taskDescription;
    }

    public void DisplayNextTask()
    {
        currentTaskIndex++;
        if (currentTaskIndex < tasks.Count)
        {
            Task nextTask = tasks[currentTaskIndex];
            taskUI.taskText.text = nextTask.taskName;
            taskUI.descText.text = nextTask.taskDescription;
            taskUI.taskVoicePlayer.clip = tasks[currentTaskIndex].englishClip;
            taskUI.taskVoicePlayer.Play();
        }
    }

    public void PlayRussianVoiceLine()
    {
        taskUI.taskVoicePlayer.clip = tasks[currentTaskIndex].russianClip;
        taskUI.taskVoicePlayer.Play();
    }
    public void PlayEnglishVoiceLine()
    {
        taskUI.taskVoicePlayer.clip = tasks[currentTaskIndex].englishClip;
        taskUI.taskVoicePlayer.Play();
    }
}
