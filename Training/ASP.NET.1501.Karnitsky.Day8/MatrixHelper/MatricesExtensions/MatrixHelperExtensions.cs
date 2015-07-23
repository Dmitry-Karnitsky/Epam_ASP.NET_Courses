using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MatrixHelper
{
    public static class MatrixExtensions
    {   
        public static void SumWith<T>(this IMatrix<T> firstAddend, IMatrix<T> secondAddend, Func<T,T,T> additionMethod) 
        {
            if (firstAddend == null)
                throw new NullReferenceException("SumMatrices");
            if (secondAddend == null)
                throw new ArgumentNullException("SumMatrices");

            if (firstAddend.Rows != secondAddend.Rows || firstAddend.Columns != secondAddend.Columns)            
                throw new ArgumentException("Matrices with different sizes can't be added.");   
         
            if(additionMethod == null)            
               throw new ArgumentNullException("Can't execute addition operation without addition delegate.");

            Sum(firstAddend, secondAddend, additionMethod); 
        }

        private static void Sum<T>(IMatrix<T> firstAddend, IMatrix<T> secondAddend, Func<T, T, T> additionMethod)
        {   
            for(int i = 0; i < firstAddend.Rows; i++)
            {
                for(int j = 0; j < secondAddend.Columns; j++)
                {
                    try
                    {
                        firstAddend[i, j] = additionMethod(firstAddend[i, j], secondAddend[i, j]);
                    }
                    catch(Exception e)
                    {
                        throw new InvalidOperationException("SumWith", e);
                    }
                }
            }
        }
    }
}
