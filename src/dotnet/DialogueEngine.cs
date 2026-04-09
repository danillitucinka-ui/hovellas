using System;
using System.Collections.Generic;

// Двигатель диалогов
public class DialogueEngine
{
    private SuspectManager suspectManager;

    public DialogueEngine(SuspectManager manager)
    {
        suspectManager = manager;
    }

    // Начать диалог с NPC
    public string StartDialogue(string suspectName, string playerChoice = "")
    {
        Suspect suspect = suspectManager.GetSuspect(suspectName);
        if (suspect == null) return "Подозреваемый не найден.";

        // Логика на основе Trust
        if (suspect.Trust < 30)
        {
            return $"{suspect.Name}: Я не буду с вами разговаривать. Уходите!";
        }
        else if (suspect.Trust > 70)
        {
            // Открыть секретную ветку
            return $"{suspect.Name}: Хорошо, я расскажу правду. {suspect.Secrets[0]}"; // Пример
        }
        else
        {
            // Стандартный диалог
            return $"{suspect.Name}: {suspect.DialogueTree}";
        }
    }

    // Обновить Trust на основе выбора игрока
    public void UpdateTrust(string suspectName, int change, string decision = "Unknown")
    {
        Suspect suspect = suspectManager.GetSuspect(suspectName);
        if (suspect != null)
        {
            suspect.Trust = Math.Clamp(suspect.Trust + change, 0, 100);
            suspectManager.LogDecision(suspectName, decision, change);
        }
    }

    // Получить текущий Trust
    public int GetTrust(string suspectName)
    {
        Suspect suspect = suspectManager.GetSuspect(suspectName);
        return suspect?.Trust ?? 0;
    }
}