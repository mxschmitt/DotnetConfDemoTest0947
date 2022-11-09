using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightDotnetConf;

[TestClass]
public class Tests : PageTest
{
    [TestMethod]
    public async Task MyTest()
    {
        await Page.GotoAsync("https://dotnetpodcasts.azurewebsites.net/");

        await Page.GetByRole(AriaRole.Link, new() { NameString = "Discover more" }).ClickAsync();
        await Page.WaitForURLAsync("https://dotnetpodcasts.azurewebsites.net/discover");

        await Page.GetByRole(AriaRole.Link, new() { NameString = ".NET Rocks!  .NET Rocks! Carl Franklin" }).ClickAsync();
        await Page.WaitForURLAsync("https://dotnetpodcasts.azurewebsites.net/show/924a1d79-af9c-46bb-68fc-08d9b42c62b0");

        await Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = ".NET Rocks!" })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = "Carl Franklin" })).ToBeVisibleAsync();

        // Click on "Listen Later" button
        await Page.Locator("article:nth-child(6) > .episode-actions > button:nth-child(2)").ClickAsync();

        await Page.GetByRole(AriaRole.Link, new() { NameString = "Listen Later" }).ClickAsync();
        await Page.WaitForURLAsync("https://dotnetpodcasts.azurewebsites.net/listen-later");

        await Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = "Testing Web Apps using Playwright Debbie O'Brien" })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = ".NET Rocks!" })).ToBeVisibleAsync();
    }
}
