var styles = [
    "https://unpkg.com/sakura.css/css/sakura.css",
    "https://cdn.jsdelivr.net/npm/water.css@2/out/dark.css",
    "https://unpkg.com/chota@latest",
    "https://cdnjs.cloudflare.com/ajax/libs/milligram/1.4.1/milligram.css",
    "https://classless.de/classless.css",
    "https://unpkg.com/awsm.css@3.0.7/dist/awsm.min.css",
    "https://unpkg.com/mvp.css",
    "https://cdn.jsdelivr.net/npm/@exampledev/new.css@1/new.min.css",
    "https://cdn.jsdelivr.net/gh/yegor256/tacit@gh-pages/tacit-css.min.css",
    "https://cdn.jsdelivr.net/npm/picnic@6.5.3/picnic.min.css",
    "https://cdn.rawgit.com/kimeiga/bahunya/css/bahunya-0.1.3.css",
    "https://cdn.jsdelivr.net/npm/holiday.css@0.9.5"
  ];
var sheet = styles[Math.floor(Math.random() * styles.length)];
document.getElementById('pagestyle').setAttribute('href', sheet);