// Lab3_CPP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Matrix.h"
#include "MatrixAddition.h"
#include "MatrixMultiplication.h"
#include "MatrixAddThreadPool.h"
#include "MatrixMulThreadPool.h"
#include <chrono>

using namespace std;
void AddSeq(MatrixAddtion &mat);
void AddN(MatrixAddtion &mat);
void AddNxN(MatrixAddtion &mat);
void AddSeqThreadPool(MatrixAddThreadPool &mat);
void AddNThreadPool(MatrixAddThreadPool &mat);
void AddNxNThreadPool(MatrixAddThreadPool &mat);
void MulSeq(MatrixMultiplication &mat);
void MulN(MatrixMultiplication &mat);
void MulNxN(MatrixMultiplication &mat);
void MulSeqThreadPool(MatrixMulThreadPool &mat);
void MulNThreadPool(MatrixMulThreadPool &mat);
void MulNxNThreadPool(MatrixMulThreadPool &mat);
void FutureMenu(Matrix& mat1, Matrix& mat2);
void ThreadMenu(Matrix mat1, Matrix mat2);

int main()
{
	Matrix mat1, mat2;
	mat1.SetNoRows(4); 
	mat1.SetNoColumns(4);
	mat2.SetNoRows(4);
	mat2.SetNoColumns(4);

	while (true)
	{
		int j;
		cout << "0: exit" << endl;
		cout << "1: Thread Pool" << endl;
		cout << "2: Future" << endl;
		cout << "Input:";
		cin >> j;

		if (j == 0)
			break;
		if (j == 1)
			ThreadMenu(mat1, mat2);
		if (j == 2)
			FutureMenu(mat1, mat2);
		
	}
    return 0;
}

void DisplayMat(Matrix mat1, Matrix mat2)
{
	cout << mat1.toString();
	cout << endl;
	cout << mat2.toString();
	cout << endl;
}

void FutureMenu(Matrix& mat1, Matrix& mat2)
{
	for (size_t i = 0; i < mat1.GetNoRows(); i++)
		for (size_t j = 0; j < mat1.GetNoColumns(); j++)
		{
			mat1.SetMatrixItem(i, j, rand() % 10 + 1);
			mat2.SetMatrixItem(i, j, rand() % 10 + 1);
		}

	MatrixAddtion mat;
	MatrixMultiplication matMul;
	mat.initData(mat1, mat2);
	matMul.initData(mat1, mat2);
	int i = 1;
	while (true)
	{
		cout << "1: 1 Thread" << endl;
		cout << "2: n Threads" << endl;
		cout << "3: nXn Threads" << endl;
		cout << "0: exit" << endl;
		cout << "Input:";
		cin >> i;

		if (i == 1)
		{
			DisplayMat(mat1, mat2);
			AddSeq(mat);
			MulSeq(matMul);
		}
		if (i == 2)
		{
			DisplayMat(mat1, mat2);
			AddN(mat);
			MulN(matMul);
		}
		if (i == 3)
		{
			DisplayMat(mat1, mat2);
			AddNxN(mat);
			MulNxN(matMul);
		}
		if (i == 0)
			break;
	}
}

void MulSeq(MatrixMultiplication &mat)
{
	cout << "Multiplication :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	mat.MulSeq();
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	cout << mat.GetMat().toString() << endl;
	cout << to_string(mil.count()) << " ms" << endl;
}

void MulN(MatrixMultiplication &mat)
{
	cout << "Multiplication :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	mat.MulN();
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	cout << mat.GetMat().toString() << endl;
	cout << to_string(mil.count()) << " ms" << endl;
}

void MulNxN(MatrixMultiplication &mat)
{
	cout << "Multiplication :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	mat.MulNxN();
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	cout << mat.GetMat().toString() << endl;
	cout << to_string(mil.count()) << " ms" << endl;
}

