﻿using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

public class RequestsService
{
    public RequestModel LoadConfiguration(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var requestModel = JsonSerializer.Deserialize<RequestModel>(jsonContent, options);
        return requestModel;
    }
}
