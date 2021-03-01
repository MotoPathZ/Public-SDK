using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MPZ.Config;
using Newtonsoft.Json;

namespace MPZ.Tools
{
    static class ProcessingLocalConfig
    {
        public static MPZConfig data { get; set; }

        public static string pathToLoad { get; set; } = "/config/mpz.ini";

        public static bool Load()
        {
            bool check = false;
            try
            {
                if (File.Exists(pathToLoad))
                {
                    data = JsonConvert.DeserializeObject<MPZConfig>(File.ReadAllText(pathToLoad));
                }
                else
                {
                    check = false;
                    File.Create(pathToLoad);
                    //data = new MPZConfig();
                }
            }
            catch
            {
                check = false;
            }
            return check;
        }

    }
}
