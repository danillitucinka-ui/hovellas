#ifndef GAMESTATEMANAGER_H
#define GAMESTATEMANAGER_H

// Определение состояний игры
enum GameState {
    EXPLORATION,  // Бродим по 3D
    INTERROGATION, // Режим допроса 2D/UI
    DEDUCTION     // Экран сборки улик
};

// Менеджер состояний игры
class GameStateManager {
private:
    GameState currentState = EXPLORATION;

public:
    // Получить текущее состояние
    GameState GetCurrentState() {
        return currentState;
    }

    // Переключить состояние
    void SetState(GameState newState) {
        currentState = newState;
    }

    // Обновить логику в зависимости от состояния
    void Update() {
        switch (currentState) {
            case EXPLORATION:
                // Логика исследования: перемещение, взаимодействие с объектами
                break;
            case INTERROGATION:
                // Логика допроса: диалоги с NPC
                break;
            case DEDUCTION:
                // Логика дедукции: соединение улик
                break;
        }
    }

    // Отрисовка в зависимости от состояния
    void Draw() {
        switch (currentState) {
            case EXPLORATION:
                // Отрисовка 3D сцены
                break;
            case INTERROGATION:
                // Отрисовка UI диалога
                break;
            case DEDUCTION:
                // Отрисовка доски улик
                break;
        }
    }
};

#endif // GAMESTATEMANAGER_H