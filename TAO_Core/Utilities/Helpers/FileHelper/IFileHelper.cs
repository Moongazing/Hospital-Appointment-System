using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TAO_Core.Utilities.Helpers.FileHelper
{
  public interface IFileHelper
  {
    void Delete(string filePath);
    string Update(IFormFile file, string filePath, string root);
    string Upload(IFormFile file, string imagesPath);

  }
}
