#pragma once
#include "stdafx.h"
#include <string>
#include <iostream>

using namespace std;

class Matrix
{
public:
	Matrix() {}
	~Matrix() {}

	int GetElem(size_t i, size_t j);
	size_t GetNoRows() { return this->No_Rows; }
	size_t GetNoColumns() { return this->No_Columns; }
	void SetNoRows(size_t row) { this->No_Rows = row; }
	void SetNoColumns(size_t column) { this->No_Columns = column; }
	void SetMatrix(size_t row, rsize_t column);
	void SetMatrixItem(size_t row ,size_t column, int item);
	string toString();

private:
	size_t No_Columns;
	size_t No_Rows;
	int elem[100][100];
};

