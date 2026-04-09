#ifndef EVENTMANAGER_H
#define EVENTMANAGER_H

#include <functional>
#include <vector>
#include <string>

// Определение типов событий
enum EventType {
    FLASH_DRIVE_FOUND,
    APPROACH_COMPUTER,
    DIALOGUE_TRIGGER
};

// Структура события
struct GameEvent {
    EventType type;
    std::string data; // Дополнительные данные, например ID объекта
};

// Менеджер событий
class EventManager {
private:
    std::vector<std::function<void(GameEvent)>> listeners;
    bool hasFlashDrive = false; // Флаг наличия флешки

public:
    // Регистрация слушателя
    void AddListener(std::function<void(GameEvent)> listener) {
        listeners.push_back(listener);
    }

    // Триггер события
    void TriggerEvent(GameEvent event) {
        for (auto& listener : listeners) {
            listener(event);
        }
    }

    // Специальный триггер для флешки
    void OnTrigger(std::string objectID) {
        if (objectID == "computer" && hasFlashDrive) {
            // Вызов .NET окна взлома (здесь P/Invoke или интерфейс)
            // Например: OpenHackWindowInDotNet();
            TriggerEvent({FLASH_DRIVE_FOUND, "hack_window"});
        }
    }

    // Установить флаг флешки
    void SetFlashDrive(bool value) {
        hasFlashDrive = value;
    }
};

#endif // EVENTMANAGER_H