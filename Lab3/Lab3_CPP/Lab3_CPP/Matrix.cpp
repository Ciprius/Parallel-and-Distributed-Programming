#include "Matrix.h"

int Matrix::GetElem(size_t i, size_t j)
{
	return this->elem[i][j];
}

void Matrix::SetMatrix(size_t row, rsize_t column)
{
	this->No_Rows = row;
	this->No_Columns = column;
}

void Matrix::SetMatrixItem(size_t row, size_t column, int item)
{
	this->elem[row][column] = item;
}

string Matrix::toString()
{
	string str = "";
	for (size_t i = 0; i < this->No_Rows; i++)
	{
		for (size_t j = 0; j < this->No_Columns; j++)
			str = str + " " + to_string(elem[i][j]);
		str = str + "\n";
	}
	return str;
}