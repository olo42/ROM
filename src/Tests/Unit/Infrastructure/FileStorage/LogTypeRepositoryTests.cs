// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Domain;
using com.github.olo42.ROM.Infrastructure.FileStorage;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace com.github.olo42.ROM.Test.Unit.Infrastructure.FileStorage
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
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      var configuration = new Mock<IConfiguration>();
      configuration.Setup(x => x["ApplicationDataDir"]).Returns(path);
      repository = new LogTypeRepository(configuration.Object);

      this.filePath = filePath = Path.Combine(path, this.repository.GetType().Name + ".dat");
    }

    [TearDown]
    public void TearDown()
    {
      var path = Path.Combine(Path.GetTempPath(), "FileStorage");
      if (Directory.Exists(path)) { }
      Directory.Delete(path, true);
    }

    [Test]
    public async Task Write_SerializesAsync()
    {
      var logType = new LogType { Id = "abcdefg", Name = "My First LogType" };
      await this.repository.WriteAsync(logType);

      var content = GetFileContent(this.filePath);
      var expected = "[{\"Name\":\"My First LogType\",\"Id\":\"abcdefg\"}]";
      Assert.That(content, Is.EqualTo(expected));
    }

    [Test]
    public async Task Write_UpdatesAsync()
    {
      var origin = new List<LogType> { new LogType { Id = "abcdefg", Name = "My First LogType" } };
      SerializeToFile(origin);

      var update = new LogType { Id = "abcdefg", Name = "My Updated LogType" };
      await this.repository.WriteAsync(update);

      string content = GetFileContent(this.filePath);
      var expected = "[{\"Name\":\"My Updated LogType\",\"Id\":\"abcdefg\"}]";
      Assert.That(content, Is.EqualTo(expected));
    }

    [Test]
    public async Task ReadAll()
    {
      var origin = new List<LogType>
      {
        new LogType { Id = "1", Name = "First LogType" },
        new LogType { Id = "2", Name = "Second LogType" }
      };

      SerializeToFile(origin);

      var result = (await this.repository.ReadAsync()).ToList();

      Assert.That(result.Count(), Is.EqualTo(2));
      Assert.That(result.Exists(x => x.Id == "1"), Is.True);
      Assert.That(result.Exists(x => x.Id == "2"), Is.True);

    }

    [Test]
    public async Task ReadOne()
    {
      var origin = new List<LogType>
      {
        new LogType { Id = "1", Name = "First LogType" },
        new LogType { Id = "2", Name = "Second LogType" }
      };

      SerializeToFile(origin);

      var result = (await this.repository.ReadAsync("1"));

      Assert.That(result.Id, Is.EqualTo("1"));
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