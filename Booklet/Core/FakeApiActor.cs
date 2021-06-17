using Booklet.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booklet.Api.Core
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "Fake Admin";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 1000);
    }
}
