using PlaywrightTests.Core;
using PlaywrightTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Tests
{
    public class BlogDoAgiTest : BaseTest
    {

        [Test]
        public async Task ValidarPesquisa()
        {
            MainPage _mainpage = new MainPage(page);
            await _mainpage.ClickBotaoPesquisa();
            await _mainpage.InserirPalavra();
            await _mainpage.ValidarPalavraPesquisada();
        }

        [Test]
        public async Task ValidarSubMenu()
        {
            MainPage _mainpage = new MainPage(page);
            await _mainpage.FocarMenuEmprestimo();
            await _mainpage.ClicarMenuEmprestimo();
            await _mainpage.ValidarMensagemEmprestimo();
        }

        [Test]
        public async Task ValidarInscricaoEmail()
        {
            MainPage _mainpage = new MainPage(page);
            await _mainpage.PreencherEmail();
            await _mainpage.ClicarBotaoInscrever();
            await _mainpage.ClicarBotaoEntendi();
            await _mainpage.ValidarAusenciaPopUpInscricao();
        }

        [Test]
        public async Task ValidarPaginacao()
        {
            MainPage _mainpage = new MainPage(page);
            await _mainpage.ClicarBotaoPaginacao();
            await _mainpage.ValidarURLPaginacao();
        }

        [Test]
        public async Task ValidarLinkDownloadAPP()
        {
            MainPage _mainpage = new MainPage(page);
            await _mainpage.ValidarBotaoAppSotre();
        }

    }
}
