using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Lib.Utils
{
    /// <summary>
    /// Lab 표준 출력 스트림을 나타냅니다. 
    /// 이 클래스는 상속될 수 없습니다.
    /// </summary>
    public sealed class Log
    {
        /// <summary>
        /// 지정한 값을 문자열로 변환시켜 Lab 표준 출력 스트림에 씁니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">작성할 값입니다.</param>
        public static void Write<T>(T value)
        {
            Console.Write(value.ToString());
        }

        /// <summary>
        /// 뒤에 현재 줄 종결자가 오는, 지정한 값을 문자열로 변환시켜 표준 출력 스트림에 씁니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">작성할 값입니다.</param>
        public static void WriteLine<T>(T value)
        {
            Console.WriteLine(value.ToString());
        }

        /// <summary>
        /// 에러 로그 메시지를 표준 출력 스트림에 씁니다.
        /// </summary>
        /// <param name="msg">작성할 에러 로그입니다.</param>
        public static void Error(string msg)
        {
            Console.WriteLine($"ERROR: {msg}");
        }
    }
}
