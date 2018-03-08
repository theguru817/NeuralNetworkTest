using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest.MatrixHelper
{
    public class Matrix
    {
        private List<MatrixRow> matrixData;

        public Matrix(double[][] marray)
        {
            matrixData = new List<MatrixRow>();
            for (int i = 0; i < marray.GetLength(0); i++)
            {
                MatrixRow mRow = new MatrixRow(marray[i]);
                matrixData.Add(mRow);
            }
        }

        public Matrix()
        {
            matrixData = new List<MatrixRow>();
        }

        public void ScalarMultiply(double scalarFactor)
        {
            foreach (MatrixRow rows in matrixData)
            {
                foreach (MatrixCol colValues in rows.matrixColData)
                {
                    colValues.mdata += scalarFactor;
                }
            }
        }

        public Matrix DotMultiply(Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix();
            int mFirstColCount = matrixData[0].matrixColData.Count;
            int mSecondRowCount = secondMatrix.matrixData.Count;
            int mSecondColCount = secondMatrix.matrixData[0].matrixColData.Count;

            if (mFirstColCount == mSecondRowCount)
            {
                for (int i = 0; i < matrixData.Count; i++)
                {
                    resultMatrix.matrixData.Add(new MatrixRow());
                    for (int k = 0; k < mSecondColCount; k++)
                    {
                        double result = 0;
                        for (int j = 0; j < mFirstColCount; j++)
                        {
                            double firstMatrixItem = matrixData[i].matrixColData[j].mdata;
                            double secondMatrixItem = secondMatrix.matrixData[j].matrixColData[k].mdata;
                            result += firstMatrixItem * secondMatrixItem;
                        }
                        resultMatrix.matrixData[i].matrixColData.Add(new MatrixCol(result));
                    }
                }
            }

            return resultMatrix;
        }

        public override bool Equals(object obj)
        {
            Matrix toCompareWith = obj as Matrix;
            int mFirstRowCount = matrixData.Count;
            int mFirstColCount = matrixData[0].matrixColData.Count;
            int mSecondRowCount = toCompareWith.matrixData.Count;
            int mSecondColCount = toCompareWith.matrixData[0].matrixColData.Count;

            if (toCompareWith is null || 
                 mSecondRowCount != mFirstRowCount || 
                 mSecondColCount != mFirstColCount)
                return false;

            int numEqual = 0;
            for (int i=0; i<mFirstRowCount; i++)
            {
                for (int j=0; j<mFirstColCount; j++)
                {
                    if (Math.Round(toCompareWith.matrixData[i].matrixColData[j].mdata,6) == Math.Round(matrixData[i].matrixColData[j].mdata,6))
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
            int mFirstRowCount = matrixData.Count;
            int mFirstColCount = matrixData[0].matrixColData.Count;
            int mSecondRowCount = secondMatrix.matrixData.Count;
            int mSecondColCount = secondMatrix.matrixData[0].matrixColData.Count;

            if (mFirstRowCount==mSecondRowCount && mFirstColCount==mSecondColCount)
            {
                for (int i=0; i<mFirstRowCount; i++)
                {
                    resultMatrix.matrixData.Add(new MatrixRow());
                    for (int j=0; j<mFirstColCount; j++)
                    {
                        double firstMatrixItem = matrixData[i].matrixColData[j].mdata;
                        double secondMatrixItem = secondMatrix.matrixData[i].matrixColData[j].mdata;
                        resultMatrix.matrixData[i].matrixColData.Add(new MatrixCol(firstMatrixItem + secondMatrixItem));
                    }
                }
            }

            return resultMatrix;
        }

        public Matrix Transpose()
        {
            Matrix resultMatrix = new Matrix();
            int matrixRowCount = matrixData.Count;
            int matrixColCount = matrixData[0].matrixColData.Count;

            for (int i=0; i<matrixColCount; i++)
            {
                resultMatrix.matrixData.Add(new MatrixRow());
                for (int j = 0; j < matrixRowCount; j++)
                {
                    resultMatrix.matrixData[i].matrixColData.Add(new MatrixCol(matrixData[j].matrixColData[i].mdata));
                }
            }

            return resultMatrix;
        }

        public Matrix HadamardProduct(Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix();
            int mFirstRowCount = matrixData.Count;
            int mFirstColCount = matrixData[0].matrixColData.Count;
            int mSecondRowCount = secondMatrix.matrixData.Count;
            int mSecondColCount = secondMatrix.matrixData[0].matrixColData.Count;

            if (mFirstRowCount == mSecondRowCount && mFirstColCount == mSecondColCount)
            {
                for (int i = 0; i < mFirstRowCount; i++)
                {
                    resultMatrix.matrixData.Add(new MatrixRow());
                    for (int j = 0; j < mFirstColCount; j++)
                    {
                        resultMatrix.matrixData[i].matrixColData.Add(new MatrixCol(matrixData[i].matrixColData[j].mdata * secondMatrix.matrixData[i].matrixColData[j].mdata));
                    }
                }
            }

            return resultMatrix;
        }

    }

    internal class MatrixRow
    {
        internal List<MatrixCol> matrixColData;

        internal MatrixRow(double[] mColData)
        {
            matrixColData = new List<MatrixCol>();
            foreach (double item in mColData)
            {
                MatrixCol matrixCol = new MatrixCol(item);
                matrixColData.Add(matrixCol);
            }

        }

        internal MatrixRow()
        {
            matrixColData = new List<MatrixCol>();
        }

    }

    internal class MatrixCol
    {
        internal double mdata;

        internal MatrixCol(double mdata)
        {
            this.mdata = mdata;
        }
    }
}
