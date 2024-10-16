import styled from "styled-components";
import { theme } from "../../themes/themes";

export const HeaderLayout = styled.div`
  position: sticky;
  z-index: 10;
  top: 0%;
  width: 100%;
  height: 80px;
  margin-bottom: -80px;
  background-color: ${theme.colors.white};
  transition: all 0.2s ease-out;
  cursor: pointer;

  @media only screen and (max-width: 800px) {
    padding-left: 20px;
    height: 60px;
  }
`;

export const HeaderContainer = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;
  height: 80px;
  width: 100%;
  max-width: 1440px;
  margin-left: auto;
  margin-right: auto;

  @media only screen and (max-width: 800px) {
    height: 60px;
    margin-left: 0;
  }
`;

export const HeaderLogo = styled.div`
  display: block;
  width: 165px;
  height: 52px;
  transform: translateZ(0);
  backface-visibility: hidden;
  background-position: center;
  background-repeat: no-repeat;
  background-size: 165px 52px;
  background-image: url("/assets/navLogo.png");

  @media only screen and (max-width: 800px) {
    flex-shrink: 0;
    width: 95px;
    height: 30px;
    background-size: 95px 30px;
  }
`;

export const HeaderNav = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  flex-wrap: wrap;

  @media only screen and (max-width: 800px) {
    position: fixed;
    z-index: 15;
    top: 0;
    right: -100%;
    flex-direction: column-reverse;
    width: 100%;
    height: 100vh;
    min-height: 810px;
    background-color: ${theme.colors.white};
    transition: all 0.2s ease-out;
  }
`;
