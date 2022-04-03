using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WinFormsApp1
{
    public class auth
    {
		public List<Info> workerList = new List<Info>();
		public auth()
		{
			StreamReader stream = new StreamReader("regcfg.txt");
			Info info;
			while (!stream.EndOfStream)
			{
				info = new Info();
				string line = stream.ReadLine();
				int i = 0;
				while (line[i] != ' ')
				{
					info.login += line[i];
					i++;
				}
				i++;
				while (line[i] != ' ')
				{
					info.password += line[i];
					i++;
				}
				i++;
				while (line[i] != ' ')
				{
					info.role += line[i];
					i++;
					if (i >= line.Length)
                    {
						break;
                    }
				}
				workerList.Add(info);
			}
        }
        public class Info
        {
			public string login;
			public string password;
			public string role;
		}

    }
}
