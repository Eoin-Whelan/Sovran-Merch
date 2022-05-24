/*
  FileName:   vue.config.js
  Author:     Eoin Farrell C00164354
  Purpose:    vue.config.js serves as a vue module export file.
              Contextually, this file serves to allow for local dev server proxy requests.
*/
module.exports = {
  devServer: {
    proxy: {
      //  Catalog Proxies
      '^/PullCatalog': {
        target: 'https://sovran-catalog.azurewebsites.net/Catalog',
        ws: true,
        changeOrigin: true,
      },
      '^/uploadImg': {
        target: 'https://localhost:49159/Catalog',
        ws: true,
        changeOrigin: true,
      },
      //  Account Proxies
      '^/Account/RegisterAccount': {
          target: 'https://sovran-accounts.azurewebsites.net',
          ws: true,
          changeOrigin: true
      },
      '^/DummyRegister': {
        target: 'https://sovran-accounts.azurewebsites.net',
        ws: true,
        changeOrigin: true
    },
      '^/Account/Login': {
        target: 'https://sovran-accounts.azurewebsites.net',
        ws: true,
        changeOrigin: true,
      },
      //  Payment Proxies
      '^/CreateIntent': {
        target: 'https://localhost:49153/',
        ws: true,
        changeOrigin: true,
      },
    }
  }
}