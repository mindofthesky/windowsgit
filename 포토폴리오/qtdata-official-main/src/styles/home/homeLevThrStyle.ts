import styled from "styled-components";
import { theme } from "../../themes/themes";

export const HomeThrWrap = styled.div`
  display: flex;
  justify-content: center;
  width: 100%;
  height: 980px;
  padding-top: 426px;
  background-color: ${theme.colors.sectionBg};

  @media only screen and (max-width: 800px) {
    height: auto;
    padding-top: 0;
    margin-top: 40%;
    margin-bottom: 20%;
  }
`;

export const HomeThrItems = styled.div`
  display: flex;
  gap: 78px;
  justify-content: center;
  max-width: 1440px;
  width: 100%;

  @media only screen and (max-width: 800px) {
    align-items: center;
    flex-direction: column;
  }
`;
