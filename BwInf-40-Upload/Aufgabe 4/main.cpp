#include <iomanip>
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <tuple>


#define HOUR_TO_MIN(hour)(60 * (hour))

auto simulation0(std::vector<uint32_t> incoming_time, std::vector<uint32_t> work_time) {
	std::vector<uint32_t> waiting_time(incoming_time.size());

	uint32_t current_time = HOUR_TO_MIN(9);
	for (size_t t = 0; t < incoming_time.size(); ++t) {
		if (current_time < incoming_time[t]) current_time = incoming_time[t];
		current_time += work_time[t] + (((current_time - HOUR_TO_MIN(9)) % HOUR_TO_MIN(9) + work_time[t]) / HOUR_TO_MIN(9)) * 16 /* houres */;
		waiting_time[t] = current_time - incoming_time[t];
	}

	return waiting_time;
}

auto simulation1(std::vector<uint32_t> incoming_time, std::vector<uint32_t> work_time) {
	std::vector<uint32_t> waiting_time(incoming_time.size(), 0);

	uint32_t current_time = HOUR_TO_MIN(9);
	for (size_t t = 0; t < incoming_time.size(); ++t) {

		for (size_t t_2 = t; t_2 < incoming_time.size() and incoming_time[t_2] < current_time; ++t_2) {
			if (not waiting_time[t_2] and work_time[t_2] < work_time[t]) t = t_2;
		}

		while (waiting_time[t]) t++;

		if (current_time < incoming_time[t]) current_time = incoming_time[t];
		current_time += work_time[t] + (((current_time - HOUR_TO_MIN(9)) % HOUR_TO_MIN(9) + work_time[t]) / HOUR_TO_MIN(9)) * 16 /* houres */;
		waiting_time[t] = current_time - incoming_time[t];
	}

	return waiting_time;
}

auto simulation2(std::vector<uint32_t> incoming_time, std::vector<uint32_t> work_time) {
	std::vector<uint32_t> waiting_time(incoming_time.size(), 0);

	uint32_t current_time = HOUR_TO_MIN(9); size_t _30min = 0;
	for (size_t t = 0; t < incoming_time.size(); ++t) {

		if (work_time[t] < 30) _30min++;

		for (size_t t_2 = t; t_2 < incoming_time.size() and incoming_time[t_2] < current_time; ++t_2) {
			if (_30min < 4) {
				if (not waiting_time[t_2] and work_time[t_2] < work_time[t]) t = t_2;
			}
			else {
				if (not waiting_time[t_2] and work_time[t_2] > work_time[t]) t = t_2;
				_30min = 0;
			}
		}

		while (waiting_time[t]) t++;

		if (current_time < incoming_time[t]) current_time = incoming_time[t];
		auto
			wrk_time_more_houres = (((current_time - HOUR_TO_MIN(9)) % HOUR_TO_MIN(9) + work_time[t] - 60) / HOUR_TO_MIN(9)) * 16,
			wrk_time = work_time[t] + (((current_time - HOUR_TO_MIN(9)) % HOUR_TO_MIN(9) + work_time[t]) / HOUR_TO_MIN(9)) * 16;
		if (wrk_time_more_houres < wrk_time)
			current_time += work_time[t] + wrk_time_more_houres;
		else current_time += wrk_time;
		waiting_time[t] = current_time - incoming_time[t];
	}

	return waiting_time;
}

auto calcStats(std::vector<uint32_t> waiting_times, size_t total_tasks) {
	uint32_t max = 0;
	double average = 0;

	for (auto time : waiting_times) {
		if (max < time) max = time;
		average += (double)time;
	}

	average /= (double)total_tasks;
	return std::make_tuple(max, average);
}

int main(int argc, char** argv) {

	auto read_file = [](char const* const str) {
		std::ifstream ifstr(str, std::ios::in);
		std::vector<uint32_t> incoming_time{}, work_time{};

		if (not ifstr.is_open()) {
			throw std::exception("Could not open file!");
		}

		int start, duration;
		std::string lnin;

		while (not ifstr.eof()) {
			ifstr >> start >> duration;
			incoming_time.push_back(start);
			work_time.push_back(duration);
		}

		return std::make_tuple(incoming_time, work_time);
	};

	if (argc != 2) {
		std::cerr << "Unknown arguments!\nUsage: " << *argv << " <filename>" << std::endl;
		return -1;
	}

	try {

		//auto [incTime, wrkTime] = read_file("D:\\BWINF\\a43.txt");
		auto [incTime, wrkTime] = read_file(argv[1]);
		

		std::cout
			<< "Input file: \"" << argv[1] << "\"\n"
			<< "Total tasks: " << incTime.size() << std::endl;
		std::cout << "\nStart first simulation (sorted by incoming Tasks) . . . ";

		{
			auto [max_wtime, average_wtime] = calcStats(simulation0(incTime, wrkTime), incTime.size());
			std::cout
				<< "done!\nMaximum waiting time: " << max_wtime << ".0 min, average waiting time: " << std::fixed << std::setprecision(1) << average_wtime << " min\n\n"
				<< "Start second simulation (sorted by task length) . . . ";
		}

		{
			auto [max_wtime, average_wtime] = calcStats(simulation1(incTime, wrkTime), incTime.size());
			std::cout
				<< "done!\nMaximum waiting time: " << max_wtime << ".0 min, average waiting time: " << std::fixed << std::setprecision(1) << average_wtime << " min\n\n"
				<< "Start third simulation (own ideas) . . . ";
		}

		{
			auto [max_wtime, average_wtime] = calcStats(simulation2(incTime, wrkTime), incTime.size());
			std::cout
				<< "done!\nMaximum waiting time: " << max_wtime << ".0 min, average waiting time: " << std::fixed << std::setprecision(1) << average_wtime << " min"
				<< std::endl;
		}

	}
	catch (std::exception e) {
		std::cerr << "Error: " << e.what() << std::endl;
		return -1;
	}

	return 0;
}