void AddSeq(MatrixAddtion &mat)
{
	cout << "Addition :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	mat.AddSeq();
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	cout << mat.GetMat().toString() << endl;
	cout << to_string(mil.count()) << " ms" << endl;
}

void AddN(MatrixAddtion &mat)
{
	cout << "Addition :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	mat.AddN();
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	cout << mat.GetMat().toString() << endl;
	cout << to_string(mil.count()) << " ms" << endl;
}

void AddNxN(MatrixAddtion &mat)
{
	cout << "Addition :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	mat.AddNxN();
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	cout << mat.GetMat().toString() << endl;
	cout << to_string(mil.count()) << " ms" << endl;
}

void ThreadMenu(Matrix mat1, Matrix mat2)
{
	for (size_t i = 0; i < mat1.GetNoRows(); i++)
		for (size_t j = 0; j < mat1.GetNoColumns(); j++)
		{
			mat1.SetMatrixItem(i, j, rand() % 10 + 1);
			mat2.SetMatrixItem(i, j, rand() % 10 + 1);
		}

	MatrixAddThreadPool mat;
	MatrixMulThreadPool matMul;
	mat.initData(mat1, mat2);
	matMul.initData(mat1, mat2);
	int i = 1;
	while (true)
	{
		cout << "1: 1 Thread" << endl;
		cout << "2: n Threads" << endl;
		cout << "3: nXn Threads" << endl;
		cout << "0: exit" << endl;
		cout << "Input:";
		cin >> i;

		if (i == 1)
		{
			DisplayMat(mat1, mat2);
			mat.initThreadPool(i);
			matMul.initThreadPool(i);
			AddSeqThreadPool(mat);
			MulSeqThreadPool(matMul);
		}
		if (i == 2)
		{
			DisplayMat(mat1, mat2);
			mat.initThreadPool(i);
			matMul.initThreadPool(i);
			AddNThreadPool(mat);
			MulNThreadPool(matMul);
		}
		if (i == 3)
		{
			DisplayMat(mat1, mat2);
			mat.initThreadPool(i);
			matMul.initThreadPool(i);
			AddNxNThreadPool(mat);
			MulNxNThreadPool(matMul);
		}
		if (i == 0)
		{
			break;
		}
	}
}

void AddSeqThreadPool(MatrixAddThreadPool &mat)
{
	cout << "Addition :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	cout << mat.AddSeq().toString() << endl;
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	mat.StopPool();
	cout << to_string(mil.count()) << " ms" << endl;
}

void AddNThreadPool(MatrixAddThreadPool &mat)
{
	cout << "Addition :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	cout << mat.AddN().toString() << endl;
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	mat.StopPool();
	cout << to_string(mil.count())<< " ms" << endl;
}

void AddNxNThreadPool(MatrixAddThreadPool &mat)
{
	cout << "Addition :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	cout << mat.AddNxN().toString() << endl;
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	mat.StopPool();
	cout << to_string(mil.count()) << " ms" << endl;
}

void MulSeqThreadPool(MatrixMulThreadPool &mat)
{
	cout << "Multiplication :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	cout << mat.MulSeq().toString() << endl;
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	mat.StopPool();
	cout << to_string(mil.count()) << " ms" << endl;
}

void MulNThreadPool(MatrixMulThreadPool &mat)
{
	cout << "Multiplication :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	cout << mat.MulN().toString() << endl;
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	mat.StopPool();
	cout << to_string(mil.count()) << " ms" << endl;
}

void MulNxNThreadPool(MatrixMulThreadPool &mat)
{
	cout << "Multiplication :" << endl;
	auto start_time = chrono::high_resolution_clock::now();
	cout << mat.MulNxN().toString() << endl;
	auto end_time = chrono::high_resolution_clock::now();
	auto mil = chrono::duration_cast<chrono::milliseconds>(end_time - start_time);
	mat.StopPool();
	cout << to_string(mil.count()) << " ms" << endl;
}