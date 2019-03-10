#pragma once

#include "Matrix.h"
#include "stdafx.h"
#include <iostream>
#include <string>
#include <vector>
#include <thread>
#include <future>
#include <chrono>

class MatrixMultiplication
{
public:
	MatrixMultiplication() {}
	~MatrixMultiplication() {}

	void initData(Matrix& mat1, Matrix& mat2)
	{
		this->matrix1 = mat1;
		this->matrix2 = mat2;

		this->matrix.SetNoRows(mat1.GetNoRows());
		this->matrix.SetNoColumns(mat1.GetNoColumns());
	}

	void MulNxN()
	{
		for (size_t i = 0; i < this->matrix.GetNoRows(); i++)
		{
			size_t row = i;
			for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
			{
				size_t col = j;
				int sum = 0;
				futures.emplace_back(std::async(std::launch::async, [this](size_t row, size_t col, int sum) {
					for (size_t k = 0; k < this->matrix1.GetNoColumns(); k++)
						sum += matrix1.GetElem(row, k) * matrix2.GetElem(k, col);
					matrix.SetMatrixItem(row, col, sum);
				}, row, col,sum));
			}
		}

		for (auto const& item : futures)
			item.wait();
	}

	void MulN()
	{
		for (size_t i = 0; i < this->matrix.GetNoRows(); i++)
		{
			size_t row = i;
			futures.emplace_back(std::async(std::launch::async, [this](size_t row) {
				for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
				{
					size_t col = j;
					int sum = 0;
					for (size_t k = 0; k < this->matrix1.GetNoColumns(); k++)
						sum += matrix1.GetElem(row, k) * matrix2.GetElem(k, col);
					matrix.SetMatrixItem(row, col, sum);
				}
			}, row));
		}

		for (auto const& item : futures)
			item.wait();
	}

	void MulSeq()
	{
		futures.emplace_back(std::async(std::launch::async, [this]() {
			for (size_t i = 0; i < this->matrix.GetNoRows(); i++)
			{
				size_t row = i;
				for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
				{
					size_t col = j;
					int sum = 0;
					for (size_t k = 0; k < this->matrix1.GetNoColumns(); k++)
						sum += matrix1.GetElem(row, k) * matrix2.GetElem(k, col);
					matrix.SetMatrixItem(row, col, sum);
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
