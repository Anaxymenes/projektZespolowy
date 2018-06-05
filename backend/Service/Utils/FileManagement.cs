using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Utils
{
    public class FileManagement {
        static public async Task UploadFile(IFormFile file, string module, string filename) {
            if (file != null || file.Length > 0) {
                var folderContains = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/img",
                        module);
                if (!Directory.Exists(folderContains))
                    Directory.CreateDirectory(folderContains);
                var filePath = Path.Combine(folderContains, filename);

                using(var steam = new FileStream(filePath, FileMode.Create)) {
                    await file.CopyToAsync(steam);
                }
            }  
        }
        static public string GetFileName(IFormFile file) {
            return Guid.NewGuid() + Path.GetExtension(file.FileName);
        }

        static public string GetFilePathForDatabase(string filename, string module) {
            return "/img/" + module + "/" + filename;
        }
    }
}
