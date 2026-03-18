namespace Formica.WebUI.E2ETests;

using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public sealed class CounterPageTests
{
    private const string DEFAULT_BASE_URL = "http://127.0.0.1:5080";

    [TestMethod]
    public async Task CounterPage_ShouldIncrementValue_WhenButtonIsClicked()
    {
        var baseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? DEFAULT_BASE_URL;

        using var playwright = await Playwright.CreateAsync();

        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true,
            Channel = "msedge",
        });

        var page = await browser.NewPageAsync();

        await page.GotoAsync($"{baseUrl}/counter");

        await Expect(page.GetByText("Current count: 0")).ToBeVisibleAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync();

        await Expect(page.GetByText("Current count: 1")).ToBeVisibleAsync();
    }
}
