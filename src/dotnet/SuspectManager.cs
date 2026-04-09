using System;
using System.Collections.Generic;

// Класс для подозреваемого
public class Suspect
{
    public string Name { get; set; }
    public List<string> Secrets { get; set; }
    public bool IsGuilty { get; set; }
    public string DialogueTree { get; set; } // JSON или простой текст для дерева диалогов
    public int Trust { get; set; } // Шкала доверия 0-100
    public int SuspicionIndex { get; set; } // Индекс подозрительности 0-100

    public Suspect(string name, List<string> secrets, bool guilty, string dialogue, int trust = 50, int suspicion = 50)
    {
        Name = name;
        Secrets = secrets;
        IsGuilty = guilty;
        DialogueTree = dialogue;
        Trust = trust;
        SuspicionIndex = suspicion;
    }
}

// Менеджер подозреваемых
public class SuspectManager
{
    private List<Suspect> suspects;

    public SuspectManager()
    {
        suspects = new List<Suspect>();
        InitializeSuspects();
    }

    // Инициализация 13 подозреваемых
    private void InitializeSuspects()
    {
        suspects.Add(new Suspect("Алексей Иванов", new List<string> { "Был в лаборатории ночью", "Знает о проекте ИИ" }, false, "Диалог для Алексея...", 50, 40));
        suspects.Add(new Suspect("Мария Петрова", new List<string> { "Имела доступ к квартире", "Ревновала к инженеру" }, false, "Диалог для Марии...", 50, 45));
        suspects.Add(new Suspect("Дмитрий Сидоров", new List<string> { "Работал над проектом", "Имеет мотив" }, true, "Диалог для Дмитрия...", 50, 80));
        suspects.Add(new Suspect("Елена Кузнецова", new List<string> { "Секрет 1", "Секрет 2" }, false, "Диалог...", 50, 50));
        suspects.Add(new Suspect("Игорь Волков", new List<string> { "Секрет 1", "Секрет 2" }, false, "Диалог...", 50, 55));
        suspects.Add(new Suspect("Ольга Новикова", new List<string> { "Секрет 1", "Секрет 2" }, false, "Диалог...", 50, 60));
        suspects.Add(new Suspect("Павел Морозов", new List<string> { "Секрет 1", "Секрет 2" }, false, "Диалог...", 50, 35));
        suspects.Add(new Suspect("Светлана Романова", new List<string> { "Секрет 1", "Секрет 2" }, false, "Диалог...", 50, 50));
        suspects.Add(new Suspect("Андрей Ковалев", new List<string> { "Секрет 1", "Секрет 2" }, false, "Диалог...", 50, 65));
        suspects.Add(new Suspect("Татьяна Смирнова", new List<string> { "Секрет 1", "Секрет 2" }, false, "Диалог...", 50, 40));
        suspects.Add(new Suspect("Владимир Попов", new List<string> { "Секрет 1", "Секрет 2" }, false, "Диалог...", 50, 70));
        suspects.Add(new Suspect("Наталья Фролова", new List<string> { "Секрет 1", "Секрет 2" }, false, "Диалог...", 50, 45));
        suspects.Add(new Suspect("Максим Егоров", new List<string> { "Секрет 1", "Секрет 2" }, false, "Диалог...", 50, 55));
    }

    // Получить подозреваемого по имени
    public Suspect GetSuspect(string name)
    {
        return suspects.Find(s => s.Name == name);
    }

    // Получить всех подозреваемых
    public List<Suspect> GetAllSuspects()
    {
        return suspects;
    }

    // Обновить состояние подозреваемого
    public void UpdateSuspect(Suspect suspect)
    {
        // Логика обновления
    }

    // Логировать решение игрока в базу данных
    public void LogDecision(string suspectName, string decision, int trustChange)
    {
        // Простая логика: записать в файл или DB
        System.IO.File.AppendAllText("decisions.log", $"{DateTime.Now}: {suspectName} - {decision} - Trust change: {trustChange}\n");
    }
}