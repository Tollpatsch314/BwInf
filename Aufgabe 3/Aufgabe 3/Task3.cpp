#include "Task3.hpp"
#define STEP_DOCUMENTATION

// siehe Dokumentation
// [0] => oben, [1] => oben links, [2] => oben rechts, [3] => mitte,
// [4] => unten links, [5] => unten rechts, [6] => unten, [7] => 0
uint8_t rods_bitmap[] = {
	/*0h 238*/ 0b11101110, /*1h 036*/ 0b00100100, /*2h 186*/ 0b10111010, /*3h 182*/ 0b10110110,
	/*4h 116*/ 0b01110100, /*5h 214*/ 0b11010110, /*6h 222*/ 0b11011110, /*7h 164*/ 0b10100100,
	/*8h 254*/ 0b11111110, /*9h 246*/ 0b11110110, /*Ah 252*/ 0b11111100, /*Bh 094*/ 0b01011110,
	/*Ch 202*/ 0b11001010, /*Dh 062*/ 0b00111110, /*Eh 218*/ 0b11011010, /*Fh 216*/ 0b11011000
};

/*__forceinline uint8_t at(uint8_t* rods, uint8_t index) {
	return (0x80 >> index) & *rods;	// gibt 0 zurück, wenn die Stelle 0 ist
}
__forceinline uint8_t count(uint8_t* rods) {
	uint8_t ret; ret ^= ret;
	for (uint8_t t = t ^ t; t < 8; t++) if (at(rods, t)) ret++;
	return ret;
}*/

__forceinline uint8_t count(uint8_t* rods) {
	return __popcnt16(*rods);
}

__forceinline uint8_t max(uint8_t* add, uint8_t* del) {
	return count(add) < count(del) ? count(del) : count(add);
}

// Dadurch landen die auch nicht auf den Stack, da sie ja immer existieren
uint8_t g_tmp_calc, g_changes, g_add, g_del;
int8_t g_diff;
uint16_t g_stepcounter = 0;
uint64_t g_recCounter = 0;


bool recursive_transfer(uint8_t* arr, uint8_t size_arr, uint16_t steps, int8_t diff)
{
	g_recCounter++;
	if (size_arr == 0 || steps == 0) return false;

	for (uint8_t num = 0x0F; diff ? num > 0 : num > *arr; num--)
	{
		g_changes = rods_bitmap[num] ^ rods_bitmap[*arr];
		g_add = g_changes & rods_bitmap[num],
		g_del = g_changes & rods_bitmap[*arr];
		g_diff = (int8_t)count(&g_add) - (int8_t)count(&g_del);

		if (g_diff + diff == 0) {
			g_tmp_calc = (diff < 0 ? count(&g_add) : count(&g_del)) - diff;
			if (((int16_t)steps - (int16_t)g_tmp_calc) < 0) continue;
			*arr = num;
			goto best_end;	// so wird num auch noch gelöscht, und müllt nicht den Stack zu
		}
		else {
			g_tmp_calc = max(&g_add, &g_del);
			if (((int16_t)steps - (int16_t)g_tmp_calc) < 0) continue;
			if (recursive_transfer(arr + 1, size_arr - 1, steps - g_tmp_calc, g_diff + diff)) {
				*arr = num;
				return true;
			}
			else continue;
		}
	}

	return recursive_transfer(arr + 1, size_arr - 1, steps, diff);

best_end:
	g_stepcounter = steps - g_tmp_calc;
	recursive_transfer(arr + 1, size_arr - 1, steps - g_tmp_calc);
	return true;
}

uint16_t getRequiredStepCount(uint16_t steps) {
	return steps - g_stepcounter;
}

uint64_t getRecursionCalls() {
	return g_recCounter;
}

void resetStat() {
	g_stepcounter ^= g_stepcounter;
	g_recCounter ^= g_recCounter;
}