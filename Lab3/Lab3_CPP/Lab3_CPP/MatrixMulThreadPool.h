#pragma once

#include "Matrix.h"
#include "ThreadPool.h"
#include "stdafx.h"
#include <iostream>
#include <string>
#include <vector>
#include <thread>
#include <future>
#include <chrono>


class MatrixMulThreadPool
{
public:
	MatrixMulThreadPool() {}
	~MatrixMulThreadPool() {}

	void initData(Matrix& mat1, Matrix& mat2)
	{
		this->matrix1 = mat1;
		this->matrix2 = mat2;

		this->matrix.SetNoRows(mat1.GetNoRows());
		this->matrix.SetNoColumns(mat1.GetNoColumns());
	}

	Matrix GetMat() { return this->matrix; }

	Matrix MulSeq()
	{
		pool->push([this] (int){
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
		});
		return this->matrix;
	}

	Matrix MulN()
	{
		for (size_t i = 0; i < this->matrix.GetNoRows(); i++)
		{
			size_t row = i;
			pool->push([row,this](int) {
				for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
				{
					size_t col = j;
					int sum = 0;
					for (size_t k = 0; k < this->matrix1.GetNoColumns(); k++)
						sum += matrix1.GetElem(row, k) * matrix2.GetElem(k, col);
					matrix.SetMatrixItem(row, col, sum);
				}
			});
		}
		return this->matrix;
	}

	Matrix MulNxN()
	{
		for (size_t i = 0; i < this->matrix.GetNoRows(); i++)
		{
			size_t row = i;
			for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
			{
				size_t col = j;
				int sum = 0;
				pool->push([row,col,this] (int){
					int sum = 0;
					for (size_t k = 0; k < this->matrix1.GetNoColumns(); k++)
						sum += matrix1.GetElem(row, k) * matrix2.GetElem(k, col);
					matrix.SetMatrixItem(row, col, sum);
				});
			}
		}
		return this->matrix;
	}

	void initThreadPool(int i)
	{
		pool = new ctpl::thread_pool();
		if (i == 1)
			pool->resize(1);
		if (i == 2)
			pool->resize(4);
		if (i == 3)
			pool->resize(16);
	}

	void StopPool() 
	{ 
		pool->stop(); 
		delete pool;
	}
private:
	ctpl::thread_pool  *pool;
	Matrix matrix;
	Matrix matrix1;
	Matrix matrix2;
};
