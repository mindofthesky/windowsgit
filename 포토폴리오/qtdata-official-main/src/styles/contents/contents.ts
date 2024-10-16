import styled from "styled-components";
import { theme } from "../../themes/themes";

export const ContentWrap = styled.div`
  overflow-y: auto;
  overflow-x: hidden;
  background-color: ${theme.colors.white};
`;

export const ContentContainer = styled.div`
  display: flex;
  align-items: center;
  flex-direction: column;
  row-gap: 80px;
  width: 100%;
  padding-top: 180px;
  padding-bottom: 244px;

  @media only screen and (max-width: 800px) {
    align-items: center;
    row-gap: 40px;
    padding-top: 140px;
    padding-bottom: 80px;
  }
`;

export const HeadlineBox = styled.div`
  text-align: center;
`;

export const ContentNewsWrap = styled.div`
  overflow: hidden;
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
  flex-direction: column;
  align-items: center;
  row-gap: 60px;
  -moz-column-gap: 16px;
  column-gap: 16px;
  max-width: 1440px;
  width: 85%;
  padding-top: 80px;
  padding-bottom: 80px;

  @media only screen and (max-width: 800px) {
    align-content: center;
    row-gap: 60px;
    width: auto;
    padding-bottom: 0px;
    padding-top: 0px;
  }
`;
