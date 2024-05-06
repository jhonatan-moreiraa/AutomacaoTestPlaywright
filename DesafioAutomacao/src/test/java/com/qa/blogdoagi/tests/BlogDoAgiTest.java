package com.qa.blogdoagi.tests;

import org.testng.annotations.Test;

import com.qa.blogdoagi.base.BaseTest;
import com.qa.blogdoagi.pages.MainPage;

public class BlogDoAgiTest extends BaseTest {
	
	@Test(priority = 1)
	public void validarPesquisa() {
		MainPage mainPage = new MainPage(page);
		mainPage.clicarBotaoPesquisa();
		mainPage.inserirPalavra();
		mainPage.validarPalavraPesquisada();

	}
	
	@Test(priority = 2)
	public void validarSubMenu() {
		MainPage mainPage = new MainPage(page);
		mainPage.focarMenuEmprestimo();
		mainPage.clicarMenuEmprestimo();
		mainPage.validarMensagemEmprestimo();

	}
	
	@Test(priority = 3)
	public void validarInscricaoEmail() {
		MainPage mainPage = new MainPage(page);
		mainPage.preencherEmail();
		mainPage.clicarBotaoInscrever();
		mainPage.clicarBotaoEntendi();
		mainPage.validarAusenciaPopUpInscricao();
		
	}
	
	@Test(priority = 4)
	public void validarPaginacao() {
		MainPage mainPage = new MainPage(page);
		mainPage.clicarBotaoPaginacao();
		mainPage.validarUrlPaginacao2();
	}
	
	@Test(priority = 5)
	public void validarLinkDownloadAPP() {
		MainPage mainPage = new MainPage(page);
		mainPage.validarBotaoAPPStore();
	}

}
