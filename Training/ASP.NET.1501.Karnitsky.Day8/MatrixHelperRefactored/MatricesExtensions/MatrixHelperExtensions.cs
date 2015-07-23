using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MatrixHelperRefactored
{
    public static class MatrixExtensions
    {
        public static void SumWith<T>(this AbstractSquareMatrix<T> firstAddend, AbstractSquareMatrix<T> secondAddend)
        {   
            firstAddend.SumWith(secondAddend, null);      
        }

        public static void SumWith<T>(this AbstractSquareMatrix<T> firstAddend, AbstractSquareMatrix<T> secondAddend, Func<T, T, T> additionMethod)
        {
            if (firstAddend == null)
                throw new NullReferenceException("SumMatrices");
            if (secondAddend == null)
                throw new ArgumentNullException("SumMatrices");

            AbstractSquareMatrix<T> sumResult = SumMatrices(firstAddend, secondAddend, additionMethod);

            if (firstAddend.Order != secondAddend.Order)
                throw new ArgumentException("Matrices with different orders can't be added.");

            for (int i = 0; i < firstAddend.Order; i++)
                for (int j = 0; j < firstAddend.Order; j++)
                    firstAddend[i, j] = sumResult[i, j];
        }
        
        public static SquareMatrix<T> SumMatrices<T>(AbstractSquareMatrix<T> firstAddend, AbstractSquareMatrix<T> secondAddend)
        {
            return SumMatrices(firstAddend, secondAddend, null);
        }
        
        public static SquareMatrix<T> SumMatrices<T>(AbstractSquareMatrix<T> firstAddend, AbstractSquareMatrix<T> secondAddend, Func<T, T, T> additionMethod) 
        {
            if (firstAddend == null)
                throw new NullReferenceException("SumMatrices");
            if (secondAddend == null)
                throw new ArgumentNullException("SumMatrices");

            if (firstAddend.Order!= secondAddend.Order)            
                throw new ArgumentException("Matrices with different orders can't be added.");   
         
            if(additionMethod == null)
            {
                MethodInfo op_Addition = typeof(T).GetMethod("op_Addition", BindingFlags.Static);
                if (op_Addition != null)
                {
                    additionMethod = (Func<T,T,T>)op_Addition.CreateDelegate(typeof(Func<T,T,T>));
                }
                else
                {
                    additionMethod = (T t1, T t2) =>
                    {
                        dynamic d1 = t1;
                        dynamic d2 = t2;
                        return d1 + d2;
                    };
                }
            }

            return Sum(firstAddend, secondAddend, additionMethod); 
        }

        private static SquareMatrix<T> Sum<T>(AbstractSquareMatrix<T> firstAddend, AbstractSquareMatrix<T> secondAddend, Func<T, T, T> additionMethod)
        {
            SquareMatrix<T> result = new SquareMatrix<T>(firstAddend.Order);

            int order = firstAddend.Order;

            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    try
                    {
                        result[i, j] = additionMethod(firstAddend[i, j], secondAddend[i, j]);
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException("SumWith", e);
                    }
                }
            }
            return result;
        }
    }
}
