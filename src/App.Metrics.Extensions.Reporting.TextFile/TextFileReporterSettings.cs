// Copyright (c) Allan hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;

namespace App.Metrics.Extensions.Reporting.TextFile
{
    public class TextFileReporterSettings : ITextFileReporterSettings
    {
        public IMetricsFilter Filter { get; set; }

        public MetricTags GlobalTags { get; set; } = MetricTags.None;

        public TimeSpan ReportInterval { get; set; } = TimeSpan.FromSeconds(5);

        public string FileName { get; set; }
    }
}