using Lab6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6.Controller
{
    class Cont
    {
        private NormalAlg normalAlg;
        private KaratsubaAlg karatsubaAlg;
        private int[] firstPolynom;
        private int[] secondPolynom;

        public Cont(int firstPolynomSize, int secondPolynomSize)
        {
            this.firstPolynom = new int[firstPolynomSize];
            this.secondPolynom = new int[secondPolynomSize];
            Random random = new Random();

            for (int i = 0; i < firstPolynomSize; i++)
                this.firstPolynom[i] = random.Next(1, 10);
            for (int i = 0; i < secondPolynomSize; i++)
                this.secondPolynom[i] = random.Next(1, 10);
        }

        public void ShowResKat()
        {
            int[] res = this.karatsubaAlg.GetRes();
            for (int i = 0; i < res.Length; i++)
                Console.Write("{0}X^{1} {2} ", res[i], i, (i + 1) == res.Length ? "\n" : "+");
            Console.WriteLine();
        }

        public void ShowResNor()
        {
            int[] res = this.normalAlg.GetRes();
            for (int i = 0; i < res.Length; i++)
                Console.Write("{0}X^{1} {2} ", res[i], i, (i + 1) == res.Length ? "\n" : "+");
            Console.WriteLine();
        }

        public void InitKaratsuba(int Code)
        {
            Show(firstPolynom, secondPolynom);
            this.karatsubaAlg = new KaratsubaAlg(this.firstPolynom, this.secondPolynom);
            this.karatsubaAlg.InitThreads(Code);
        }

        public void InitNormal(int Code)
        {
            Show(firstPolynom, secondPolynom);
            this.normalAlg = new NormalAlg(this.firstPolynom, this.secondPolynom);
            this.normalAlg.InitThreads(Code);
        }

        private void Show(int[] firstPolynom, int[] secondPolynom)
        {
            for (int i = 0; i < this.firstPolynom.Length; i++)
                Console.Write("{0}X^{1} {2} ", firstPolynom[i], i, (i+1) == firstPolynom.Length ? "\n" : "+");
            for (int i = 0; i < this.secondPolynom.Length; i++)
                Console.Write("{0}X^{1} {2} ", secondPolynom[i], i, (i + 1) == secondPolynom.Length ? "\n" : "+");
        }
    }
}
