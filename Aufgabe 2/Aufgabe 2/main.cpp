#define CHRONOMETER

#include <cstdint>
#include <string>
#include <vector>
#include <iostream>
#include <fstream>

#ifdef CHRONOMETER
#include <chrono>
#endif

#define OPTYPE_ADD 0b0000'0000
#define OPTYPE_SUB 0b0100'0000
#define OPTYPE_MUL 0b1000'0000
#define OPTYPE_DIV 0b1100'0000

#define NUMBER_MASK 0x0F
#define OP_MASK 0xF0

uint8_t g_count;

class ATask {
	int conclusion;
	uint8_t* task;
	uint8_t task_count;
	bool valid;
	
public:
	ATask(uint8_t part_count);
	ATask(uint8_t part_count, uint8_t first_num);
	~ATask();
	
	bool is_valid();
	bool is_conclusion_valid();
	void calc();
	std::string str();
	
	//const uint8_t& operator[](uint8_t) const;
	uint8_t& operator[](uint8_t) const;
};

ATask::ATask(uint8_t part_count)
 : task_count(part_count), conclusion(0), valid(true) {
	this->task = new uint8_t[this->task_count];
}

ATask::ATask(uint8_t part_count, uint8_t first_num)
 : task_count(part_count), conclusion(0), valid(true) {
	this->task = new uint8_t[this->task_count];
	*this->task = first_num;
}

ATask::~ATask() { delete[] this->task; }

bool ATask::is_valid() {
	
}

bool ATask::is_conclusion_valid() {
	return this->conclusion > 0 && this->is_valid();
}

// Structur:
// +1-2*3+4-4/2

void ATask::calc() {
	this->conclusion = 0;
	bool op_branch = false; // = add/sub
	int tmp = 0;
	for (uint8_t t = 0; t < this->task_count; t++) {
		if (this->task[t] & OPTYPE_MUL /* MUL/DIV */) {

		}
		else {
			if (op_branch) op_branch = false;
			else tmp = this->task[t] & NUMBER_MASK;
			this->conclusion += (this->task[t] & OPTYPE_SUB) ? tmp * -1 : tmp;
			tmp = 0;
		}
	}
}

uint8_t& ATask::operator[](uint8_t i) const { return this->task[i]; }
 
ATask& genRATask(uint8_t count, uint16_t seed) {
	if(count <= 1) return *(new ATask(g_count, seed % 8 + 2));
	ATask& k = genRATask(count--, seed + 2);
	
	do {
		seed++;
		uint8_t operation = (seed % 4) << 6;
		k[count] = operation | (operation >= OPTYPE_MUL ? (seed % 8) + 2 : (seed % 9) + 1);
	} while(!k.is_valid());

	return k;
}
 
int main(int argc, char** argv) {
	if(argv == NULL) return -1; argv++;
	if(argv == NULL) return -1;
	int count = std::atoi(*argv);
	
	ATask& task = genRATask(g_count = count, 42);
	return 0;
}
