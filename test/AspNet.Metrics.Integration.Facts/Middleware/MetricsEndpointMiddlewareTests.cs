﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using App.Metrics;
using AspNet.Metrics.Integration.Facts.Startup;
using FluentAssertions;
using Xunit;

namespace AspNet.Metrics.Integration.Facts.Middleware
{
    public class MetricsEndpointMiddlewareTests : IClassFixture<MetricsHostTestFixture<DefaultTestStartup>>
    {
        public MetricsEndpointMiddlewareTests(MetricsHostTestFixture<DefaultTestStartup> fixture)
        {
            Client = fixture.Client;
            Context = fixture.Context;
        }

        public HttpClient Client { get; }

        public IMetrics Context { get; }

        [Fact]
        public async Task uses_correct_mimetype_for_json_version()
        {
            var result = await Client.GetAsync("/metrics");

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Content.Headers.ContentType.ToString().Should().Match<string>(s => s == "application/vnd.app.metrics.v1.metrics+json");
        }
    }
}