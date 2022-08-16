
using Microsoft.AspNetCore.Components.Forms;

namespace AlAnon.Services.IServices
{
    public interface IFileService 
    {
        public Task<string> UploadFile(IBrowserFile file);
        public Task DeleteFile(string imageUrl);
        public Task<string> UploadMainPic(IBrowserFile file);
    }
}
