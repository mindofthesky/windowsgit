import styled from "styled-components";
import { theme } from "../../themes/themes";

export const ContactLayout = styled.div`
  overflow-x: hidden;
  overflow-y: auto;
  width: 100%;
  height: 1800px;
  background-color: ${theme.colors.white};

  @media only screen and (max-width: 800px) {
    height: 2000px;
  }
`;

export const ContactContainer = styled.div`
  width: 100%;
  height: 500px;
  margin-left: auto;
  margin-right: auto;
  background-size: cover;
  background-repeat: no-repeat;
`;

export const ContactMainWrap = styled.div`
  display: flex;
  align-items: center;
  flex-direction: column;
  height: 100%;
  padding-top: 180px;
  padding-bottom: 244px;

  @media only screen and (max-width: 800px) {
    align-items: center;
    row-gap: 40px;
    width: 88%;
    padding-top: 140px;
    padding-bottom: 80px;
    margin-left: auto;
    margin-right: auto;
  }
`;

export const HeadLineBox = styled.div`
  text-align: center;
`;

export const ContactMainBox = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: first baseline;
  max-width: 1440px;
  width: 100%;
  margin-top: 80px;

  @media only screen and (max-width: 800px) {
    display: flex;
    flex-direction: column-reverse;
  }
`;
