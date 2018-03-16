using System;
using System.Collections.Generic;

namespace NeuralNetworkTest.MatrixHelper
{
    public class Matrix : List<MatrixRow>
    {
        public Matrix(double[,] marray)
        {
            for (int i = 0; i < marray.GetLength(0); i++)
            {
                double[] rowArray = new double[marray.GetLength(1)];
                for (int j = 0; j < marray.GetLength(1); j++)
                {
                    rowArray[j] = marray[i, j];
                }
                this.Add(new MatrixRow(rowArray));
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Matrix()
        {
           
        }

        public Matrix ScalarMultiply(double scalarFactor)
        {
            Matrix resultMatrix = new Matrix();
            int mFirstColCount = this[0].Count;

            for (int i=0; i< this.Count; i++)
            {
                double[] resultantArray = new double[mFirstColCount];
                for (int j=0; j<mFirstColCount; j++ )
                {
                    resultantArray[j] = this[i][j].data * scalarFactor;
                }
                resultMatrix.Add(new MatrixRow(resultantArray));
            }

            return resultMatrix;
        }

        public Matrix DotMultiply(Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix();
            int mFirstColCount = this[0].Count;
            int mSecondRowCount = secondMatrix.Count;
            int mSecondColCount = secondMatrix[0].Count;

            if (mFirstColCount == mSecondRowCount)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    double[] resultRowArray = new double[mSecondColCount];
                    for (int k = 0; k < mSecondColCount; k++)
                    {
                        double result = 0;
                        for (int j = 0; j < mFirstColCount; j++)
                        {
                            double firstMatrixItem = this[i][j].data;
                            double secondMatrixItem = secondMatrix[j][k].data;
                            result += firstMatrixItem * secondMatrixItem;
                        }
                        resultRowArray[k] = result;
                        
                    }
                    resultMatrix.Add(new MatrixRow(resultRowArray));
                }
            }

            return resultMatrix;
        }

        public override bool Equals(object obj)
        {
            Matrix toCompareWith = obj as Matrix;
            int mFirstRowCount = this.Count;
            int mFirstColCount = this[0].Count;
            int mSecondRowCount = toCompareWith.Count;
            int mSecondColCount = toCompareWith[0].Count;

            if (toCompareWith is null || mSecondRowCount != mFirstRowCount ||
                 mSecondColCount != mFirstColCount)
                return false;

            int numEqual = 0;
            for (int i = 0; i < mFirstRowCount; i++)
            {
                for (int j = 0; j < mFirstColCount; j++)
                {
                    if (Math.Round(toCompareWith[i][j].data, 6) == Math.Round(this[i][j].data, 6))
                        numEqual++;
                }
            }

            if (numEqual == mFirstRowCount * mFirstColCount)
                return true;

            return false;
        }

        public Matrix Add(Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix();
            int mFirstRowCount = this.Count;
            int mFirstColCount = this[0].Count;
            int mSecondRowCount = secondMatrix.Count;
            int mSecondColCount = secondMatrix[0].Count;

            if (mFirstRowCount == mSecondRowCount && mFirstColCount == mSecondColCount)
            {
                for (int i = 0; i < mFirstRowCount; i++)
                {
                    double[] resultantArray = new double[mFirstColCount];
                    for (int j = 0; j < mFirstColCount; j++)
                    {
                        double firstMatrixItem = this[i][j].data;
                        double secondMatrixItem = secondMatrix[i][j].data;
                        resultantArray[j] = firstMatrixItem + secondMatrixItem;
                    }
                    resultMatrix.Add(new MatrixRow(resultantArray));
                }
            }

            return resultMatrix;
        }

        public Matrix Transpose()
        {
            Matrix resultMatrix = new Matrix();
            int matrixRowCount = this.Count;
            int matrixColCount = this[0].Count;

            for (int i = 0; i < matrixColCount; i++)
            {
                double[] resultantArray = new double[matrixRowCount];
                for (int j = 0; j < matrixRowCount; j++)
                {
                    resultantArray[j] = this[j][i].data;
                }
                resultMatrix.Add(new MatrixRow(resultantArray));
            }

            return resultMatrix;
        }

        public Matrix HadamardProduct(Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix();
            int mFirstRowCount = this.Count;
            int mFirstColCount = this[0].Count;
            int mSecondRowCount = secondMatrix.Count;
            int mSecondColCount = secondMatrix[0].Count;

            if (mFirstRowCount == mSecondRowCount && mFirstColCount == mSecondColCount)
            {
                for (int i = 0; i < mFirstRowCount; i++)
                {
                    double[] resultantArray = new double[mFirstColCount];
                    for (int j = 0; j < mFirstColCount; j++)
                    {
                        resultantArray[j] = this[i][j].data * secondMatrix[i][j].data;
                    }
                    resultMatrix.Add(new MatrixRow(resultantArray));
                }
            }

            return resultMatrix;
        }
    }

    public class MatrixRow: List<MatrixCol>
    {
        public MatrixRow (double[] rowData)
        {
            foreach (double rowItem in rowData)
            {
                this.Add(new MatrixCol(rowItem));
            }
        }
    }

    public class MatrixCol
    {
        internal double data;

        internal MatrixCol(double data)
        {
            this.data = data;
        }
    }
}