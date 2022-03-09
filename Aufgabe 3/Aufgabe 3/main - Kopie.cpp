#include <iostream>
#include <fstream>
#include <string>

#define CHRONOMETER
#define DEBUG

#ifdef CHRONOMETER
#include <chrono>
std::chrono::high_resolution_clock::time_point chr_start;
#endif // CHRONOMETER

uint8_t count_rods[] = {
	/*0h*/ 6, /*1h*/ 2, /*2h*/ 5, /*3h*/ 5, /*4h*/ 4, /*5h*/ 5, /*6h*/ 6, /*7h*/ 3,
	/*8h*/ 7, /*9h*/ 6, /*Ah*/ 6, /*Bh*/ 5, /*Ch*/ 4, /*Dh*/ 5, /*Eh*/ 5, /*Fh*/ 4
};

// Bsp.:
//      _  0b10000000
// XOR  _| 0b00110000
// XOR |_  0b00001010
//  =      0b10111010

// [0] => oben, [1] => oben links, [2] => oben rechts, [3] => mitte,
// [4] => unten links, [5] => unten rechts, [6] => unten, [7] => 0
uint8_t rods_bitmap[] = {
	/*0h 238*/ 0b11101110, /*1h 036*/ 0b00100100, /*2h 186*/ 0b10111010, /*3h 182*/ 0b10110110,
	/*4h 116*/ 0b01110100, /*5h 214*/ 0b11010110, /*6h 222*/ 0b11011110, /*7h 164*/ 0b10100100,
	/*8h 254*/ 0b11111110, /*9h 246*/ 0b11110110, /*Ah 252*/ 0b11111100, /*Bh 094*/ 0b01011110,
	/*Ch 202*/ 0b11001010, /*Dh 062*/ 0b00111110, /*Eh 218*/ 0b11011010, /*Fh 216*/ 0b11011000
};

__forceinline uint8_t at(uint8_t* rods, uint8_t index) {
	return (0x80 >> index) & *rods;	// gibt 0 zurück, wenn die Stelle 0 ist
}

__forceinline void set(uint8_t* rods, uint8_t index) {
	*rods &= ~(0x80 >> index);
}

__forceinline void unset(uint8_t* rods, uint8_t index) {
	*rods |= 0x80 >> index;
}

/*__forceinline void set(uint8_t* rod, uint8_t index, bool val) {
	if (val) *rod &= ~(0x80 >> index);
	else *rod |= 0x80 >> index;
}*/

__forceinline uint8_t count(uint8_t* rods) {
	// TODO: Optimierung des Zählens der gesetzten Bits.
	uint8_t ret; ret ^= ret;
	for (uint8_t t = t ^ t; t < 8; t++) if (at(rods, t)) ret++;
	return ret;
}

#ifdef DEBUG
void print(uint8_t* rods) {
	std::cout << "     0123\n";
	std::cout << "[0]:  " << (at(rods, 0) ? '_' : ' ') << "\n[1]: ";
	std::cout << (at(rods, 1) ? '|' : ' ') << (at(rods, 3) ? '_' : ' ') << (at(rods, 2) ? '|' : ' ') << "\n[2]: ";
	std::cout << (at(rods, 4) ? '|' : ' ') << (at(rods, 6) ? '_' : ' ') << (at(rods, 5) ? '|' : ' ') << "\n" << std::endl;
}
#endif // DEBUG

__forceinline void read(uint8_t* p_digits, uint16_t size) {
	// TODO: Einlesen der Werte (sind noch nicht auf der BwInf-Web-Site).
}

// in-code-definition erfreut den Stack (müsste ansonnsten rekursiv übergeben werden)
uint8_t* gp_digits;
uint8_t* g_digits;
uint16_t g_steps;
uint16_t gc_steps;

//void recursive_search(uint16_t pos, uint16_t c_steps, uint8_t rods) {
//
//	for (uint8_t digit = 0x0F; digit > gp_digits[pos]; digit--)
//	{
//		uint8_t del, add, changes = g_digits[pos] ^ rods_bitmap[digit];
//		int8_t change_count;
//		del = changes & g_digits[pos];
//		add = changes & rods_bitmap[digit];
//		change_count = count(&add) - count(&del);
//
//		if (change_count == 0 && c_steps + add <= g_steps) {
//			gc_steps += add;
//			g_digits[pos] = rods_bitmap[digit];
//			gp_digits[pos] = digit;
//			std::cout << "";
//			return;
//		}
//		else {
//			recursive_search(pos + 1, c_steps, rods);
//			std::cout << "|etwas anderes|";
//		}
//	}
//
//	return;
//}

__forceinline void calc(uint8_t* p_digits, uint16_t count_digits, uint16_t steps) {

	uint8_t* digits = new uint8_t[count_digits];
	gp_digits = p_digits;
	g_digits = digits;
	g_steps = steps;
	uint16_t sum = 0;

	for (uint16_t t = 0; t < count_digits; t++) {
		sum += count_rods[p_digits[t]];
		digits[t] = rods_bitmap[p_digits[t]];
	}

	// findet Bestes
	gc_steps ^= gc_steps;
	for(uint16_t pos = 0; pos < count_digits; pos++)
	{
		if (p_digits[pos] == 0x0F) continue;

		//recursive_search(pos, gc_steps);

		for (uint8_t digit = 0x0F; digit > p_digits[pos]; digit--)
		{
			uint8_t del, add, changes = digits[pos] ^ rods_bitmap[digit];
			int8_t change_count;
			del = changes & digits[pos];
			add = changes & rods_bitmap[digit];
			change_count = count(&add) - count(&del);

			if (change_count == 0 && gc_steps + add <= steps) {
				gc_steps += add;
				digits[pos] = rods_bitmap[digit];
				p_digits[pos] = digit;
				break;
			}
			else {

				// andere Idee:
				// merke dir die restlichen benötigten/zu verteilenden stäbchen und arbeite weiter

				/*for (uint16_t next_index = pos + 1; next_index < count_digits; next_index++) {
					for (uint8_t next_digit = 0x0F; next_digit > p_digits[next_index]; next_digit--) {

					}
				}*/
			}

		}
	}

	std::cout << gc_steps;
	delete[] digits;

	// TODO: last

	/*sum = steps < sum ? steps : sum;

	for (uint16_t t = 0; t < sum; t++) {

	}


	std::cout << "Zahl: \n";
	print(&digits[0]);
	uint8_t del, add, changes = digits[0] ^ rods_bitmap[0x0F];
	del = changes & digits[0]; // weg damit
	add = changes & rods_bitmap[0x0F];			// das brauchen wir
	int8_t tmp = add - del;

	if (tmp == 0) {
		// add Schritte
	}

	std::cout << "weg damit:\n";
	print(&del);

	std::cout << "her damit:\n";
	print(&add);*/
}

int main() {
	std::cout << "Hello BwInf, Hello World!" << std::endl;

	//for (int i = 0; i <= 0xf; i++)print(&rods_bitmap[i]);

#ifdef CHRONOMETER
	chr_start = std::chrono::high_resolution_clock::now();
#endif // CHRONOMETER

	uint8_t digits[] = { 0x4, 0x1, 0x3 };
	calc(digits, 3, 10);

	std::cout << "\n";

	for (int i = 0; i < 3; i++) std::cout << std::hex << i << ": " << std::hex << (int)digits[i] << "\n";

	return 0;
}