using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Utils
{
    public class FileManagement {
        static public async Task UploadFile(IFormFile file, string module) {
            if (file != null || file.Length > 0) {
                var folderContains = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/img",
                        module);
                if (!Directory.Exists(folderContains))
                    Directory.CreateDirectory(folderContains);
                var filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(folderContains, filename);

                using(var steam = new FileStream(filePath, FileMode.Create)) {
                    await file.CopyToAsync(steam);
                }
            }  
            //string filename = FileNameGenerator.GenerateFileName();
            //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", module,);

        }
    }
}
