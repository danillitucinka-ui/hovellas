#ifndef RAYCASTSYSTEM_H
#define RAYCASTSYSTEM_H

#include "raylib.h"
#include <vector>
#include <string>

// Структура для 3D объекта
struct GameObject {
    BoundingBox bbox;
    std::string id;
    bool isActive; // Активная улика для подсветки
};

// Система рейкастинга
class RaycastSystem {
private:
    std::vector<GameObject> objects;

public:
    // Добавить объект
    void AddObject(BoundingBox bbox, std::string id, bool active = false) {
        objects.push_back({bbox, id, active});
    }

    // Выполнить рейкастинг и вернуть ID объекта под курсором
    std::string Raycast(Vector2 mousePos, Camera camera) {
        Ray ray = GetMouseRay(mousePos, camera);
        for (auto& obj : objects) {
            if (CheckCollisionRayBox(ray, obj.bbox)) {
                return obj.id;
            }
        }
        return "";
    }

    // Подсветка контура для активных улик
    void DrawOutlineEffect() {
        for (auto& obj : objects) {
            if (obj.isActive) {
                // Простая подсветка: нарисовать bounding box в желтом
                DrawBoundingBox(obj.bbox, YELLOW);
            }
        }
    }

    // Установить активность объекта
    void SetActive(std::string id, bool active) {
        for (auto& obj : objects) {
            if (obj.id == id) {
                obj.isActive = active;
            }
        }
    }
};

#endif // RAYCASTSYSTEM_H