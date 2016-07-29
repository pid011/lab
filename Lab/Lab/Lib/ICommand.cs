using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Lib.Utils;
using Lab.Lib;

namespace Lab.Lib
{
    /// <summary>
    /// 명령어에 필요한 메서드, 속성을 정의합니다.
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// 명령어의 사용방법을 제공합니다.
        /// </summary>
        Usage CommandUsage { get; }
        
        /// <summary>
        /// 명령어의 진입점입니다.
        /// </summary>
        /// <param name="args"></param>
        void ExecuteCommand(string[] args);
    }
}
