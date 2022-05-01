using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Lab4CSharp.Models;

namespace Lab4CSharp.Repositories
{
    class FileRepository
    {
        private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UsersStorage");

        public FileRepository()
        {
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);
        }

        public async Task AddAsync(UserCandidate obj)
        {
            var stringObj = JsonSerializer.Serialize(obj);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, obj.Email), false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public void Remove(String userEmail)
        {
            File.Delete(Path.Combine(BaseFolder, userEmail));
        }

        public List<UserCandidate> GetAll()
        {
            var res = new List<UserCandidate>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = sw.ReadToEnd();
                }

                res.Add(JsonSerializer.Deserialize<UserCandidate>(stringObj));
            }

            return res;
        }
    }
}
