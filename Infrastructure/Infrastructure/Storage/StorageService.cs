using Application.Abstract.Storage;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Storage
{
    public class StorageService : IStorageService
    {
        readonly IStorage _Storage;
        public StorageService(IStorage storage)
        {
            _Storage = storage;
        }
        public string StorageName { get => _Storage.GetType().Name; }
        public async Task DeleteAsync(string pathOrContainerName, string fileName)
        => await _Storage.DeleteAsync(pathOrContainerName, fileName);
        public List<string> GetFiles(string pathOrContainerName)
        => _Storage.GetFiles(pathOrContainerName);
        public bool HasFile(string pathOrContainerName, string fileName)
        => _Storage.HasFile(pathOrContainerName, fileName);
        public Task<List<(string fileName, string path)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        => _Storage.UploadAsync(pathOrContainerName, files);
    }
}
