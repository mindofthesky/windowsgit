import styled from "styled-components";
import { theme } from "../../themes/themes";

export const HomeFourWrap = styled.div`
  display: flex;
  z-index: -4;
  align-items: center;
  flex-direction: column;
  width: 100%;
  height: 1095px;
  padding-top: 162px;
  text-align: center;
  background-color: ${theme.colors.white};

  @media only screen and (max-width: 800px) {
    height: 780px;
    padding-top: 0;
    padding-bottom: 20px;
  }
`;

export const HomeFourContainer = styled.div`
  display: flex;
  flex-direction: column;
  margin-bottom: 20px;

  @media only screen and (max-width: 800px) {
    background-color: ${theme.colors.white};
  }
`;

export const HomeFourArrowTag = styled.a`
  display: flex;
  margin-top: 40px;
  padding: 10px 30px;
  text-align: center;
  font-size: 16px;
  font-style: normal;
  font-weight: 500;
  line-height: 24px;
  color: ${theme.colors.sub};
  border-radius: 6px;
  background: ${theme.colors.primary};
  transition: all 0.2s ease-out;

  &:hover {
    background: ${theme.colors.enable};
    transition: all 0.2s ease-out;
  }

  @media only screen and (max-width: 800px) {
    background: ${theme.colors.primary};
  }
`;

export const FourArrowImg = styled.img`
  width: 24px;
  height: 24px;
`;

export const HomeFourNoteImg = styled.img`
  width: 800px;
  height: 600px;
  margin-left: auto;
  margin-right: auto;

  @media only screen and (max-width: 800px) {
    width: 360px;
    height: 270px;
  }
`;
