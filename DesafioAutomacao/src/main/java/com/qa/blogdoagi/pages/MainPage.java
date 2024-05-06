package com.qa.blogdoagi.pages;

import com.microsoft.playwright.Locator;
import com.microsoft.playwright.Page;
import static com.microsoft.playwright.assertions.PlaywrightAssertions.assertThat;

import com.microsoft.playwright.FrameLocator;
import com.microsoft.playwright.options.AriaRole;
import com.microsoft.playwright.options.LoadState;

public class MainPage {
	private Page page;
	private Locator iconePesquisa;
	private Locator campoSearch;
	private Locator elementoH1;
	private Locator menuProduto;
	private Locator menuEmprestimo;
	private Locator subMenuEmprestimo;
	private Locator campoEmail;
	private Locator botaoInscrever;
	private Locator botaoEntendi;
	private Locator botaoPaginacao;

	public MainPage(Page page) {

		this.page = page;
		this.iconePesquisa = page.getByLabel("Link do ícone de pesquisa");
		this.campoSearch = page.getByPlaceholder("Search...");
		this.elementoH1 = page.locator("h1");
		this.menuProduto = page.locator("//span[text()='Produtos']");
		this.menuEmprestimo = page.locator("//span[text()='Empréstimos']");
		this.subMenuEmprestimo = page.getByRole(AriaRole.LINK,
				new Page.GetByRoleOptions().setName("Empréstimo na Conta de Luz"));
		this.campoEmail = page.getByPlaceholder("Adicione seu e-mail ");
		this.botaoInscrever = page.getByRole(AriaRole.BUTTON, new Page.GetByRoleOptions().setName("Inscrever-se"));
		this.botaoEntendi = page.frameLocator("internal:text=\"This feature requires inline\"i")
				.getByRole(AriaRole.BUTTON, new FrameLocator.GetByRoleOptions().setName("Entendi"));
		this.botaoPaginacao = page.getByRole(AriaRole.LINK, new Page.GetByRoleOptions().setName("2").setExact(true));

	}

	public void clicarBotaoPesquisa() {
		page.waitForLoadState(LoadState.LOAD);
		page.waitForLoadState();
		iconePesquisa.click();

	}

	public void inserirPalavra() {
		campoSearch.fill("produtos");
		campoSearch.press("Enter");

	}

	public void validarPalavraPesquisada() {
		page.waitForLoadState(LoadState.LOAD);
		assertThat(elementoH1).containsText("Resultados encontrados para: produtos");

	}

	public void focarMenuEmprestimo() {
		menuProduto.first().hover();
		menuEmprestimo.first().hover();
	}

	public void clicarMenuEmprestimo() {
		subMenuEmprestimo.click();
	}

	public void validarMensagemEmprestimo() {
		page.waitForLoadState(LoadState.LOAD);
		assertThat(elementoH1).containsText("Empréstimo na Conta de Luz");
	}

	public void preencherEmail() {
		page.waitForLoadState(LoadState.LOAD);
		campoEmail.fill("test@email.com");

	}

	public void clicarBotaoInscrever() {
		botaoInscrever.click();
		page.waitForTimeout(2000);

	}

	public void clicarBotaoEntendi() {
		botaoEntendi.click();
	}

	public void validarAusenciaPopUpInscricao() {
		page.waitForTimeout(2000);
		assertThat(botaoEntendi).isHidden();
	}

	public void clicarBotaoPaginacao() {
		page.waitForTimeout(3000);
		botaoPaginacao.click();

	}

	public void validarUrlPaginacao2() {
		page.waitForTimeout(3000);
		assertThat(page).hasURL("https://blogdoagi.com.br/page/2/");
	}

	public void validarBotaoAPPStore() {
		page.waitForLoadState(LoadState.LOAD);
		Page page1 = page.waitForPopup(() -> {
			page.locator(".wp-block-image > a").first().click();
		});
		page1.waitForTimeout(1000);
		assertThat(page1.locator("h1")).containsText("Agibank: Conta, Crédito Brazil L +4");
	}

}
