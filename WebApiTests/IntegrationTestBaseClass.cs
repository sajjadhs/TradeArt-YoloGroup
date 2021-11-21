using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Test___TradeArt_YoloGroup;
using Xunit;
using Xunit.Abstractions;

namespace WebApiTests
{
    public abstract class IntegrationTestBaseClass
    {
        protected readonly ITestOutputHelper testLogger;
        protected readonly HttpClient testClient;
        protected readonly IServiceScope serviceScope;
        protected IntegrationTestBaseClass(ITestOutputHelper testLogger)
        {
            this.testLogger = testLogger;
            var app = new WebApplicationFactory<Startup>();
            testClient = app.CreateClient();

            serviceScope  = app.Services.CreateScope();
        }

    }
}
