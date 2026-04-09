#ifndef GAME_STATE_H
#define GAME_STATE_H

struct GameState {
    int suspect_guilt;
    bool clue_found;
    int player_reputation;
};

#endif // GAME_STATE_H