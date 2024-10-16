import styled from "styled-components";
import { theme } from "../../themes/themes";

export const HomeLevOneContainer = styled.div`
  position: relative;
  display: flex;
  align-items: center;
  flex-direction: column;
  width: 100%;
  height: auto;
  padding-bottom: 96rem;

  @media only screen and (max-width: 1900px) {
    padding-bottom: 76rem;
  }

  @media only screen and (max-width: 1440px) {
    row-gap: 56px;
    padding-bottom: 48rem;
  }

  @media only screen and (max-width: 800px) {
    padding-bottom: 32rem;
  }
`;

export const HomeImageWrap = styled.div`
  position: absolute;
  z-index: -1;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
`;

export const HomeImg = styled.img`
  width: 100%;
  height: auto;

  @media only screen and (max-width: 800px) {
    display: none;
    margin-top: 80px;
  }
`;

export const MHomeImg = styled.img`
  display: none;

  @media only screen and (max-width: 800px) {
    display: block;
    width: 100%;
    height: 341px;
    margin-top: 76px;
  }
`;

export const SloganBox = styled.div`
  padding-top: 100px;
`;

export const Slogan = styled.span`
  position: absolute;
  left: 50%;
  align-items: center;
  height: 100%;
  width: 90%;
  text-align: center;
  word-wrap: break-word;
  font-weight: 900;
  font-size: 80px;
  line-height: 120px;
  letter-spacing: 28px;
  color: ${theme.colors.white};
  transform: translate(-50%, -70%);

  @media only screen and (max-width: 2000px) {
    top: 14rem;
    transform: translate(-50%, 5%);
  }

  @media only screen and (max-width: 800px) {
    width: 56%;
    font-weight: 900;
    font-size: 32px;
    line-height: 52px;
    letter-spacing: 0px;
    transform: translate(-50%, -15%);
  }
`;

export const SloganSub = styled.span`
  position: absolute;
  top: 20rem;
  left: 50%;
  width: 100%;
  margin-top: 13%;
  font-weight: 400;
  font-size: 70px;
  line-height: 105px;
  color: ${theme.colors.white};
  text-align: center;
  transform: translate(-50%, 150%);

  @media only screen and (max-width: 2000px) {
    top: 12rem;
    transform: translate(-50%, 140%);
  }

  @media only screen and (max-width: 800px) {
    width: 56%;
    font-weight: 100;
    font-size: 28px;
    line-height: 52px;
  }
`;
