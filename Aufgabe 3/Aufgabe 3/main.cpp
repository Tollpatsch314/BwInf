// TODO: Dokumentation
#define DEBUG

#include <iostream>
#include <fstream>
#include <string>
#include <windows.h>

#ifdef DEBUG
#define CHRONOMETER
#endif // DEBUG

#ifdef CHRONOMETER
#include <chrono>
std::chrono::high_resolution_clock::time_point chr_start;
std::chrono::high_resolution_clock::duration chr_time;
uint16_t chr_min, chr_sec, chr_mili_sec, chr_micro_sec;
#endif // CHRONOMETER

#include "Task3.hpp"

uint8_t* readFile() {
	// TODO: Einlesen der Werte, wenn diese auf https://bwinf.de/bundeswettbewerb/40/2/ verfügbar sind
	return nullptr;
}

void handleHexNumInput() {

	std::cout << "Hex-Zahl: ";
	std::string num = "";
	uint16_t steps;
	std::getline(std::cin, num);

	uint8_t count = num.length();
	uint8_t* digits = new uint8_t[count];
	for (uint8_t t = 0; t < count; t++) {
		digits[t] = (uint8_t)std::tolower(num[t]);
		digits[t] -= (digits[t] < 'a' - 1 ? '0' : 'a' - 10);
	}

	std::cout << "Anzahl maximale Umlegungen: ";

	std::getline(std::cin, num);
	steps = std::atoi(num.c_str());

#ifdef CHRONOMETER
	std::cout << "\nBerechne f\x81r Hex-Zahl \"";
	for (uint8_t t = 0; t < count; t++) std::cout << std::hex << (int)digits[t];
	std::cout << "\" mit " << std::dec <<  steps << " Umlegungen . . . ";
	resetStat();
	chr_start = std::chrono::high_resolution_clock::now();

	recursive_transfer(digits, count, steps);

	chr_time = std::chrono::high_resolution_clock::now() - chr_start;

	chr_min = std::chrono::duration_cast<std::chrono::minutes>(chr_time).count(),
	chr_sec = std::chrono::duration_cast<std::chrono::seconds>(chr_time -= std::chrono::minutes(chr_min)).count(),
	chr_mili_sec = std::chrono::duration_cast<std::chrono::milliseconds>(chr_time -= std::chrono::seconds(chr_sec)).count(),
	chr_micro_sec = std::chrono::duration_cast<std::chrono::microseconds>(chr_time -= std::chrono::milliseconds(chr_mili_sec)).count();

	std::cout << "Fertig!\n";
	std::cout << "\nben\224tigte Berechnungszeit: " << (chr_min != 0 ? std::to_string(chr_min) + " min, " : "");
	std::cout << (chr_sec != 0 ? std::to_string(chr_sec) + " s, " : "") << chr_mili_sec << " ms, " << chr_micro_sec << " \xE6s" << std::endl;
	std::cout << "Rekursionsaufrufe: " << getRecursionCalls() << "\nUmlegungen: "  << getRequiredStepCount(steps) << std::endl;

#else
	recursive_transfer(digits, count, steps);
#endif	// CHRONOMETER
	
	std::cout << "\nErgebnis: ";
	for (int i = 0; i < count; i++) std::cout << std::hex << (int)digits[i];
	std::cout << std::endl;

	delete[] digits;
}

__forceinline void header() {
	system("cls");
	HANDLE current = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(current, 0x000F | COMMON_LVB_UNDERSCORE);
	std::cout << "BwInf 2021, Runde 2 - Aufgabe 3: \"Hex-Max\"";
	SetConsoleTextAttribute(current, 0x0000);
	std::cout << "\xDB" << std::endl;
	SetConsoleTextAttribute(current, 0x0007);
	std::cout << "Teilnehmer-ID: ";
	SetConsoleTextAttribute(current, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
	std::cout << "61719";
	SetConsoleTextAttribute(current, 0x0007);
	std::cout << "\n" << std::endl;
}

int main()
{
	std::string tmp_in = "";
	system("title BwInf 2021, Runde 2 - Aufgabe 3: \"Hex-Max\"");

	while (true)
	{
		header();
		handleHexNumInput();

ask:
		std::cout << "Beenden? [J/N] ";
		std::getline(std::cin, tmp_in);

		if (tmp_in == "J" || tmp_in == "j") return 0;
		else if (!(tmp_in == "N" || tmp_in == "n")) goto ask;
	}
}