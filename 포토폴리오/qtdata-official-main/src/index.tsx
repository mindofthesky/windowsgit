import ReactDOM from "react-dom/client";
import App from "./App";
import { BrowserRouter } from "react-router-dom";
import { ThemeProvider } from "styled-components";
import { theme } from "./themes/themes";
import ScrollTop from "./utils/ScrollTop";
import { GlobalStyle } from "./styles/globalStyle";
import "./i18n";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
root.render(
  <BrowserRouter>
    <ThemeProvider theme={theme}>
      <GlobalStyle />
      <ScrollTop />
      <App />
    </ThemeProvider>
  </BrowserRouter>
);
