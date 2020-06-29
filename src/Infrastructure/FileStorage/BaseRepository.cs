
// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Application;

namespace com.github.olo42.ROM.Infrastructure.FileStorage
{
  public abstract class BaseRepository<T> : IRepository<T>
  {
    private const string FILE_EXTENSION = ".dat";
    private readonly string directoryPath;

    public BaseRepository(string directoryPath)
    {
      if (string.IsNullOrEmpty(directoryPath))
      {
        throw new ArgumentException($"'{nameof(directoryPath)}' cannot be null or empty", nameof(directoryPath));
      }

      this.directoryPath = directoryPath;
    }
    public abstract Task<T> ReadAsync(string id);

    public Task<IEnumerable<T>> ReadAsync()
    {
      var objects = this.Deserialize();
      
      return Task.FromResult(objects);
    }

    public abstract Task WriteAsync(T input);

    protected string GetFilePath()
    {
      var name = this.GetType().Name;

      return Path.Combine(this.directoryPath, name + FILE_EXTENSION);
    }

    protected IEnumerable<T> Deserialize()
    {
      var path = this.GetFilePath();
      if(!File.Exists(path))
      {
        File.Create(path).Dispose();

        return new List<T>();
      }
      var json = File.ReadAllText(path);
      var objects = (IEnumerable<T>)JsonSerializer.Deserialize(json, typeof(IEnumerable<T>));
     
      return objects;
    }
  }
}
