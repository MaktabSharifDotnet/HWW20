using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppFileAgg
{
    public interface IFileUploader
    {
        public string Upload(IFormFile file, string folder);
    }
}
