// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Moq;
using NUnit.Framework;
using com.github.olo42.SAROnion.Core.Application;
using com.github.olo42.SAROnion.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using com.github.olo42.SAROnion.Core.Application.Log.Type;

namespace com.github.olo42.SAROnion.Test.Unit.Core.Log.Type
{
  [TestFixture]
  public class ReadTests
  {
    private IRead<ReadIn, ReadOut> read;
    private Mock<IRepository<LogType>> repository;

    [SetUp]
    public void Setup()
    {
      repository = new Mock<IRepository<LogType>>();
      read = new Read(repository.Object);
    }

    [Test]
    public void ReadLogTypeObject()
    {
      var logType = Task.FromResult(new LogType());
      repository.Setup(x => x.Read(It.IsAny<string>())).Returns(logType);
      var input = new ReadIn { Id = null };
      
      var result = read.Execute(input);

      Assert.That(result.Data.Result, Is.Not.Null);
    }

    [Test]
    public void ReturnsLogTypeWithInputId()
    {
      var logType = Task.FromResult(new LogType { Id = "abcdefg" });
      repository.Setup(x => x.Read(It.IsAny<string>())).Returns(logType);
      
      var input = new ReadIn { Id = "abcdefg" };
      var result = read.Execute(input);

      Assert.That(result.Data.Result.Id, Is.EqualTo("abcdefg"));
    }
  }
}