#include "raylib.h"
#include <iostream>
#include <thread> // Для многопоточности
using namespace std;

// Определение локаций
enum Location {
    OFFICE,
    LABORATORY,
    APARTMENT
};

// Глобальные переменные для игры
Location currentLocation = OFFICE;
float gameTime = 7200.0f; // 2 часа в секундах

// Функция для отрисовки текущей локации
void DrawLocation(Location loc) {
    BeginDrawing();
    ClearBackground(RAYWHITE);

    switch (loc) {
        case OFFICE:
            DrawText("Офис - место работы инженера", 10, 10, 20, BLACK);
            // Здесь добавить 3D модели и объекты офиса
            break;
        case LABORATORY:
            DrawText("Лаборатория - центр исследований", 10, 10, 20, BLACK);
            // Здесь добавить 3D модели лаборатории
            break;
        case APARTMENT:
            DrawText("Квартира - личное пространство", 10, 10, 20, BLACK);
            // Здесь добавить 3D модели квартиры
            break;
    }

    // Отображение времени
    DrawText(TextFormat("Время: %.0f сек", gameTime), 10, 50, 20, RED);

    EndDrawing();
}

// Функция для обработки ввода и смены локаций
void HandleInput() {
    if (IsKeyPressed(KEY_ONE)) currentLocation = OFFICE;
    if (IsKeyPressed(KEY_TWO)) currentLocation = LABORATORY;
    if (IsKeyPressed(KEY_THREE)) currentLocation = APARTMENT;

    // Здесь добавить обработку кликов по объектам с raycasting
}

// Основной игровой цикл
int main() {
    // Инициализация Raylib
    InitWindow(800, 600, "The Glass Paradox");
    SetTargetFPS(60);

    while (!WindowShouldClose()) {
        // Многопоточность: разделить логику и рендеринг на потоки для оптимизации на i5-12450H
        std::thread logicThread([&]() {
            // Обновление времени
            gameTime -= GetFrameTime();
            if (gameTime <= 0) {
                // Конец игры
                return;
            }
            // Обработка ввода
            HandleInput();
        });

        std::thread renderThread([&]() {
            // Отрисовка
            DrawLocation(currentLocation);
        });

        logicThread.join();
        renderThread.join();
    }

    CloseWindow();
    return 0;
}