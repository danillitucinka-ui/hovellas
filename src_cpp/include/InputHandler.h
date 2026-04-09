#ifndef INPUT_HANDLER_H
#define INPUT_HANDLER_H

#include <raylib.h>

class InputHandler {
private:
    bool inDialogMode = false;

public:
    void Update3DControls(Vector3& playerPos, Camera& camera);
    void SetDialogMode(bool mode);
    bool IsInDialogMode() { return inDialogMode; }
};

#endif // INPUT_HANDLER_H