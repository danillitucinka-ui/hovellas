using System;
using System.Collections.Generic;

// Класс для анализа улик
public class EvidenceAnalyzer
{
    private Dictionary<string, string> evidenceDescriptions;

    public EvidenceAnalyzer()
    {
        evidenceDescriptions = new Dictionary<string, string>();
        InitializeDescriptions();
    }

    // Инициализация описаний улик
    private void InitializeDescriptions()
    {
        evidenceDescriptions["glass_fragment"] = "Разбитое стекло из лаборатории. Анализ показывает следы химических веществ, связанных с проектом ИИ.";
        evidenceDescriptions["security_log"] = "Журнал безопасности показывает вход в здание в нерабочее время. Подозреваемый: Дмитрий Сидоров.";
        evidenceDescriptions["personal_note"] = "Личная записка инженера с намеком на угрозу. 'Не доверяй коллегам в проекте.'";
        evidenceDescriptions["fingerprint"] = "Отпечатки пальцев на клавиатуре. Соответствуют Марии Петровой.";
        // Добавить больше улик
    }

    // Функция анализа улики
    public string AnalyzeEvidence(string objectID)
    {
        if (evidenceDescriptions.ContainsKey(objectID))
        {
            return evidenceDescriptions[objectID];
        }
        else
        {
            return "Улика не найдена или не распознана.";
        }
    }

    // Добавить новую улику
    public void AddEvidence(string id, string description)
    {
        evidenceDescriptions[id] = description;
    }
}