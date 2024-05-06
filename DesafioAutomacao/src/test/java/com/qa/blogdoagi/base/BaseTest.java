package com.qa.blogdoagi.base;

import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import com.microsoft.playwright.Browser;
import com.microsoft.playwright.BrowserContext;
import com.microsoft.playwright.BrowserType;
import com.microsoft.playwright.Page;
import com.microsoft.playwright.Playwright;

public class BaseTest {

	private Browser browser;
	private BrowserContext browserContext;
	protected static Page page;

	@BeforeMethod
	public void setUp() {
		Playwright playw = Playwright.create();
		browser = playw.chromium().launch(new BrowserType.LaunchOptions().setHeadless(true));
		browserContext = browser.newContext();
		page = browserContext.newPage();
		page.navigate("https://blogdoagi.com.br");

	}

	@AfterMethod
	public void tearDown() {
		page.screenshot();
		page.close();

	}

}
