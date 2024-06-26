namespace ReportApp.Models;

public class ShopReportConfiguration
{
    public int HeaderKeyRow { get; set; }
    public int HeaderKeyColumn { get; set; }
    public int HeaderValueRow { get; set; }
    public int HeaderValueColumn { get; set; }
    public int HeaderRowsAmount { get; set; }
    public int ReportTitleRow { get; set; }
    public int FirstColumn { get; set; }
    public int LastColumn { get; set; }
    public int FirstRowForDynamicGroup { get; set; }
    public int FirstRowForStaticGroup { get; set; }
    public int GroupCount { get; set; }
    public int LastRow { get; set; }
    public int DefaultRow { get; set; }
}
