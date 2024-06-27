﻿using ReportApp.Interfaces;

namespace ReportApp.Models.Activity;

public class ActivityReportConfiguration : IReportConfiguration
{
    public int ReportTitleRow { get; set; }

    public int FirstColumn { get; set; }

    public int LastColumn { get; set; }

    public int FirstRowForDynamicGroup { get; set; }

    public int FirstRowForStaticGroup { get; set; }

    public int LastRow { get; set; }

    public int DefaultRow { get; set; }

}
