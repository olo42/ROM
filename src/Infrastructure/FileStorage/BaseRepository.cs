
// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Application;
using Microsoft.Extensions.Configuration;

namespace com.github.olo42.ROM.Infrastructure.FileStorage
{
  public abstract class BaseRepository<T> : IRepository<T>
  {
    private const string FILE_EXTENSION = ".dat";
    private readonly IConfiguration _configuration;

    public BaseRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public abstract Task<T> ReadAsync(string id);

    public Task<IEnumerable<T>> ReadAsync()
    {
      var objects = this.Deserialize();

      return Task.FromResult(objects);
    }

    public abstract Task Delete(string id);

    public abstract Task WriteAsync(T input);

    protected string GetFilePath()
    {
      var name = this.GetType().Name;

      return Path.Combine(_configuration["ApplicationDataDir"], name + FILE_EXTENSION);
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
