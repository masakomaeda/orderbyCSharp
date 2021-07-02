using System;
using System.Linq;

namespace orderby
{
    class Program
    {
        /// <summary>
        /// メイン処理
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("数値をカンマ区切りで指定してください...");
                var inStr = Console.ReadLine();

                // 比較は数値で行いたいためinputを数値に変換する
                var inStrArry = inStr.Split(",");
                var inNumArry = inStrArry.Select(s => int.Parse(s)).ToArray();

                Order(inNumArry).ToList().ForEach(n =>
                {
                    Console.Write(n);
                    Console.Write(",");
                }) ;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// order by 処理
        /// </summary>
        /// <param name="numArry"></param>
        /// <returns></returns>
        static int[] Order(int[] numArry )
        {
            // returnするものは新しく定義したオブジェクトにしなくてはいけない
            int[] retNumArry = new int[numArry.Count()];
            numArry.CopyTo(retNumArry, 0);


            for (var i = 0; i < numArry.Count(); i++)
            {
                for (var j = 0; j < numArry.Count(); j++)
                {
                    if (retNumArry[i] < retNumArry[j])
                    {
                        var tempNo = retNumArry[j];
                        retNumArry[j] = retNumArry[i];
                        retNumArry[i] = tempNo;
                    }
                }
            }

            return retNumArry;
        }
    }
}
