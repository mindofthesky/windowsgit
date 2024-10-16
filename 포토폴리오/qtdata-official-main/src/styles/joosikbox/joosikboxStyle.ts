import styled from "styled-components";
import { theme } from "../../themes/themes";

// 주식박스 - 임시 준비중 스타일

export const JoosikLayout = styled.div`
  overflow-x: hidden;
  overflow-y: auto;
`;

export const JoosikContainer = styled.div`
  width: 100%;
  height: 100vh;
  background-image: url("/assets/joosikbox.jpg");
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;

  @media only screen and (max-width: 400px) {
    height: 55vh;
  }
`;

export const ContinueDescBox = styled.div`
  transform: translate(0px, 510px);

  @media only screen and (max-width: 1950px) {
    transform: translate(0px, 370px);
  }

  @media only screen and (max-width: 400px) {
    transform: translate(0px, 150px);
  }
`;

export const TobeContinue = styled.div`
  width: 100%;
  text-align: center;
  font-size: 92px;
  font-weight: 700;
  line-height: 73px;
  color: ${theme.colors.white};

  @media only screen and (max-width: 1950px) {
    font-size: 60px;
  }

  @media only screen and (max-width: 400px) {
    font-size: 24px;
  }
`;

export const ContinueDesc = styled.div`
  padding-top: 120px;

  font-size: 36px;
  text-align: center;
  font-weight: 400;
  line-height: 52px;
  color: ${theme.colors.white};

  @media only screen and (max-width: 1950px) {
    padding-top: 60px;
    font-size: 20px;
    line-height: 34px;
  }

  @media only screen and (max-width: 400px) {
    width: 80%;
    padding-top: 30px;
    font-size: 14px;
    line-height: 24px;
    transform: translate(36px, 0px);
  }
`;

export const NeosWrap = styled.div`
  overflow-y: auto;
  overflow-x: hidden;
`;
