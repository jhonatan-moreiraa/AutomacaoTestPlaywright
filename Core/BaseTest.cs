using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightTests.Core
{
    public class BaseTest
    {
        protected IBrowser browser;
        protected IBrowserContext context;
        protected IPlaywright playwright;
        public IPage page;
        [SetUp]
        public async Task Setup()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                Channel = "chrome"
            });
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
            await page.SetViewportSizeAsync(1500, 1000);
            await page.WaitForLoadStateAsync(LoadState.Load);
            await page.GotoAsync("https://blogdoagi.com.br");      

        }

        [TearDown]
        public async Task TearDown()
        {
            await page.ScreenshotAsync(new()
            {
                Path = "Screenshots\\screenchot1.png",
            });
            await page.CloseAsync();
        }
    }
}
