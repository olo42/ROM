// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Moq;
using NUnit.Framework;
using com.github.olo42.ROM.Core.Application;
using com.github.olo42.ROM.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace com.github.olo42.ROM.Test.Unit.Core.Log.Type
{
  [TestFixture]
  public class ReadAllTests
  {
    private IRead<LogType> read;
    private Mock<IRepository<LogType>> repository;

    [SetUp]
    public void Setup()
    {
      repository = new Mock<IRepository<LogType>>();
      read = new BaseRead<LogType>(repository.Object);
    }

    [Test]
    public void ReadLogTypeObjects()
    {
      var logTypes = new List<LogType>{ new LogType(), new LogType() } as IEnumerable<LogType>;
      var logTypeTask = Task.FromResult(logTypes);
      repository.Setup(x => x.ReadAsync()).Returns(logTypeTask);

      var result = read.Execute();

      Assert.That(result.Result.Count, Is.EqualTo(2));
    }
  }
}