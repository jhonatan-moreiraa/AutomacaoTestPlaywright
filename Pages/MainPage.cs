using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class MainPage : PageTest
    {
        private IPage _page;
        private ILocator iconeDePesquisa;
        private ILocator campoSearch;
        private ILocator elementoH1;
        private ILocator menuProduto;
        private ILocator menuEmprestimo;
        private ILocator subMenuEmprestimo;
        private ILocator campoEmail;
        private ILocator botaoInscrever;
        private ILocator botaoEntendi;
        private ILocator botaoPaginacao;

        
        public MainPage(IPage page)
        {
            _page = page;
            iconeDePesquisa = _page.GetByLabel("Link do ícone de pesquisa");
            campoSearch = _page.GetByPlaceholder("Search...");
            elementoH1 = _page.Locator("h1");
            menuProduto = _page.Locator("//span[text()='Produtos']");
            menuEmprestimo = _page.Locator("//span[text()='Empréstimos']");
            subMenuEmprestimo = _page.GetByRole(AriaRole.Link, new() { Name = "Empréstimo na Conta de Luz" });
            campoEmail = _page.GetByPlaceholder("Adicione seu e-mail ");
            botaoInscrever = _page.GetByRole(AriaRole.Button, new() { Name = "Inscrever-se" });
            botaoEntendi = _page.GetByText("This feature requires inline").Locator("internal:control=enter-frame").GetByRole(AriaRole.Button, new() { Name = "Entendi" });
            botaoPaginacao = _page.GetByRole(AriaRole.Link, new() { Name = "2", Exact = true });
        }

        public async Task ClickBotaoPesquisa()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
            await iconeDePesquisa.ClickAsync();
        }

        public async Task InserirPalavra()
        {
            await campoSearch.FillAsync("produtos");
            await campoSearch.PressAsync("Enter");
        }

        public async Task ValidarPalavraPesquisada()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
            await Expect(elementoH1).ToContainTextAsync("produtos");
        }

        public async Task FocarMenuEmprestimo()
        {
            await menuProduto.First.HoverAsync();
            await menuEmprestimo.First.HoverAsync();
        }

        public async Task ClicarMenuEmprestimo() => await subMenuEmprestimo.ClickAsync();

        public async Task ValidarMensagemEmprestimo()
        {
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Expect(elementoH1).ToContainTextAsync("Empréstimo na Conta de Luz");
        }

        public async Task PreencherEmail()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
            Thread.Sleep(4000);
            await campoEmail.FillAsync("test@gmail.com");
        }

        public async Task ClicarBotaoInscrever() => await botaoInscrever.ClickAsync();

        public async Task ClicarBotaoEntendi()
        {
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);            
            await botaoEntendi.ClickAsync();
        }

        public async Task ValidarAusenciaPopUpInscricao()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
            Thread.Sleep(4000);
            await Expect(elementoH1).ToBeHiddenAsync();
        }

        public async Task ClicarBotaoPaginacao()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
            await botaoPaginacao.ClickAsync();
        }

        public async Task ValidarURLPaginacao()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
            await Expect(_page).ToHaveURLAsync("https://blogdoagi.com.br/page/2/");
        }

        public async Task ValidarBotaoAppSotre()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
            var page1 = await _page.RunAndWaitForPopupAsync(async () =>
            {
                await _page.Locator(".wp-block-image > a").First.ClickAsync();
            });
            await Expect(page1.Locator("h1")).ToContainTextAsync("Agibank: Conta, Crédito Brazil L +4");
        }
    }
}
