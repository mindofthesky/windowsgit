import "styled-components";

declare module "styled-components" {
  export interface DefaultTheme {
    colors: {
      primary: string;
      sub: string;
      focus: string;
      focusSub: string;
      enable: string;
      white: string;
      black: string;
      sectionBg: string;
      disabled: string;
    };
  }
}
