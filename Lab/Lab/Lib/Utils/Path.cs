using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Lab.Lib.Utils
{
    /// <summary>
    /// 디렉터리정보에 대한 여러가지 메서드 또는 속성을 제공합니다.
    /// </summary>
    public class Path
    {
        /// <summary>
        /// 플러그인 폴더 이름 = LabPlugins
        /// </summary>
        const string FOLDERNAME = "LabPlugins";
        /// <summary>
        /// 환경변수 이름 = LABPLUGINPATH
        /// </summary>
        public const string ENVVARIABLENAME = "LABPLUGINPATH";

        /// <summary>
        /// 플러그인 디렉터리경로를 가져옵니다. 
        /// 디렉터리가 존재하지 않으면 티렉터리를 생성합니다.
        /// </summary>
        public static string GetPluginDirectoryPath
        {
            get
            {
                string path = System.IO.Path.Combine(@"C:\", FOLDERNAME);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        /// <summary>
        /// ProgramFiles디렉터리의 위치를 가져옵니다.
        /// </summary>
        public static string ProgramFilesPath =>
            IntPtr.Size == 8 || !string.IsNullOrEmpty(
                Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))
            ? Environment.GetEnvironmentVariable("ProgramFiles(x86)")
            : Environment.GetEnvironmentVariable("ProgramFiles");
    }
}
