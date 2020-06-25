// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using com.github.olo42.SAROnion.Core.Domain;
using com.github.olo42.SAROnion.Infrastructure.FileStorage;
using NUnit.Framework;

namespace com.github.olo42.SAROnion.Test.Unit.Infrastructure.FileStorage
{
  [TestFixture]
  public class LogTypeRepositoryTests
  {
    private string filePath;
    private LogTypeRepository repository;

    [SetUp]
    public void Setup()
    {
      var path = Path.Combine(Path.GetTempPath(), "FileStorage");
      if(!Directory.Exists(path)) 
        Directory.CreateDirectory(path);

      repository = new LogTypeRepository(path);

      this.filePath = filePath = Path.Combine(path, this.repository.GetType().Name + ".dat");
    }

    [TearDown]
    public void TearDown()
    {
      var path = Path.Combine(Path.GetTempPath(), "FileStorage");
      if(Directory.Exists(path)) {}
        Directory.Delete(path, true);
    }

    [Test]
    public async Task Write_SerializesAsync()
    {
      var logType = new LogType { Id = "abcdefg", Name = "My First LogType" };
      await this.repository.WriteAsync(logType);

      var content = GetFileContent(this.filePath);
      var expectedJsonString = "[{\"Name\":\"My First LogType\",\"Id\":\"abcdefg\"}]";  
      Assert.That(content, Is.EqualTo(expectedJsonString));
    }

    [Test]
    public async Task Write_UpdatesAsync()
    {
      var origin = new List<LogType> { new LogType { Id = "abcdefg", Name = "My First LogType" } };
      SerializeToFile(origin);
      
      var update = new LogType { Id = "abcdefg", Name = "My Updated LogType" };
      await this.repository.WriteAsync(update);
      
      string content = GetFileContent(this.filePath);
      var expectedJsonString = "[{\"Name\":\"My Updated LogType\",\"Id\":\"abcdefg\"}]";
      Assert.That(content, Is.EqualTo(expectedJsonString));
    }

    private string GetFileContent(string path)
    {
      return File.ReadAllText(path);
    }

    private void SerializeToFile(List<LogType> origin)
    {
      var json = JsonSerializer.Serialize(origin);
      File.WriteAllText(this.filePath, json);
    }
  }
}