using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Lib.Utils
{
    /// <summary>
    /// 명령어에 대한 사용방법을 나타냅니다. 
    /// 이 클래스는 상속될 수 없습니다.
    /// </summary>
    public sealed class Usage
    {
        /// <summary>
        /// 명령어 사용방법을 적고 <see cref="Usage"/>를 초기화 합니다.
        /// </summary>
        /// <param name="command">사용할 주 명령어입니다.</param>
        /// <param name="description">명령어의 자세한 설명입니다. 
        /// ex) ["lab help"] = "Shows Help information."
        /// </param>
        public Usage(string command, Dictionary<string, string> description)
        {
            this.Command = command;
            this.Description = description;
        }

        /// <summary>
        /// 명령어의 주 명령어를 제공합니다.
        /// ex) help command -> help
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// 명령어에 대한 자세한 사용방법을 제공합니다.
        /// </summary>
        public Dictionary<string, string> Description { get; set; } = new Dictionary<string, string>();
    }
}
