using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest.MatrixHelper
{
    public class MatrixMath
    {
        public Matrix matrix;

        public MatrixMath (Matrix matrix)
        {
            this.matrix = matrix;
        }

        public void ScalarMultiply (double scalarFactor)
        {
            foreach (MatrixRow rows in matrix.matrixData)
            {
                foreach (MatrixCol colValues in rows.matrixColData)
                {
                    colValues.mdata *= scalarFactor;
                }
            }
        }

        public void DotMultiply (Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix();
            int mFirstColCount = matrix.matrixData[0].matrixColData.Count;
            int mSecondRowCount = secondMatrix.matrixData.Count;
            
            if (mFirstColCount==mSecondRowCount)
            {
                foreach (MatrixRow mRow in matrix.matrixData)
                {
                    foreach (MatrixCol mCol in mRow.matrixColData)
                    {
                        double newColumn = mCol.mdata
                    }
                }
            }
        }
        

    }

    
}
