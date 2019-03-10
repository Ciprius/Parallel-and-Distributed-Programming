#pragma once

#include "Matrix.h"
#include "stdafx.h"
#include <iostream>
#include <string>
#include <vector>
#include <thread>
#include <future>
#include <chrono>
using namespace std;

class MatrixAddtion
{
public:
	MatrixAddtion() {}
	~MatrixAddtion() {}

	void initData(Matrix& mat1, Matrix& mat2)
	{
		this->matrix1 = mat1;
		this->matrix2 = mat2;

		this->matrix.SetNoRows(mat1.GetNoRows());
		this->matrix.SetNoColumns(mat1.GetNoColumns());
	}

	void AddNxN()
	{
		for (size_t i = 0; i < this->matrix.GetNoRows(); i++)
		{
			size_t row = i;
			for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
			{
				size_t col = j;
				futures.emplace_back(std::async(std::launch::async, [this](size_t row, size_t col) {
					matrix.SetMatrixItem(row, col, matrix1.GetElem(row, col) + matrix2.GetElem(row, col));
				}, row, col));
			}
		}

		for (auto const& item : futures)
			item.wait();
	}

	void AddN()
	{
		for (size_t i = 0; i < this->matrix.GetNoRows(); i++)
		{
			size_t row = i;
			futures.emplace_back(std::async(std::launch::async, [this](size_t row) {
				for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
				{
					size_t col = j;
					matrix.SetMatrixItem(row, col, matrix1.GetElem(row, col) + matrix2.GetElem(row, col));
				}
			}, row));
		}

		for (auto const& item : futures)
			item.wait();
	}

	void AddSeq()
	{
		futures.emplace_back(std::async(std::launch::async, [this]() {
			for (size_t i = 0; i < this->matrix.GetNoRows(); i++)
			{
				size_t row = i;
				for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
				{
					size_t col = j;
					matrix.SetMatrixItem(row, col, matrix1.GetElem(row, col) + matrix2.GetElem(row, col));
				}
			}
		}));

		for (auto const& item : futures)
			item.wait();
	}

	Matrix GetMat() { return this->matrix; }

private:
	vector<future<void>> futures;
	Matrix matrix;
	Matrix matrix1;
	Matrix matrix2;
};
