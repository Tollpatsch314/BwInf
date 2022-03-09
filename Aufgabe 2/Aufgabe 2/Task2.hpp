#pragma once
#include <stdint.h>
#include <string>
#include <random>
#include <time.h>	// temporarily

enum class Operations : char { Addition = '+', Subtraction = '-', Multiplication = '*', Division = '/', None };

//#pragma pack (push, 1)
struct OpNode {

public:

	// structur of each element from "values": 0bTtDDDDDD
	// T ... type of the operation
	// t ... only for the first element, discripe the operation-type between the nodes (Addition/Subtraction)
	// D ... this is the space for the digits (only the second nibble is needed 0-F)
	// --------------------------------------------------------------------------------
	// ### types ###
	// the first element discripe the type of the node:
	//   1 ==> Addition/Subtraction, 0 ==> Multiplication/Division
	// the next elements discripe the operations between the elements
	//   Addition/Subtraction: 1 ==> Addition, 0 ==> Subtraction
	//   Multiplication/Division: 1 ==> Multiplication, 0 ==> Division
	// --------------------------------------------------------------------------------
	// ### getting values ###
	// T: value & 0b10000000
	// D: value & 0b01111111
	// ### setting values ###
	// if type should be true: value = 0x80 OR value
	// else: value = value & 0b01111111
	// --------------------------------------------------------------------------------
	// important: value < 128
	uint8_t* values = nullptr;
	uint8_t num_values = 0;

	int calc();
};
//#pragma pack (pop)

struct ArithTask {
	OpNode* nodes = nullptr;
	uint8_t num_nodes = 0;

	//~ArithTask();
	int calc();
	std::string content();
};

ArithTask gen_task(uint8_t size);

std::string gen_arithmetic_task(uint8_t max);