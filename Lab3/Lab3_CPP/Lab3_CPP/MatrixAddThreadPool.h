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

class MatrixAddThreadPool
{
public:
	MatrixAddThreadPool() {}
	~MatrixAddThreadPool() {}

	void initData(Matrix& mat1, Matrix& mat2)
	{
		this->matrix1 = mat1;
		this->matrix2 = mat2;

		this->matrix.SetNoRows(mat1.GetNoRows());
		this->matrix.SetNoColumns(mat1.GetNoColumns());
	}

	Matrix GetMat() { return this->matrix; }

	Matrix AddSeq()
	{
		pool->push([this] (int){
			for (size_t i = 0; i < this->matrix.GetNoRows();i++)
			{
				for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
				{
					matrix.SetMatrixItem(i, j, matrix1.GetElem(i, j) + matrix2.GetElem(i, j));
				}
			}
		});
		return this->matrix;
	}

	Matrix AddN()
	{
		for (size_t i = 0; i < this->matrix.GetNoRows(); i++)
		{
			int row = i;
			pool->push([row,this] (int){
				for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
				{
					matrix.SetMatrixItem(row, j, matrix1.GetElem(row, j) + matrix2.GetElem(row, j));
				}
			});
		}
		return this->matrix;
	}

	Matrix AddNxN()
	{
		for (size_t i = 0; i < this->matrix.GetNoRows(); i++)
		{
			int row = i;
			for (size_t j = 0; j < this->matrix.GetNoColumns(); j++)
			{
				int col = j;
				pool->push([row, col ,this](int) {
					matrix.SetMatrixItem(row, col, matrix1.GetElem(row, col) + matrix2.GetElem(row, col));
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
