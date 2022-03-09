#include "Task2.hpp"

#define NUM_MIN 1
#define NUM_MAX 9

#define OPERATOR_MIN 1
#define OPERATOR_MAX 9

std::random_device g_rand_device;
std::default_random_engine g_generator = std::default_random_engine(g_rand_device());
std::uniform_int_distribution<int> g_num_distr(NUM_MIN, NUM_MAX);
std::uniform_int_distribution<int> g_operator_distr(OPERATOR_MIN, OPERATOR_MAX);

int OpNode::calc() {
	int ret = (*this->values & 0x0F);

	// 0b1??????? ==> Addition/Subtraction
	if (*this->values & 0b10000000) {
		for (uint8_t t = 1; t < this->num_values; t++) {
			if (this->values[t] & 0b10000000) ret += this->values[t] & 0x0F;	// 0b1??????? ==> Addition
			else ret -= this->values[t] & 0x0F;									// 0b0??????? ==> Subtraction
		}

		return ret;
	}

	// 0b0??????? ==> Multiplication/Division
	for (uint8_t t = 1; t < this->num_values; t++) {
		if (this->values[t] & 0b10000000) ret *= this->values[t] & 0x0F;		// 0b1??????? ==> Multiplication
		else ret /= this->values[t] & 0x0F;										// 0b0??????? ==> Division
	}

	return ret;
}

int ArithTask::calc() {

	int ret = this->nodes->calc();	// should be the first element

	for (uint8_t t = 1; t < this->num_nodes; t++) {
		if (*(this->nodes[t].values) & 0b01000000) ret += this->nodes[t].calc();	// 0b?1?????? ==> Addition
		else ret -= this->nodes[t].calc();											// 0b?0?????? ==> Subtraction
	}

	return ret;
}

std::string ArithTask::content() {
	std::string ret = "";
	bool addOrSub;
	
	for (uint8_t t = 0; t < this->num_nodes; t++)
	{
		addOrSub = *this->nodes[t].values & 0b10000000;
		if (t != 0) {
			if (*this->nodes[t].values & 0b01000000) ret += " + ";
			else ret += " - ";
		}

		ret += std::to_string(*this->nodes[t].values & 0x0F);

		for (uint8_t v = 1; v < this->nodes[t].num_values; v++) {
			ret += " ";
			ret += (this->nodes[t].values[v] & 0b10000000 != 0 ? (addOrSub ? '+' : '*') : (addOrSub ? '-' : '/'));
			ret += " ";
			ret += std::to_string(this->nodes[t].values[v] & 0x0F);
		}
	}

	return ret;
}

ArithTask gen_task(uint8_t size) {

	ArithTask* aTask = new ArithTask();
	srand(time(NULL));

	// gen operator
	uint8_t* op = new uint8_t[size];
	op[size - 1] = 5;
	aTask->num_nodes = 1;
	op[0] = rand() % 4;
	bool addOrSub = op[0] < 2;
	bool addition = false;
	
	for (uint8_t t = 1; t < size - 1; t++) 
	{
		op[t] = rand() % 4;

		if (!addOrSub && op[t] < 2) {
			aTask->num_nodes++;
			addOrSub = true;
		} else if (addOrSub && op[t] > 1) {
			aTask->num_nodes++;
			addOrSub = false;
		}
	}

	aTask->nodes = new OpNode[aTask->num_nodes]();
	addOrSub = op[0] < 2;

	for (uint8_t t = 0; t < aTask->num_nodes; t++)
	{
		aTask->nodes[t].values = op;

		while (true) // switch the pointer to the next operators
		{
			if ((!addOrSub && *op < 2) || (addOrSub && *op >= 2)) {
				addOrSub = !addOrSub;
				break;
			}

			if (*(op++) == 5) {
				op++;
				break;
			}
		}

		aTask->nodes[t].num_values = op - aTask->nodes[t].values;

		// TODO: replace the rand() with the rigth values and a better random-function
		size = (1 + rand() % 9) | (aTask->nodes[t].values[0] < 2 ? 0b10000000 : 0b00000000) | (t != 0 && addition ? 0b01000000 : 0b01000000);
		addition = aTask->nodes[t].values[0] == 0 || aTask->nodes[t].values[0] == 2;
		aTask->nodes[t].values[0] = size;

		for (uint8_t v = 1; v < aTask->nodes[t].num_values - 1; v++) {
			size = (1 + rand() % 9) | (addition ? 0b10000000 : 0b00000000);
			addition = aTask->nodes[t].values[v] == 0 || aTask->nodes[t].values[v] == 2;
			aTask->nodes[t].values[v] = size;
		}

		size = (1 + rand() % 9) | (addition ? 0b10000000 : 0b00000000);
		addition = aTask->nodes[t].values[aTask->nodes[t].num_values - 1] == 0;
		aTask->nodes[t].values[aTask->nodes[t].num_values - 1] = size;
	}

	//for (uint8_t t = 0; t < size; t++) op[t] = 1 + rand() % 9;	// 1 <= random number <= 9
	return *aTask;
}