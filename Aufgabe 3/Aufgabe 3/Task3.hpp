#pragma once
#include <stdint.h>
#include <intrin0.inl.h>	// __popcnt16

// TODO: Mögliche Optimierung, indem die differenz ausgelagert wird
// TODO: max(uint8_t* add, uint8_t* del) ist eventuell Optimierbar
bool recursive_transfer(uint8_t* arr, uint8_t size_arr, uint16_t steps, int8_t diff = 0);
uint16_t getRequiredStepCount(uint16_t steps);
uint64_t getRecursionCalls();
void resetStat();

//extern uint8_t rods_bitmap[];