import { createGlobalStyle } from 'styled-components';

export const GlobalStyle = createGlobalStyle`


@font-face {
  font-family: "Pretendard";
  src: url("../src/assets/fonts/Pretendard-Black.ttf") format("ttf");
  font-weight: 100;
  font-display: swap;
}

body {
  font-family: "pretendard", "sans-serif";
  margin: 0;

  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  -ms-text-size-adjust: 100%;
  -webkit-text-size-adjust: 100%;
  line-height: 1.5em;
  color: #6d7783;
  margin: 0;
  width: 100vw;
  height: 100vh;
  overflow-y: scroll;
  overflow-x: hidden;

  /* background-color: #fff; */
}

html {
  line-height: 1.5;
  -webkit-text-size-adjust: 100%;
  -moz-tab-size: 4;
  -o-tab-size: 4;
  tab-size: 4;
  font-feature-settings: normal;
  font-variation-settings: normal;
  font-size: 16px;
  color: #6d7783;
}

* {
  box-sizing: border-box;
  border-width: 0;
  border-style: solid;
  border-color: #e5e7eb;
  word-break: keep-all;
  /* background-color: #fff; */
}

a {
  color: inherit;
  cursor: pointer;
  text-decoration: inherit;
}

ol,
ul,
menu {
  list-style: none;
  margin: 0;
  padding: 0;
}

ul {
  display: block;
  list-style-type: disc;
  margin-inline-start: 0px;
  margin-inline-end: 0px;
}
li {
  list-style: none;
}
button,
input,
optgroup,
select,
textarea {
  font-family: inherit;
  font-feature-settings: inherit;
  font-variation-settings: inherit;
  font-size: 100%;
  font-weight: inherit;
  line-height: inherit;
  color: inherit;
  margin: 0;
  padding: 0;
}

button,
select {
  text-transform: none;
}

button,
[role="button"] {
  cursor: pointer;
}

button,
[type="button"],
[type="reset"],
[type="submit"] {
  -webkit-appearance: button;
  background-color: transparent;
  background-image: none;
}

blockquote,
dl,
dd,
h1,
h2,
h3,
h4,
h5,
h6,
hr,
figure,
p,
pre {
  margin: 0;
}

img,
video {
  max-width: 100%;
  height: auto;
}

img {
  overflow-clip-margin: content-box;
  overflow: clip;
}

img,
svg,
video,
canvas,
audio,
iframe,
embed,
object {
  display: block;
  vertical-align: middle;
}

b,
strong {
  font-weight: bolder;
  margin-right: 10px;
}

nav {
  display: block;
}

`;
