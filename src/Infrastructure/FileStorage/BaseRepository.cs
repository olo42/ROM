
// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Application;
using com.github.olo42.ROM.Core.Domain;
using Microsoft.Extensions.Configuration;

namespace com.github.olo42.ROM.Infrastructure.FileStorage
{
  public abstract class BaseRepository<T> : IRepository<T> where T : IIdentifiable
  {
    private const string FILE_EXTENSION = ".dat";
    private readonly IConfiguration _configuration;

    public BaseRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public async Task<T> ReadAsync(string id)
    {
      return (await ReadAsync()).ToList().Find(x => x.Id == id);
    }

    public Task<IEnumerable<T>> ReadAsync()
    {
      var objects = new List<T>();
      var path = GetFilePath();

      if (File.Exists(path))
      {
        var json = File.ReadAllText(path);
        if (!string.IsNullOrWhiteSpace(json))
        {
          objects = (List<T>)JsonSerializer.Deserialize(json, typeof(List<T>));
        }
      }

      return Task.FromResult(objects as IEnumerable<T>);
    }

    public async Task WriteAsync(T input)
    {
      var objects = (await ReadAsync()).ToList();
      
      objects.Remove(objects.Find(x => x.Id == input.Id));
      objects.Add(input);

      var json = JsonSerializer.Serialize(objects);
      var path = GetFilePath();
      AssureFileExists(path);

      await File.WriteAllTextAsync(GetFilePath(), json);
    }

    private string GetFilePath()
    {
      var name = GetType().Name;

      return Path.Combine(_configuration["ApplicationDataDir"], name + FILE_EXTENSION);
    }

    private void AssureFileExists(string path)
    {
      if (!File.Exists(path))
      {
        File.Create(path).Dispose();
      }
    }

    public async Task Delete(string id)
    {
      var objects = (await ReadAsync()).ToList();
      objects.Remove(objects.Find(x => x.Id == id));

      var json = JsonSerializer.Serialize(objects);
      await File.WriteAllTextAsync(GetFilePath(), json);
    }
  }
}
