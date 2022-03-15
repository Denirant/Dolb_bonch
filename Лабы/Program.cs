using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабы
{
    internal class Program
    {
        //Нахождение определителя через метод треугольника
        static double determinantOfMatrix(double[,] mat) {
            double ans;
            ans = mat[0, 0] * (mat[1, 1] * mat[2, 2] - mat[2, 1] * mat[1, 2])
                - mat[0, 1] * (mat[1, 0] * mat[2, 2] - mat[1, 2] * mat[2, 0])
                + mat[0, 2] * (mat[1, 0] * mat[2, 1] - mat[1, 1] * mat[2, 0]);
            return ans;
        }

        
        static void findSolution(double[,] coeff) {
            //Определитель матрицы D (только кооф)
            double[,] d = {
        { coeff[0,0], coeff[0,1], coeff[0,2] },
        { coeff[1,0], coeff[1,1], coeff[1,2] },
        { coeff[2,0], coeff[2,1], coeff[2,2] },
    };

            //Определитель матрицы D1 (первый столбик с ответами уравнений)
            double[,] d1 = {
        { coeff[0,3], coeff[0,1], coeff[0,2] },
        { coeff[1,3], coeff[1,1], coeff[1,2] },
        { coeff[2,3], coeff[2,1], coeff[2,2] },
    };

            //Определитель матрицы D2 (второй столбик с ответами уравнений)
            double[,] d2 = {
        { coeff[0,0], coeff[0,3], coeff[0,2] },
        { coeff[1,0], coeff[1,3], coeff[1,2] },
        { coeff[2,0], coeff[2,3], coeff[2,2] },
    };

            //Определитель матрицы D3 (третий столбик с ответами уравнений)
            double[,] d3 = {
        { coeff[0,0], coeff[0,1], coeff[0,3] },
        { coeff[1,0], coeff[1,1], coeff[1,3] },
        { coeff[2,0], coeff[2,1], coeff[2,3] },
    };

            // Вычисление определителей матрицы и вывод в консоль
            double D = determinantOfMatrix(d);
            double D1 = determinantOfMatrix(d1);
            double D2 = determinantOfMatrix(d2);
            double D3 = determinantOfMatrix(d3);
            Console.Write("Опеределитель D: {0:F6} \n", D);
            Console.Write("Опеределитель D1: {0:F6} \n", D1);
            Console.Write("Опеределитель D2: {0:F6} \n", D2);
            Console.Write("Опеределитель D3: {0:F6} \n", D3);

            if (D != 0) {
                double x = D1 / D; // вычисление переменной x
                double y = D2 / D; // вычисление переменной y
                double z = D3 / D; // вычисление переменной z 
                Console.Write("Значение x: {0:F6}\n", x);
                Console.Write("Значение y: {0:F6}\n", y);
                Console.Write("Значение z: {0:F6}\n", z);
            } else {
                if (D1 == 0 && D2 == 0 && D3 == 0)
                    Console.Write("Бесконечные решения...\n");
                else if (D1 != 0 || D2 != 0 || D3 != 0)
                    Console.Write("Нет решений...\n");
            }
        }

        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double[,] odds = {{ 2, -1, 3, 9 },
                              { 1, 1, 1, 6 },
                              { 1, -1, 1, 2 }};
            findSolution(odds);
        }
    }
}
