import styled from "styled-components";
import { theme } from "../../themes/themes";

export const AboutLayout = styled.div`
  overflow-x: hidden;
  overflow-y: auto;
  background-color: ${theme.colors.white};
`;

export const AboutContainer = styled.div`
  max-width: 1440px;
  width: 100%;
  margin-left: auto;
  margin-right: auto;
  padding-top: 160px;

  @media only screen and (max-width: 810px) {
    display: none;
  }
`;

export const AboutLeaderBox = styled.div`
  position: relative;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  width: 100%;
  height: 780px;
  padding-left: 400px;

  @media only screen and (max-width: 1440px) {
    margin-bottom: 350px;
  }
`;
